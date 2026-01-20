// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Extension methods for loading GitHub repositories into a Virtual File System.
/// </summary>
public static class VFSGitHubExtensions
{
    private static readonly GitHubRepositoryLoader DefaultLoader = new();

    /// <summary>
    /// Loads a GitHub repository into the Virtual File System.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="owner">The repository owner (user or organization).</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>The Virtual File System for method chaining.</returns>
    /// <exception cref="GitHubLoadException">Thrown when the repository cannot be loaded.</exception>
    /// <exception cref="GitHubRateLimitException">Thrown when the GitHub API rate limit is exceeded.</exception>
    /// <example>
    /// <code>
    /// var vfs = new VFS();
    /// await vfs.LoadGitHubRepositoryAsync("microsoft", "dotnet");
    /// </code>
    /// </example>
    public static async Task<IVirtualFileSystem> LoadGitHubRepositoryAsync(
        this IVirtualFileSystem vfs,
        string owner,
        string repository,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var loader = CreateLoader(options);
        await loader.LoadRepositoryAsync(vfs, owner, repository, options, cancellationToken);
        return vfs;
    }

    /// <summary>
    /// Loads a GitHub repository into the Virtual File System and returns detailed results.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="owner">The repository owner (user or organization).</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result containing details about the load operation.</returns>
    /// <exception cref="GitHubLoadException">Thrown when the repository cannot be loaded.</exception>
    /// <exception cref="GitHubRateLimitException">Thrown when the GitHub API rate limit is exceeded.</exception>
    /// <example>
    /// <code>
    /// var vfs = new VFS();
    /// var result = await vfs.LoadGitHubRepositoryWithResultAsync(
    ///     "dotnet", "runtime",
    ///     new GitHubLoaderOptions
    ///     {
    ///         Branch = "main",
    ///         SubPath = "src/libraries/System.Text.Json",
    ///         IncludeExtensions = [".cs"]
    ///     });
    /// Console.WriteLine($"Loaded {result.FilesLoaded} files");
    /// </code>
    /// </example>
    public static async Task<GitHubLoadResult> LoadGitHubRepositoryWithResultAsync(
        this IVirtualFileSystem vfs,
        string owner,
        string repository,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var loader = CreateLoader(options);
        return await loader.LoadRepositoryAsync(vfs, owner, repository, options, cancellationToken);
    }

    /// <summary>
    /// Loads a GitHub repository from a URL into the Virtual File System.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="repositoryUrl">The GitHub repository URL.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>The Virtual File System for method chaining.</returns>
    /// <exception cref="ArgumentException">Thrown when the URL is not a valid GitHub repository URL.</exception>
    /// <exception cref="GitHubLoadException">Thrown when the repository cannot be loaded.</exception>
    /// <exception cref="GitHubRateLimitException">Thrown when the GitHub API rate limit is exceeded.</exception>
    /// <example>
    /// <code>
    /// var vfs = new VFS();
    /// await vfs.LoadGitHubRepositoryFromUrlAsync("https://github.com/owner/repo");
    /// </code>
    /// </example>
    public static async Task<IVirtualFileSystem> LoadGitHubRepositoryFromUrlAsync(
        this IVirtualFileSystem vfs,
        string repositoryUrl,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var loader = CreateLoader(options);
        await loader.LoadRepositoryFromUrlAsync(vfs, repositoryUrl, options, cancellationToken);
        return vfs;
    }

    /// <summary>
    /// Loads a GitHub repository from a URL into the Virtual File System and returns detailed results.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="repositoryUrl">The GitHub repository URL.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result containing details about the load operation.</returns>
    /// <exception cref="ArgumentException">Thrown when the URL is not a valid GitHub repository URL.</exception>
    /// <exception cref="GitHubLoadException">Thrown when the repository cannot be loaded.</exception>
    /// <exception cref="GitHubRateLimitException">Thrown when the GitHub API rate limit is exceeded.</exception>
    public static async Task<GitHubLoadResult> LoadGitHubRepositoryFromUrlWithResultAsync(
        this IVirtualFileSystem vfs,
        string repositoryUrl,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var loader = CreateLoader(options);
        return await loader.LoadRepositoryFromUrlAsync(vfs, repositoryUrl, options, cancellationToken);
    }

    /// <summary>
    /// Attempts to load a GitHub repository, returning a tuple instead of throwing on failure.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="owner">The repository owner (user or organization).</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A tuple containing success status and the load result if successful.</returns>
    /// <example>
    /// <code>
    /// var vfs = new VFS();
    /// var (success, result) = await vfs.TryLoadGitHubRepositoryAsync("owner", "repo");
    /// if (success)
    /// {
    ///     Console.WriteLine($"Loaded {result.FilesLoaded} files");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("Failed to load repository");
    /// }
    /// </code>
    /// </example>
    public static async Task<(bool Success, GitHubLoadResult? Result)> TryLoadGitHubRepositoryAsync(
        this IVirtualFileSystem vfs,
        string owner,
        string repository,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var loader = CreateLoader(options);
            var result = await loader.LoadRepositoryAsync(vfs, owner, repository, options, cancellationToken);
            return (true, result);
        }
        catch
        {
            return (false, null);
        }
    }

    /// <summary>
    /// Attempts to load a GitHub repository from a URL, returning false instead of throwing on failure.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="repositoryUrl">The GitHub repository URL.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A tuple indicating success and the load result.</returns>
    public static async Task<(bool Success, GitHubLoadResult? Result)> TryLoadGitHubRepositoryFromUrlAsync(
        this IVirtualFileSystem vfs,
        string repositoryUrl,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var loader = CreateLoader(options);
            var result = await loader.LoadRepositoryFromUrlAsync(vfs, repositoryUrl, options, cancellationToken);
            return (true, result);
        }
        catch
        {
            return (false, null);
        }
    }

    /// <summary>
    /// Parses a GitHub URL to extract owner and repository name.
    /// </summary>
    /// <param name="url">The GitHub repository URL.</param>
    /// <param name="owner">The extracted owner.</param>
    /// <param name="repository">The extracted repository name.</param>
    /// <returns>True if the URL was successfully parsed, false otherwise.</returns>
    public static bool TryParseGitHubUrl(string url, out string owner, out string repository)
        => DefaultLoader.TryParseGitHubUrl(url, out owner, out repository);

    private static GitHubRepositoryLoader CreateLoader(GitHubLoaderOptions? options)
    {
        // Use cached default loader if no custom options or only default options
        if (options == null || options.AccessToken == null)
            return DefaultLoader;

        // Create new loader with custom access token
        return new GitHubRepositoryLoader(options);
    }
}
