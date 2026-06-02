namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public enum ProviderSkipReason { TooLarge, BlockedExtension, NotMatchingGlob, LoadError }

public sealed record ProviderSkippedFile(string RemotePath, ProviderSkipReason Reason, long SizeBytes, string? Message);

public sealed record ProviderLoadResult
{
    public required string RemoteRoot { get; init; }
    public int FilesLoaded { get; init; }
    public int DirectoriesCreated { get; init; }
    public long TotalBytes { get; init; }
    public IReadOnlyList<ProviderSkippedFile> Skipped { get; init; } = [];
    public TimeSpan Duration { get; init; }
}
