using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Provider-neutral import service that delegates <see cref="ImportAsync"/> to whichever
/// <see cref="IStorageProvider"/> is currently active in the <see cref="IStorageProviderRegistry"/>.
/// Exposes <see cref="IsImporting"/> and <see cref="OnStateChanged"/> so UI components can
/// react to import progress without being coupled to a specific provider.
/// </summary>
public sealed class StorageImportService
{
    private readonly IStorageProviderRegistry _registry;
    private readonly IVirtualFileSystem _vfs;

    public StorageImportService(IStorageProviderRegistry registry, IVirtualFileSystem vfs)
    {
        _registry = registry;
        _vfs = vfs;
    }

    /// <summary>Raised when <see cref="IsImporting"/> changes (import started or finished).</summary>
    public event Action? OnStateChanged;

    /// <summary>True while an import is in progress.</summary>
    public bool IsImporting { get; private set; }

    /// <summary>
    /// Imports into the VFS using the active provider and the supplied <paramref name="options"/>.
    /// </summary>
    public async Task<ProviderLoadResult> ImportAsync(ProviderLoadOptions options, CancellationToken ct = default)
    {
        IsImporting = true;
        OnStateChanged?.Invoke();
        try
        {
            return await _registry.Active.ImportAsync(_vfs, options, ct);
        }
        finally
        {
            IsImporting = false;
            OnStateChanged?.Invoke();
        }
    }
}
