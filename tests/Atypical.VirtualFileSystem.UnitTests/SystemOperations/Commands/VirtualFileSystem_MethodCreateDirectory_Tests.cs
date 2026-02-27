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
        _vfs.IsEmpty.ShouldBeFalse();
        _vfs.Index.RawIndex.ShouldNotBeEmpty();
        _vfs.Index.RawIndex.Count.ShouldBe(1);
        _vfs.Index.RawIndex.ShouldContainKey(new VFSDirectoryPath("vfs://dir1"));
        _vfs.Root.IsDirectory.ShouldBeTrue();
        _vfs.Root.IsFile.ShouldBeFalse();
        _vfs.Root.Path.Value.ShouldBe("vfs://");
        (DateTime.Now - _vfs.Root.CreationTime).ShouldBeLessThan(TimeSpan.FromHours(1));
    }

    [Fact]
    public void CreateDirectory_creates_a_directory_and_its_parents()
    {
        // Arrange
        _directoryPath = new("dir1/dir2/dir3");

        // Act
        Act();

        // Assert
        _vfs.Index.RawIndex.ShouldNotBeEmpty();
        _vfs.Index.RawIndex.Count.ShouldBe(3); // dir1 + dir2 + dir3
        _vfs.Index.RawIndex.ShouldContainKey(_directoryPath);
        _vfs.Index.RawIndex.ShouldContainKey(new VFSDirectoryPath("vfs://dir1"));
        _vfs.Index.RawIndex.ShouldContainKey(new VFSDirectoryPath("vfs://dir1/dir2"));
        _vfs.Index.RawIndex.ShouldContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
            
        _vfs.Index[new VFSDirectoryPath("vfs://dir1")].ShouldBeAssignableTo<IDirectoryNode>();
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2")].ShouldBeAssignableTo<IDirectoryNode>();
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].ShouldBeAssignableTo<IDirectoryNode>();
            
        ((IDirectoryNode)_vfs.Index[new VFSDirectoryPath("vfs://dir1")]).Directories.ShouldNotBeEmpty();
        ((IDirectoryNode)_vfs.Index[new VFSDirectoryPath("vfs://dir1")]).Directories.Count().ShouldBe(1);
    }

    [Fact]
    public void CreateDirectory_throws_an_exception_if_the_directory_already_exists()
    {
        // Arrange
        Act();

        // Act
        var action = Act;

        // Assert
        var ex = Should.Throw<VirtualFileSystemException>(action);
        ex.Message.ShouldBe("The node 'vfs://dir1' already exists in the index.");
    }
        
    [Fact]
    public void CreateDirectory_throws_an_exception_if_the_path_is_the_root_directory()
    {
        // Act
        Action action = () => _vfs.CreateDirectory(new VFSRootPath());

        // Assert
        var ex = Should.Throw<VirtualFileSystemException>(action);
        ex.Message.ShouldBe("Cannot create the root directory.");
    }

    [Fact]
    public void CreateDirectory_raises_a_DirectoryCreated_event()
    {
        // Arrange
        var eventRaised = false;

        _vfs.DirectoryCreated += args => 
        {
            eventRaised = true;
            args.Path.ShouldBe(_directoryPath);
        };

        // Act
        Act();

        // Assert
        eventRaised.ShouldBeTrue();
    }
    
    [Fact]
    public void CreateDirectory_adds_a_change_to_the_ChangeHistory()
    {
        // Act
        Act();

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        _vfs.ChangeHistory.UndoStack.ShouldContain(change);
        _vfs.ChangeHistory.UndoStack.Count.ShouldBe(1);
        _vfs.ChangeHistory.RedoStack.ShouldBeEmpty();
    }
}