namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Stores GitHub Personal Access Token credentials and associated rate limit information.
/// </summary>
public sealed record GitHubCredentials
{
    /// <summary>
    /// The GitHub Personal Access Token (PAT).
    /// </summary>
    public required string Token { get; init; }

    /// <summary>
    /// The authenticated GitHub username.
    /// </summary>
    public string? Username { get; init; }

    /// <summary>
    /// The remaining API calls before rate limiting.
    /// </summary>
    public int RateLimitRemaining { get; init; }

    /// <summary>
    /// The total rate limit for the current time window.
    /// </summary>
    public int RateLimitTotal { get; init; }

    /// <summary>
    /// When the rate limit resets (UTC).
    /// </summary>
    public DateTimeOffset? RateLimitReset { get; init; }

    /// <summary>
    /// Whether the credentials have been validated against the GitHub API.
    /// </summary>
    public bool IsValidated { get; init; }

    /// <summary>
    /// When the credentials were last validated.
    /// </summary>
    public DateTimeOffset? LastValidated { get; init; }

    /// <summary>
    /// Gets a formatted string showing remaining/total rate limit.
    /// </summary>
    public string RateLimitDisplay => $"{RateLimitRemaining:N0}/{RateLimitTotal:N0}";

    /// <summary>
    /// Gets the time until rate limit reset as a human-readable string.
    /// </summary>
    public string? TimeUntilReset
    {
        get
        {
            if (RateLimitReset is null)
                return null;

            var remaining = RateLimitReset.Value - DateTimeOffset.UtcNow;
            if (remaining <= TimeSpan.Zero)
                return "now";

            if (remaining.TotalMinutes < 1)
                return $"{(int)remaining.TotalSeconds}s";

            if (remaining.TotalHours < 1)
                return $"{(int)remaining.TotalMinutes}m";

            return $"{(int)remaining.TotalHours}h {remaining.Minutes}m";
        }
    }

    /// <summary>
    /// Creates anonymous credentials (no token, default rate limits).
    /// </summary>
    public static GitHubCredentials Anonymous => new()
    {
        Token = string.Empty,
        RateLimitRemaining = 60,
        RateLimitTotal = 60,
        IsValidated = false
    };
}
