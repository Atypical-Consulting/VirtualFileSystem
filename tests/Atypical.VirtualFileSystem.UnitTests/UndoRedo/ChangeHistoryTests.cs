namespace VirtualFileSystem.UnitTests.UndoRedo;

public class ChangeHistoryTests
{
    [Fact]
    public void AddChange_AddsChangeToUndoStackAndClearsRedoStack()
    {
        // Arrange
        var vfs = new VFS();
        var changeHistory = new ChangeHistory(vfs);
        var change = new VFSFileCreatedArgs(new VFSFilePath("file.txt"), "content");

        // Act
        changeHistory.AddChange(change);

        // Assert
        changeHistory.UndoStack.Should().Contain(change);
        changeHistory.RedoStack.Should().NotContain(change);
    }

    [Fact]
    public void Undo_UndoesMostRecentChangeAndMovesItToRedoStack()
    {
        // Arrange
        var vfs = new VFS();
        var changeHistory = new ChangeHistory(vfs);
        var filePath = new VFSFilePath("file.txt");
        var change = new VFSFileCreatedArgs(filePath, "content");
        vfs.CreateFile(filePath); // Ensure the file is created and added to the index

        // Check if the file exists in the index
        if (!vfs.Index.ContainsKey(filePath))
            throw new Exception($"The file '{filePath}' was not properly created.");

        changeHistory.AddChange(change);

        // Act
        changeHistory.Undo();

        // Assert
        changeHistory.UndoStack.Should().BeEmpty();
        changeHistory.RedoStack.Should().Contain(change);
        changeHistory.RedoStack.Should().HaveCount(1);
    }

    [Fact]
    public void Redo_RedoesMostRecentUndoneChangeAndMovesItBackToUndoStack()
    {
        // Arrange
        var vfs = new VFS();
        var changeHistory = new ChangeHistory(vfs);
        var filePath = new VFSFilePath("file.txt");
        var change = new VFSFileCreatedArgs(filePath, "content");
        vfs.CreateFile(filePath);
        
        // Check if the file exists in the index
        if (!vfs.Index.ContainsKey(filePath))
            throw new Exception($"The file '{filePath}' was not properly created.");
        
        changeHistory.AddChange(change);
        changeHistory.Undo();

        // Act
        changeHistory.Redo();

        // Assert
        changeHistory.RedoStack.Should().BeEmpty();
        changeHistory.UndoStack.Should().Contain(change);
        changeHistory.UndoStack.Should().HaveCount(1);
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
    