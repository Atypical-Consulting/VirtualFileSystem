namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>A pluggable storage backend that can import into, and write back from, a VFS.</summary>
public interface IStorageProvider
{
    /// <summary>A stable, lowercase identifier for the provider (e.g. "github", "ftp").</summary>
    string Id { get; }

    /// <summary>A human-readable name for the provider, suitable for display in a UI.</summary>
    string DisplayName { get; }

    /// <summary>Describes which optional operations this provider supports.</summary>
    ProviderCapabilities Capabilities { get; }

    /// <summary>The authentication handler for this provider.</summary>
    IStorageProviderAuth Auth { get; }

    /// <summary>
    /// Imports remote files into the given Virtual File System according to the supplied options.
    /// </summary>
    /// <param name="vfs">The Virtual File System to import the remote files into.</param>
    /// <param name="options">Options controlling the import (root, strategy, filters, callbacks).</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result summarizing the files loaded, directories created, and any skipped files.</returns>
    Task<ProviderLoadResult> ImportAsync(IVirtualFileSystem vfs, ProviderLoadOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reads the content of a single remote file.
    /// </summary>
    /// <param name="remotePath">The provider-specific path of the file to read.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>The file content along with an opaque version token.</returns>
    Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes a batch of file changes (adds, updates, deletes) back to the remote storage.
    /// </summary>
    /// <param name="changes">The changes to apply.</param>
    /// <param name="context">Optional commit context; providers honor only what their capabilities allow.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result reporting overall success and per-file outcomes.</returns>
    Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns identity and quota/limit information for the authenticated account.
    /// When the provider is not authenticated this returns <see cref="ProviderAccountInfo.Anonymous"/>;
    /// it never returns <see langword="null"/> and does not throw for the unauthenticated case.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>The authenticated account's info, or <see cref="ProviderAccountInfo.Anonymous"/> when not authenticated.</returns>
    Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken cancellationToken = default);
}
