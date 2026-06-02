namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>
/// Credentials-based authentication for the FTP provider. Validates credentials by opening
/// (and immediately closing) a connection, and exposes the resulting <see cref="FtpConnectionSettings"/>.
/// </summary>
public sealed class FtpProviderAuth : IStorageProviderAuth
{
    private readonly Func<FtpConnectionSettings, IFtpConnection> _factory;

    /// <summary>Creates the auth helper using the given connection factory.</summary>
    public FtpProviderAuth(Func<FtpConnectionSettings, IFtpConnection> factory) => _factory = factory;

    /// <inheritdoc />
    public AuthKind Kind => AuthKind.Credentials;

    /// <inheritdoc />
    public bool IsAuthenticated => Settings is not null;

    /// <inheritdoc />
    public ProviderAccountInfo? Account { get; private set; }

    /// <summary>The validated connection settings, or <c>null</c> when not authenticated.</summary>
    public FtpConnectionSettings? Settings { get; private set; }

    /// <inheritdoc />
    public event Action? AuthChanged;

    /// <inheritdoc />
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
            // Disconnect with a non-cancellable token so a cancelled request still closes cleanly.
            await conn.DisconnectAsync(CancellationToken.None);
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

    /// <inheritdoc />
    public Task SignOutAsync(CancellationToken ct = default)
    {
        Settings = null;
        Account = null;
        AuthChanged?.Invoke();
        return Task.CompletedTask;
    }
}
