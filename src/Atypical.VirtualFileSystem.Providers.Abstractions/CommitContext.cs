namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>
/// Optional context for a write. Providers honor only what their capabilities allow
/// and ignore the rest (e.g. FTP ignores all of these).
/// </summary>
public sealed record CommitContext
{
    public static readonly CommitContext Empty = new();
    public string? Message { get; init; }
    public string? Branch { get; init; }
    public bool Draft { get; init; }
}
