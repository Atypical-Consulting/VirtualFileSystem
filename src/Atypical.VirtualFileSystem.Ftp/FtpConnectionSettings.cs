namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>
/// Connection parameters used to open an FTP/FTPS session.
/// </summary>
public sealed record FtpConnectionSettings
{
    /// <summary>The FTP server host name or IP address.</summary>
    public required string Host { get; init; }

    /// <summary>The FTP control-channel port. Defaults to 21.</summary>
    public int Port { get; init; } = 21;

    /// <summary>The user name used to authenticate, or <c>null</c> for anonymous access.</summary>
    public string? Username { get; init; }

    /// <summary>The password used to authenticate, or <c>null</c> for anonymous access.</summary>
    public string? Password { get; init; }

    /// <summary>When <c>true</c>, connects using explicit FTPS (TLS).</summary>
    public bool UseTls { get; init; }

    /// <summary>
    /// When <c>true</c>, accepts any server certificate without validation (TLS only).
    /// Defaults to <c>false</c>; enable only for trusted test servers.
    /// </summary>
    public bool AllowInvalidCertificate { get; init; }
}
