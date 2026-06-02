namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>The production <see cref="IFtpConnectionFactory"/> that creates FluentFTP-backed connections.</summary>
public sealed class FluentFtpConnectionFactory : IFtpConnectionFactory
{
    /// <inheritdoc />
    public IFtpConnection Create(FtpConnectionSettings settings) => new FluentFtpConnection(settings);
}
