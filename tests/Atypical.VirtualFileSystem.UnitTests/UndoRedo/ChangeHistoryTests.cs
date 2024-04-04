namespace VirtualFileSystem.UnitTests.UndoRedo;

public class ChangeHistoryTests
{
    [Fact]
    public void AddChange_AddsChangeToUndoStackAndClearsRedoStack()
    {
        // Arrange
        var vfs = new VFS();
        var filePath = new VFSFilePath("file.txt");
        var change = new VFSFileCreatedArgs(filePath, "content");

        // Act
        vfs.ChangeHistory.AddChange(change);

        // Assert
        vfs.ChangeHistory.UndoStack.Should().Contain(change);
        vfs.ChangeHistory.RedoStack.Should().NotContain(change);
    }

    [Fact]
    public void Undo_UndoesMostRecentChangeAndMovesItToRedoStack()
    {
        // Arrange
        var vfs = new VFS();
        var filePath = new VFSFilePath("file.txt");
        vfs.CreateFile(filePath);

        // Check if the file exists in the index
        if (!vfs.Index.ContainsKey(filePath))
            throw new Exception($"The file '{filePath}' was not properly created.");

        // Act
        vfs.ChangeHistory.Undo();

        // Assert
        vfs.ChangeHistory.UndoStack.Should().BeEmpty();
        vfs.ChangeHistory.RedoStack.Should().HaveCount(1);
    }

    [Fact]
    public void Redo_RedoesMostRecentUndoneChangeAndMovesItBackToUndoStack()
    {
        // Arrange
        var vfs = new VFS();
        var filePath = new VFSFilePath("file.txt");
        vfs.CreateFile(filePath);
        
        // Check if the file exists in the index
        if (!vfs.Index.ContainsKey(filePath))
            throw new Exception($"The file '{filePath}' was not properly created.");
        
        // vfs.ChangeHistory.AddChange(change);
        vfs.ChangeHistory.Undo();

        // Act
        vfs.ChangeHistory.Redo();

        // Assert
        vfs.ChangeHistory.RedoStack.Should().BeEmpty();
        vfs.ChangeHistory.UndoStack.Should().HaveCount(1);
    }

    [Fact]
    public void Dispose_UnsubscribesFromAllVFSEvents()
    {
        // Arrange
        var vfs = new VFS();
        var changeHistory = new ChangeHistory(vfs);
        var filePath = new VFSFilePath("file.txt");

        // Act
        changeHistory.Dispose();

        // Add a change and check that it's not added to the undo stack
        vfs.CreateFile(filePath);

        // Assert
        changeHistory.UndoStack.Should().BeEmpty();
    }
}
    