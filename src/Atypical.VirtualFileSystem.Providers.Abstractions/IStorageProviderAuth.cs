namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public interface IStorageProviderAuth
{
    AuthKind Kind { get; }
    bool IsAuthenticated { get; }
    ProviderAccountInfo? Account { get; }
    Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken cancellationToken = default);
    Task SignOutAsync(CancellationToken cancellationToken = default);
    event Action? AuthChanged;
}
