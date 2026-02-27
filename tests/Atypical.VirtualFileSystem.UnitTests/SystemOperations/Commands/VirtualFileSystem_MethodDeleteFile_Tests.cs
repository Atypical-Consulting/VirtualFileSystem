namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodDeleteFile_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private readonly VFSFilePath _filePath = new("dir1/dir2/dir3/file.txt");
    
    private void Act()
        => _vfs.DeleteFile(_filePath);
    
    [Fact]
    public void DeleteFile_deletes_a_file()
    {
        // Arrange
        _vfs.CreateFile(_filePath);

        // Act
        Act();

        // Assert
        _vfs.Index.Count.ShouldBe(3); // dir1, dir2, dir3
    }

    [Fact]
    public void DeleteFile_throws_an_exception_if_the_file_does_not_exist()
    {
        // Act
        var action = Act;

        // Assert
        var ex = Should.Throw<VirtualFileSystemException>(action);
        ex.Message.ShouldBe("The file 'vfs://dir1/dir2/dir3/file.txt' does not exist in the index.");
    }
    
    [Fact]
    public void DeleteFile_raises_a_FileDeleted_event()
    {
        // Arrange
        _vfs.CreateFile(_filePath);

        // Act
        Act();

        // Assert
        _vfs.Index.Count.ShouldBe(3); // dir1, dir2, dir3
    }
    
    [Fact]
    public void DeleteFile_adds_a_change_to_the_ChangeHistory()
    {
        // Arrange
        _vfs.CreateFile(_filePath);

        // Act
        Act();

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        _vfs.ChangeHistory.UndoStack.ShouldContain(change);
        _vfs.ChangeHistory.UndoStack.Count.ShouldBe(5);
        _vfs.ChangeHistory.RedoStack.ShouldBeEmpty();
    }
}