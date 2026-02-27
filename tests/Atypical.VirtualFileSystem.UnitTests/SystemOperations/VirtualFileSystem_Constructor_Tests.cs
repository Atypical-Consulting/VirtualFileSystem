namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_Constructor_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void Constructor_creates_a_new_file_system()
    {
        // Act
        var vfs = CreateVFS();

        // Assert
        vfs.ShouldNotBeNull();
        vfs.IsEmpty.ShouldBeTrue();
        vfs.Root.IsDirectory.ShouldBeTrue();
        vfs.Root.IsFile.ShouldBeFalse();
        vfs.Root.Path.Value.ShouldBe("vfs://");
        (DateTime.Now - vfs.Root.CreationTime).ShouldBeLessThan(TimeSpan.FromHours(1));
    }
}