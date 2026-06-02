using Atypical.VirtualFileSystem.Providers.Abstractions;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Persists per-provider <see cref="AuthRequest"/> payloads in encrypted browser local storage
/// (via <see cref="ProtectedLocalStorage"/>). All access is wrapped in try/catch so that the
/// service is prerender-safe (JS interop is unavailable during static prerendering).
/// </summary>
public sealed class StorageCredentialStore
{
    private readonly ProtectedLocalStorage _storage;

    public StorageCredentialStore(ProtectedLocalStorage storage) => _storage = storage;

    private static string Key(string providerId) => $"provider_creds_{providerId}";

    /// <summary>Saves the credentials for <paramref name="providerId"/> to encrypted local storage.</summary>
    public async Task SaveAsync(string providerId, AuthRequest request)
    {
        try
        {
            await _storage.SetAsync(Key(providerId), request);
        }
        catch
        {
            // Silently fail: JS interop unavailable during prerender, or storage is locked.
        }
    }

    /// <summary>Loads previously saved credentials for <paramref name="providerId"/>, or null if none.</summary>
    public async Task<AuthRequest?> LoadAsync(string providerId)
    {
        try
        {
            var result = await _storage.GetAsync<AuthRequest>(Key(providerId));
            return result.Success ? result.Value : null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>Removes stored credentials for <paramref name="providerId"/>.</summary>
    public async Task ClearAsync(string providerId)
    {
        try
        {
            await _storage.DeleteAsync(Key(providerId));
        }
        catch
        {
            // Silently fail: unavailable during prerender.
        }
    }
}
