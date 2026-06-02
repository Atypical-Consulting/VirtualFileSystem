namespace Atypical.VirtualFileSystem.Ftp;

public sealed record FtpRemoteItem(string FullPath, bool IsDirectory, long SizeBytes, DateTime LastModifiedUtc);

/// <summary>Minimal async FTP surface used by FtpStorageProvider; backed by FluentFTP in production.</summary>
public interface IFtpConnection
{
    Task ConnectAsync(CancellationToken ct);
    Task DisconnectAsync(CancellationToken ct);
    Task<IReadOnlyList<FtpRemoteItem>> ListAsync(string remoteDir, CancellationToken ct);
    Task<byte[]> DownloadAsync(string remotePath, CancellationToken ct);
    Task UploadAsync(string remotePath, byte[] content, CancellationToken ct);
    Task DeleteFileAsync(string remotePath, CancellationToken ct);
}
