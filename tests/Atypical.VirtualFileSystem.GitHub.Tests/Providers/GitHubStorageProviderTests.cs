// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.GitHub.Providers;
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.GitHub.Tests.Providers;

public class GitHubStorageProviderTests
{
    [Fact]
    public void Provider_exposes_github_id_and_pr_capabilities()
    {
        var provider = new GitHubStorageProvider(new GitHubRepositoryLoader(), new GitHubWriteService(), new GitHubProviderAuth());
        provider.Id.ShouldBe("github");
        provider.Capabilities.SupportsPullRequests.ShouldBeTrue();
        provider.Capabilities.SupportsBranches.ShouldBeTrue();
        provider.Capabilities.SupportsAtomicMultiFileCommit.ShouldBeTrue();
        provider.Capabilities.AuthKind.ShouldBe(AuthKind.Token);
    }
}
