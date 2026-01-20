// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.GitHub.Tests;

public class GitHubLoaderOptionsTests
{
    [Fact]
    public void Default_ShouldHaveExpectedValues()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.Default;

        // Assert
        options.AccessToken.Should().BeNull();
        options.Branch.Should().BeNull();
        options.SubPath.Should().BeNull();
        options.TargetPath.Should().Be("/");
        options.MaxFileSize.Should().Be(1_048_576);
        options.IncludeExtensions.Should().BeNull();
        options.ExcludeExtensions.Should().BeNull();
        options.ExcludePatterns.Should().BeNull();
        options.IncludeBinaryFiles.Should().BeTrue();
        options.Strategy.Should().Be(GitHubLoadingStrategy.Eager);
        options.ProgressCallback.Should().BeNull();
    }

    [Fact]
    public void SourceCodeOnly_ShouldExcludeBinaryFilesAndCommonDirectories()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.SourceCodeOnly;

        // Assert
        options.IncludeBinaryFiles.Should().BeFalse();
        options.ExcludePatterns.Should().NotBeNull();
        options.ExcludePatterns.Should().Contain("**/node_modules/**");
        options.ExcludePatterns.Should().Contain("**/bin/**");
        options.ExcludePatterns.Should().Contain("**/obj/**");
    }

    [Fact]
    public void CSharpOnly_ShouldIncludeOnlyCSharpExtensions()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.CSharpOnly;

        // Assert
        options.IncludeBinaryFiles.Should().BeFalse();
        options.IncludeExtensions.Should().NotBeNull();
        options.IncludeExtensions.Should().Contain(".cs");
        options.IncludeExtensions.Should().Contain(".csproj");
        options.IncludeExtensions.Should().Contain(".sln");
        options.ExcludePatterns.Should().Contain("**/bin/**");
        options.ExcludePatterns.Should().Contain("**/obj/**");
    }

    [Fact]
    public void MetadataOnlyPreset_ShouldUseMetadataOnlyStrategy()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.MetadataOnlyPreset;

        // Assert
        options.Strategy.Should().Be(GitHubLoadingStrategy.MetadataOnly);
    }

    [Theory]
    [InlineData(".png", true)]
    [InlineData(".jpg", true)]
    [InlineData(".exe", true)]
    [InlineData(".dll", true)]
    [InlineData(".zip", true)]
    [InlineData(".mp3", true)]
    [InlineData(".pdf", true)]
    [InlineData(".cs", false)]
    [InlineData(".js", false)]
    [InlineData(".json", false)]
    [InlineData(".md", false)]
    [InlineData(".txt", false)]
    public void IsBinaryExtension_ShouldCorrectlyIdentifyBinaryExtensions(string extension, bool expected)
    {
        // Arrange & Act
        var result = GitHubLoaderOptions.IsBinaryExtension(extension);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(".PNG", true)]
    [InlineData(".Exe", true)]
    [InlineData(".DLL", true)]
    public void IsBinaryExtension_ShouldBeCaseInsensitive(string extension, bool expected)
    {
        // Arrange & Act
        var result = GitHubLoaderOptions.IsBinaryExtension(extension);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void WithRecord_ShouldCreateNewInstanceWithModifiedProperty()
    {
        // Arrange
        var original = GitHubLoaderOptions.Default;

        // Act
        var modified = original with { AccessToken = "test-token" };

        // Assert
        original.AccessToken.Should().BeNull();
        modified.AccessToken.Should().Be("test-token");
        modified.MaxFileSize.Should().Be(original.MaxFileSize);
    }

    [Fact]
    public void WithRecord_ShouldSupportMultipleModifications()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.Default with
        {
            AccessToken = "my-token",
            Branch = "develop",
            MaxFileSize = 5_000_000,
            Strategy = GitHubLoadingStrategy.Lazy
        };

        // Assert
        options.AccessToken.Should().Be("my-token");
        options.Branch.Should().Be("develop");
        options.MaxFileSize.Should().Be(5_000_000);
        options.Strategy.Should().Be(GitHubLoadingStrategy.Lazy);
    }
}
