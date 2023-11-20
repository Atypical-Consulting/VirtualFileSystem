namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_Constructor_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void Constructor_creates_a_new_file_system()
    {
        // Act
        var vfs = CreateVFS();

        // Assert
        vfs.Should().NotBeNull();
        vfs.IsEmpty.Should().BeTrue();
        vfs.Root.IsDirectory.Should().BeTrue();
        vfs.Root.IsFile.Should().BeFalse();
        vfs.Root.Path.Value.Should().Be("vfs://");
        vfs.Root.CreationTime.Should().BeCloseTo(DateTime.Now, TimeSpan.FromHours(1));
    }
}