// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Service interface for loading GitHub repositories into a Virtual File System.
/// </summary>
public interface IGitHubRepositoryLoader
{
    /// <summary>
    /// Loads a GitHub repository into the specified Virtual File System.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="owner">The repository owner (user or organization).</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result containing details about the load operation.</returns>
    /// <exception cref="GitHubLoadException">Thrown when the repository cannot be loaded.</exception>
    /// <exception cref="GitHubRateLimitException">Thrown when the GitHub API rate limit is exceeded.</exception>
    Task<GitHubLoadResult> LoadRepositoryAsync(
        IVirtualFileSystem vfs,
        string owner,
        string repository,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Loads a GitHub repository from a URL into the specified Virtual File System.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="repositoryUrl">The GitHub repository URL.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result containing details about the load operation.</returns>
    /// <exception cref="ArgumentException">Thrown when the URL is not a valid GitHub repository URL.</exception>
    /// <exception cref="GitHubLoadException">Thrown when the repository cannot be loaded.</exception>
    /// <exception cref="GitHubRateLimitException">Thrown when the GitHub API rate limit is exceeded.</exception>
    Task<GitHubLoadResult> LoadRepositoryFromUrlAsync(
        IVirtualFileSystem vfs,
        string repositoryUrl,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to load a GitHub repository, returning a tuple instead of throwing.
    /// </summary>
    /// <param name="vfs">The Virtual File System to load the repository into.</param>
    /// <param name="owner">The repository owner (user or organization).</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="options">Options for controlling the loading behavior. Uses defaults if null.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A tuple containing success status and the result if successful.</returns>
    Task<(bool Success, GitHubLoadResult? Result)> TryLoadRepositoryAsync(
        IVirtualFileSystem vfs,
        string owner,
        string repository,
        GitHubLoaderOptions? options = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Parses a GitHub URL to extract owner and repository name.
    /// </summary>
    /// <param name="url">The GitHub repository URL.</param>
    /// <param name="owner">The extracted owner.</param>
    /// <param name="repository">The extracted repository name.</param>
    /// <returns>True if the URL was successfully parsed, false otherwise.</returns>
    bool TryParseGitHubUrl(string url, out string owner, out string repository);
}
