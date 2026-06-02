namespace Atypical.VirtualFileSystem.Ftp;

public sealed record FtpConnectionSettings
{
    public required string Host { get; init; }
    public int Port { get; init; } = 21;
    public string? Username { get; init; }
    public string? Password { get; init; }
    public bool UseTls { get; init; }
}
