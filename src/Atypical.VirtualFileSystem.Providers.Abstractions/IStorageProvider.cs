namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>A pluggable storage backend that can import into, and write back from, a VFS.</summary>
public interface IStorageProvider
{
    string Id { get; }
    string DisplayName { get; }
    ProviderCapabilities Capabilities { get; }
    IStorageProviderAuth Auth { get; }

    Task<ProviderLoadResult> ImportAsync(IVirtualFileSystem vfs, ProviderLoadOptions options, CancellationToken cancellationToken = default);
    Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken cancellationToken = default);
    Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken cancellationToken = default);
    Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken cancellationToken = default);
}
