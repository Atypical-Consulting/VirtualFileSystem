namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodRenameDirectory_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void RenameDirectory_renames_a_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);
        var indexLength = vfs.Index.Count;
        var tree = vfs.GetTree();

        // Act
        vfs.RenameDirectory(directoryPath, "new_dir");

        // Assert
        vfs.Index.Count.Should().Be(indexLength);
        vfs.Index.RawIndex.Should().NotContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2/new_dir"));
        vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].IsDirectory.Should().BeTrue();
        vfs.GetTree().Should().NotBe(tree);
    }
        
    [Fact]
    public void RenameDirectory_updates_the_directory_path()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);

        // Act
        vfs.RenameDirectory(directoryPath, "new_dir");

        // Assert
        vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].Path.Value
            .Should().Be("vfs://dir1/dir2/new_dir");
    }
        
    [Fact]
    public void RenameDirectory_updates_the_last_write_time()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);
        var creationTime = vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].CreationTime;
        var lastAccessTime = vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastAccessTime;
        var lastWriteTime = vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastWriteTime;

        // Act
        Thread.Sleep(100);
        vfs.RenameDirectory(directoryPath, "new_dir");

        // Assert
        vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].CreationTime.Should().Be(creationTime);
        vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].LastAccessTime.Should().Be(lastAccessTime);
        vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].LastWriteTime.Should().NotBe(lastWriteTime);
    }
    
    [Fact]
    public void RenameDirectory_throws_an_exception_if_the_directory_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");

        // Act
        Action action = () => vfs.RenameDirectory(directoryPath, "new_dir");

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The directory 'vfs://dir1/dir2/dir3' does not exist in the index.");
    }
    
    [Fact]
    public void RenameDirectory_raises_a_DirectoryRenamed_event()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);
        bool eventRaised = false;

        vfs.DirectoryRenamed += args => 
        {
            eventRaised = true;
            args.Path.Should().Be(directoryPath);
            args.NewName.Should().Be("new_dir");
        };

        // Act
        vfs.RenameDirectory(directoryPath, "new_dir");

        // Assert
        eventRaised.Should().BeTrue();
    }
    
    [Fact]
    public void RenameDirectory_adds_a_change_to_the_ChangeHistory()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);

        // Act
        vfs.RenameDirectory(directoryPath, "new_dir");

        // Retrieve the change from the UndoStack
        var change = vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        vfs.ChangeHistory.UndoStack.Should().ContainEquivalentOf(change);
        vfs.ChangeHistory.UndoStack.Should().HaveCount(1);
        vfs.ChangeHistory.RedoStack.Should().BeEmpty();
    }
}