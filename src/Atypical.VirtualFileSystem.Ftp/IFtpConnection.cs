namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>Minimal async FTP surface used by <see cref="FtpStorageProvider"/>; backed by FluentFTP in production.</summary>
public interface IFtpConnection
{
    /// <summary>Opens the FTP control connection.</summary>
    Task ConnectAsync(CancellationToken ct);

    /// <summary>Closes the FTP control connection.</summary>
    Task DisconnectAsync(CancellationToken ct);

    /// <summary>Lists the immediate children (files and directories) of the given remote directory.</summary>
    Task<IReadOnlyList<FtpRemoteItem>> ListAsync(string remoteDir, CancellationToken ct);

    /// <summary>Downloads the full contents of a remote file.</summary>
    Task<byte[]> DownloadAsync(string remotePath, CancellationToken ct);

    /// <summary>Uploads (overwriting) the given content to a remote path, creating parent directories as needed.</summary>
    Task UploadAsync(string remotePath, byte[] content, CancellationToken ct);

    /// <summary>Deletes a remote file.</summary>
    Task DeleteFileAsync(string remotePath, CancellationToken ct);
}
