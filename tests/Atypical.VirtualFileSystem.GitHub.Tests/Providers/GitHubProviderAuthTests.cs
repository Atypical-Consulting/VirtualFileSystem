// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.GitHub.Providers;
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.GitHub.Tests.Providers;

public class GitHubProviderAuthTests
{
    [Fact]
    public void New_auth_is_token_kind_and_unauthenticated()
    {
        var auth = new GitHubProviderAuth();
        auth.Kind.ShouldBe(AuthKind.Token);
        auth.IsAuthenticated.ShouldBeFalse();
        auth.Account.ShouldBeNull();
    }

    [Fact]
    public async Task AuthenticateAsync_with_empty_token_returns_failure()
    {
        var auth = new GitHubProviderAuth();
        var result = await auth.AuthenticateAsync(new AuthRequest { Token = "" });
        result.Success.ShouldBeFalse();
    }
}
