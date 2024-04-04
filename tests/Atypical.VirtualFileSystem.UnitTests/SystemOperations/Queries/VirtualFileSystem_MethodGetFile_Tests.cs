namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodGetFile_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void GetFile_returns_the_file()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSFilePath filePath = new("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);

        // Act
        var file = vfs.GetFile(filePath);

        // Assert
        file.Should().NotBeNull();
        file.Path.Value.Should().Be("vfs://dir1/dir2/dir3/file.txt");
    }

    [Fact]
    public void GetFile_throws_an_exception_if_the_file_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSFilePath filePath = new("dir1/dir2/dir3/file.txt");  

        // Act
        Action action = () => vfs.GetFile(filePath);

        // Assert
        action.Should().Throw<KeyNotFoundException>();
    }
}