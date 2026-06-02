namespace Atypical.VirtualFileSystem.Ftp.Tests;

/// <summary>In-memory FTP server: a path->bytes map plus directory entries.</summary>
public sealed class FakeFtpConnection : IFtpConnection
{
    public Dictionary<string, byte[]> Files { get; } = new();
    public HashSet<string> Directories { get; } = new();
    public List<string> Uploaded { get; } = new();
    public List<string> Deleted { get; } = new();

    public Task ConnectAsync(CancellationToken ct) => Task.CompletedTask;
    public Task DisconnectAsync(CancellationToken ct) => Task.CompletedTask;

    public Task<IReadOnlyList<FtpRemoteItem>> ListAsync(string remoteDir, CancellationToken ct)
    {
        var dir = remoteDir.TrimEnd('/');
        IReadOnlyList<FtpRemoteItem> Children() =>
            Directories.Where(d => ParentOf(d) == dir)
                .Select(d => new FtpRemoteItem(d, true, 0, DateTime.UnixEpoch))
                .Concat(Files.Where(f => ParentOf(f.Key) == dir)
                    .Select(f => new FtpRemoteItem(f.Key, false, f.Value.Length, DateTime.UnixEpoch)))
                .ToList();
        return Task.FromResult(Children());
    }

    public Task<byte[]> DownloadAsync(string remotePath, CancellationToken ct) => Task.FromResult(Files[remotePath]);

    public Task UploadAsync(string remotePath, byte[] content, CancellationToken ct)
    {
        Files[remotePath] = content;
        Uploaded.Add(remotePath);
        return Task.CompletedTask;
    }

    public Task DeleteFileAsync(string remotePath, CancellationToken ct)
    {
        Files.Remove(remotePath);
        Deleted.Add(remotePath);
        return Task.CompletedTask;
    }

    private static string ParentOf(string path)
    {
        var p = path.TrimEnd('/');
        var idx = p.LastIndexOf('/');
        return idx <= 0 ? "" : p[..idx];
    }
}
