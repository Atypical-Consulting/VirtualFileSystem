namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodMoveFile_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private readonly VFSFilePath _filePath = new("dir1/dir2/dir3/file.txt");
    private readonly VFSFilePath _newFilePath = new("new_file.txt");
    
    [Fact]
    public void MoveFile_moves_a_file()
    {
        // Arrange
        _vfs.CreateFile(_filePath);
        var indexLength = _vfs.Index.Count;

        // Act
        _vfs.MoveFile(_filePath, _newFilePath);

        // Assert
        _vfs.Index.Count.Should().Be(indexLength);
        _vfs.Index.RawIndex.Should().ContainKey(new VFSFilePath("vfs://new_file.txt"));
    }
        
    [Fact]
    public void MoveFile_updates_the_file_path()
    {
        // Arrange
        _vfs.CreateFile(_filePath);

        // Act
        _vfs.MoveFile(_filePath, _newFilePath);

        // Assert
        _vfs.Index[new VFSFilePath("vfs://new_file.txt")].Path.Value
            .Should().Be("vfs://new_file.txt");
    }
        
    [Fact]
    public void MoveFile_updates_the_last_write_time()
    {
        // Arrange
        _vfs.CreateFile(_filePath);
        var creationTime = _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/file.txt")].CreationTime;
        var lastAccessTime = _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/file.txt")].LastAccessTime;
        var lastWriteTime = _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/file.txt")].LastWriteTime;

        // Act
        _vfs.MoveFile(_filePath, _newFilePath);

        // Assert
        _vfs.Index[new VFSFilePath("vfs://new_file.txt")].CreationTime.Should().Be(creationTime);
        _vfs.Index[new VFSFilePath("vfs://new_file.txt")].LastAccessTime.Should().Be(lastAccessTime);
        _vfs.Index[new VFSFilePath("vfs://new_file.txt")].LastWriteTime.Should().NotBe(lastWriteTime);
    }

    [Fact]
    public void MoveFile_throws_an_exception_if_the_file_does_not_exist()
    {
        // Act
        Action action = () => _vfs.MoveFile(_filePath, _newFilePath);

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The file 'vfs://dir1/dir2/dir3/file.txt' does not exist in the index.");
    }

    [Fact]
    public void MoveFile_raises_a_FileMoved_event()
    {
        // Arrange
        _vfs.CreateFile(_filePath);
        var eventRaised = false;

        _vfs.FileMoved += args => 
        {
            eventRaised = true;
            args.SourcePath.Should().Be(_filePath);
            args.DestinationPath.Should().Be(_newFilePath);
        };

        // Act
        _vfs.MoveFile(_filePath, _newFilePath);

        // Assert
        eventRaised.Should().BeTrue();
    }
    
    [Fact]
    public void MoveFile_adds_a_change_to_the_ChangeHistory()
    {
        // Arrange
        _vfs.CreateFile(_filePath);

        // Act
        _vfs.MoveFile(_filePath, _newFilePath);

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        _vfs.ChangeHistory.UndoStack.Should().ContainEquivalentOf(change);
        _vfs.ChangeHistory.UndoStack.Should().HaveCount(5);
        _vfs.ChangeHistory.RedoStack.Should().BeEmpty();
    }
}