namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>Identity and quota/limit info for the authenticated account.</summary>
public sealed record ProviderAccountInfo
{
    public static readonly ProviderAccountInfo Anonymous = new() { DisplayName = "Anonymous" };

    public required string DisplayName { get; init; }
    public long? QuotaUsedBytes { get; init; }
    public long? QuotaTotalBytes { get; init; }
    public int? RateLimitRemaining { get; init; }
    public int? RateLimitTotal { get; init; }
    public DateTimeOffset? RateLimitReset { get; init; }
}
