namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodDeleteDirectory_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private VFSDirectoryPath _directoryPath = new("dir1");
    
    private void Act()
        => _vfs.DeleteDirectory(_directoryPath);

    [Fact]
    public void DeleteDirectory_deletes_a_directory()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);

        // Act
        Act();

        // Assert
        _vfs.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void DeleteDirectory_deletes_a_directory_and_its_children()
    {
        // Arrange
        _directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        _vfs.CreateDirectory(_directoryPath);

        // Act
        VFSDirectoryPath ancestorPath = new("dir1");
        _vfs.DeleteDirectory(ancestorPath);

        // Assert
        _vfs.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void DeleteDirectory_throws_an_exception_if_the_directory_does_not_exist()
    {
        // Act
        var action = Act;

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The directory 'vfs://dir1' does not exist in the index.");
    }
        
    [Fact]
    public void DeleteDirectory_throws_an_exception_if_the_path_is_the_root_directory()
    {
        // Arrange
        _directoryPath = new VFSRootPath();

        // Act
        var action = () => Act();

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("Cannot delete the root directory.");
    }
    
    [Fact]
    public void DeleteDirectory_raises_a_DirectoryDeleted_event()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var eventRaised = false;

        _vfs.DirectoryDeleted += args => 
        {
            eventRaised = true;
            args.Path.Should().Be(_directoryPath);
        };

        // Act
        Act();

        // Assert
        eventRaised.Should().BeTrue();
    }
    
    [Fact]
    public void DeleteDirectory_adds_a_change_to_the_ChangeHistory()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);

        // Act
        Act();

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        _vfs.ChangeHistory.UndoStack.Should().ContainEquivalentOf(change);
        _vfs.ChangeHistory.UndoStack.Should().HaveCount(2);
        _vfs.ChangeHistory.RedoStack.Should().BeEmpty();
    }
}