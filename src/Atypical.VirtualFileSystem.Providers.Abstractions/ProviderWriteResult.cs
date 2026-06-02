namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public sealed record ProviderFileWriteResult(string RemotePath, bool Success, string? Message);

public sealed record ProviderWriteResult
{
    public required bool Success { get; init; }
    public IReadOnlyList<ProviderFileWriteResult> FileResults { get; init; } = [];
    /// <summary>For PR-capable providers, the URL of the created pull request (else null).</summary>
    public string? PullRequestUrl { get; init; }
    public string? Message { get; init; }
}
