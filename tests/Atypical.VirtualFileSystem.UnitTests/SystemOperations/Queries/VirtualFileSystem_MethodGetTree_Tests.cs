namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodGetTree_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void GetTree_returns_root_directory()
    {
        // Arrange
        var vfs = CreateVFS();

        // Act
        var result = vfs.GetTree();

        // Assert
        result.ShouldBe("vfs://");
    }

    [Fact]
    public void GetTree_returns_3_files_as_ASCII_tree()
    {
        // Arrange
        var expected = """
                       vfs://
                       ├── file1.txt
                       ├── file2.txt
                       └── file3.txt
                       """.ReplaceLineEndings();

        var vfs = CreateVFS();
        vfs.CreateFile(new VFSFilePath("file1.txt"));
        vfs.CreateFile(new VFSFilePath("file2.txt"));
        vfs.CreateFile(new VFSFilePath("file3.txt"));

        // Act
        var result = vfs.GetTree();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GetTree_returns_3_directories_as_ASCII_tree()
    {
        // Arrange
        var expected = """
                       vfs://
                       ├── dir1
                       ├── dir2
                       └── dir3
                       """.ReplaceLineEndings();

        var vfs = new VFS()
            .CreateDirectory(new VFSDirectoryPath("dir1"))
            .CreateDirectory(new VFSDirectoryPath("dir2"))
            .CreateDirectory(new VFSDirectoryPath("dir3"));

        // Act
        var result = vfs.GetTree();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GetTree_returns_3_files_and_3_directories_as_ASCII_tree()
    {
        // Arrange
        var expected = """
                       vfs://
                       ├── dir1
                       │   ├── file1.txt
                       │   ├── file2.txt
                       │   └── file3.txt
                       ├── dir2
                       │   ├── file1.txt
                       │   ├── file2.txt
                       │   └── file3.txt
                       └── dir3
                           ├── file1.txt
                           ├── file2.txt
                           └── file3.txt
                       """.ReplaceLineEndings();

        var vfs = new VFS();

        vfs.CreateFile(new VFSFilePath("dir1/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/file3.txt"));
            
        vfs.CreateFile(new VFSFilePath("dir2/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir2/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir2/file3.txt"));
            
        vfs.CreateFile(new VFSFilePath("dir3/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir3/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir3/file3.txt"));

        // Act
        var result = vfs.GetTree();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GetTree_returns_a_complex_tree()
    {
        // Arrange
        var expected = """
                       vfs://
                       ├── dir1
                       │   ├── dir2
                       │   │   ├── dir3
                       │   │   │   ├── file1.txt
                       │   │   │   ├── file2.txt
                       │   │   │   └── file3.txt
                       │   │   ├── file1.txt
                       │   │   ├── file2.txt
                       │   │   └── file3.txt
                       │   ├── file1.txt
                       │   ├── file2.txt
                       │   └── file3.txt
                       ├── dir2
                       │   ├── dir3
                       │   │   ├── file1.txt
                       │   │   ├── file2.txt
                       │   │   └── file3.txt
                       │   ├── file1.txt
                       │   ├── file2.txt
                       │   └── file3.txt
                       └── dir3
                           ├── file1.txt
                           ├── file2.txt
                           └── file3.txt
                       """.ReplaceLineEndings();

        var vfs = new VFS();
            
        vfs.CreateFile(new VFSFilePath("dir1/dir2/dir3/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/dir2/dir3/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/dir2/dir3/file3.txt"));
            
        vfs.CreateFile(new VFSFilePath("dir1/dir2/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/dir2/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/dir2/file3.txt"));
            
        vfs.CreateFile(new VFSFilePath("dir1/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir1/file3.txt"));
            
        vfs.CreateFile(new VFSFilePath("dir2/dir3/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir2/dir3/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir2/dir3/file3.txt"));
            
        vfs.CreateFile(new VFSFilePath("dir2/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir2/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir2/file3.txt"));
            
        vfs.CreateFile(new VFSFilePath("dir3/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir3/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir3/file3.txt"));

        // Act
        var result = vfs.GetTree();

        // Assert
        result.ShouldBe(expected);
    }
}