namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>
/// Handles authentication for a storage provider, exposing the current authenticated
/// account and notifying subscribers when the authentication state changes.
/// </summary>
public interface IStorageProviderAuth
{
    /// <summary>The kind of authentication this provider uses (token, credentials, OAuth).</summary>
    AuthKind Kind { get; }

    /// <summary>Whether the provider currently has a valid authenticated session.</summary>
    bool IsAuthenticated { get; }

    /// <summary>The authenticated account, or <see langword="null"/> when not authenticated.</summary>
    ProviderAccountInfo? Account { get; }

    /// <summary>
    /// Attempts to authenticate using the supplied request payload.
    /// </summary>
    /// <param name="request">The kind-specific authentication payload.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result indicating success or failure, with the account on success.</returns>
    Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears the current authenticated session.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    Task SignOutAsync(CancellationToken cancellationToken = default);

    /// <summary>Raised whenever the authentication state changes (sign-in or sign-out).</summary>
    event Action? AuthChanged;
}
