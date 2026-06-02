using System.Diagnostics;

namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>
/// A read+write storage provider over FTP/FTPS (backed by FluentFTP through the <see cref="IFtpConnection"/> seam).
/// </summary>
public sealed class FtpStorageProvider : IStorageProvider
{
    private readonly Func<FtpConnectionSettings, IFtpConnection> _connectionFactory;
    private readonly FtpProviderAuth _auth;

    /// <summary>Creates the provider using the given connection factory.</summary>
    public FtpStorageProvider(Func<FtpConnectionSettings, IFtpConnection> connectionFactory)
    {
        _connectionFactory = connectionFactory;
        _auth = new FtpProviderAuth(connectionFactory);
    }

    /// <inheritdoc />
    public string Id => "ftp";

    /// <inheritdoc />
    public string DisplayName => "FTP";

    /// <inheritdoc />
    public IStorageProviderAuth Auth => _auth;

    /// <inheritdoc />
    public ProviderCapabilities Capabilities => new() { AuthKind = AuthKind.Credentials };

    /// <inheritdoc />
    public async Task<ProviderLoadResult> ImportAsync(IVirtualFileSystem vfs, ProviderLoadOptions options, CancellationToken ct = default)
    {
        var settings = _auth.Settings ?? throw new InvalidOperationException("FTP provider is not authenticated.");
        var root = string.IsNullOrWhiteSpace(options.RemoteRoot) ? "/" : options.RemoteRoot!;
        var sw = Stopwatch.StartNew();
        var skipped = new List<ProviderSkippedFile>();
        int files = 0, dirs = 0;
        long bytes = 0;

        var conn = _connectionFactory(settings);
        try
        {
            await conn.ConnectAsync(ct);

            var queue = new Queue<string>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                ct.ThrowIfCancellationRequested();
                var current = queue.Dequeue();
                foreach (var item in await conn.ListAsync(current, ct))
                {
                    if (item.IsDirectory)
                    {
                        queue.Enqueue(item.FullPath);
                        dirs++;

                        // Materialize the directory node so empty directories appear in the VFS.
                        var dirPath = ToVfsPath(item.FullPath);
                        if (!vfs.Index.ContainsKey(new VFSDirectoryPath(dirPath)))
                            vfs.CreateDirectory(dirPath);

                        continue;
                    }

                    if (item.SizeBytes > options.MaxFileSizeBytes)
                    {
                        skipped.Add(new(item.FullPath, ProviderSkipReason.TooLarge, item.SizeBytes, null));
                        continue;
                    }

                    try
                    {
                        var data = await conn.DownloadAsync(item.FullPath, ct);
                        var vfsPath = ToVfsPath(item.FullPath);
                        var versionToken = $"{item.LastModifiedUtc:O}:{item.SizeBytes}";
                        if (IsBinary(item.FullPath))
                            vfs.CreateBinaryFileWithDirectories(vfsPath, data);
                        else
                            vfs.CreateFileWithDirectories(vfsPath, System.Text.Encoding.UTF8.GetString(data));
                        options.MetadataCallback?.Invoke(vfsPath, item.FullPath, versionToken);
                        files++;
                        bytes += data.Length;
                        options.ProgressCallback?.Invoke(files, item.FullPath);
                    }
                    catch (Exception ex)
                    {
                        skipped.Add(new(item.FullPath, ProviderSkipReason.LoadError, item.SizeBytes, ex.Message));
                    }
                }
            }
        }
        finally
        {
            await CloseAsync(conn);
        }

        sw.Stop();
        return new ProviderLoadResult
        {
            RemoteRoot = root,
            FilesLoaded = files,
            DirectoriesCreated = dirs,
            TotalBytes = bytes,
            Skipped = skipped,
            Duration = sw.Elapsed
        };
    }

    /// <inheritdoc />
    public async Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken ct = default)
    {
        var settings = _auth.Settings ?? throw new InvalidOperationException("FTP provider is not authenticated.");
        var conn = _connectionFactory(settings);
        try
        {
            await conn.ConnectAsync(ct);
            var data = await conn.DownloadAsync(remotePath, ct);
            return new ProviderFileContent(data, VersionToken: string.Empty, IsBinary: IsBinary(remotePath));
        }
        finally
        {
            await CloseAsync(conn);
        }
    }

    /// <inheritdoc />
    public async Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken ct = default)
    {
        var settings = _auth.Settings ?? throw new InvalidOperationException("FTP provider is not authenticated.");
        var fileResults = new List<ProviderFileWriteResult>();

        var conn = _connectionFactory(settings);
        try
        {
            await conn.ConnectAsync(ct);
            foreach (var change in changes)
            {
                ct.ThrowIfCancellationRequested();
                try
                {
                    if (change.Kind == ChangeKind.Delete)
                        await conn.DeleteFileAsync(change.RemotePath, ct);
                    else
                        await conn.UploadAsync(change.RemotePath, change.Content ?? [], ct);
                    fileResults.Add(new(change.RemotePath, true, null));
                }
                catch (Exception ex)
                {
                    fileResults.Add(new(change.RemotePath, false, ex.Message));
                }
            }
        }
        finally
        {
            await CloseAsync(conn);
        }

        return new ProviderWriteResult
        {
            Success = fileResults.All(r => r.Success),
            FileResults = fileResults
        };
    }

    /// <inheritdoc />
    public Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken ct = default)
        => Task.FromResult(_auth.Account ?? ProviderAccountInfo.Anonymous);

    /// <summary>
    /// Disconnects (best-effort, non-cancellable) and always disposes the connection so the
    /// underlying socket is never leaked, even if disconnect throws or the operation was cancelled.
    /// </summary>
    private static async Task CloseAsync(IFtpConnection conn)
    {
        try
        {
            await conn.DisconnectAsync(CancellationToken.None);
        }
        catch
        {
            // Ignore disconnect failures; disposal below still releases the socket.
        }
        finally
        {
            if (conn is IAsyncDisposable d)
                await d.DisposeAsync();
        }
    }

    // Map an absolute remote path (e.g. "/data/sub/a.txt") to a VFS-relative path ("data/sub/a.txt").
    private static string ToVfsPath(string remotePath) => remotePath.TrimStart('/');

    private static bool IsBinary(string path)
    {
        var ext = Path.GetExtension(path).ToLowerInvariant();
        return ext is ".png" or ".jpg" or ".jpeg" or ".gif" or ".pdf" or ".zip" or ".exe" or ".dll" or ".bin";
    }
}
