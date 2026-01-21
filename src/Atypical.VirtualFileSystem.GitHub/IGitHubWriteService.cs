// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Represents file content for committing to GitHub.
/// </summary>
/// <param name="Path">The file path in the repository.</param>
/// <param name="Content">The new file content.</param>
/// <param name="BlobSha">The original blob SHA (for updates), null for new files.</param>
public sealed record GitHubFileCommit(
    string Path,
    string Content,
    string? BlobSha = null);

/// <summary>
/// Result of creating a commit on GitHub.
/// </summary>
/// <param name="Success">Whether the commit was created successfully.</param>
/// <param name="CommitSha">The SHA of the created commit.</param>
/// <param name="ErrorMessage">Error message if the operation failed.</param>
public sealed record GitHubCommitResult(
    bool Success,
    string? CommitSha = null,
    string? ErrorMessage = null);

/// <summary>
/// Result of creating a branch on GitHub.
/// </summary>
/// <param name="Success">Whether the branch was created successfully.</param>
/// <param name="BranchName">The name of the created branch.</param>
/// <param name="CommitSha">The SHA of the commit the branch points to.</param>
/// <param name="ErrorMessage">Error message if the operation failed.</param>
public sealed record GitHubBranchResult(
    bool Success,
    string? BranchName = null,
    string? CommitSha = null,
    string? ErrorMessage = null);

/// <summary>
/// Result of creating a pull request on GitHub.
/// </summary>
/// <param name="Success">Whether the PR was created successfully.</param>
/// <param name="PullRequestNumber">The PR number.</param>
/// <param name="PullRequestUrl">The URL to view the PR.</param>
/// <param name="ErrorMessage">Error message if the operation failed.</param>
public sealed record GitHubPullRequestResult(
    bool Success,
    int? PullRequestNumber = null,
    string? PullRequestUrl = null,
    string? ErrorMessage = null);

/// <summary>
/// Result of forking a repository.
/// </summary>
/// <param name="Success">Whether the fork was created successfully.</param>
/// <param name="ForkOwner">The owner of the fork (authenticated user).</param>
/// <param name="ForkUrl">The URL of the fork.</param>
/// <param name="ErrorMessage">Error message if the operation failed.</param>
public sealed record GitHubForkResult(
    bool Success,
    string? ForkOwner = null,
    string? ForkUrl = null,
    string? ErrorMessage = null);

/// <summary>
/// Service for writing changes to GitHub repositories via the API.
/// Supports creating branches, commits, and pull requests.
/// </summary>
public interface IGitHubWriteService
{
    /// <summary>
    /// Checks if the authenticated user has write access to a repository.
    /// </summary>
    /// <param name="owner">The repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="accessToken">The GitHub access token.</param>
    /// <returns>True if the user has write (push) access.</returns>
    Task<bool> HasWriteAccessAsync(string owner, string repository, string accessToken);

    /// <summary>
    /// Forks a repository to the authenticated user's account.
    /// </summary>
    /// <param name="owner">The original repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="accessToken">The GitHub access token.</param>
    /// <returns>The result of the fork operation.</returns>
    Task<GitHubForkResult> ForkRepositoryAsync(string owner, string repository, string accessToken);

    /// <summary>
    /// Creates a new branch from a reference (usually the default branch).
    /// </summary>
    /// <param name="owner">The repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="branchName">The name for the new branch.</param>
    /// <param name="fromBranch">The branch to create from (null for default branch).</param>
    /// <param name="accessToken">The GitHub access token.</param>
    /// <returns>The result of the branch creation.</returns>
    Task<GitHubBranchResult> CreateBranchAsync(
        string owner,
        string repository,
        string branchName,
        string? fromBranch,
        string accessToken);

    /// <summary>
    /// Commits multiple file changes to a branch.
    /// Uses the Git Tree API for atomic multi-file commits.
    /// </summary>
    /// <param name="owner">The repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="branch">The branch to commit to.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="files">The files to commit.</param>
    /// <param name="accessToken">The GitHub access token.</param>
    /// <returns>The result of the commit operation.</returns>
    Task<GitHubCommitResult> CommitChangesAsync(
        string owner,
        string repository,
        string branch,
        string message,
        IReadOnlyList<GitHubFileCommit> files,
        string accessToken);

    /// <summary>
    /// Creates a pull request from one branch to another.
    /// </summary>
    /// <param name="owner">The target repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="title">The PR title.</param>
    /// <param name="body">The PR body/description.</param>
    /// <param name="headBranch">The source branch (can include fork owner prefix).</param>
    /// <param name="baseBranch">The target branch to merge into.</param>
    /// <param name="accessToken">The GitHub access token.</param>
    /// <param name="isDraft">Whether to create as a draft PR.</param>
    /// <returns>The result of the PR creation.</returns>
    Task<GitHubPullRequestResult> CreatePullRequestAsync(
        string owner,
        string repository,
        string title,
        string? body,
        string headBranch,
        string baseBranch,
        string accessToken,
        bool isDraft = false);
}
