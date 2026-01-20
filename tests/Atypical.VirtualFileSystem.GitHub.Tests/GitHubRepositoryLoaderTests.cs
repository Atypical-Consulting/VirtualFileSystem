// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.GitHub.Tests;

public class GitHubRepositoryLoaderTests
{
    private readonly GitHubRepositoryLoader _loader;

    public GitHubRepositoryLoaderTests()
    {
        _loader = new GitHubRepositoryLoader();
    }

    [Theory]
    [InlineData("https://github.com/owner/repo", "owner", "repo")]
    [InlineData("https://github.com/microsoft/dotnet", "microsoft", "dotnet")]
    [InlineData("https://www.github.com/owner/repo", "owner", "repo")]
    [InlineData("http://github.com/owner/repo", "owner", "repo")]
    [InlineData("https://github.com/owner/repo/", "owner", "repo")]
    [InlineData("https://github.com/owner/repo.git", "owner", "repo")]
    [InlineData("https://github.com/owner/repo/tree/main", "owner", "repo")]
    [InlineData("https://github.com/owner/repo/blob/main/README.md", "owner", "repo")]
    [InlineData("https://github.com/owner-name/repo-name", "owner-name", "repo-name")]
    [InlineData("https://github.com/owner_name/repo_name", "owner_name", "repo_name")]
    public void TryParseGitHubUrl_WithValidUrls_ShouldReturnTrue(string url, string expectedOwner, string expectedRepo)
    {
        // Act
        var result = _loader.TryParseGitHubUrl(url, out var owner, out var repo);

        // Assert
        result.Should().BeTrue();
        owner.Should().Be(expectedOwner);
        repo.Should().Be(expectedRepo);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("not-a-url")]
    [InlineData("https://gitlab.com/owner/repo")]
    [InlineData("https://bitbucket.org/owner/repo")]
    [InlineData("https://github.com/")]
    [InlineData("https://github.com/owner")]
    [InlineData("ftp://github.com/owner/repo")]
    public void TryParseGitHubUrl_WithInvalidUrls_ShouldReturnFalse(string? url)
    {
        // Act
        var result = _loader.TryParseGitHubUrl(url!, out var owner, out var repo);

        // Assert
        result.Should().BeFalse();
        owner.Should().BeEmpty();
        repo.Should().BeEmpty();
    }

    [Fact]
    public void Constructor_WithDefaultOptions_ShouldNotThrow()
    {
        // Act & Assert
        var action = () => new GitHubRepositoryLoader();
        action.Should().NotThrow();
    }

    [Fact]
    public void Constructor_WithAccessToken_ShouldNotThrow()
    {
        // Act & Assert
        var action = () => new GitHubRepositoryLoader("test-token");
        action.Should().NotThrow();
    }

    [Fact]
    public void Constructor_WithOptions_ShouldNotThrow()
    {
        // Arrange
        var options = new GitHubLoaderOptions(
            AccessToken: "test-token",
            Branch: "main",
            MaxFileSize: 5_000_000);

        // Act & Assert
        var action = () => new GitHubRepositoryLoader(options);
        action.Should().NotThrow();
    }

    [Fact]
    public async Task LoadRepositoryAsync_WithNullVfs_ShouldThrowArgumentNullException()
    {
        // Arrange & Act
        var action = () => _loader.LoadRepositoryAsync(null!, "owner", "repo");

        // Assert
        await action.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("vfs");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task LoadRepositoryAsync_WithInvalidOwner_ShouldThrowArgumentException(string? owner)
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var action = () => _loader.LoadRepositoryAsync(vfs, owner!, "repo");

        // Assert
        await action.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("owner");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task LoadRepositoryAsync_WithInvalidRepository_ShouldThrowArgumentException(string? repository)
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var action = () => _loader.LoadRepositoryAsync(vfs, "owner", repository!);

        // Assert
        await action.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("repository");
    }

    [Fact]
    public async Task LoadRepositoryFromUrlAsync_WithInvalidUrl_ShouldThrowArgumentException()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var action = () => _loader.LoadRepositoryFromUrlAsync(vfs, "not-a-valid-url");

        // Assert
        await action.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("repositoryUrl");
    }

    [Fact]
    public async Task TryLoadRepositoryAsync_WithNonExistentRepo_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var (success, result) = await _loader.TryLoadRepositoryAsync(
            vfs,
            "non-existent-owner-12345",
            "non-existent-repo-67890");

        // Assert
        success.Should().BeFalse();
        result.Should().BeNull();
    }
}
