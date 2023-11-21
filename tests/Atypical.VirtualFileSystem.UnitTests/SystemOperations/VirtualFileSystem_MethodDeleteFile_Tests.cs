namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_MethodDeleteFile_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void DeleteFile_deletes_a_file()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);

        // Act
        vfs.DeleteFile(filePath);

        // Assert
        vfs.Index.Count.Should().Be(3); // dir1, dir2, dir3
    }

    [Fact]
    public void DeleteFile_throws_an_exception_if_the_file_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act
        Action action = () => vfs.DeleteFile(new VFSFilePath("dir1/dir2/dir3/file.txt"));

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The file 'vfs://dir1/dir2/dir3/file.txt' does not exist in the index.");
    }
    
    [Fact]
    public void DeleteFile_raises_a_FileDeleted_event()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);

        // Act
        vfs.DeleteFile(filePath);

        // Assert
        vfs.Index.Count.Should().Be(3); // dir1, dir2, dir3
    }
}