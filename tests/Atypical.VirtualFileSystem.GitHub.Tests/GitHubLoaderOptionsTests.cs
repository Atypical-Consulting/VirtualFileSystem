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
        options.AccessToken.ShouldBeNull();
        options.Branch.ShouldBeNull();
        options.SubPath.ShouldBeNull();
        options.TargetPath.ShouldBe("/");
        options.MaxFileSize.ShouldBe(1_048_576);
        options.IncludeExtensions.ShouldBeNull();
        options.ExcludeExtensions.ShouldBeNull();
        options.ExcludePatterns.ShouldBeNull();
        options.IncludeBinaryFiles.ShouldBeTrue();
        options.Strategy.ShouldBe(GitHubLoadingStrategy.Eager);
        options.ProgressCallback.ShouldBeNull();
    }

    [Fact]
    public void SourceCodeOnly_ShouldExcludeBinaryFilesAndCommonDirectories()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.SourceCodeOnly;

        // Assert
        options.IncludeBinaryFiles.ShouldBeFalse();
        options.ExcludePatterns.ShouldNotBeNull();
        options.ExcludePatterns.ShouldContain("**/node_modules/**");
        options.ExcludePatterns.ShouldContain("**/bin/**");
        options.ExcludePatterns.ShouldContain("**/obj/**");
    }

    [Fact]
    public void CSharpOnly_ShouldIncludeOnlyCSharpExtensions()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.CSharpOnly;

        // Assert
        options.IncludeBinaryFiles.ShouldBeFalse();
        options.IncludeExtensions.ShouldNotBeNull();
        options.IncludeExtensions.ShouldContain(".cs");
        options.IncludeExtensions.ShouldContain(".csproj");
        options.IncludeExtensions.ShouldContain(".sln");
        options.ExcludePatterns.ShouldContain("**/bin/**");
        options.ExcludePatterns.ShouldContain("**/obj/**");
    }

    [Fact]
    public void MetadataOnlyPreset_ShouldUseMetadataOnlyStrategy()
    {
        // Arrange & Act
        var options = GitHubLoaderOptions.MetadataOnlyPreset;

        // Assert
        options.Strategy.ShouldBe(GitHubLoadingStrategy.MetadataOnly);
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
        result.ShouldBe(expected);
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
        result.ShouldBe(expected);
    }

    [Fact]
    public void WithRecord_ShouldCreateNewInstanceWithModifiedProperty()
    {
        // Arrange
        var original = GitHubLoaderOptions.Default;

        // Act
        var modified = original with { AccessToken = "test-token" };

        // Assert
        original.AccessToken.ShouldBeNull();
        modified.AccessToken.ShouldBe("test-token");
        modified.MaxFileSize.ShouldBe(original.MaxFileSize);
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
        options.AccessToken.ShouldBe("my-token");
        options.Branch.ShouldBe("develop");
        options.MaxFileSize.ShouldBe(5_000_000);
        options.Strategy.ShouldBe(GitHubLoadingStrategy.Lazy);
    }
}
