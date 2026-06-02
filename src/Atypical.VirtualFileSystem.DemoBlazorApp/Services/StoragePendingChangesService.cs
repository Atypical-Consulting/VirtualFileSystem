using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Provider-neutral "submit changes" service. It exposes the active provider's submit
/// capability and routes a set of <see cref="ProviderFileChange"/> to the active provider's
/// <see cref="IStorageProvider.WriteChangesAsync"/>.
/// </summary>
/// <remarks>
/// For pull-request-capable providers (GitHub) the existing
/// <see cref="GitHubPendingChangesService"/> fork-&gt;branch-&gt;commit-&gt;PR orchestration is the
/// real submit path used by the UI; this service is used for non-PR providers (e.g. FTP),
/// which upload changes directly. The capability flag lets the UI decide which path to show.
/// </remarks>
public sealed class StoragePendingChangesService
{
    private readonly IStorageProviderRegistry _registry;

    public StoragePendingChangesService(IStorageProviderRegistry registry)
        => _registry = registry;

    /// <summary>True when the active provider supports pull requests (GitHub); false for FTP.</summary>
    public bool SupportsPullRequests => _registry.Active.Capabilities.SupportsPullRequests;

    /// <summary>The active provider's display name, for UI labelling.</summary>
    public string ActiveProviderName => _registry.Active.DisplayName;

    /// <summary>
    /// Submits <paramref name="changes"/> to the active provider. For non-PR providers this
    /// uploads/deletes files directly and returns a per-file <see cref="ProviderWriteResult"/>.
    /// </summary>
    public Task<ProviderWriteResult> SubmitAsync(
        IReadOnlyList<ProviderFileChange> changes,
        CommitContext context,
        CancellationToken cancellationToken = default)
    {
        if (SupportsPullRequests)
            throw new InvalidOperationException(
                "Use the PR flow (GitHubPendingChangesService) for pull-request-capable providers.");

        return _registry.Active.WriteChangesAsync(changes, context, cancellationToken);
    }
}
