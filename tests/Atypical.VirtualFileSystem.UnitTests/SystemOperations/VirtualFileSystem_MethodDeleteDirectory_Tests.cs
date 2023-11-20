namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_MethodDeleteDirectory_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void DeleteDirectory_deletes_a_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1");
        vfs.CreateDirectory(directoryPath);

        // Act
        vfs.DeleteDirectory(directoryPath);

        // Assert
        vfs.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void DeleteDirectory_deletes_a_directory_and_its_children()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1/dir2/dir3");
        vfs.CreateDirectory(directoryPath);

        // Act
        VFSDirectoryPath ancestorPath = new("dir1");
        vfs.DeleteDirectory(ancestorPath);

        // Assert
        vfs.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void DeleteDirectory_throws_an_exception_if_the_directory_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath directoryPath = new("dir1");

        // Act
        Action action = () => vfs.DeleteDirectory(directoryPath);

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The directory 'vfs://dir1' does not exist in the index.");
    }
        
    [Fact]
    public void DeleteDirectory_throws_an_exception_if_the_path_is_the_root_directory()
    {
        // Arrange
        var vfs = CreateVFS();
        VFSDirectoryPath rootPath = new("vfs://");

        // Act
        Action action = () => vfs.DeleteDirectory(rootPath);

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("Cannot delete the root directory.");
    }
}