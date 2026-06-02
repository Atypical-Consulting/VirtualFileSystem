// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.UnitTests.SystemOperations.Regression;

/// <summary>
/// Regression tests for the directory-prefix matching bug in
/// <see cref="VFSIndex.GetPathsStartingWith"/>: a raw string prefix match
/// wrongly captured sibling directories that share a name prefix
/// (e.g. "docs" matching "docs2"), causing data loss on delete/move/rename.
/// </summary>
public class PrefixBoundaryRegressionTests : VirtualFileSystemTestsBase
{
    [Fact]
    public void DeleteDirectory_does_not_delete_a_prefix_sibling_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("docs/readme.txt", "a");
        vfs.CreateFile("docs2/keep.txt", "b");

        // Act — delete "docs"; "docs2" must survive
        vfs.DeleteDirectory(new VFSDirectoryPath("docs"));

        // Assert
        vfs.Index.ContainsKey(new VFSDirectoryPath("docs2")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("docs2/keep.txt")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSDirectoryPath("docs")).ShouldBeFalse();
        vfs.Index.ContainsKey(new VFSFilePath("docs/readme.txt")).ShouldBeFalse();
    }

    [Fact]
    public void MoveDirectory_does_not_drag_a_prefix_sibling_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("docs/readme.txt", "a");
        vfs.CreateFile("docs2/keep.txt", "b");

        // Act — move "docs" to "archive"; "docs2" must stay put and untouched
        vfs.MoveDirectory(new VFSDirectoryPath("docs"), new VFSDirectoryPath("archive"));

        // Assert
        vfs.Index.ContainsKey(new VFSFilePath("docs2/keep.txt")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("archive/readme.txt")).ShouldBeTrue();
        // The sibling must NOT have been rewritten to a garbage path.
        vfs.Index.ContainsKey(new VFSFilePath("archive2/keep.txt")).ShouldBeFalse();
    }

    [Fact]
    public void RenameDirectory_does_not_affect_a_prefix_sibling_directory()
    {
        // Arrange — nested under a common parent so the rename target is not the root.
        var vfs = CreateVFS();
        vfs.CreateFile("root/docs/readme.txt", "a");
        vfs.CreateFile("root/docs2/keep.txt", "b");

        // Act
        vfs.RenameDirectory(new VFSDirectoryPath("root/docs"), "renamed");

        // Assert
        vfs.Index.ContainsKey(new VFSFilePath("root/docs2/keep.txt")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("root/renamed/readme.txt")).ShouldBeTrue();
    }

    [Fact]
    public void DeleteDirectory_with_different_casing_still_removes_children()
    {
        // Arrange — the index is documented as case-insensitive.
        var vfs = CreateVFS();
        vfs.CreateFile("docs/a.txt", "a");

        // Act — delete using a different case
        vfs.DeleteDirectory(new VFSDirectoryPath("DOCS"));

        // Assert — the child must not be orphaned
        vfs.Index.ContainsKey(new VFSFilePath("docs/a.txt")).ShouldBeFalse();
        vfs.IsEmpty.ShouldBeTrue();
    }
}
