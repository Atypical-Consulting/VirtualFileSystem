namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodSelectDirectories_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void SelectDirectories_returns_all_directories()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateDirectory(new VFSDirectoryPath("dir1"));
        vfs.CreateDirectory(new VFSDirectoryPath("dir2"));
        vfs.CreateDirectory(new VFSDirectoryPath("dir3"));

        // Act
        var directories = vfs
            .FindDirectories(x => x.IsDirectory)
            .ToList();

        // Assert
        directories.ShouldNotBeEmpty();
        directories.Count.ShouldBe(3); // dir1 + dir2 + dir3
        directories.ShouldContain(d => d.Path.Value == "vfs://dir1");
        directories.ShouldContain(d => d.Path.Value == "vfs://dir2");
        directories.ShouldContain(d => d.Path.Value == "vfs://dir3");
    }
}