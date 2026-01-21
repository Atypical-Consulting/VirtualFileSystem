namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Result of a pull request creation operation.
/// </summary>
public sealed record PullRequestResult
{
    /// <summary>
    /// Whether the PR was created successfully.
    /// </summary>
    public required bool Success { get; init; }

    /// <summary>
    /// The PR number (if successful).
    /// </summary>
    public int? PullRequestNumber { get; init; }

    /// <summary>
    /// The URL to view the PR on GitHub.
    /// </summary>
    public string? PullRequestUrl { get; init; }

    /// <summary>
    /// The URL of the fork created (if applicable).
    /// </summary>
    public string? ForkUrl { get; init; }

    /// <summary>
    /// The name of the branch created for the PR.
    /// </summary>
    public string? BranchName { get; init; }

    /// <summary>
    /// The commit SHA of the changes.
    /// </summary>
    public string? CommitSha { get; init; }

    /// <summary>
    /// Error message if the operation failed.
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// Error code for programmatic handling.
    /// </summary>
    public PullRequestErrorCode? ErrorCode { get; init; }

    /// <summary>
    /// The current step when failure occurred.
    /// </summary>
    public PullRequestCreationStep? FailedAtStep { get; init; }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    public static PullRequestResult Succeeded(
        int prNumber,
        string prUrl,
        string branchName,
        string commitSha,
        string? forkUrl = null) => new()
    {
        Success = true,
        PullRequestNumber = prNumber,
        PullRequestUrl = prUrl,
        BranchName = branchName,
        CommitSha = commitSha,
        ForkUrl = forkUrl
    };

    /// <summary>
    /// Creates a failed result.
    /// </summary>
    public static PullRequestResult Failed(
        string errorMessage,
        PullRequestErrorCode errorCode,
        PullRequestCreationStep? failedAtStep = null) => new()
    {
        Success = false,
        ErrorMessage = errorMessage,
        ErrorCode = errorCode,
        FailedAtStep = failedAtStep
    };
}

/// <summary>
/// Error codes for PR creation failures.
/// </summary>
public enum PullRequestErrorCode
{
    /// <summary>
    /// Unknown error.
    /// </summary>
    Unknown,

    /// <summary>
    /// Authentication failed or token is invalid.
    /// </summary>
    AuthenticationFailed,

    /// <summary>
    /// Token doesn't have required permissions (repo scope).
    /// </summary>
    InsufficientPermissions,

    /// <summary>
    /// API rate limit exceeded.
    /// </summary>
    RateLimitExceeded,

    /// <summary>
    /// Repository not found or access denied.
    /// </summary>
    RepositoryNotFound,

    /// <summary>
    /// Branch already exists.
    /// </summary>
    BranchAlreadyExists,

    /// <summary>
    /// Base branch not found.
    /// </summary>
    BaseBranchNotFound,

    /// <summary>
    /// File was modified on GitHub since import (conflict).
    /// </summary>
    FileConflict,

    /// <summary>
    /// Network error during API call.
    /// </summary>
    NetworkError,

    /// <summary>
    /// Fork creation failed.
    /// </summary>
    ForkFailed,

    /// <summary>
    /// Commit creation failed.
    /// </summary>
    CommitFailed,

    /// <summary>
    /// PR creation failed.
    /// </summary>
    PullRequestCreationFailed
}

/// <summary>
/// Steps in the PR creation process.
/// </summary>
public enum PullRequestCreationStep
{
    /// <summary>
    /// Checking repository permissions.
    /// </summary>
    CheckingPermissions,

    /// <summary>
    /// Creating a fork of the repository.
    /// </summary>
    CreatingFork,

    /// <summary>
    /// Waiting for fork to be ready.
    /// </summary>
    WaitingForFork,

    /// <summary>
    /// Creating the feature branch.
    /// </summary>
    CreatingBranch,

    /// <summary>
    /// Committing file changes.
    /// </summary>
    CommittingChanges,

    /// <summary>
    /// Creating the pull request.
    /// </summary>
    CreatingPullRequest,

    /// <summary>
    /// Operation completed successfully.
    /// </summary>
    Completed
}
