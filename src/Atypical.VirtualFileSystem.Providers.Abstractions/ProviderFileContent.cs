namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>The content of a single remote file plus an opaque version token (ETag/SHA/mtime).</summary>
public sealed record ProviderFileContent(byte[] Content, string VersionToken, bool IsBinary);
