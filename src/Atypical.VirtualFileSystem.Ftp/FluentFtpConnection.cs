using FluentFTP;

namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>
/// Wraps <see cref="AsyncFtpClient"/> from FluentFTP (v54.x).
/// Recursive listing is handled by <see cref="FtpStorageProvider"/>; this lists one directory at a time.
/// </summary>
public sealed class FluentFtpConnection : IFtpConnection, IAsyncDisposable
{
    private readonly AsyncFtpClient _client;

    public FluentFtpConnection(FtpConnectionSettings settings)
    {
        _client = new AsyncFtpClient(settings.Host, settings.Username, settings.Password, settings.Port);
        _client.Config.EncryptionMode = settings.UseTls ? FtpEncryptionMode.Explicit : FtpEncryptionMode.None;
        // For demo purposes, accept any certificate when TLS is enabled; document for production hardening.
        _client.Config.ValidateAnyCertificate = settings.UseTls;
    }

    public Task ConnectAsync(CancellationToken ct) => _client.Connect(ct);
    public Task DisconnectAsync(CancellationToken ct) => _client.Disconnect(ct);

    public async Task<IReadOnlyList<FtpRemoteItem>> ListAsync(string remoteDir, CancellationToken ct)
    {
        // GetListing(string path, CancellationToken token) → Task<FtpListItem[]>
        var items = await _client.GetListing(remoteDir, ct);
        return items.Select(i => new FtpRemoteItem(
            i.FullName,
            i.Type == FtpObjectType.Directory,
            i.Size,
            i.Modified.ToUniversalTime())).ToList();
    }

    public Task<byte[]> DownloadAsync(string remotePath, CancellationToken ct)
        // DownloadBytes(string remotePath, CancellationToken token) → Task<byte[]>
        => _client.DownloadBytes(remotePath, ct);

    public async Task UploadAsync(string remotePath, byte[] content, CancellationToken ct)
        // UploadBytes(byte[] fileData, string remotePath, FtpRemoteExists existsMode, bool createRemoteDir,
        //             IProgress<FtpProgress> progress, CancellationToken token) → Task<FtpStatus>
        => await _client.UploadBytes(content, remotePath, FtpRemoteExists.Overwrite, createRemoteDir: true, progress: null, token: ct);

    public Task DeleteFileAsync(string remotePath, CancellationToken ct)
        => _client.DeleteFile(remotePath, ct);

    public async ValueTask DisposeAsync() => await _client.DisposeAsync();
}
