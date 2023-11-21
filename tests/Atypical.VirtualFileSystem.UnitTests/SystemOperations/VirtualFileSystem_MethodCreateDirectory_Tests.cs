namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_MethodCreateDirectory_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void CreateDirectory_creates_a_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1");

        // Act
        vfs.CreateDirectory(directoryPath);

        // Assert
        vfs.IsEmpty.Should().BeFalse();
        vfs.Index.RawIndex.Should().NotBeEmpty();
        vfs.Index.RawIndex.Should().HaveCount(1);
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1"));
        vfs.Root.IsDirectory.Should().BeTrue();
        vfs.Root.IsFile.Should().BeFalse();
        vfs.Root.Path.Value.Should().Be("vfs://");
        vfs.Root.CreationTime.Should().BeCloseTo(DateTime.Now, TimeSpan.FromHours(1));
    }

    [Fact]
    public void CreateDirectory_creates_a_directory_and_its_parents()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1/dir2/dir3");

        // Act
        vfs.CreateDirectory(directoryPath);

        // Assert
        vfs.Index.RawIndex.Should().NotBeEmpty();
        vfs.Index.RawIndex.Should().HaveCount(3); // dir1 + dir2 + dir3
        vfs.Index.RawIndex.Should().ContainKey(directoryPath);
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1"));
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2"));
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
            
        vfs.Index[new VFSDirectoryPath("vfs://dir1")].Should().BeAssignableTo<IDirectoryNode>();
        vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2")].Should().BeAssignableTo<IDirectoryNode>();
        vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].Should().BeAssignableTo<IDirectoryNode>();
            
        vfs.Index[new VFSDirectoryPath("vfs://dir1")].As<IDirectoryNode>().Directories.Should().NotBeEmpty();
        vfs.Index[new VFSDirectoryPath("vfs://dir1")].As<IDirectoryNode>().Directories.Should().HaveCount(1);
    }

    [Fact]
    public void CreateDirectory_throws_an_exception_if_the_directory_already_exists()
    {
        // Arrange
        var vfs = CreateVFS();
        var directoryPath = new VFSDirectoryPath("dir1");
        vfs.CreateDirectory(directoryPath);

        // Act
        Action action = () => vfs.CreateDirectory(directoryPath);

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage($"The node 'vfs://dir1' already exists in the index.");
    }
        
    [Fact]
    public void CreateDirectory_throws_an_exception_if_the_path_is_the_root_directory()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act
        Action action = () => vfs.CreateDirectory(new VFSRootPath());

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("Cannot create the root directory.");
    }

    [Fact]
    public void CreateDirectory_raises_a_DirectoryCreated_event()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1");
        bool eventRaised = false;

        vfs.DirectoryCreated += (args) => 
        {
            eventRaised = true;
            args.Path.Should().Be(directoryPath);
        };

        // Act
        vfs.CreateDirectory(directoryPath);

        // Assert
        eventRaised.Should().BeTrue();
    }
}