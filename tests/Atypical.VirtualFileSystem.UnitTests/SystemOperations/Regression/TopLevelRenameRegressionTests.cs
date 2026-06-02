// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.UnitTests.SystemOperations.Regression;

/// <summary>
/// Regression tests for renaming top-level entries. The parent of a top-level
/// entry is the root (<c>vfs://</c>) whose <c>Value</c> ends in a separator,
/// so the naive "{Parent}/{newName}" concatenation produced a malformed
/// triple-slash path (<c>vfs:///name</c>).
/// </summary>
public class TopLevelRenameRegressionTests : VirtualFileSystemTestsBase
{
    [Fact]
    public void RenameDirectory_at_top_level_produces_a_well_formed_path()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("docs/readme.txt", "a");

        // Act
        vfs.RenameDirectory(new VFSDirectoryPath("docs"), "renamed");

        // Assert — well-formed path, no triple slash
        vfs.Index.ContainsKey(new VFSDirectoryPath("renamed")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("renamed/readme.txt")).ShouldBeTrue();
        vfs.Index.Keys.ShouldAllBe(k => !k.Value.Contains(":///"));
    }

    [Fact]
    public void RenameFile_at_top_level_produces_a_well_formed_path()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile("readme.txt", "a");

        // Act
        vfs.RenameFile(new VFSFilePath("readme.txt"), "renamed.txt");

        // Assert
        vfs.Index.ContainsKey(new VFSFilePath("renamed.txt")).ShouldBeTrue();
        vfs.Index.Keys.ShouldAllBe(k => !k.Value.Contains(":///"));
    }
}
