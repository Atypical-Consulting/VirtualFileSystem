namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Information required to create a pull request on GitHub.
/// </summary>
public sealed record PullRequestCreateInfo
{
    /// <summary>
    /// The repository owner (target repo for PR).
    /// </summary>
    public required string Owner { get; init; }

    /// <summary>
    /// The repository name.
    /// </summary>
    public required string Repository { get; init; }

    /// <summary>
    /// The title of the pull request.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// The body/description of the pull request (markdown supported).
    /// </summary>
    public string? Body { get; init; }

    /// <summary>
    /// The base branch to merge into (e.g., "main", "master").
    /// </summary>
    public required string BaseBranch { get; init; }

    /// <summary>
    /// The head branch containing the changes.
    /// </summary>
    public required string HeadBranch { get; init; }

    /// <summary>
    /// The file changes to include in the PR.
    /// </summary>
    public required IReadOnlyList<PendingFileChange> Changes { get; init; }

    /// <summary>
    /// Whether a fork is required (user doesn't have write access to target repo).
    /// </summary>
    public bool RequiresFork { get; init; }

    /// <summary>
    /// The fork owner (if forking is required).
    /// </summary>
    public string? ForkOwner { get; init; }

    /// <summary>
    /// Draft PR mode.
    /// </summary>
    public bool IsDraft { get; init; }

    /// <summary>
    /// Gets the full head reference (owner:branch) for cross-repo PRs.
    /// </summary>
    public string HeadRef => RequiresFork && ForkOwner is not null
        ? $"{ForkOwner}:{HeadBranch}"
        : HeadBranch;

    /// <summary>
    /// Generates a default branch name based on timestamp.
    /// </summary>
    public static string GenerateBranchName(string? prefix = null)
    {
        var timestamp = DateTimeOffset.UtcNow.ToString("yyyyMMdd-HHmmss");
        return string.IsNullOrEmpty(prefix)
            ? $"edit-{timestamp}"
            : $"{prefix}-{timestamp}";
    }

    /// <summary>
    /// Generates a default PR title based on changes.
    /// </summary>
    public static string GenerateTitle(IReadOnlyList<PendingFileChange> changes)
    {
        if (changes.Count == 0)
            return "Update files";

        if (changes.Count == 1)
        {
            var change = changes[0];
            var fileName = Path.GetFileName(change.Metadata.OriginalPath);
            return change.ChangeType switch
            {
                FileChangeType.Modified => $"Update {fileName}",
                FileChangeType.Created => $"Add {fileName}",
                FileChangeType.Deleted => $"Remove {fileName}",
                _ => $"Update {fileName}"
            };
        }

        var modified = changes.Count(c => c.ChangeType == FileChangeType.Modified);
        var created = changes.Count(c => c.ChangeType == FileChangeType.Created);
        var deleted = changes.Count(c => c.ChangeType == FileChangeType.Deleted);

        var parts = new List<string>();
        if (modified > 0) parts.Add($"update {modified} file{(modified > 1 ? "s" : "")}");
        if (created > 0) parts.Add($"add {created} file{(created > 1 ? "s" : "")}");
        if (deleted > 0) parts.Add($"remove {deleted} file{(deleted > 1 ? "s" : "")}");

        return string.Join(", ", parts).CapitalizeFirst();
    }
}

internal static class StringExtensions
{
    public static string CapitalizeFirst(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToUpperInvariant(input[0]) + input[1..];
    }
}
