namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Represents a file change pending submission to GitHub via pull request.
/// </summary>
public sealed record PendingFileChange
{
    /// <summary>
    /// The VFS path of the modified file.
    /// </summary>
    public required string VfsPath { get; init; }

    /// <summary>
    /// The GitHub metadata for the file.
    /// </summary>
    public required GitHubFileMetadata Metadata { get; init; }

    /// <summary>
    /// The type of change.
    /// </summary>
    public required FileChangeType ChangeType { get; init; }

    /// <summary>
    /// The original content (before modification).
    /// </summary>
    public string? OriginalContent { get; init; }

    /// <summary>
    /// The new content (after modification).
    /// </summary>
    public string? NewContent { get; init; }

    /// <summary>
    /// When the change was made.
    /// </summary>
    public DateTimeOffset ChangedAt { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets a display-friendly summary of the change.
    /// </summary>
    public string Summary => ChangeType switch
    {
        FileChangeType.Modified => $"Modified: {Metadata.OriginalPath}",
        FileChangeType.Created => $"Added: {Metadata.OriginalPath}",
        FileChangeType.Deleted => $"Deleted: {Metadata.OriginalPath}",
        _ => Metadata.OriginalPath
    };

    /// <summary>
    /// Gets the number of lines added (approximate).
    /// </summary>
    public int LinesAdded
    {
        get
        {
            if (NewContent is null) return 0;
            if (OriginalContent is null) return NewContent.Split('\n').Length;

            var newLines = NewContent.Split('\n');
            var oldLines = OriginalContent.Split('\n');
            return Math.Max(0, newLines.Length - oldLines.Length);
        }
    }

    /// <summary>
    /// Gets the number of lines removed (approximate).
    /// </summary>
    public int LinesRemoved
    {
        get
        {
            if (OriginalContent is null) return 0;
            if (NewContent is null) return OriginalContent.Split('\n').Length;

            var newLines = NewContent.Split('\n');
            var oldLines = OriginalContent.Split('\n');
            return Math.Max(0, oldLines.Length - newLines.Length);
        }
    }
}

/// <summary>
/// The type of file change.
/// </summary>
public enum FileChangeType
{
    /// <summary>
    /// An existing file was modified.
    /// </summary>
    Modified,

    /// <summary>
    /// A new file was created.
    /// </summary>
    Created,

    /// <summary>
    /// A file was deleted.
    /// </summary>
    Deleted
}
