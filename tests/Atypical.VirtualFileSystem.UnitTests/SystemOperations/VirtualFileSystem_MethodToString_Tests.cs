namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_MethodToString_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void ToString_returns_a_summary_of_the_VFS()
    {
        // Arrange
        const string expected = "VFS: 3 files, 3 directories";

        var vfs = new VFS()
            .CreateFile(new VFSFilePath("file1.txt"))
            .CreateFile(new VFSFilePath("file2.txt"))
            .CreateFile(new VFSFilePath("file3.txt"))
            .CreateDirectory(new VFSDirectoryPath("dir1"))
            .CreateDirectory(new VFSDirectoryPath("dir2"))
            .CreateDirectory(new VFSDirectoryPath("dir3"));

        // Act
        var result = vfs.ToString();

        // Assert
        result.Should().Be(expected);
    }
}