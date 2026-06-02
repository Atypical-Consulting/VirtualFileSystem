namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>Describes which optional operations a storage provider supports.</summary>
public sealed record ProviderCapabilities
{
    public bool SupportsBranches { get; init; }
    public bool SupportsPullRequests { get; init; }
    public bool SupportsFork { get; init; }
    public bool SupportsAtomicMultiFileCommit { get; init; }
    public bool SupportsVersioning { get; init; }
    public AuthKind AuthKind { get; init; }
}
