namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>Maps a VFS file back to its remote origin so writes can target the right place.</summary>
public sealed record ProviderFileMetadata
{
    public required string ProviderId { get; init; }
    public required string ContainerKey { get; init; }   // repo "owner/name" or host+base path
    public required string RelativePath { get; init; }
    public required string VersionToken { get; init; }
    public DateTimeOffset ImportedAt { get; init; }
}
