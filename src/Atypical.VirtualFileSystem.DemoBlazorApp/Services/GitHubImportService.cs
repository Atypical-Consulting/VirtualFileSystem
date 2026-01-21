using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.DemoBlazorApp.Models;
using Atypical.VirtualFileSystem.GitHub;
using Atypical.VirtualFileSystem.GitHub.Exceptions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Service for importing GitHub repositories into the Virtual File System.
/// </summary>
public class GitHubImportService
{
    private readonly IGitHubRepositoryLoader _loader;
    private readonly GitHubAuthService _authService;
    private readonly GitHubMetadataTracker _metadataTracker;
    private CancellationTokenSource? _cancellationTokenSource;

    // Store current import context for metadata callback
    private string? _currentOwner;
    private string? _currentRepository;
    private string? _currentBranch;
    private string? _currentCommitSha;

    /// <summary>
    /// Gets the current import state.
    /// </summary>
    public GitHubImportState State { get; } = new();

    /// <summary>
    /// Event fired when the import state changes.
    /// </summary>
    public event Action? OnStateChanged;

    public GitHubImportService(
        IGitHubRepositoryLoader loader,
        GitHubAuthService authService,
        GitHubMetadataTracker metadataTracker)
    {
        _loader = loader;
        _authService = authService;
        _metadataTracker = metadataTracker;
    }

    /// <summary>
    /// Attempts to parse a GitHub URL into owner and repository components.
    /// </summary>
    public bool TryParseUrl(string url, out string owner, out string repository)
    {
        return _loader.TryParseGitHubUrl(url, out owner, out repository);
    }

    /// <summary>
    /// Imports a GitHub repository into the VFS.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load into.</param>
    /// <param name="owner">The repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="branch">Optional branch name (defaults to main).</param>
    /// <param name="subPath">Optional subdirectory to load.</param>
    /// <param name="targetPath">The VFS path where the repository will be loaded.</param>
    /// <param name="maxFileSize">Maximum file size in bytes.</param>
    /// <param name="includeExtensions">File extensions to include (null = all).</param>
    /// <param name="excludeBinaryFiles">Whether to exclude binary files.</param>
    /// <returns>The result of the import operation.</returns>
    public async Task<GitHubLoadResult?> ImportRepositoryAsync(
        IVirtualFileSystem vfs,
        string owner,
        string repository,
        string? branch = null,
        string? subPath = null,
        string? targetPath = null,
        long maxFileSize = 1_048_576,
        HashSet<string>? includeExtensions = null,
        bool excludeBinaryFiles = false)
    {
        // Reset state
        State.Reset();
        State.IsImporting = true;
        NotifyStateChanged();

        // Create cancellation token
        _cancellationTokenSource = new CancellationTokenSource();
        var token = _cancellationTokenSource.Token;

        try
        {
            // Store context for metadata callback
            _currentOwner = owner;
            _currentRepository = repository;
            _currentBranch = branch ?? "main"; // Will be updated by result

            // Build target path if not specified
            var effectiveTargetPath = targetPath ?? $"/github/{owner}/{repository}";

            // Get auth token if available
            var accessToken = _authService.GetAccessToken();

            // Build options with progress and metadata callbacks
            var options = new GitHubLoaderOptions(
                AccessToken: accessToken,
                Branch: branch,
                SubPath: subPath,
                TargetPath: effectiveTargetPath,
                MaxFileSize: maxFileSize,
                IncludeExtensions: includeExtensions,
                IncludeBinaryFiles: !excludeBinaryFiles,
                ProgressCallback: (current, total, path) =>
                {
                    State.CurrentFile = current;
                    State.TotalFiles = total;
                    State.CurrentPath = path;
                    NotifyStateChanged();
                },
                MetadataCallback: OnFileMetadataReceived
            );

            // Load the repository
            var result = await _loader.LoadRepositoryAsync(
                vfs, owner, repository, options, token);

            // Update context with actual branch and commit SHA from result
            _currentBranch = result.Branch;
            _currentCommitSha = result.CommitSha;

            return result;
        }
        catch (OperationCanceledException)
        {
            State.WasCancelled = true;
            State.ErrorMessage = "Import was cancelled.";
            return null;
        }
        catch (GitHubRateLimitException ex)
        {
            State.ErrorMessage = ex.ResetTime.HasValue
                ? $"GitHub API rate limit exceeded. Try again after {ex.ResetTime.Value:HH:mm:ss}. " +
                  "Consider using a Personal Access Token for higher limits."
                : "GitHub API rate limit exceeded. Consider using a Personal Access Token.";
            return null;
        }
        catch (GitHubLoadException ex)
        {
            State.ErrorMessage = $"Failed to load repository: {ex.Message}";
            return null;
        }
        catch (Exception ex)
        {
            State.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
            return null;
        }
        finally
        {
            State.IsImporting = false;
            NotifyStateChanged();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
            ClearImportContext();
        }
    }

    /// <summary>
    /// Cancels the current import operation.
    /// </summary>
    public void CancelImport()
    {
        _cancellationTokenSource?.Cancel();
    }

    private void NotifyStateChanged()
    {
        OnStateChanged?.Invoke();
    }

    /// <summary>
    /// Callback invoked when file metadata is received during import.
    /// </summary>
    private void OnFileMetadataReceived(string vfsPath, string originalPath, string blobSha)
    {
        if (_currentOwner is null || _currentRepository is null || _currentBranch is null)
            return;

        var metadata = new GitHubFileMetadata
        {
            Owner = _currentOwner,
            Repository = _currentRepository,
            Branch = _currentBranch,
            OriginalPath = originalPath,
            BlobSha = blobSha,
            CommitSha = _currentCommitSha,
            ImportedAt = DateTimeOffset.UtcNow
        };

        _metadataTracker.TrackFile(vfsPath, metadata);
    }

    /// <summary>
    /// Clears the current import context.
    /// </summary>
    private void ClearImportContext()
    {
        _currentOwner = null;
        _currentRepository = null;
        _currentBranch = null;
        _currentCommitSha = null;
    }
}
