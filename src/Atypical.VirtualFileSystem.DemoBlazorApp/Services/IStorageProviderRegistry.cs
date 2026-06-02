using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Tracks the registered <see cref="IStorageProvider"/> instances and exposes the currently active one.
/// </summary>
public interface IStorageProviderRegistry
{
    /// <summary>All registered providers, in registration order.</summary>
    IReadOnlyList<IStorageProvider> Providers { get; }

    /// <summary>The currently active provider. Defaults to the first registered provider.</summary>
    IStorageProvider Active { get; }

    /// <summary>Switches the active provider to the one with the given <paramref name="providerId"/>.</summary>
    /// <exception cref="ArgumentException">Thrown when no provider with the given id is registered.</exception>
    void SetActive(string providerId);

    /// <summary>Raised whenever <see cref="Active"/> changes.</summary>
    event Action? ActiveProviderChanged;
}
