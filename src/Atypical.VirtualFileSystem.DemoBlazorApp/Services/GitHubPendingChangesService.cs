using System.Collections.Concurrent;
using Atypical.VirtualFileSystem.DemoBlazorApp.Models;
using Atypical.VirtualFileSystem.GitHub;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Tracks pending changes to GitHub files awaiting PR submission.
/// </summary>
public sealed class GitHubPendingChangesService
{
    private readonly ConcurrentDictionary<string, PendingFileChange> _pendingChanges = new(StringComparer.OrdinalIgnoreCase);
    private readonly GitHubMetadataTracker _metadataTracker;
    private readonly GitHubAuthService _authService;
    private readonly IGitHubWriteService _writeService;

    /// <summary>
    /// Event fired when pending changes are added, removed, or cleared.
    /// </summary>
    public event Action? OnPendingChangesChanged;

    public GitHubPendingChangesService(
        GitHubMetadataTracker metadataTracker,
        GitHubAuthService authService,
        IGitHubWriteService writeService)
    {
        _metadataTracker = metadataTracker;
        _authService = authService;
        _writeService = writeService;
    }

    /// <summary>
    /// Gets whether there are any pending changes.
    /// </summary>
    public bool HasPendingChanges => !_pendingChanges.IsEmpty;

    /// <summary>
    /// Gets the count of pending changes.
    /// </summary>
    public int PendingChangeCount => _pendingChanges.Count;

    /// <summary>
    /// Adds or updates a pending change for a file.
    /// </summary>
    /// <param name="vfsPath">The VFS path of the file.</param>
    /// <param name="originalContent">The original content before modification.</param>
    /// <param name="newContent">The new content after modification.</param>
    /// <returns>True if the change was added, false if the file is not from GitHub.</returns>
    public bool AddChange(string vfsPath, string? originalContent, string newContent)
    {
        var metadata = _metadataTracker.GetMetadata(vfsPath);
        if (metadata is null)
        {
            return false;
        }

        var change = new PendingFileChange
        {
            VfsPath = vfsPath,
            Metadata = metadata,
            ChangeType = FileChangeType.Modified,
            OriginalContent = originalContent,
            NewContent = newContent,
            ChangedAt = DateTimeOffset.UtcNow
        };

        _pendingChanges[vfsPath] = change;
        OnPendingChangesChanged?.Invoke();
        return true;
    }

    /// <summary>
    /// Removes a pending change for a file.
    /// </summary>
    /// <param name="vfsPath">The VFS path of the file.</param>
    public void RemoveChange(string vfsPath)
    {
        if (_pendingChanges.TryRemove(vfsPath, out _))
        {
            OnPendingChangesChanged?.Invoke();
        }
    }

    /// <summary>
    /// Gets all pending changes.
    /// </summary>
    public IReadOnlyList<PendingFileChange> GetAllChanges()
    {
        return _pendingChanges.Values.ToList();
    }

    /// <summary>
    /// Gets pending changes for a specific file.
    /// </summary>
    public PendingFileChange? GetChange(string vfsPath)
    {
        return _pendingChanges.TryGetValue(vfsPath, out var change) ? change : null;
    }

    /// <summary>
    /// Checks if a file has pending changes.
    /// </summary>
    public bool HasPendingChange(string vfsPath)
    {
        return _pendingChanges.ContainsKey(vfsPath);
    }

    /// <summary>
    /// Gets pending changes grouped by repository.
    /// </summary>
    public IReadOnlyDictionary<string, List<PendingFileChange>> GetChangesGroupedByRepository()
    {
        return _pendingChanges.Values
            .GroupBy(c => c.Metadata.RepositoryKey)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    /// <summary>
    /// Gets pending changes for a specific repository.
    /// </summary>
    public IReadOnlyList<PendingFileChange> GetChangesForRepository(string owner, string repository)
    {
        var key = $"{owner}/{repository}";
        return _pendingChanges.Values
            .Where(c => c.Metadata.RepositoryKey.Equals(key, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    /// <summary>
    /// Clears all pending changes.
    /// </summary>
    public void ClearAll()
    {
        _pendingChanges.Clear();
        OnPendingChangesChanged?.Invoke();
    }

    /// <summary>
    /// Clears pending changes for a specific repository.
    /// </summary>
    public void ClearForRepository(string owner, string repository)
    {
        var key = $"{owner}/{repository}";
        var keysToRemove = _pendingChanges
            .Where(kvp => kvp.Value.Metadata.RepositoryKey.Equals(key, StringComparison.OrdinalIgnoreCase))
            .Select(kvp => kvp.Key)
            .ToList();

        foreach (var k in keysToRemove)
        {
            _pendingChanges.TryRemove(k, out _);
        }

        if (keysToRemove.Count > 0)
        {
            OnPendingChangesChanged?.Invoke();
        }
    }

    /// <summary>
    /// Creates a pull request with all pending changes for a repository.
    /// </summary>
    public async Task<PullRequestResult> CreatePullRequestAsync(PullRequestCreateInfo createInfo)
    {
        var token = _authService.GetAccessToken();
        if (string.IsNullOrEmpty(token))
        {
            return PullRequestResult.Failed(
                "Not authenticated. Please sign in to GitHub first.",
                PullRequestErrorCode.AuthenticationFailed,
                PullRequestCreationStep.CheckingPermissions);
        }

        var owner = createInfo.Owner;
        var repository = createInfo.Repository;
        var forkOwner = createInfo.ForkOwner;

        try
        {
            // Step 1: Check permissions and fork if needed
            if (createInfo.RequiresFork && !string.IsNullOrEmpty(forkOwner))
            {
                // Fork the repository
                var forkResult = await _writeService.ForkRepositoryAsync(owner, repository, token);
                if (!forkResult.Success)
                {
                    return PullRequestResult.Failed(
                        forkResult.ErrorMessage ?? "Failed to fork repository",
                        PullRequestErrorCode.ForkFailed,
                        PullRequestCreationStep.CreatingFork);
                }

                // Use fork for branch and commit operations
                owner = forkOwner;
            }

            // Step 2: Create branch
            var branchResult = await _writeService.CreateBranchAsync(
                owner, repository, createInfo.HeadBranch, createInfo.BaseBranch, token);

            if (!branchResult.Success)
            {
                return PullRequestResult.Failed(
                    branchResult.ErrorMessage ?? "Failed to create branch",
                    PullRequestErrorCode.BranchAlreadyExists,
                    PullRequestCreationStep.CreatingBranch);
            }

            // Step 3: Commit changes
            var files = createInfo.Changes
                .Where(c => c.NewContent is not null)
                .Select(c => new GitHubFileCommit(
                    c.Metadata.OriginalPath,
                    c.NewContent!,
                    c.Metadata.BlobSha))
                .ToList();

            var commitMessage = $"{createInfo.Title}\n\n{createInfo.Body ?? ""}".Trim();
            var commitResult = await _writeService.CommitChangesAsync(
                owner, repository, createInfo.HeadBranch, commitMessage, files, token);

            if (!commitResult.Success)
            {
                return PullRequestResult.Failed(
                    commitResult.ErrorMessage ?? "Failed to commit changes",
                    PullRequestErrorCode.CommitFailed,
                    PullRequestCreationStep.CommittingChanges);
            }

            // Step 4: Create PR (against original repo if forked)
            var targetOwner = createInfo.RequiresFork ? createInfo.Owner : owner;
            var headRef = createInfo.RequiresFork ? $"{owner}:{createInfo.HeadBranch}" : createInfo.HeadBranch;

            var prResult = await _writeService.CreatePullRequestAsync(
                targetOwner,
                repository,
                createInfo.Title,
                createInfo.Body,
                headRef,
                createInfo.BaseBranch,
                token,
                createInfo.IsDraft);

            if (!prResult.Success)
            {
                return PullRequestResult.Failed(
                    prResult.ErrorMessage ?? "Failed to create pull request",
                    PullRequestErrorCode.PullRequestCreationFailed,
                    PullRequestCreationStep.CreatingPullRequest);
            }

            // Clear the pending changes for this repository
            ClearForRepository(createInfo.Owner, createInfo.Repository);

            return PullRequestResult.Succeeded(
                prResult.PullRequestNumber!.Value,
                prResult.PullRequestUrl!,
                createInfo.HeadBranch,
                commitResult.CommitSha!,
                createInfo.RequiresFork ? $"https://github.com/{owner}/{repository}" : null);
        }
        catch (Exception ex)
        {
            return PullRequestResult.Failed(
                $"An unexpected error occurred: {ex.Message}",
                PullRequestErrorCode.Unknown);
        }
    }
}
