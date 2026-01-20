// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Service for loading GitHub repositories into a Virtual File System.
/// </summary>
public sealed partial class GitHubRepositoryLoader : IGitHubRepositoryLoader
{
    private const string ProductHeaderValue = "Atypical.VirtualFileSystem.GitHub";

    private readonly GitHubClient _client;
    private readonly GitHubLoaderOptions _defaultOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRepositoryLoader"/> class.
    /// </summary>
    /// <param name="defaultOptions">Default options to use when loading repositories.</param>
    public GitHubRepositoryLoader(GitHubLoaderOptions? defaultOptions = null)
    {
        _defaultOptions = defaultOptions ?? GitHubLoaderOptions.Default;
        _client = CreateClient(_defaultOptions.AccessToken);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRepositoryLoader"/> class with an access token.
    /// </summary>
    /// <param name="accessToken">The GitHub Personal Access Token.</param>
    public GitHubRepositoryLoader(string accessToken)
        : this(new GitHubLoaderOptions(AccessToken: accessToken))
    {
    }

    /// <inheritdoc />
    public async Task<GitHubLoadResult> LoadRepositoryAsync(
        IVirtualFileSystem vfs,
        string owner,
        string repository,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(vfs);
        ArgumentException.ThrowIfNullOrWhiteSpace(owner);
        ArgumentException.ThrowIfNullOrWhiteSpace(repository);

        options ??= _defaultOptions;
        var stopwatch = Stopwatch.StartNew();
        var skippedFiles = new List<GitHubSkippedFile>();
        var directoriesCreated = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var filesLoaded = 0;
        long totalBytesLoaded = 0;

        // Create client with options-specific token if different from default
        var client = options.AccessToken != _defaultOptions.AccessToken
            ? CreateClient(options.AccessToken)
            : _client;

        try
        {
            // Get repository info
            Repository repo;
            try
            {
                repo = await client.Repository.Get(owner, repository);
            }
            catch (NotFoundException ex)
            {
                throw new GitHubLoadException(owner, repository, "Repository not found", ex);
            }

            // Determine branch
            var branch = options.Branch ?? repo.DefaultBranch;

            // Get the tree recursively
            TreeResponse tree;
            try
            {
                var reference = await client.Git.Reference.Get(owner, repository, $"heads/{branch}");
                var commitSha = reference.Object.Sha;
                tree = await client.Git.Tree.GetRecursive(owner, repository, commitSha);
            }
            catch (NotFoundException ex)
            {
                throw new GitHubLoadException(owner, repository, $"Branch '{branch}' not found", ex);
            }

            // Get commit SHA for result
            var refInfo = await client.Git.Reference.Get(owner, repository, $"heads/{branch}");
            var sha = refInfo.Object.Sha;

            // Filter tree items
            var filesToLoad = FilterTreeItems(tree.Tree, options, skippedFiles);

            // Calculate total for progress
            var totalFiles = filesToLoad.Count;
            var currentFile = 0;

            // Load files
            foreach (var item in filesToLoad)
            {
                cancellationToken.ThrowIfCancellationRequested();

                currentFile++;
                var relativePath = GetRelativePath(item.Path, options.SubPath);
                var targetPath = CombinePaths(options.TargetPath, relativePath);

                // Report progress
                options.ProgressCallback?.Invoke(currentFile, totalFiles, item.Path);

                // Ensure parent directories exist
                var parentDir = GetParentPath(targetPath);
                if (!string.IsNullOrEmpty(parentDir) && directoriesCreated.Add(parentDir))
                {
                    EnsureDirectoryExists(vfs, parentDir, directoriesCreated);
                }

                try
                {
                    if (options.Strategy == GitHubLoadingStrategy.MetadataOnly)
                    {
                        // Create file with placeholder content
                        var metadataContent = $"[GitHub: {owner}/{repository}/{item.Path}] Size: {item.Size} bytes";
                        vfs.CreateFileWithDirectories(targetPath, metadataContent);
                    }
                    else if (options.Strategy == GitHubLoadingStrategy.Lazy)
                    {
                        // Create file with lazy loading marker
                        var lazyContent = $"[LAZY:{owner}/{repository}/{item.Sha}]";
                        vfs.CreateFileWithDirectories(targetPath, lazyContent);
                    }
                    else
                    {
                        // Eager loading - fetch content
                        var content = await FetchFileContentAsync(client, owner, repository, item, cancellationToken);

                        if (IsBinaryFile(item.Path))
                        {
                            vfs.CreateBinaryFileWithDirectories(targetPath, content);
                        }
                        else
                        {
                            var textContent = System.Text.Encoding.UTF8.GetString(content);
                            vfs.CreateFileWithDirectories(targetPath, textContent);
                        }

                        totalBytesLoaded += content.Length;
                    }

                    filesLoaded++;
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    skippedFiles.Add(new GitHubSkippedFile(item.Path, SkipReason.LoadError, item.Size, ex.Message));
                }
            }

            stopwatch.Stop();

            return new GitHubLoadResult(
                owner,
                repository,
                branch,
                sha,
                filesLoaded,
                directoriesCreated.Count,
                totalBytesLoaded,
                skippedFiles,
                stopwatch.Elapsed,
                options.TargetPath);
        }
        catch (RateLimitExceededException ex)
        {
            throw new GitHubRateLimitException(ex);
        }
        catch (ApiException ex) when (ex is not RateLimitExceededException)
        {
            throw new GitHubLoadException(owner, repository, ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<GitHubLoadResult> LoadRepositoryFromUrlAsync(
        IVirtualFileSystem vfs,
        string repositoryUrl,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (!TryParseGitHubUrl(repositoryUrl, out var owner, out var repository))
        {
            throw new ArgumentException($"Invalid GitHub repository URL: {repositoryUrl}", nameof(repositoryUrl));
        }

        return await LoadRepositoryAsync(vfs, owner, repository, options, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<(bool Success, GitHubLoadResult? Result)> TryLoadRepositoryAsync(
        IVirtualFileSystem vfs,
        string owner,
        string repository,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await LoadRepositoryAsync(vfs, owner, repository, options, cancellationToken);
            return (true, result);
        }
        catch
        {
            return (false, null);
        }
    }

    /// <inheritdoc />
    public bool TryParseGitHubUrl(string url, out string owner, out string repository)
    {
        owner = string.Empty;
        repository = string.Empty;

        if (string.IsNullOrWhiteSpace(url))
            return false;

        var match = GitHubUrlRegex().Match(url);
        if (!match.Success)
            return false;

        owner = match.Groups["owner"].Value;
        repository = match.Groups["repo"].Value;

        // Remove .git suffix if present
        if (repository.EndsWith(".git", StringComparison.OrdinalIgnoreCase))
        {
            repository = repository[..^4];
        }

        return !string.IsNullOrEmpty(owner) && !string.IsNullOrEmpty(repository);
    }

    private static GitHubClient CreateClient(string? accessToken)
    {
        var client = new GitHubClient(new ProductHeaderValue(ProductHeaderValue));

        if (!string.IsNullOrEmpty(accessToken))
        {
            client.Credentials = new Credentials(accessToken);
        }

        return client;
    }

    private static List<TreeItem> FilterTreeItems(
        IReadOnlyList<TreeItem> items,
        GitHubLoaderOptions options,
        List<GitHubSkippedFile> skippedFiles)
    {
        var result = new List<TreeItem>();

        foreach (var item in items)
        {
            // Skip directories (we only care about files/blobs)
            if (item.Type != TreeType.Blob)
                continue;

            // Check SubPath filter
            if (!string.IsNullOrEmpty(options.SubPath))
            {
                var normalizedSubPath = options.SubPath.TrimStart('/').TrimEnd('/');
                if (!item.Path.StartsWith(normalizedSubPath, StringComparison.OrdinalIgnoreCase))
                    continue;
            }

            // Check file size
            if (options.MaxFileSize > 0 && item.Size > options.MaxFileSize)
            {
                skippedFiles.Add(new GitHubSkippedFile(item.Path, SkipReason.TooLarge, item.Size));
                continue;
            }

            // Get file extension
            var extension = Path.GetExtension(item.Path);

            // Check binary files
            if (!options.IncludeBinaryFiles && GitHubLoaderOptions.IsBinaryExtension(extension))
            {
                skippedFiles.Add(new GitHubSkippedFile(item.Path, SkipReason.BinaryExcluded, item.Size));
                continue;
            }

            // Check exclude extensions
            if (options.ExcludeExtensions?.Contains(extension, StringComparer.OrdinalIgnoreCase) == true)
            {
                skippedFiles.Add(new GitHubSkippedFile(item.Path, SkipReason.ExtensionExcluded, item.Size));
                continue;
            }

            // Check include extensions
            if (options.IncludeExtensions?.Count > 0 &&
                !options.IncludeExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
            {
                skippedFiles.Add(new GitHubSkippedFile(item.Path, SkipReason.ExtensionNotIncluded, item.Size));
                continue;
            }

            // Check exclude patterns
            if (MatchesExcludePattern(item.Path, options.ExcludePatterns))
            {
                skippedFiles.Add(new GitHubSkippedFile(item.Path, SkipReason.PatternExcluded, item.Size));
                continue;
            }

            result.Add(item);
        }

        return result;
    }

    private static bool MatchesExcludePattern(string path, List<string>? patterns)
    {
        if (patterns == null || patterns.Count == 0)
            return false;

        foreach (var pattern in patterns)
        {
            if (MatchGlobPattern(path, pattern))
                return true;
        }

        return false;
    }

    private static bool MatchGlobPattern(string path, string pattern)
    {
        // Convert glob pattern to regex
        var regexPattern = "^" + Regex.Escape(pattern)
            .Replace(@"\*\*", ".*")
            .Replace(@"\*", "[^/]*")
            .Replace(@"\?", ".") + "$";

        return Regex.IsMatch(path, regexPattern, RegexOptions.IgnoreCase);
    }

    private static async Task<byte[]> FetchFileContentAsync(
        GitHubClient client,
        string owner,
        string repository,
        TreeItem item,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var blob = await client.Git.Blob.Get(owner, repository, item.Sha);

        return blob.Encoding == EncodingType.Base64
            ? Convert.FromBase64String(blob.Content)
            : System.Text.Encoding.UTF8.GetBytes(blob.Content);
    }

    private static string GetRelativePath(string path, string? subPath)
    {
        if (string.IsNullOrEmpty(subPath))
            return path;

        var normalizedSubPath = subPath.TrimStart('/').TrimEnd('/');
        if (path.StartsWith(normalizedSubPath, StringComparison.OrdinalIgnoreCase))
        {
            return path[(normalizedSubPath.Length)..].TrimStart('/');
        }

        return path;
    }

    private static string CombinePaths(string basePath, string relativePath)
    {
        var normalizedBase = basePath.TrimEnd('/');
        var normalizedRelative = relativePath.TrimStart('/');

        if (string.IsNullOrEmpty(normalizedBase) || normalizedBase == "/")
            return "/" + normalizedRelative;

        return normalizedBase + "/" + normalizedRelative;
    }

    private static string GetParentPath(string path)
    {
        var lastSlash = path.LastIndexOf('/');
        if (lastSlash <= 0)
            return string.Empty;

        return path[..lastSlash];
    }

    private static void EnsureDirectoryExists(
        IVirtualFileSystem vfs,
        string directoryPath,
        HashSet<string> createdDirectories)
    {
        if (string.IsNullOrEmpty(directoryPath) || directoryPath == "/")
            return;

        // Check parent first
        var parent = GetParentPath(directoryPath);
        if (!string.IsNullOrEmpty(parent) && createdDirectories.Add(parent))
        {
            EnsureDirectoryExists(vfs, parent, createdDirectories);
        }

        // Create this directory if needed
        if (!vfs.DirectoryExists(directoryPath))
        {
            vfs.CreateDirectory(directoryPath);
        }
    }

    private static bool IsBinaryFile(string path)
    {
        var extension = Path.GetExtension(path);
        return GitHubLoaderOptions.IsBinaryExtension(extension);
    }

    [GeneratedRegex(@"^https?://(?:www\.)?github\.com/(?<owner>[^/]+)/(?<repo>[^/]+)(?:/.*)?$", RegexOptions.IgnoreCase)]
    private static partial Regex GitHubUrlRegex();
}
