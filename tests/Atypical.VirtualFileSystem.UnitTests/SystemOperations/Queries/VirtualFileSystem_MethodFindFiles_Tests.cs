using System.Text.RegularExpressions;

namespace VirtualFileSystem.UnitTests.SystemOperations.Queries;

public class VirtualFileSystem_MethodFindFiles_Tests : VirtualFileSystemTestsBase
{
    [Fact]
    public void FindFiles_returns_all_files()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateDirectory(new VFSDirectoryPath("dir1"));
        vfs.CreateDirectory(new VFSDirectoryPath("dir2"));
        vfs.CreateDirectory(new VFSDirectoryPath("dir3"));
        vfs.CreateFile(new VFSFilePath("dir1/file1.txt"));
        vfs.CreateFile(new VFSFilePath("dir2/file2.txt"));
        vfs.CreateFile(new VFSFilePath("dir3/file3.txt"));

        // Act
        var files = vfs.Files.ToList();

        // Assert
        files.Should().NotBeEmpty();
        files.Should().HaveCount(3);
        files.Should().Contain(f => f.Path.Value == "vfs://dir1/file1.txt");
        files.Should().Contain(f => f.Path.Value == "vfs://dir2/file2.txt");
        files.Should().Contain(f => f.Path.Value == "vfs://dir3/file3.txt");
    }

    [Fact]
    public void FindFiles_with_valid_data_returns_a_list_of_files_with_content_and_name()
    {
        // Arrange
        var vfs = CreateVFS();
        vfs.CreateFile(new VFSFilePath("file1.txt"), "content1");
        vfs.CreateFile(new VFSFilePath("file2.txt"), "content2");
        vfs.CreateFile(new VFSFilePath("file3.txt"), "content3");

        var regex = new Regex(@"file\d.txt");

        // Act
        var files = vfs.FindFiles(regex).ToList();

        // Assert
        files.Should().NotBeNull();
        files.Count.Should().Be(3);
        files[0].Name.Should().Be("file1.txt");
        files[0].Content.Should().Be("content1");
        files[1].Name.Should().Be("file2.txt");
        files[1].Content.Should().Be("content2");
        files[2].Name.Should().Be("file3.txt");
        files[2].Content.Should().Be("content3");
        // Assert Index
        vfs.Index.Count.Should().Be(3); // file1, file2, file3
    }
}