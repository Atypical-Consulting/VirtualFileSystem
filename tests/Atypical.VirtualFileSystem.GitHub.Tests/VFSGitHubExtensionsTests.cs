// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.GitHub.Tests;

public class VFSGitHubExtensionsTests
{
    [Theory]
    [InlineData("https://github.com/owner/repo", "owner", "repo")]
    [InlineData("https://github.com/microsoft/dotnet", "microsoft", "dotnet")]
    [InlineData("https://github.com/owner/repo.git", "owner", "repo")]
    public void TryParseGitHubUrl_WithValidUrls_ShouldParse(string url, string expectedOwner, string expectedRepo)
    {
        // Act
        var result = VFSGitHubExtensions.TryParseGitHubUrl(url, out var owner, out var repo);

        // Assert
        result.ShouldBeTrue();
        owner.ShouldBe(expectedOwner);
        repo.ShouldBe(expectedRepo);
    }

    [Theory]
    [InlineData("https://gitlab.com/owner/repo")]
    [InlineData("not-a-url")]
    [InlineData("")]
    public void TryParseGitHubUrl_WithInvalidUrls_ShouldReturnFalse(string url)
    {
        // Act
        var result = VFSGitHubExtensions.TryParseGitHubUrl(url, out _, out _);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public async Task TryLoadGitHubRepositoryAsync_WithNonExistentRepo_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var (success, result) = await vfs.TryLoadGitHubRepositoryAsync(
            "non-existent-owner-abc123",
            "non-existent-repo-xyz789");

        // Assert
        success.ShouldBeFalse();
        result.ShouldBeNull();
    }

    [Fact]
    public async Task TryLoadGitHubRepositoryFromUrlAsync_WithInvalidUrl_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var (success, result) = await vfs.TryLoadGitHubRepositoryFromUrlAsync("not-a-valid-url");

        // Assert
        success.ShouldBeFalse();
        result.ShouldBeNull();
    }
}
