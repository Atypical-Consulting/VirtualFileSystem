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
        _vfs.IsEmpty.Should().BeFalse();
        _vfs.Index.RawIndex.Should().NotBeEmpty();
        _vfs.Index.RawIndex.Should().HaveCount(1);
        _vfs.Index.RawIndex.Should().ContainKey(new VFSFilePath("vfs://file.txt"));
        _vfs.Root.Files.Should().NotBeEmpty();
        _vfs.Root.Files.Should().HaveCount(1);
    }

    [Fact]
    public void CreateFile_creates_a_file_and_its_parents()
    {
        // Arrange
        _filePath = new("dir1/dir2/dir3/file.txt");
            
        // Act
        Act();
            
        // Assert
        _vfs.IsEmpty.Should().BeFalse();
        _vfs.Index.RawIndex.Should().NotBeEmpty();
        _vfs.Index.RawIndex.Should().HaveCount(4); // dir1 + dir2 + dir3 + file.txt
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1"));
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2"));
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
        _vfs.Index.RawIndex.Should().ContainKey(new VFSFilePath("vfs://dir1/dir2/dir3/file.txt"));
        _vfs.Root.Directories.Should().NotBeEmpty();
        _vfs.Root.Directories.Should().HaveCount(1);
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
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The node 'vfs://dir1/dir2/dir3/file.txt' already exists in the index.");
    }
    
    [Fact]
    public void CreateFile_raises_a_FileCreated_event()
    {
        // Arrange
        var eventRaised = false;

        _vfs.FileCreated += args => 
        {
            eventRaised = true;
            args.Path.Should().Be(_filePath);
        };

        // Act
        Act();

        // Assert
        eventRaised.Should().BeTrue();
    }
    
    [Fact]
    public void CreateFile_adds_a_change_to_the_ChangeHistory()
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