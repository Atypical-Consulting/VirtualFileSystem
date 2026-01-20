// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.GitHub.Exceptions;

/// <summary>
/// Exception thrown when GitHub API rate limit is exceeded.
/// </summary>
[Serializable]
public class GitHubRateLimitException : GitHubLoadException
{
    /// <summary>
    /// Gets the time when the rate limit will reset.
    /// </summary>
    public DateTimeOffset? ResetTime { get; }

    /// <summary>
    /// Gets the number of remaining requests when the exception was thrown.
    /// </summary>
    public int RemainingRequests { get; }

    /// <summary>
    /// Gets the maximum number of requests allowed in the rate limit window.
    /// </summary>
    public int RequestLimit { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRateLimitException"/> class.
    /// </summary>
    public GitHubRateLimitException()
        : base("GitHub API rate limit exceeded.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRateLimitException"/> class with a message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public GitHubRateLimitException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRateLimitException"/> class with rate limit details.
    /// </summary>
    /// <param name="resetTime">The time when the rate limit will reset.</param>
    /// <param name="remainingRequests">The number of remaining requests.</param>
    /// <param name="requestLimit">The maximum number of requests allowed.</param>
    public GitHubRateLimitException(DateTimeOffset? resetTime, int remainingRequests = 0, int requestLimit = 60)
        : base(BuildMessage(resetTime, remainingRequests, requestLimit))
    {
        ResetTime = resetTime;
        RemainingRequests = remainingRequests;
        RequestLimit = requestLimit;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRateLimitException"/> class with a message and inner exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of this exception.</param>
    public GitHubRateLimitException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRateLimitException"/> class from an Octokit exception.
    /// </summary>
    /// <param name="rateLimitException">The Octokit rate limit exception.</param>
    public GitHubRateLimitException(RateLimitExceededException rateLimitException)
        : base(BuildMessage(rateLimitException.Reset, 0, rateLimitException.Limit), rateLimitException)
    {
        ResetTime = rateLimitException.Reset;
        RemainingRequests = 0;
        RequestLimit = rateLimitException.Limit;
    }

    private static string BuildMessage(DateTimeOffset? resetTime, int remainingRequests, int requestLimit)
    {
        var message = $"GitHub API rate limit exceeded. Limit: {requestLimit} requests.";

        if (resetTime.HasValue)
        {
            var waitTime = resetTime.Value - DateTimeOffset.UtcNow;
            if (waitTime.TotalSeconds > 0)
            {
                message += $" Rate limit resets in {waitTime.TotalMinutes:F0} minutes at {resetTime.Value:HH:mm:ss UTC}.";
            }
        }

        message += " Consider using an access token to increase the rate limit from 60 to 5000 requests per hour.";

        return message;
    }
}
