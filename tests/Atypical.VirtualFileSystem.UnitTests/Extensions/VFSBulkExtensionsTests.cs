// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.Core.Extensions;
using VirtualFileSystem.UnitTests.SystemOperations;

namespace Atypical.VirtualFileSystem.UnitTests.Extensions;

public class VFSBulkExtensionsTests : VirtualFileSystemTestsBase
{
    #region CreateFiles Tests

    [Fact]
    public void CreateFiles_WithTupleCollection_ShouldCreateAllFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        var files = new[]
        {
            ("/docs/file1.txt", "Content 1"),
            ("/docs/file2.txt", "Content 2"),
            ("/src/main.cs", "Content 3")
        };

        // Act
        var result = vfs.CreateFiles(files);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/docs/file1.txt").Should().BeTrue();
        vfs.FileExists("/docs/file2.txt").Should().BeTrue();
        vfs.FileExists("/src/main.cs").Should().BeTrue();
        vfs.DirectoryExists("/docs").Should().BeTrue();
        vfs.DirectoryExists("/src").Should().BeTrue();
        vfs.GetFile("/docs/file1.txt").Content.Should().Be("Content 1");
        vfs.GetFile("/docs/file2.txt").Content.Should().Be("Content 2");
        vfs.GetFile("/src/main.cs").Content.Should().Be("Content 3");
    }

    [Fact]
    public void CreateFiles_WithDictionary_ShouldCreateAllFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        var files = new Dictionary<string, string>
        {
            { "/file1.txt", "Content 1" },
            { "/file2.txt", "Content 2" },
            { "/file3.txt", "Content 3" }
        };

        // Act
        var result = vfs.CreateFiles(files);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/file1.txt").Should().BeTrue();
        vfs.FileExists("/file2.txt").Should().BeTrue();
        vfs.FileExists("/file3.txt").Should().BeTrue();
        vfs.GetFile("/file1.txt").Content.Should().Be("Content 1");
        vfs.GetFile("/file2.txt").Content.Should().Be("Content 2");
        vfs.GetFile("/file3.txt").Content.Should().Be("Content 3");
    }

    [Fact]
    public void CreateFiles_WithCreateDirectoriesFalse_ShouldStillCreateFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        var files = new[] { ("/nonexistent/file.txt", "Content") };

        // Act
        var result = vfs.CreateFiles(files, createDirectories: false);

        // Assert
        // Note: Base VFS CreateFile automatically creates parent directories
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/nonexistent/file.txt").Should().BeTrue();
        vfs.DirectoryExists("/nonexistent").Should().BeTrue();
    }

    [Fact]
    public void CreateFiles_WithEmptyCollection_ShouldReturnVfs()
    {
        // Arrange
        var vfs = CreateVFS();
        var files = Array.Empty<(string, string)>();

        // Act
        var result = vfs.CreateFiles(files);

        // Assert
        result.Should().BeSameAs(vfs);
    }

    [Fact]
    public void TryCreateFiles_WithValidFiles_ShouldReturnAllPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        var files = new[]
        {
            ("/docs/file1.txt", "Content 1"),
            ("/docs/file2.txt", "Content 2")
        };

        // Act
        var successfulPaths = vfs.TryCreateFiles(files).ToList();

        // Assert
        successfulPaths.Should().HaveCount(2);
        successfulPaths.Should().Contain("/docs/file1.txt");
        successfulPaths.Should().Contain("/docs/file2.txt");
        vfs.FileExists("/docs/file1.txt").Should().BeTrue();
        vfs.FileExists("/docs/file2.txt").Should().BeTrue();
    }

    [Fact]
    public void TryCreateFiles_WithSomeInvalidPaths_ShouldReturnOnlySuccessfulPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/existing.txt", "existing");
        var files = new[]
        {
            ("/valid.txt", "Content"),
            ("/existing.txt", "Duplicate"),  // This should fail
            ("/another.txt", "Content 2")
        };

        // Act
        var successfulPaths = vfs.TryCreateFiles(files).ToList();

        // Assert
        successfulPaths.Should().HaveCount(2);
        successfulPaths.Should().Contain("/valid.txt");
        successfulPaths.Should().Contain("/another.txt");
        successfulPaths.Should().NotContain("/existing.txt");
    }

    #endregion

    #region CreateDirectories Tests

    [Fact]
    public void CreateDirectories_WithValidPaths_ShouldCreateAllDirectories()
    {
        // Arrange
        var vfs = CreateVFS();
        var directories = new[] { "/docs", "/src/main", "/tests/unit" };

        // Act
        var result = vfs.CreateDirectories(directories);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.DirectoryExists("/docs").Should().BeTrue();
        vfs.DirectoryExists("/src/main").Should().BeTrue();
        vfs.DirectoryExists("/tests/unit").Should().BeTrue();
        vfs.DirectoryExists("/src").Should().BeTrue();
        vfs.DirectoryExists("/tests").Should().BeTrue();
    }

    [Fact]
    public void CreateDirectories_WithCreateRecursivelyFalse_ShouldStillCreateDirectories()
    {
        // Arrange
        var vfs = CreateVFS();
        var directories = new[] { "/parent/child" };

        // Act
        var result = vfs.CreateDirectories(directories, createRecursively: false);

        // Assert
        // Note: Base VFS CreateDirectory automatically creates parent directories
        result.Should().BeSameAs(vfs);
        vfs.DirectoryExists("/parent").Should().BeTrue();
        vfs.DirectoryExists("/parent/child").Should().BeTrue();
    }

    [Fact]
    public void TryCreateDirectories_WithValidPaths_ShouldReturnAllPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        var directories = new[] { "/docs", "/src", "/tests" };

        // Act
        var successfulPaths = vfs.TryCreateDirectories(directories).ToList();

        // Assert
        successfulPaths.Should().HaveCount(3);
        successfulPaths.Should().Contain("/docs");
        successfulPaths.Should().Contain("/src");
        successfulPaths.Should().Contain("/tests");
    }

    [Fact]
    public void TryCreateDirectories_WithSomeExistingPaths_ShouldReturnAllSuccessfulPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateDirectory("/existing");
        var directories = new[] { "/valid", "/existing", "/another" };

        // Act
        var successfulPaths = vfs.TryCreateDirectories(directories).ToList();

        // Assert
        // VFS TryCreateDirectory succeeds for existing directories (idempotent operation)
        successfulPaths.Should().HaveCount(3);
        successfulPaths.Should().Contain("/valid");
        successfulPaths.Should().Contain("/existing");
        successfulPaths.Should().Contain("/another");
    }

    #endregion

    #region DeleteFiles Tests

    [Fact]
    public void DeleteFiles_WithExistingFiles_ShouldDeleteAllFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/file1.txt", "Content 1");
        vfs.CreateFile("/file2.txt", "Content 2");
        vfs.CreateFile("/file3.txt", "Content 3");
        var filesToDelete = new[] { "/file1.txt", "/file2.txt" };

        // Act
        var result = vfs.DeleteFiles(filesToDelete);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/file1.txt").Should().BeFalse();
        vfs.FileExists("/file2.txt").Should().BeFalse();
        vfs.FileExists("/file3.txt").Should().BeTrue(); // Should remain
    }

    [Fact]
    public void DeleteFiles_WithNonExistentFiles_ShouldNotThrow()
    {
        // Arrange
        var vfs = CreateVFS();
        var filesToDelete = new[] { "/nonexistent1.txt", "/nonexistent2.txt" };

        // Act
        var result = vfs.DeleteFiles(filesToDelete);

        // Assert
        result.Should().BeSameAs(vfs);
    }

    [Fact]
    public void TryDeleteFiles_WithExistingFiles_ShouldReturnSuccessfulPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/file1.txt", "Content 1");
        vfs.CreateFile("/file2.txt", "Content 2");
        var filesToDelete = new[] { "/file1.txt", "/file2.txt", "/nonexistent.txt" };

        // Act
        var successfulPaths = vfs.TryDeleteFiles(filesToDelete).ToList();

        // Assert
        successfulPaths.Should().HaveCount(2);
        successfulPaths.Should().Contain("/file1.txt");
        successfulPaths.Should().Contain("/file2.txt");
        successfulPaths.Should().NotContain("/nonexistent.txt");
    }

    #endregion

    #region DeleteDirectories Tests

    [Fact]
    public void DeleteDirectories_WithExistingDirectories_ShouldDeleteAllDirectories()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateDirectory("/dir1");
        vfs.CreateDirectory("/dir2");
        vfs.CreateDirectory("/dir3");
        var directoriesToDelete = new[] { "/dir1", "/dir2" };

        // Act
        var result = vfs.DeleteDirectories(directoriesToDelete);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.DirectoryExists("/dir1").Should().BeFalse();
        vfs.DirectoryExists("/dir2").Should().BeFalse();
        vfs.DirectoryExists("/dir3").Should().BeTrue(); // Should remain
    }

    [Fact]
    public void DeleteDirectories_WithNonExistentDirectories_ShouldNotThrow()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoriesToDelete = new[] { "/nonexistent1", "/nonexistent2" };

        // Act
        var result = vfs.DeleteDirectories(directoriesToDelete);

        // Assert
        result.Should().BeSameAs(vfs);
    }

    [Fact]
    public void TryDeleteDirectories_WithExistingDirectories_ShouldReturnSuccessfulPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateDirectory("/dir1");
        vfs.CreateDirectory("/dir2");
        var directoriesToDelete = new[] { "/dir1", "/dir2", "/nonexistent" };

        // Act
        var successfulPaths = vfs.TryDeleteDirectories(directoriesToDelete).ToList();

        // Assert
        successfulPaths.Should().HaveCount(2);
        successfulPaths.Should().Contain("/dir1");
        successfulPaths.Should().Contain("/dir2");
        successfulPaths.Should().NotContain("/nonexistent");
    }

    #endregion

    #region MoveFiles Tests

    [Fact]
    public void MoveFiles_WithValidFiles_ShouldMoveAllFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/source1.txt", "Content 1");
        vfs.CreateFile("/source2.txt", "Content 2");
        var moves = new[]
        {
            ("/source1.txt", "/dest/file1.txt"),
            ("/source2.txt", "/dest/file2.txt")
        };

        // Act
        var result = vfs.MoveFiles(moves);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/source1.txt").Should().BeFalse();
        vfs.FileExists("/source2.txt").Should().BeFalse();
        vfs.FileExists("/dest/file1.txt").Should().BeTrue();
        vfs.FileExists("/dest/file2.txt").Should().BeTrue();
        vfs.DirectoryExists("/dest").Should().BeTrue();
        vfs.GetFile("/dest/file1.txt").Content.Should().Be("Content 1");
        vfs.GetFile("/dest/file2.txt").Content.Should().Be("Content 2");
    }

    [Fact]
    public void MoveFiles_WithCreateDirectoriesFalse_ShouldFailSilentlyForMissingDirectories()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/source.txt", "Content");
        vfs.CreateDirectory("/existing");
        var moves = new[] 
        {
            ("/source.txt", "/existing/dest.txt"), // This should work
        };

        // Act
        var result = vfs.MoveFiles(moves, createDirectories: false);

        // Assert
        // Note: VFS MoveFile does NOT automatically create parent directories
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/source.txt").Should().BeFalse();
        vfs.FileExists("/existing/dest.txt").Should().BeTrue();
        vfs.DirectoryExists("/existing").Should().BeTrue();
    }

    [Fact]
    public void MoveFiles_WithNonExistentSource_ShouldSkipAndContinue()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/existing.txt", "Content");
        var moves = new[]
        {
            ("/nonexistent.txt", "/dest1.txt"),
            ("/existing.txt", "/dest2.txt")
        };

        // Act
        var result = vfs.MoveFiles(moves);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/dest1.txt").Should().BeFalse();
        vfs.FileExists("/dest2.txt").Should().BeTrue();
        vfs.FileExists("/existing.txt").Should().BeFalse();
    }

    [Fact]
    public void TryMoveFiles_WithValidFiles_ShouldReturnSuccessfulPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/source1.txt", "Content 1");
        vfs.CreateFile("/source2.txt", "Content 2");
        var moves = new[]
        {
            ("/source1.txt", "/dest/file1.txt"),
            ("/source2.txt", "/dest/file2.txt"),
            ("/nonexistent.txt", "/dest/file3.txt")
        };

        // Act
        var successfulPaths = vfs.TryMoveFiles(moves).ToList();

        // Assert
        successfulPaths.Should().HaveCount(2);
        successfulPaths.Should().Contain("/source1.txt");
        successfulPaths.Should().Contain("/source2.txt");
        successfulPaths.Should().NotContain("/nonexistent.txt");
    }

    #endregion

    #region CopyFiles Tests

    [Fact]
    public void CopyFiles_WithValidFiles_ShouldCopyAllFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/source1.txt", "Content 1");
        vfs.CreateFile("/source2.txt", "Content 2");
        var copies = new[]
        {
            ("/source1.txt", "/dest/copy1.txt"),
            ("/source2.txt", "/dest/copy2.txt")
        };

        // Act
        var result = vfs.CopyFiles(copies);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/source1.txt").Should().BeTrue(); // Source should remain
        vfs.FileExists("/source2.txt").Should().BeTrue(); // Source should remain
        vfs.FileExists("/dest/copy1.txt").Should().BeTrue();
        vfs.FileExists("/dest/copy2.txt").Should().BeTrue();
        vfs.DirectoryExists("/dest").Should().BeTrue();
        vfs.GetFile("/dest/copy1.txt").Content.Should().Be("Content 1");
        vfs.GetFile("/dest/copy2.txt").Content.Should().Be("Content 2");
    }

    [Fact]
    public void CopyFiles_WithCreateDirectoriesFalse_ShouldStillCopyFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/source.txt", "Content");
        vfs.CreateDirectory("/existing");
        var copies = new[]
        {
            ("/source.txt", "/existing/copy.txt"),
            ("/source.txt", "/nonexistent/copy.txt")
        };

        // Act
        var result = vfs.CopyFiles(copies, createDirectories: false);

        // Assert
        // Note: Base VFS operations automatically create parent directories
        result.Should().BeSameAs(vfs);
        vfs.FileExists("/existing/copy.txt").Should().BeTrue();
        vfs.FileExists("/nonexistent/copy.txt").Should().BeTrue();
        vfs.DirectoryExists("/nonexistent").Should().BeTrue();
    }

    [Fact]
    public void TryCopyFiles_WithValidFiles_ShouldReturnSuccessfulPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/source1.txt", "Content 1");
        vfs.CreateFile("/source2.txt", "Content 2");
        var copies = new[]
        {
            ("/source1.txt", "/dest/copy1.txt"),
            ("/source2.txt", "/dest/copy2.txt"),
            ("/nonexistent.txt", "/dest/copy3.txt")
        };

        // Act
        var successfulPaths = vfs.TryCopyFiles(copies).ToList();

        // Assert
        successfulPaths.Should().HaveCount(2);
        successfulPaths.Should().Contain("/source1.txt");
        successfulPaths.Should().Contain("/source2.txt");
        successfulPaths.Should().NotContain("/nonexistent.txt");
    }

    #endregion

    #region UpdateFiles Tests

    [Fact]
    public void UpdateFiles_WithExistingFiles_ShouldUpdateAllContents()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/file1.txt", "Original 1");
        vfs.CreateFile("/file2.txt", "Original 2");
        var updates = new[]
        {
            ("/file1.txt", "Updated 1"),
            ("/file2.txt", "Updated 2")
        };

        // Act
        var result = vfs.UpdateFiles(updates);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.GetFile("/file1.txt").Content.Should().Be("Updated 1");
        vfs.GetFile("/file2.txt").Content.Should().Be("Updated 2");
    }

    [Fact]
    public void UpdateFiles_WithNonExistentFiles_ShouldSkipMissingFiles()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/existing.txt", "Original");
        var updates = new[]
        {
            ("/existing.txt", "Updated"),
            ("/nonexistent.txt", "New Content")
        };

        // Act
        var result = vfs.UpdateFiles(updates);

        // Assert
        result.Should().BeSameAs(vfs);
        vfs.GetFile("/existing.txt").Content.Should().Be("Updated");
        vfs.FileExists("/nonexistent.txt").Should().BeFalse();
    }

    [Fact]
    public void TryUpdateFiles_WithExistingFiles_ShouldReturnSuccessfulPaths()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("/file1.txt", "Original 1");
        vfs.CreateFile("/file2.txt", "Original 2");
        var updates = new[]
        {
            ("/file1.txt", "Updated 1"),
            ("/file2.txt", "Updated 2"),
            ("/nonexistent.txt", "New Content")
        };

        // Act
        var successfulPaths = vfs.TryUpdateFiles(updates).ToList();

        // Assert
        successfulPaths.Should().HaveCount(2);
        successfulPaths.Should().Contain("/file1.txt");
        successfulPaths.Should().Contain("/file2.txt");
        successfulPaths.Should().NotContain("/nonexistent.txt");
        vfs.GetFile("/file1.txt").Content.Should().Be("Updated 1");
        vfs.GetFile("/file2.txt").Content.Should().Be("Updated 2");
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void BulkOperations_WithEmptyCollections_ShouldReturnVfsWithoutError()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act & Assert
        vfs.CreateFiles(Array.Empty<(string, string)>()).Should().BeSameAs(vfs);
        vfs.CreateDirectories(Array.Empty<string>()).Should().BeSameAs(vfs);
        vfs.DeleteFiles(Array.Empty<string>()).Should().BeSameAs(vfs);
        vfs.DeleteDirectories(Array.Empty<string>()).Should().BeSameAs(vfs);
        vfs.MoveFiles(Array.Empty<(string, string)>()).Should().BeSameAs(vfs);
        vfs.CopyFiles(Array.Empty<(string, string)>()).Should().BeSameAs(vfs);
        vfs.UpdateFiles(Array.Empty<(string, string)>()).Should().BeSameAs(vfs);
    }

    [Fact]
    public void TryBulkOperations_WithEmptyCollections_ShouldReturnEmptyResults()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act & Assert
        vfs.TryCreateFiles(Array.Empty<(string, string)>()).Should().BeEmpty();
        vfs.TryCreateDirectories(Array.Empty<string>()).Should().BeEmpty();
        vfs.TryDeleteFiles(Array.Empty<string>()).Should().BeEmpty();
        vfs.TryDeleteDirectories(Array.Empty<string>()).Should().BeEmpty();
        vfs.TryMoveFiles(Array.Empty<(string, string)>()).Should().BeEmpty();
        vfs.TryCopyFiles(Array.Empty<(string, string)>()).Should().BeEmpty();
        vfs.TryUpdateFiles(Array.Empty<(string, string)>()).Should().BeEmpty();
    }

    #endregion
}