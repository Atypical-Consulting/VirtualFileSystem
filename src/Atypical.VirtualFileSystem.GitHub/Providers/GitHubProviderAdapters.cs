// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.GitHub.Providers;

public static class GitHubProviderAdapters
{
    /// <summary>
    /// Maps a neutral <see cref="ProviderLoadOptions"/> to a <see cref="GitHubLoaderOptions"/>.
    /// </summary>
    /// <param name="o">The neutral provider load options.</param>
    /// <param name="accessToken">The GitHub personal access token.</param>
    public static GitHubLoaderOptions ToGitHubLoaderOptions(ProviderLoadOptions o, string? accessToken)
        => new(
            AccessToken: accessToken,
            // RemoteRoot is the REMOTE sub-path to import FROM, so it maps to the loader's
            // SubPath (a remote filter). TargetPath is the VFS DESTINATION root and is left
            // at the loader's default ("/"), preserving the original load layout.
            SubPath: o.RemoteRoot,
            MaxFileSize: o.MaxFileSizeBytes,
            Strategy: o.Strategy switch
            {
                ProviderLoadingStrategy.Lazy => GitHubLoadingStrategy.Lazy,
                ProviderLoadingStrategy.MetadataOnly => GitHubLoadingStrategy.MetadataOnly,
                _ => GitHubLoadingStrategy.Eager
            },
            IncludeExtensions: o.AllowedExtensions is null
                ? null
                : new HashSet<string>(o.AllowedExtensions, StringComparer.OrdinalIgnoreCase),
            ExcludeExtensions: o.BlockedExtensions is null
                ? null
                : new HashSet<string>(o.BlockedExtensions, StringComparer.OrdinalIgnoreCase),
            // NOTE: GlobPattern is not forwarded this milestone (GitHub exposes only exclude patterns
            // via ExcludePatterns; include-glob support is a follow-on). The neutral GlobPattern is an
            // include-style filter, so mapping it onto the exclude-style ExcludePatterns would invert
            // its meaning. Dropping it is intentional rather than mismapping it.
            MetadataCallback: o.MetadataCallback,
            ProgressCallback: o.ProgressCallback is null
                ? null
                : (current, total, path) => o.ProgressCallback(current, path)
        );

    /// <summary>
    /// Maps a <see cref="GitHubLoadResult"/> to a neutral <see cref="ProviderLoadResult"/>.
    /// </summary>
    /// <param name="r">The GitHub load result.</param>
    /// <param name="requestedRemoteRoot">
    /// The originally requested remote root (e.g. <c>owner/repo[/subpath]</c>) echoed back on the
    /// result. The GitHub result only carries the VFS <c>TargetPath</c> (usually <c>/</c>), so the
    /// neutral <see cref="ProviderLoadResult.RemoteRoot"/> is supplied by the caller instead.
    /// </param>
    public static ProviderLoadResult ToProviderLoadResult(GitHubLoadResult r, string requestedRemoteRoot)
        => new()
        {
            RemoteRoot = requestedRemoteRoot,
            FilesLoaded = r.FilesLoaded,
            DirectoriesCreated = r.DirectoriesCreated,
            TotalBytes = r.TotalBytesLoaded,
            Duration = r.LoadDuration,
            Skipped = r.SkippedFiles
                // Size is unknown for some skip reasons; the neutral record uses 0 as 'unknown'.
                .Select(s => new ProviderSkippedFile(s.Path, ToSkipReason(s.Reason), s.Size ?? 0, s.ErrorMessage))
                .ToList(),
        };

    private static ProviderSkipReason ToSkipReason(SkipReason r) => r switch
    {
        SkipReason.TooLarge => ProviderSkipReason.TooLarge,
        // BinaryExcluded / ExtensionNotIncluded / ExtensionExcluded intentionally collapse to
        // BlockedExtension: the neutral enum is coarser and does not distinguish those reasons.
        SkipReason.ExtensionNotIncluded => ProviderSkipReason.BlockedExtension,
        SkipReason.ExtensionExcluded => ProviderSkipReason.BlockedExtension,
        SkipReason.BinaryExcluded => ProviderSkipReason.BlockedExtension,
        SkipReason.PatternExcluded => ProviderSkipReason.NotMatchingGlob,
        _ => ProviderSkipReason.LoadError
    };
}
