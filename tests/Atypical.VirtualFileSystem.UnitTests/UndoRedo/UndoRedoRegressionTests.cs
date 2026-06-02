// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace VirtualFileSystem.UnitTests.UndoRedo;

/// <summary>
/// Regression tests for undo/redo correctness gaps:
/// broken file-rename inverse, delete operations that threw
/// NotImplementedException, and history state left corrupted when an
/// inverse operation throws.
/// </summary>
public class UndoRedoRegressionTests
{
    [Fact]
    public void Undo_after_RenameFile_restores_the_original_file()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFile("docs/file.txt", "hello");

        // Act
        vfs.RenameFile(new VFSFilePath("docs/file.txt"), "renamed.txt");
        vfs.ChangeHistory.Undo();

        // Assert
        vfs.Index.ContainsKey(new VFSFilePath("docs/file.txt")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("docs/renamed.txt")).ShouldBeFalse();
    }

    [Fact]
    public void Redo_after_undo_of_RenameFile_reapplies_the_rename()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFile("docs/file.txt", "hello");
        vfs.RenameFile(new VFSFilePath("docs/file.txt"), "renamed.txt");

        // Act
        vfs.ChangeHistory.Undo();
        vfs.ChangeHistory.Redo();

        // Assert
        vfs.Index.ContainsKey(new VFSFilePath("docs/renamed.txt")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("docs/file.txt")).ShouldBeFalse();
    }

    [Fact]
    public void Undo_after_DeleteFile_restores_the_file_with_its_content()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFile("docs/file.txt", "important content");

        // Act
        vfs.DeleteFile(new VFSFilePath("docs/file.txt"));
        vfs.ChangeHistory.Undo();

        // Assert
        vfs.Index.TryGetFile(new VFSFilePath("docs/file.txt"), out var node).ShouldBeTrue();
        node!.Content.ShouldBe("important content");
    }

    [Fact]
    public void Undo_after_DeleteDirectory_restores_the_directory_and_its_files()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFile("docs/sub/a.txt", "A");
        vfs.CreateFile("docs/b.txt", "B");

        // Act
        vfs.DeleteDirectory(new VFSDirectoryPath("docs"));
        vfs.ChangeHistory.Undo();

        // Assert
        vfs.Index.ContainsKey(new VFSDirectoryPath("docs")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSDirectoryPath("docs/sub")).ShouldBeTrue();
        vfs.Index.TryGetFile(new VFSFilePath("docs/sub/a.txt"), out var a).ShouldBeTrue();
        a!.Content.ShouldBe("A");
        vfs.Index.TryGetFile(new VFSFilePath("docs/b.txt"), out var b).ShouldBeTrue();
        b!.Content.ShouldBe("B");
    }

    [Fact]
    public void A_failing_inverse_does_not_permanently_disable_history_tracking()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFile("a.txt", "a");

        // Inject a change whose inverse will throw (moving a file that doesn't exist).
        vfs.ChangeHistory.AddChange(
            new VFSFileMovedArgs(new VFSFilePath("ghost.txt"), new VFSFilePath("ghost2.txt")));

        // Act — the inverse throws...
        Should.Throw<VirtualFileSystemException>(() => vfs.ChangeHistory.Undo());

        // ...but history tracking must recover and keep recording new operations.
        vfs.CreateFile("b.txt", "b");

        // Assert
        vfs.ChangeHistory.UndoStack
            .OfType<VFSFileCreatedArgs>()
            .ShouldContain(created => created.Path.Value.EndsWith("b.txt"));
    }
}
