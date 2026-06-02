// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.UnitTests.SystemOperations.Regression;

/// <summary>
/// Regression tests for unsafe move semantics: moving onto an existing
/// destination silently overwrote it (orphaning its children), and a directory
/// could be moved into itself or its own subtree, corrupting the index.
/// </summary>
public class MoveSafetyRegressionTests : VirtualFileSystemTestsBase
{
    [Fact]
    public void MoveDirectory_onto_an_existing_destination_throws()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("src/a.txt", "a");
        vfs.CreateFile("dst/b.txt", "b");

        // Act
        var act = () => vfs.MoveDirectory(new VFSDirectoryPath("src"), new VFSDirectoryPath("dst"));

        // Assert — must not silently overwrite "dst"
        Should.Throw<VirtualFileSystemException>(act);
        vfs.Index.ContainsKey(new VFSFilePath("dst/b.txt")).ShouldBeTrue();
    }

    [Fact]
    public void MoveFile_onto_an_existing_destination_throws()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("a.txt", "a");
        vfs.CreateFile("b.txt", "b");

        // Act
        var act = () => vfs.MoveFile(new VFSFilePath("a.txt"), new VFSFilePath("b.txt"));

        // Assert
        Should.Throw<VirtualFileSystemException>(act);
        vfs.Index.GetFile(new VFSFilePath("b.txt")).Content.ShouldBe("b");
    }

    [Fact]
    public void MoveDirectory_into_itself_throws()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("docs/a.txt", "a");

        // Act
        var act = () => vfs.MoveDirectory(new VFSDirectoryPath("docs"), new VFSDirectoryPath("docs"));

        // Assert
        Should.Throw<VirtualFileSystemException>(act);
    }

    [Fact]
    public void MoveDirectory_into_its_own_subtree_throws()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("docs/sub/a.txt", "a");

        // Act
        var act = () => vfs.MoveDirectory(new VFSDirectoryPath("docs"), new VFSDirectoryPath("docs/sub/inner"));

        // Assert
        Should.Throw<VirtualFileSystemException>(act);
    }
}
