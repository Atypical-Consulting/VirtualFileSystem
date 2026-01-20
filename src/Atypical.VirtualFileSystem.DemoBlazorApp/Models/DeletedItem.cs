using Atypical.VirtualFileSystem.Core;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Represents an item in the recycle bin
/// </summary>
public class DeletedItem
{
    public required string OriginalPath { get; init; }
    public required string Name { get; init; }
    public required bool IsDirectory { get; init; }
    public required DateTime DeletedAt { get; init; }
    public string? Content { get; init; }

    /// <summary>
    /// Unique identifier for the deleted item
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();
}
