// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.GitHub.Providers;
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.GitHub.Tests.Providers;

public class GitHubProviderAdaptersTests
{
    [Fact]
    public void ToGitHubLoaderOptions_maps_strategy_and_filters()
    {
        var opts = new ProviderLoadOptions
        {
            RemoteRoot = "src",
            Strategy = ProviderLoadingStrategy.Lazy,
            MaxFileSizeBytes = 1234,
        };

        var gh = GitHubProviderAdapters.ToGitHubLoaderOptions(opts, accessToken: "tok");

        gh.Strategy.ShouldBe(GitHubLoadingStrategy.Lazy);
        gh.MaxFileSize.ShouldBe(1234);
        // RemoteRoot maps to the REMOTE filter (SubPath), not the VFS destination (TargetPath).
        gh.SubPath.ShouldBe("src");
        gh.TargetPath.ShouldBe("/");
        gh.AccessToken.ShouldBe("tok");
    }

    [Fact]
    public void ToProviderLoadResult_maps_counts_and_skips()
    {
        var ghResult = new GitHubLoadResult(
            RepositoryOwner: "o",
            RepositoryName: "r",
            Branch: "main",
            CommitSha: "sha",
            FilesLoaded: 3,
            DirectoriesCreated: 2,
            TotalBytesLoaded: 99,
            SkippedFiles: new List<GitHubSkippedFile> { new("a.bin", SkipReason.LoadError, 5, "boom") },
            LoadDuration: TimeSpan.FromSeconds(1),
            TargetPath: "src");

        var result = GitHubProviderAdapters.ToProviderLoadResult(ghResult);

        result.FilesLoaded.ShouldBe(3);
        result.DirectoriesCreated.ShouldBe(2);
        result.TotalBytes.ShouldBe(99);
        result.Skipped.Count.ShouldBe(1);
        result.Skipped[0].Reason.ShouldBe(ProviderSkipReason.LoadError);
    }
}
