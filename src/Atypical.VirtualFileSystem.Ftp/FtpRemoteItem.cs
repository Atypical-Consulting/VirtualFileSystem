namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>A single entry returned by an FTP directory listing.</summary>
/// <param name="FullPath">The absolute remote path of the entry.</param>
/// <param name="IsDirectory">Whether the entry is a directory.</param>
/// <param name="SizeBytes">The size of the entry in bytes (0 for directories).</param>
/// <param name="LastModifiedUtc">The last-modified timestamp, in UTC.</param>
public sealed record FtpRemoteItem(string FullPath, bool IsDirectory, long SizeBytes, DateTimeOffset LastModifiedUtc);
