namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodGetRootPath_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void GetRootPath_returns_the_root_path()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act
        var rootPath = vfs.RootPath;

        // Assert
        rootPath.Should().NotBeNull();
        rootPath.Value.Should().Be("vfs://");
    }
}