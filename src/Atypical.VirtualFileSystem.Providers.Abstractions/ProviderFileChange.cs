namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public enum ChangeKind { Add, Update, Delete }

public sealed record ProviderFileChange
{
    public required string RemotePath { get; init; }
    public required ChangeKind Kind { get; init; }
    public byte[]? Content { get; init; }
    public string? BaseVersionToken { get; init; }
}
