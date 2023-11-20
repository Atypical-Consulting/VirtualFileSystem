namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_MethodCreateFile_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void CreateFile_creates_a_file()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSFilePath filePath = new("file.txt");

        // Act
        vfs.CreateFile(filePath);
            
        // Assert
        vfs.IsEmpty.Should().BeFalse();
        vfs.Index.RawIndex.Should().NotBeEmpty();
        vfs.Index.RawIndex.Should().HaveCount(1);
        vfs.Index.RawIndex.Should().ContainKey(new VFSFilePath("vfs://file.txt"));
        vfs.Root.Files.Should().NotBeEmpty();
        vfs.Root.Files.Should().HaveCount(1);
    }

    [Fact]
    public void CreateFile_creates_a_file_and_its_parents()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSFilePath filePath = new("dir1/dir2/dir3/file.txt");
            
        // Act
        vfs.CreateFile(filePath);
            
        // Assert
        vfs.IsEmpty.Should().BeFalse();
        vfs.Index.RawIndex.Should().NotBeEmpty();
        vfs.Index.RawIndex.Should().HaveCount(4); // dir1 + dir2 + dir3 + file.txt
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1"));
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2"));
        vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
        vfs.Index.RawIndex.Should().ContainKey(new VFSFilePath("vfs://dir1/dir2/dir3/file.txt"));
        vfs.Root.Directories.Should().NotBeEmpty();
        vfs.Root.Directories.Should().HaveCount(1);
    }

    [Fact]
    public void CreateFile_throws_an_exception_if_the_file_already_exists()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);

        // Act
        Action action = () => vfs.CreateFile(filePath);

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The node 'vfs://dir1/dir2/dir3/file.txt' already exists in the index.");
    }
}