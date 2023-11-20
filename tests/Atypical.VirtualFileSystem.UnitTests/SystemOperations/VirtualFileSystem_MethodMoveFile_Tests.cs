namespace VirtualFileSystem.UnitTests.SystemOperations;

public class VirtualFileSystem_MethodMoveFile_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void MoveFile_moves_a_file()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);
        var indexLength = vfs.Index.Count;

        // Act
        vfs.MoveFile(filePath, new VFSFilePath("new_file.txt"));

        // Assert
        vfs.Index.Count.Should().Be(indexLength);
        vfs.Index.RawIndex.Should().ContainKey("vfs://new_file.txt");
    }
        
    [Fact]
    public void MoveFile_updates_the_file_path()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);

        // Act
        vfs.MoveFile(filePath, new VFSFilePath("new_file.txt"));

        // Assert
        vfs.Index["vfs://new_file.txt"].Path.Value
            .Should().Be("vfs://new_file.txt");
    }
        
    [Fact]
    public void MoveFile_updates_the_last_write_time()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        vfs.CreateFile(filePath);
        var creationTime = vfs.Index["vfs://dir1/dir2/dir3/file.txt"].CreationTime;
        var lastAccessTime = vfs.Index["vfs://dir1/dir2/dir3/file.txt"].LastAccessTime;
        var lastWriteTime = vfs.Index["vfs://dir1/dir2/dir3/file.txt"].LastWriteTime;

        // Act
        vfs.MoveFile(filePath, new VFSFilePath("new_file.txt"));

        // Assert
        vfs.Index["vfs://new_file.txt"].CreationTime.Should().Be(creationTime);
        vfs.Index["vfs://new_file.txt"].LastAccessTime.Should().Be(lastAccessTime);
        vfs.Index["vfs://new_file.txt"].LastWriteTime.Should().NotBe(lastWriteTime);
    }

    [Fact]
    public void MoveFile_throws_an_exception_if_the_file_does_not_exist()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = new VFSFilePath("dir1/dir2/dir3/file.txt");

        // Act
        Action action = () => vfs.MoveFile(filePath, new VFSFilePath("new_file.txt"));

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The file 'vfs://dir1/dir2/dir3/file.txt' does not exist in the index.");
    }
}