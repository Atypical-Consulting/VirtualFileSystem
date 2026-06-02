// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.GitHub.Providers;

/// <summary>
/// An <see cref="IStorageProvider"/> that wraps the existing <see cref="IGitHubRepositoryLoader"/>
/// and <see cref="IGitHubWriteService"/> behind the neutral provider abstraction.
/// All import logic is delegated to the loader; no loader/write-service logic is duplicated here.
/// </summary>
/// <remarks>
/// Design note: GitHub's write orchestration (fork→branch→commit→PR) already lives in the
/// Blazor <c>GitHubPendingChangesService</c>. To avoid duplicating it, the provider's
/// <see cref="WriteChangesAsync"/> throws for now and the app's <c>StoragePendingChangesService</c>
/// calls the GitHub write service directly when the active provider is GitHub.
/// This is a deliberate, documented seam — revisit when extracting writes fully in a later milestone.
/// </remarks>
public sealed class GitHubStorageProvider : IStorageProvider
{
    private readonly IGitHubRepositoryLoader _loader;
    private readonly IGitHubWriteService _writeService;
    private readonly GitHubProviderAuth _auth;

    /// <summary>
    /// Initialises a new <see cref="GitHubStorageProvider"/>.
    /// </summary>
    /// <param name="loader">The repository loader.</param>
    /// <param name="writeService">The write service (used for future write orchestration).</param>
    /// <param name="auth">The token-based auth handler.</param>
    public GitHubStorageProvider(IGitHubRepositoryLoader loader, IGitHubWriteService writeService, GitHubProviderAuth auth)
    {
        _loader = loader;
        _writeService = writeService;
        _auth = auth;
    }

    /// <inheritdoc />
    public string Id => "github";

    /// <inheritdoc />
    public string DisplayName => "GitHub";

    /// <inheritdoc />
    public IStorageProviderAuth Auth => _auth;

    /// <inheritdoc />
    public ProviderCapabilities Capabilities => new()
    {
        SupportsBranches = true,
        SupportsPullRequests = true,
        SupportsFork = true,
        SupportsAtomicMultiFileCommit = true,
        SupportsVersioning = true,
        AuthKind = AuthKind.Token
    };

    /// <inheritdoc />
    /// <remarks>
    /// <paramref name="options"/>.<see cref="ProviderLoadOptions.RemoteRoot"/> must be in the form
    /// <c>owner/repo</c> or <c>owner/repo/subpath</c>. The sub-path (if any) is forwarded to the
    /// loader as the <see cref="GitHubLoaderOptions.SubPath"/> filter so that only files under that
    /// path are imported. The VFS target root defaults to <c>/</c>.
    /// </remarks>
    public async Task<ProviderLoadResult> ImportAsync(
        IVirtualFileSystem vfs,
        ProviderLoadOptions options,
        CancellationToken cancellationToken = default)
    {
        var (owner, repo, subPath) = ParseRemoteRoot(options.RemoteRoot);
        var ghOptions = GitHubProviderAdapters.ToGitHubLoaderOptions(
            options with { RemoteRoot = subPath },
            _auth.Token);
        var result = await _loader.LoadRepositoryAsync(vfs, owner, repo, ghOptions, cancellationToken);
        return GitHubProviderAdapters.ToProviderLoadResult(result);
    }

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">
    /// Always thrown — single-file reads are performed during import for GitHub and are not
    /// exposed through the provider surface in the current milestone.
    /// </exception>
    public Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken cancellationToken = default)
        => throw new NotSupportedException(
            "Single-file read is performed during import for GitHub; not used by the current UI.");

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">
    /// Always thrown — GitHub writes are orchestrated by <c>StoragePendingChangesService</c> in Task 4.x.
    /// </exception>
    public Task<ProviderWriteResult> WriteChangesAsync(
        IReadOnlyList<ProviderFileChange> changes,
        CommitContext context,
        CancellationToken cancellationToken = default)
        => throw new NotSupportedException(
            "GitHub writes are orchestrated by StoragePendingChangesService in Task 4.x.");

    /// <inheritdoc />
    public Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_auth.Account ?? ProviderAccountInfo.Anonymous);

    /// <summary>
    /// Parses a GitHub remote root string of the form <c>owner/repo[/subpath]</c>.
    /// </summary>
    private static (string owner, string repo, string? subPath) ParseRemoteRoot(string? remoteRoot)
    {
        var parts = (remoteRoot ?? string.Empty).Trim('/').Split('/', 3);
        if (parts.Length < 2 || string.IsNullOrEmpty(parts[0]) || string.IsNullOrEmpty(parts[1]))
            throw new ArgumentException(
                "GitHub RemoteRoot must be 'owner/repo[/subpath]'.", nameof(remoteRoot));
        return (parts[0], parts[1], parts.Length == 3 ? parts[2] : null);
    }
}
