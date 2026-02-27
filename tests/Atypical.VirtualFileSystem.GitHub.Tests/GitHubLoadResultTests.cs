// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.GitHub.Tests;

public class GitHubLoadResultTests
{
    [Fact]
    public void FullRepositoryName_ShouldCombineOwnerAndRepo()
    {
        // Arrange
        var result = CreateTestResult();

        // Act & Assert
        result.FullRepositoryName.ShouldBe("testowner/testrepo");
    }

    [Fact]
    public void FilesSkipped_ShouldReturnCountOfSkippedFiles()
    {
        // Arrange
        var skippedFiles = new List<GitHubSkippedFile>
        {
            new("file1.bin", SkipReason.TooLarge, 5_000_000),
            new("file2.exe", SkipReason.BinaryExcluded)
        };
        var result = CreateTestResult(skippedFiles: skippedFiles);

        // Act & Assert
        result.FilesSkipped.ShouldBe(2);
    }

    [Fact]
    public void HasSkippedFiles_ShouldReturnTrueWhenFilesSkipped()
    {
        // Arrange
        var skippedFiles = new List<GitHubSkippedFile>
        {
            new("file1.bin", SkipReason.TooLarge)
        };
        var result = CreateTestResult(skippedFiles: skippedFiles);

        // Act & Assert
        result.HasSkippedFiles.ShouldBeTrue();
    }

    [Fact]
    public void HasSkippedFiles_ShouldReturnFalseWhenNoFilesSkipped()
    {
        // Arrange
        var result = CreateTestResult();

        // Act & Assert
        result.HasSkippedFiles.ShouldBeFalse();
    }

    [Theory]
    [InlineData(500, "500 B")]
    [InlineData(1024, "1.0 KB")]
    [InlineData(1536, "1.5 KB")]
    [InlineData(1_048_576, "1.0 MB")]
    [InlineData(1_572_864, "1.5 MB")]
    [InlineData(1_073_741_824, "1.0 GB")]
    public void Summary_ShouldContainFormattedSize(long bytes, string expectedSize)
    {
        // Arrange
        var result = CreateTestResult(totalBytesLoaded: bytes);

        // Act
        var summary = result.Summary;

        // Assert
        summary.ShouldContain(expectedSize);
    }

    [Fact]
    public void Summary_ShouldIncludeSkippedFilesCount()
    {
        // Arrange
        var skippedFiles = new List<GitHubSkippedFile>
        {
            new("file1.bin", SkipReason.TooLarge),
            new("file2.exe", SkipReason.BinaryExcluded),
            new("file3.dll", SkipReason.ExtensionExcluded)
        };
        var result = CreateTestResult(skippedFiles: skippedFiles);

        // Act
        var summary = result.Summary;

        // Assert
        summary.ShouldContain("3 files skipped");
    }

    [Fact]
    public void SkippedFilesByReason_ShouldGroupCorrectly()
    {
        // Arrange
        var skippedFiles = new List<GitHubSkippedFile>
        {
            new("file1.bin", SkipReason.TooLarge, 5_000_000),
            new("file2.zip", SkipReason.TooLarge, 10_000_000),
            new("file3.exe", SkipReason.BinaryExcluded),
            new("file4.dll", SkipReason.ExtensionExcluded)
        };
        var result = CreateTestResult(skippedFiles: skippedFiles);

        // Act
        var byReason = result.SkippedFilesByReason;

        // Assert
        byReason.ShouldContainKey(SkipReason.TooLarge);
        byReason[SkipReason.TooLarge].Count.ShouldBe(2);
        byReason[SkipReason.BinaryExcluded].Count.ShouldBe(1);
        byReason[SkipReason.ExtensionExcluded].Count.ShouldBe(1);
    }

    private static GitHubLoadResult CreateTestResult(
        string owner = "testowner",
        string repo = "testrepo",
        string branch = "main",
        string sha = "abc123",
        int filesLoaded = 10,
        int directoriesCreated = 5,
        long totalBytesLoaded = 1024,
        IReadOnlyList<GitHubSkippedFile>? skippedFiles = null,
        TimeSpan? loadDuration = null,
        string targetPath = "/")
    {
        return new GitHubLoadResult(
            owner,
            repo,
            branch,
            sha,
            filesLoaded,
            directoriesCreated,
            totalBytesLoaded,
            skippedFiles ?? [],
            loadDuration ?? TimeSpan.FromSeconds(1),
            targetPath);
    }
}
