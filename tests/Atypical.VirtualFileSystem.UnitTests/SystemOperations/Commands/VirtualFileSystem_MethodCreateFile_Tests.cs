namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodCreateFile_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private VFSFilePath _filePath = new("file.txt");
    
    private void Act()
        => _vfs.CreateFile(_filePath);
    
    [Fact]
    public void CreateFile_creates_a_file()
    {
        // Act
        Act();
            
        // Assert
        _vfs.IsEmpty.ShouldBeFalse();
        _vfs.Index.RawIndex.ShouldNotBeEmpty();
        _vfs.Index.RawIndex.Count.ShouldBe(1);
        _vfs.Index.RawIndex.ShouldContainKey(new VFSFilePath("vfs://file.txt"));
        _vfs.Root.Files.ShouldNotBeEmpty();
        _vfs.Root.Files.Count().ShouldBe(1);
    }

    [Fact]
    public void CreateFile_creates_a_file_and_its_parents()
    {
        // Arrange
        _filePath = new("dir1/dir2/dir3/file.txt");
            
        // Act
        Act();
            
        // Assert
        _vfs.IsEmpty.ShouldBeFalse();
        _vfs.Index.RawIndex.ShouldNotBeEmpty();
        _vfs.Index.RawIndex.Count.ShouldBe(4); // dir1 + dir2 + dir3 + file.txt
        _vfs.Index.RawIndex.ShouldContainKey(new VFSDirectoryPath("vfs://dir1"));
        _vfs.Index.RawIndex.ShouldContainKey(new VFSDirectoryPath("vfs://dir1/dir2"));
        _vfs.Index.RawIndex.ShouldContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
        _vfs.Index.RawIndex.ShouldContainKey(new VFSFilePath("vfs://dir1/dir2/dir3/file.txt"));
        _vfs.Root.Directories.ShouldNotBeEmpty();
        _vfs.Root.Directories.Count().ShouldBe(1);
    }

    [Fact]
    public void CreateFile_throws_an_exception_if_the_file_already_exists()
    {
        // Arrange
        _filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        Act();

        // Act
        var action = Act;

        // Assert
        var ex = Should.Throw<VirtualFileSystemException>(action);
        ex.Message.ShouldBe("The node 'vfs://dir1/dir2/dir3/file.txt' already exists in the index.");
    }
    
    [Fact]
    public void CreateFile_raises_a_FileCreated_event()
    {
        // Arrange
        var eventRaised = false;

        _vfs.FileCreated += args => 
        {
            eventRaised = true;
            args.Path.ShouldBe(_filePath);
        };

        // Act
        Act();

        // Assert
        eventRaised.ShouldBeTrue();
    }
    
    [Fact]
    public void CreateFile_adds_a_change_to_the_ChangeHistory()
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