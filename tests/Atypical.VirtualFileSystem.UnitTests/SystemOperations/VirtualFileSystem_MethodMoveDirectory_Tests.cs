namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_MethodMoveDirectory_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void MoveDirectory_moves_a_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);
        var indexLength = vfs.Index.Count;

        // Act
        vfs.MoveDirectory(directoryPath, new VFSDirectoryPath("new_dir"));

        // Assert
        vfs.Index.Count.Should().Be(indexLength);
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://new_dir"));
    }

    [Fact]
    public void MoveDirectory_updates_the_directory_path()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);

        // Act
        vfs.MoveDirectory(directoryPath, new VFSDirectoryPath("new_dir"));

        // Assert
        vfs.Index[new VFSDirectoryPath("vfs://new_dir")].Path.Value
            .Should().Be("vfs://new_dir");
    }

    [Fact]
    public void MoveDirectory_updates_the_last_write_time()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);
        var creationTime = vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].CreationTime;
        var lastAccessTime = vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastAccessTime;
        var lastWriteTime = vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastWriteTime;

        // Act
        vfs.MoveDirectory(directoryPath, new VFSDirectoryPath("new_dir"));

        // Assert
        vfs.Index[new VFSDirectoryPath("vfs://new_dir")].CreationTime.Should().Be(creationTime);
        vfs.Index[new VFSDirectoryPath("vfs://new_dir")].LastAccessTime.Should().Be(lastAccessTime);
        vfs.Index[new VFSDirectoryPath("vfs://new_dir")].LastWriteTime.Should().NotBe(lastWriteTime);
    }

    [Fact]
    public void MoveDirectory_throws_an_exception_if_the_directory_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");

        // Act
        Action action = () => vfs.MoveDirectory(directoryPath, new VFSDirectoryPath("new_dir"));

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The directory 'vfs://dir1/dir2/dir3' does not exist in the index.");
    }

    [Fact]
    public void MoveDirectory_raises_a_DirectoryMoved_event()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);
        bool eventRaised = false;

        vfs.DirectoryMoved += args => 
        {
            eventRaised = true;
            args.SourcePath.Should().Be(directoryPath);
            args.DestinationPath.Should().Be(new VFSDirectoryPath("new_dir"));
        };

        // Act
        vfs.MoveDirectory(directoryPath, new VFSDirectoryPath("new_dir"));

        // Assert
        eventRaised.Should().BeTrue();
    }
}