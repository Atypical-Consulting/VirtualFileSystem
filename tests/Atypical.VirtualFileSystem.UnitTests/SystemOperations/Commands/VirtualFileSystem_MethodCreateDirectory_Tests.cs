namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodCreateDirectory_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private VFSDirectoryPath _directoryPath = new("dir1");

    private void Act()
        => _vfs.CreateDirectory(_directoryPath);
    
    [Fact]
    public void CreateDirectory_creates_a_directory()
    {
        // Act
        Act();

        // Assert
        _vfs.IsEmpty.Should().BeFalse();
        _vfs.Index.RawIndex.Should().NotBeEmpty();
        _vfs.Index.RawIndex.Should().HaveCount(1);
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1"));
        _vfs.Root.IsDirectory.Should().BeTrue();
        _vfs.Root.IsFile.Should().BeFalse();
        _vfs.Root.Path.Value.Should().Be("vfs://");
        _vfs.Root.CreationTime.Should().BeCloseTo(DateTime.Now, TimeSpan.FromHours(1));
    }

    [Fact]
    public void CreateDirectory_creates_a_directory_and_its_parents()
    {
        // Arrange
        _directoryPath = new("dir1/dir2/dir3");

        // Act
        Act();

        // Assert
        _vfs.Index.RawIndex.Should().NotBeEmpty();
        _vfs.Index.RawIndex.Should().HaveCount(3); // dir1 + dir2 + dir3
        _vfs.Index.RawIndex.Should().ContainKey(_directoryPath);
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1"));
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2"));
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
            
        _vfs.Index[new VFSDirectoryPath("vfs://dir1")].Should().BeAssignableTo<IDirectoryNode>();
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2")].Should().BeAssignableTo<IDirectoryNode>();
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].Should().BeAssignableTo<IDirectoryNode>();
            
        _vfs.Index[new VFSDirectoryPath("vfs://dir1")].As<IDirectoryNode>().Directories.Should().NotBeEmpty();
        _vfs.Index[new VFSDirectoryPath("vfs://dir1")].As<IDirectoryNode>().Directories.Should().HaveCount(1);
    }

    [Fact]
    public void CreateDirectory_throws_an_exception_if_the_directory_already_exists()
    {
        // Arrange
        Act();

        // Act
        var action = Act;

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage($"The node 'vfs://dir1' already exists in the index.");
    }
        
    [Fact]
    public void CreateDirectory_throws_an_exception_if_the_path_is_the_root_directory()
    {
        // Act
        Action action = () => _vfs.CreateDirectory(new VFSRootPath());

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("Cannot create the root directory.");
    }

    [Fact]
    public void CreateDirectory_raises_a_DirectoryCreated_event()
    {
        // Arrange
        var eventRaised = false;

        _vfs.DirectoryCreated += args => 
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
    public void CreateDirectory_adds_a_change_to_the_ChangeHistory()
    {
        // Act
        Act();

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        _vfs.ChangeHistory.UndoStack.Should().ContainEquivalentOf(change);
        _vfs.ChangeHistory.UndoStack.Should().HaveCount(1);
        _vfs.ChangeHistory.RedoStack.Should().BeEmpty();
    }
}