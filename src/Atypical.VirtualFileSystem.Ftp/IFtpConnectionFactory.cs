namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>Creates <see cref="IFtpConnection"/> instances from connection settings.</summary>
public interface IFtpConnectionFactory
{
    /// <summary>Creates a new connection for the given settings.</summary>
    IFtpConnection Create(FtpConnectionSettings settings);
}
