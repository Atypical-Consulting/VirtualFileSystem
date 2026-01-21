namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Tracks the GitHub source information for imported files.
/// Used to enable PR creation when files are modified.
/// </summary>
public sealed record GitHubFileMetadata
{
    /// <summary>
    /// The repository owner (user or organization).
    /// </summary>
    public required string Owner { get; init; }

    /// <summary>
    /// The repository name.
    /// </summary>
    public required string Repository { get; init; }

    /// <summary>
    /// The branch the file was imported from.
    /// </summary>
    public required string Branch { get; init; }

    /// <summary>
    /// The original path of the file in the GitHub repository.
    /// </summary>
    public required string OriginalPath { get; init; }

    /// <summary>
    /// The blob SHA of the file content at import time.
    /// Used for conflict detection and API updates.
    /// </summary>
    public required string BlobSha { get; init; }

    /// <summary>
    /// The commit SHA when the file was imported.
    /// </summary>
    public string? CommitSha { get; init; }

    /// <summary>
    /// When the file was imported.
    /// </summary>
    public DateTimeOffset ImportedAt { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets a unique key for grouping files by repository.
    /// </summary>
    public string RepositoryKey => $"{Owner}/{Repository}";

    /// <summary>
    /// Gets the GitHub URL to view the file.
    /// </summary>
    public string GitHubUrl => $"https://github.com/{Owner}/{Repository}/blob/{Branch}/{OriginalPath}";

    /// <summary>
    /// Gets the GitHub URL to view the repository.
    /// </summary>
    public string RepositoryUrl => $"https://github.com/{Owner}/{Repository}";
}
