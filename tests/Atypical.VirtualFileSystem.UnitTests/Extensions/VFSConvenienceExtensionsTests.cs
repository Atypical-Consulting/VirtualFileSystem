using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Extensions;
using Xunit;

namespace Atypical.VirtualFileSystem.UnitTests.Extensions;

public class VFSConvenienceExtensionsTests
{
    [Fact]
    public void CreateFile_WithStringPath_ShouldCreateFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";

        // Act
        vfs.CreateFile(filePath, content);

        // Assert
        Assert.True(vfs.FileExists(filePath));
        var file = vfs.GetFile(filePath);
        Assert.Equal(content, file.Content);
    }

    [Fact]
    public void CreateDirectory_WithStringPath_ShouldCreateDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";

        // Act
        vfs.CreateDirectory(directoryPath);

        // Assert
        Assert.True(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void DeleteFile_WithStringPath_ShouldDeleteFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFile(filePath, "content");

        // Act
        vfs.DeleteFile(filePath);

        // Assert
        Assert.False(vfs.FileExists(filePath));
    }

    [Fact]
    public void DeleteDirectory_WithStringPath_ShouldDeleteDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        vfs.DeleteDirectory(directoryPath);

        // Assert
        Assert.False(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void MoveFile_WithStringPaths_ShouldMoveFile()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/file.txt";
        const string content = "test content";
        
        vfs.CreateFileWithDirectories(sourcePath, content);

        // Act
        vfs.MoveFile(sourcePath, destinationPath);

        // Assert
        Assert.False(vfs.FileExists(sourcePath));
        Assert.True(vfs.FileExists(destinationPath));
        var file = vfs.GetFile(destinationPath);
        Assert.Equal(content, file.Content);
    }

    [Fact]
    public void MoveDirectory_WithStringPaths_ShouldMoveDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/dir/";
        const string destinationPath = "/destination/dir/";
        const string filePath = "/source/dir/file.txt";
        
        vfs.CreateDirectory(sourcePath);
        vfs.CreateFile(filePath, "content");

        // Act
        vfs.MoveDirectory(sourcePath, destinationPath);

        // Assert
        Assert.False(vfs.DirectoryExists(sourcePath));
        Assert.True(vfs.DirectoryExists(destinationPath));
        Assert.True(vfs.FileExists("/destination/dir/file.txt"));
    }

    [Fact]
    public void RenameFile_WithStringPath_ShouldRenameFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/oldfile.txt";
        const string newName = "newfile.txt";
        const string content = "test content";
        
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        vfs.RenameFile(filePath, newName);

        // Assert
        Assert.False(vfs.FileExists(filePath));
        Assert.True(vfs.FileExists("/test/newfile.txt"));
        var file = vfs.GetFile("/test/newfile.txt");
        Assert.Equal(content, file.Content);
    }

    [Fact]
    public void RenameDirectory_WithStringPath_ShouldRenameDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/olddir/";
        const string newName = "newdir";
        
        vfs.CreateDirectory(directoryPath);
        vfs.CreateFile("/test/olddir/file.txt", "content");

        // Act
        vfs.RenameDirectory(directoryPath, newName);

        // Assert
        Assert.False(vfs.DirectoryExists(directoryPath));
        Assert.True(vfs.DirectoryExists("/test/newdir/"));
        Assert.True(vfs.FileExists("/test/newdir/file.txt"));
    }

    [Fact]
    public void TryGetFile_WithStringPath_ShouldReturnTrueForExistingFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        var result = vfs.TryGetFile(filePath, out var file);

        // Assert
        Assert.True(result);
        Assert.NotNull(file);
        Assert.Equal(content, file.Content);
    }

    [Fact]
    public void TryGetFile_WithStringPath_ShouldReturnFalseForNonExistingFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";

        // Act
        var result = vfs.TryGetFile(filePath, out var file);

        // Assert
        Assert.False(result);
        Assert.Null(file);
    }

    [Fact]
    public void TryGetDirectory_WithStringPath_ShouldReturnTrueForExistingDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.TryGetDirectory(directoryPath, out var directory);

        // Assert
        Assert.True(result);
        Assert.NotNull(directory);
    }

    [Fact]
    public void TryGetDirectory_WithStringPath_ShouldReturnFalseForNonExistingDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/nonexistent/";

        // Act
        var result = vfs.TryGetDirectory(directoryPath, out var directory);

        // Assert
        Assert.False(result);
        Assert.Null(directory);
    }

    [Fact]
    public void Exists_ShouldReturnTrueForExistingFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act & Assert
        Assert.True(vfs.Exists(filePath));
    }

    [Fact]
    public void Exists_ShouldReturnTrueForExistingDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act & Assert
        Assert.True(vfs.Exists(directoryPath));
    }

    [Fact]
    public void Exists_ShouldReturnFalseForNonExistingPath()
    {
        // Arrange
        var vfs = new VFS();
        const string path = "/test/nonexistent";

        // Act & Assert
        Assert.False(vfs.Exists(path));
    }

    [Fact]
    public void FileExists_ShouldReturnTrueForExistingFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act & Assert
        Assert.True(vfs.FileExists(filePath));
    }

    [Fact]
    public void FileExists_ShouldReturnFalseForDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act & Assert
        Assert.False(vfs.FileExists(directoryPath));
    }

    [Fact]
    public void DirectoryExists_ShouldReturnTrueForExistingDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act & Assert
        Assert.True(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void DirectoryExists_ShouldReturnFalseForFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act & Assert
        Assert.False(vfs.DirectoryExists(filePath));
    }

    [Fact]
    public void MethodChaining_ShouldWorkCorrectly()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        vfs.CreateDirectory("/docs/")
           .CreateDirectory("/src/")
           .CreateFile("/docs/readme.txt", "readme content")
           .CreateFile("/src/main.cs", "main content");

        // Assert
        Assert.True(vfs.DirectoryExists("/docs/"));
        Assert.True(vfs.DirectoryExists("/src/"));
        Assert.True(vfs.FileExists("/docs/readme.txt"));
        Assert.True(vfs.FileExists("/src/main.cs"));
        
        var readmeFile = vfs.GetFile("/docs/readme.txt");
        Assert.Equal("readme content", readmeFile.Content);
        
        var mainFile = vfs.GetFile("/src/main.cs");
        Assert.Equal("main content", mainFile.Content);
    }
}