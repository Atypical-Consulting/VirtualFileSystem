namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodTryGetFile_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void TryGetFile_returns_the_file()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSFilePath filePath = new("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);

        // Act
        var result = vfs.TryGetFile(filePath, out var file);

        // Assert
        result.ShouldBeTrue();
        file.ShouldNotBeNull();
        file!.Path.Value.ShouldBe("vfs://dir1/dir2/dir3/file.txt");
    }

    [Fact]
    public void TryGetFile_returns_false_if_the_file_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSFilePath filePath = new("dir1/dir2/dir3/file.txt");

        // Act
        var result = vfs.TryGetFile(filePath, out var file);

        // Assert
        result.ShouldBeFalse();
        file.ShouldBeNull();
    }
}