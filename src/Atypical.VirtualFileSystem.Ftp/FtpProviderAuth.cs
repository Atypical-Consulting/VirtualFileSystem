namespace Atypical.VirtualFileSystem.Ftp;

public sealed class FtpProviderAuth : IStorageProviderAuth
{
    private readonly Func<FtpConnectionSettings, IFtpConnection> _factory;

    public FtpProviderAuth(Func<FtpConnectionSettings, IFtpConnection> factory) => _factory = factory;

    public AuthKind Kind => AuthKind.Credentials;
    public bool IsAuthenticated => Settings is not null;
    public ProviderAccountInfo? Account { get; private set; }
    public FtpConnectionSettings? Settings { get; private set; }
    public event Action? AuthChanged;

    public async Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.Host))
            return new AuthResult(false, "Host is required.", null);

        var settings = new FtpConnectionSettings
        {
            Host = request.Host,
            Port = request.Port == 0 ? 21 : request.Port,
            Username = request.Username,
            Password = request.Password,
            UseTls = request.UseTls
        };
        var conn = _factory(settings);
        try
        {
            await conn.ConnectAsync(ct);
            await conn.DisconnectAsync(ct);
        }
        catch (Exception ex)
        {
            return new AuthResult(false, $"Connection failed: {ex.Message}", null);
        }
        finally
        {
            if (conn is IAsyncDisposable d) await d.DisposeAsync();
        }

        Settings = settings;
        Account = new ProviderAccountInfo { DisplayName = $"{request.Username}@{request.Host}" };
        AuthChanged?.Invoke();
        return new AuthResult(true, null, Account);
    }

    public Task SignOutAsync(CancellationToken ct = default)
    {
        Settings = null;
        Account = null;
        AuthChanged?.Invoke();
        return Task.CompletedTask;
    }
}
