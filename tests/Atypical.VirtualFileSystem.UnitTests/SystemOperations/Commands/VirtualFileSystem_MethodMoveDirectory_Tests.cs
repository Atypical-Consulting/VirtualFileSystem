namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodMoveDirectory_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private readonly VFSDirectoryPath _directoryPath = new("dir1/dir2/dir3");
    private readonly VFSDirectoryPath _newDirectoryPath = new("new_dir");
    
    private void Act()
        => _vfs.MoveDirectory(_directoryPath, _newDirectoryPath);

    [Fact]
    public void MoveDirectory_moves_a_directory()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var indexLength = _vfs.Index.Count;

        // Act
        Act();

        // Assert
        _vfs.Index.Count.Should().Be(indexLength);
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://new_dir"));
    }

    [Fact]
    public void MoveDirectory_updates_the_directory_path()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);

        // Act
        Act();

        // Assert
        _vfs.Index[new VFSDirectoryPath("vfs://new_dir")].Path.Value
            .Should().Be("vfs://new_dir");
    }

    [Fact]
    public void MoveDirectory_updates_the_last_write_time()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var creationTime = _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].CreationTime;
        var lastAccessTime = _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastAccessTime;
        var lastWriteTime = _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastWriteTime;

        // Act
        Act();

        // Assert
        _vfs.Index[new VFSDirectoryPath("vfs://new_dir")].CreationTime.Should().Be(creationTime);
        _vfs.Index[new VFSDirectoryPath("vfs://new_dir")].LastAccessTime.Should().Be(lastAccessTime);
        _vfs.Index[new VFSDirectoryPath("vfs://new_dir")].LastWriteTime.Should().NotBe(lastWriteTime);
    }

    [Fact]
    public void MoveDirectory_throws_an_exception_if_the_directory_does_not_exist()
    {
        // Act
        var action = Act;

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The directory 'vfs://dir1/dir2/dir3' does not exist in the index.");
    }

    [Fact]
    public void MoveDirectory_raises_a_DirectoryMoved_event()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var eventRaised = false;

        _vfs.DirectoryMoved += args => 
        {
            eventRaised = true;
            args.SourcePath.Should().Be(_directoryPath);
            args.DestinationPath.Should().Be(_newDirectoryPath);
        };

        // Act
        Act();

        // Assert
        eventRaised.Should().BeTrue();
    }
    
    [Fact]
    public void MoveDirectory_adds_a_change_to_the_ChangeHistory()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);

        // Act
        Act();

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        _vfs.ChangeHistory.UndoStack.Should().ContainEquivalentOf(change);
        _vfs.ChangeHistory.UndoStack.Should().HaveCount(4);
        _vfs.ChangeHistory.RedoStack.Should().BeEmpty();
    }
}