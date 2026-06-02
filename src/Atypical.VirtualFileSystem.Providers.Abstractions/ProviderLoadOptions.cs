namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public enum ProviderLoadingStrategy { Eager, Lazy, MetadataOnly }

/// <summary>Options controlling an import into the VFS.</summary>
public sealed record ProviderLoadOptions
{
    /// <summary>Remote sub-path to import from (provider-specific root if null/empty).</summary>
    public string? RemoteRoot { get; init; }
    public ProviderLoadingStrategy Strategy { get; init; } = ProviderLoadingStrategy.Eager;
    public long MaxFileSizeBytes { get; init; } = 10 * 1024 * 1024;
    public IReadOnlyList<string>? AllowedExtensions { get; init; }
    public IReadOnlyList<string>? BlockedExtensions { get; init; }
    public string? GlobPattern { get; init; }
    /// <summary>Invoked as each file is loaded: (vfsPath, remotePath, versionToken).</summary>
    public Action<string, string, string>? MetadataCallback { get; init; }
    /// <summary>Invoked for progress: (filesLoaded, message).</summary>
    public Action<int, string>? ProgressCallback { get; init; }
}
