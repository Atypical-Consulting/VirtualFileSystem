namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodGetDirectory_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void GetDirectory_returns_the_root_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        var rootPath = new VFSRootPath();

        // Act
        var root = vfs.GetDirectory(rootPath);

        // Assert
        root.ShouldNotBeNull();
        root.Path.Value.ShouldBe("vfs://");
    }

    [Fact]
    public void GetDirectory_returns_a_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);

        // Act
        var directory = vfs.GetDirectory(directoryPath);

        // Assert
        directory.ShouldNotBeNull();
        directory.Path.Value.ShouldBe("vfs://dir1/dir2/dir3");
    }

    [Fact]
    public void GetDirectory_throws_an_exception_if_the_directory_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1/dir2/dir3");

        // Act
        Action action = () => vfs.GetDirectory(directoryPath);

        // Assert
        Should.Throw<KeyNotFoundException>(action);
    }
}