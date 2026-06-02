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
            TargetPath: o.RemoteRoot ?? "/",
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
            MetadataCallback: o.MetadataCallback,
            ProgressCallback: o.ProgressCallback is null
                ? null
                : (current, total, path) => o.ProgressCallback(current, path)
        );

    /// <summary>
    /// Maps a <see cref="GitHubLoadResult"/> to a neutral <see cref="ProviderLoadResult"/>.
    /// </summary>
    public static ProviderLoadResult ToProviderLoadResult(GitHubLoadResult r)
        => new()
        {
            RemoteRoot = r.TargetPath ?? string.Empty,
            FilesLoaded = r.FilesLoaded,
            DirectoriesCreated = r.DirectoriesCreated,
            TotalBytes = r.TotalBytesLoaded,
            Duration = r.LoadDuration,
            Skipped = r.SkippedFiles
                .Select(s => new ProviderSkippedFile(s.Path, ToSkipReason(s.Reason), s.Size ?? 0, s.ErrorMessage))
                .ToList(),
        };

    private static ProviderSkipReason ToSkipReason(SkipReason r) => r switch
    {
        SkipReason.TooLarge => ProviderSkipReason.TooLarge,
        SkipReason.ExtensionNotIncluded => ProviderSkipReason.BlockedExtension,
        SkipReason.ExtensionExcluded => ProviderSkipReason.BlockedExtension,
        SkipReason.BinaryExcluded => ProviderSkipReason.BlockedExtension,
        SkipReason.PatternExcluded => ProviderSkipReason.NotMatchingGlob,
        _ => ProviderSkipReason.LoadError
    };
}
