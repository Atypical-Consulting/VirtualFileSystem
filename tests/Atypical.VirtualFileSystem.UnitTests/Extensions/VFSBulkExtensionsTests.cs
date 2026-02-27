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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/docs/file1.txt").ShouldBeTrue();
        vfs.FileExists("/docs/file2.txt").ShouldBeTrue();
        vfs.FileExists("/src/main.cs").ShouldBeTrue();
        vfs.DirectoryExists("/docs").ShouldBeTrue();
        vfs.DirectoryExists("/src").ShouldBeTrue();
        vfs.GetFile("/docs/file1.txt").Content.ShouldBe("Content 1");
        vfs.GetFile("/docs/file2.txt").Content.ShouldBe("Content 2");
        vfs.GetFile("/src/main.cs").Content.ShouldBe("Content 3");
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/file1.txt").ShouldBeTrue();
        vfs.FileExists("/file2.txt").ShouldBeTrue();
        vfs.FileExists("/file3.txt").ShouldBeTrue();
        vfs.GetFile("/file1.txt").Content.ShouldBe("Content 1");
        vfs.GetFile("/file2.txt").Content.ShouldBe("Content 2");
        vfs.GetFile("/file3.txt").Content.ShouldBe("Content 3");
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/nonexistent/file.txt").ShouldBeTrue();
        vfs.DirectoryExists("/nonexistent").ShouldBeTrue();
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
        result.ShouldBeSameAs(vfs);
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
        successfulPaths.Count.ShouldBe(2);
        successfulPaths.ShouldContain("/docs/file1.txt");
        successfulPaths.ShouldContain("/docs/file2.txt");
        vfs.FileExists("/docs/file1.txt").ShouldBeTrue();
        vfs.FileExists("/docs/file2.txt").ShouldBeTrue();
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
        successfulPaths.Count.ShouldBe(2);
        successfulPaths.ShouldContain("/valid.txt");
        successfulPaths.ShouldContain("/another.txt");
        successfulPaths.ShouldNotContain("/existing.txt");
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
        result.ShouldBeSameAs(vfs);
        vfs.DirectoryExists("/docs").ShouldBeTrue();
        vfs.DirectoryExists("/src/main").ShouldBeTrue();
        vfs.DirectoryExists("/tests/unit").ShouldBeTrue();
        vfs.DirectoryExists("/src").ShouldBeTrue();
        vfs.DirectoryExists("/tests").ShouldBeTrue();
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
        result.ShouldBeSameAs(vfs);
        vfs.DirectoryExists("/parent").ShouldBeTrue();
        vfs.DirectoryExists("/parent/child").ShouldBeTrue();
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
        successfulPaths.Count.ShouldBe(3);
        successfulPaths.ShouldContain("/docs");
        successfulPaths.ShouldContain("/src");
        successfulPaths.ShouldContain("/tests");
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
        successfulPaths.Count.ShouldBe(3);
        successfulPaths.ShouldContain("/valid");
        successfulPaths.ShouldContain("/existing");
        successfulPaths.ShouldContain("/another");
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/file1.txt").ShouldBeFalse();
        vfs.FileExists("/file2.txt").ShouldBeFalse();
        vfs.FileExists("/file3.txt").ShouldBeTrue(); // Should remain
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
        result.ShouldBeSameAs(vfs);
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
        successfulPaths.Count.ShouldBe(2);
        successfulPaths.ShouldContain("/file1.txt");
        successfulPaths.ShouldContain("/file2.txt");
        successfulPaths.ShouldNotContain("/nonexistent.txt");
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
        result.ShouldBeSameAs(vfs);
        vfs.DirectoryExists("/dir1").ShouldBeFalse();
        vfs.DirectoryExists("/dir2").ShouldBeFalse();
        vfs.DirectoryExists("/dir3").ShouldBeTrue(); // Should remain
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
        result.ShouldBeSameAs(vfs);
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
        successfulPaths.Count.ShouldBe(2);
        successfulPaths.ShouldContain("/dir1");
        successfulPaths.ShouldContain("/dir2");
        successfulPaths.ShouldNotContain("/nonexistent");
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/source1.txt").ShouldBeFalse();
        vfs.FileExists("/source2.txt").ShouldBeFalse();
        vfs.FileExists("/dest/file1.txt").ShouldBeTrue();
        vfs.FileExists("/dest/file2.txt").ShouldBeTrue();
        vfs.DirectoryExists("/dest").ShouldBeTrue();
        vfs.GetFile("/dest/file1.txt").Content.ShouldBe("Content 1");
        vfs.GetFile("/dest/file2.txt").Content.ShouldBe("Content 2");
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/source.txt").ShouldBeFalse();
        vfs.FileExists("/existing/dest.txt").ShouldBeTrue();
        vfs.DirectoryExists("/existing").ShouldBeTrue();
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/dest1.txt").ShouldBeFalse();
        vfs.FileExists("/dest2.txt").ShouldBeTrue();
        vfs.FileExists("/existing.txt").ShouldBeFalse();
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
        successfulPaths.Count.ShouldBe(2);
        successfulPaths.ShouldContain("/source1.txt");
        successfulPaths.ShouldContain("/source2.txt");
        successfulPaths.ShouldNotContain("/nonexistent.txt");
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/source1.txt").ShouldBeTrue(); // Source should remain
        vfs.FileExists("/source2.txt").ShouldBeTrue(); // Source should remain
        vfs.FileExists("/dest/copy1.txt").ShouldBeTrue();
        vfs.FileExists("/dest/copy2.txt").ShouldBeTrue();
        vfs.DirectoryExists("/dest").ShouldBeTrue();
        vfs.GetFile("/dest/copy1.txt").Content.ShouldBe("Content 1");
        vfs.GetFile("/dest/copy2.txt").Content.ShouldBe("Content 2");
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
        result.ShouldBeSameAs(vfs);
        vfs.FileExists("/existing/copy.txt").ShouldBeTrue();
        vfs.FileExists("/nonexistent/copy.txt").ShouldBeTrue();
        vfs.DirectoryExists("/nonexistent").ShouldBeTrue();
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
        successfulPaths.Count.ShouldBe(2);
        successfulPaths.ShouldContain("/source1.txt");
        successfulPaths.ShouldContain("/source2.txt");
        successfulPaths.ShouldNotContain("/nonexistent.txt");
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
        result.ShouldBeSameAs(vfs);
        vfs.GetFile("/file1.txt").Content.ShouldBe("Updated 1");
        vfs.GetFile("/file2.txt").Content.ShouldBe("Updated 2");
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
        result.ShouldBeSameAs(vfs);
        vfs.GetFile("/existing.txt").Content.ShouldBe("Updated");
        vfs.FileExists("/nonexistent.txt").ShouldBeFalse();
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
        successfulPaths.Count.ShouldBe(2);
        successfulPaths.ShouldContain("/file1.txt");
        successfulPaths.ShouldContain("/file2.txt");
        successfulPaths.ShouldNotContain("/nonexistent.txt");
        vfs.GetFile("/file1.txt").Content.ShouldBe("Updated 1");
        vfs.GetFile("/file2.txt").Content.ShouldBe("Updated 2");
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void BulkOperations_WithEmptyCollections_ShouldReturnVfsWithoutError()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act & Assert
        vfs.CreateFiles(Array.Empty<(string, string)>()).ShouldBeSameAs(vfs);
        vfs.CreateDirectories(Array.Empty<string>()).ShouldBeSameAs(vfs);
        vfs.DeleteFiles(Array.Empty<string>()).ShouldBeSameAs(vfs);
        vfs.DeleteDirectories(Array.Empty<string>()).ShouldBeSameAs(vfs);
        vfs.MoveFiles(Array.Empty<(string, string)>()).ShouldBeSameAs(vfs);
        vfs.CopyFiles(Array.Empty<(string, string)>()).ShouldBeSameAs(vfs);
        vfs.UpdateFiles(Array.Empty<(string, string)>()).ShouldBeSameAs(vfs);
    }

    [Fact]
    public void TryBulkOperations_WithEmptyCollections_ShouldReturnEmptyResults()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act & Assert
        vfs.TryCreateFiles(Array.Empty<(string, string)>()).ShouldBeEmpty();
        vfs.TryCreateDirectories(Array.Empty<string>()).ShouldBeEmpty();
        vfs.TryDeleteFiles(Array.Empty<string>()).ShouldBeEmpty();
        vfs.TryDeleteDirectories(Array.Empty<string>()).ShouldBeEmpty();
        vfs.TryMoveFiles(Array.Empty<(string, string)>()).ShouldBeEmpty();
        vfs.TryCopyFiles(Array.Empty<(string, string)>()).ShouldBeEmpty();
        vfs.TryUpdateFiles(Array.Empty<(string, string)>()).ShouldBeEmpty();
    }

    #endregion
}