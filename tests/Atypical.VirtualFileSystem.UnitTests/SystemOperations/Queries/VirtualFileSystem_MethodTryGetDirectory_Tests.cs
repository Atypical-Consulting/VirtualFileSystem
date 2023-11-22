namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodTryGetDirectory_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void TryGetDirectory_returns_true_if_the_directory_exists()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.TryGetDirectory(directoryPath, out var directory);

        // Assert
        result.Should().BeTrue();
        directory.Should().NotBeNull();
        directory!.Path.Value.Should().Be("vfs://dir1/dir2/dir3");
    }

    [Fact]
    public void TryGetDirectory_returns_false_if_the_directory_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1/dir2/dir3");

        // Act
        var result = vfs.TryGetDirectory(directoryPath, out var directory);

        // Assert
        result.Should().BeFalse();
        directory.Should().BeNull();
    }
}