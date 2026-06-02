using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Default implementation of <see cref="IStorageProviderRegistry"/>.
/// Scoped per Blazor Server circuit; the active provider defaults to the first registered provider.
/// </summary>
public sealed class StorageProviderRegistry : IStorageProviderRegistry
{
    private IStorageProvider _active;

    /// <inheritdoc />
    public IReadOnlyList<IStorageProvider> Providers { get; }

    /// <inheritdoc />
    public event Action? OnActiveProviderChanged;

    /// <summary>
    /// Creates a registry from all <see cref="IStorageProvider"/> instances registered in DI.
    /// </summary>
    /// <param name="providers">The full set of registered providers (injected as IEnumerable).</param>
    /// <exception cref="InvalidOperationException">Thrown when the provider list is empty.</exception>
    public StorageProviderRegistry(IEnumerable<IStorageProvider> providers)
    {
        Providers = providers.ToList();
        if (Providers.Count == 0)
            throw new InvalidOperationException("No storage providers registered.");
        _active = Providers[0];
    }

    /// <inheritdoc />
    public IStorageProvider Active => _active;

    /// <inheritdoc />
    public void SetActive(string providerId)
    {
        var match = Providers.FirstOrDefault(p => p.Id == providerId)
            ?? throw new ArgumentException($"Unknown provider '{providerId}'.", nameof(providerId));

        if (!ReferenceEquals(match, _active))
        {
            _active = match;
            OnActiveProviderChanged?.Invoke();
        }
    }
}
