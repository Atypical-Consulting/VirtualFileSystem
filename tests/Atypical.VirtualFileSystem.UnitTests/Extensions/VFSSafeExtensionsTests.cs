using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Extensions;
using Xunit;

namespace Atypical.VirtualFileSystem.UnitTests.Extensions;

public class VFSSafeExtensionsTests
{
    [Fact]
    public void TryCreateFile_WithValidPath_ShouldReturnTrueAndCreateFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";

        // Act
        var result = vfs.TryCreateFile(filePath, content);

        // Assert
        Assert.True(result);
        Assert.True(vfs.FileExists(filePath));
        var createdFile = vfs.GetFile(filePath);
        Assert.Equal(content, createdFile.Content);
    }

    [Fact]
    public void TryCreateFile_WithNullContent_ShouldReturnTrueAndCreateFileWithEmptyContent()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";

        // Act
        var result = vfs.TryCreateFile(filePath, null);

        // Assert
        Assert.True(result);
        Assert.True(vfs.FileExists(filePath));
        var createdFile = vfs.GetFile(filePath);
        Assert.Equal(string.Empty, createdFile.Content);
    }

    [Fact]
    public void TryCreateFile_WithExistingFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "original");

        // Act
        var result = vfs.TryCreateFile(filePath, "new content");

        // Assert
        Assert.False(result);
        var existingFile = vfs.GetFile(filePath);
        Assert.Equal("original", existingFile.Content);
    }

    [Fact]
    public void TryCreateFile_WithInvalidPath_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string invalidPath = ""; // Invalid empty path

        // Act
        var result = vfs.TryCreateFile(invalidPath, "content");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryCreateDirectory_WithValidPath_ShouldReturnTrueAndCreateDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";

        // Act
        var result = vfs.TryCreateDirectory(directoryPath);

        // Assert
        Assert.True(result);
        Assert.True(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void TryCreateDirectory_WithExistingDirectory_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.TryCreateDirectory(directoryPath);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryCreateDirectory_WithInvalidPath_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string invalidPath = ""; // Invalid empty path

        // Act
        var result = vfs.TryCreateDirectory(invalidPath);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryDeleteFile_WithExistingFile_ShouldReturnTrueAndDeleteFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act
        var result = vfs.TryDeleteFile(filePath);

        // Assert
        Assert.True(result);
        Assert.False(vfs.FileExists(filePath));
    }

    [Fact]
    public void TryDeleteFile_WithNonExistingFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";

        // Act
        var result = vfs.TryDeleteFile(filePath);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryDeleteFile_WithDirectoryPath_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.TryDeleteFile(directoryPath);

        // Assert
        Assert.False(result);
        Assert.True(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void TryDeleteDirectory_WithExistingDirectory_ShouldReturnTrueAndDeleteDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.TryDeleteDirectory(directoryPath);

        // Assert
        Assert.True(result);
        Assert.False(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void TryDeleteDirectory_WithNonExistingDirectory_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/nonexistent/";

        // Act
        var result = vfs.TryDeleteDirectory(directoryPath);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryDeleteDirectory_WithRootDirectory_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var result = vfs.TryDeleteDirectory("/");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryDeleteDirectory_WithFilePath_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act
        var result = vfs.TryDeleteDirectory(filePath);

        // Assert
        Assert.False(result);
        Assert.True(vfs.FileExists(filePath));
    }

    [Fact]
    public void TryMoveFile_WithValidPaths_ShouldReturnTrueAndMoveFile()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(sourcePath, content);
        vfs.CreateDirectory("/destination/");

        // Act
        var result = vfs.TryMoveFile(sourcePath, destinationPath);

        // Assert
        Assert.True(result);
        Assert.False(vfs.FileExists(sourcePath));
        Assert.True(vfs.FileExists(destinationPath));
        var movedFile = vfs.GetFile(destinationPath);
        Assert.Equal(content, movedFile.Content);
    }

    [Fact]
    public void TryMoveFile_WithNonExistingSource_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/nonexistent.txt";
        const string destinationPath = "/destination/file.txt";

        // Act
        var result = vfs.TryMoveFile(sourcePath, destinationPath);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryMoveFile_WithExistingDestination_ShouldReturnTrueAndOverwrite()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/existing.txt";
        vfs.CreateFileWithDirectories(sourcePath, "source content");
        vfs.CreateFileWithDirectories(destinationPath, "destination content");

        // Act
        var result = vfs.TryMoveFile(sourcePath, destinationPath);

        // Assert
        // Note: VFS allows overwriting during move
        Assert.True(result);
        Assert.False(vfs.FileExists(sourcePath));
        Assert.True(vfs.FileExists(destinationPath));
        Assert.Equal("source content", vfs.GetFile(destinationPath).Content);
    }

    [Fact]
    public void TryMoveDirectory_WithValidPaths_ShouldReturnTrueAndMoveDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/dir/";
        const string destinationPath = "/destination/dir/";
        const string filePath = "/source/dir/file.txt";
        vfs.CreateDirectory(sourcePath);
        vfs.CreateFile(filePath, "content");

        // Act
        var result = vfs.TryMoveDirectory(sourcePath, destinationPath);

        // Assert
        Assert.True(result);
        Assert.False(vfs.DirectoryExists(sourcePath));
        Assert.True(vfs.DirectoryExists(destinationPath));
        Assert.True(vfs.FileExists("/destination/dir/file.txt"));
    }

    [Fact]
    public void TryMoveDirectory_WithNonExistingSource_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/nonexistent/";
        const string destinationPath = "/destination/dir/";

        // Act
        var result = vfs.TryMoveDirectory(sourcePath, destinationPath);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryRenameFile_WithValidParameters_ShouldReturnTrueAndRenameFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/oldname.txt";
        const string newName = "newname.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        var result = vfs.TryRenameFile(filePath, newName);

        // Assert
        Assert.True(result);
        Assert.False(vfs.FileExists(filePath));
        Assert.True(vfs.FileExists("/test/newname.txt"));
        var renamedFile = vfs.GetFile("/test/newname.txt");
        Assert.Equal(content, renamedFile.Content);
    }

    [Fact]
    public void TryRenameFile_WithNonExistingFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";
        const string newName = "newname.txt";

        // Act
        var result = vfs.TryRenameFile(filePath, newName);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryRenameFile_WithExistingTargetName_ShouldReturnTrueAndOverwrite()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/oldname.txt";
        const string existingFile = "/test/existing.txt";
        const string newName = "existing.txt";
        vfs.CreateFileWithDirectories(filePath, "original");
        vfs.CreateFile(existingFile, "existing");

        // Act
        var result = vfs.TryRenameFile(filePath, newName);

        // Assert
        // Note: VFS allows overwriting when renaming
        Assert.True(result);
        Assert.False(vfs.FileExists(filePath));
        Assert.True(vfs.FileExists(existingFile));
        Assert.Equal("original", vfs.GetFile(existingFile).Content);
    }

    [Fact]
    public void TryRenameDirectory_WithValidParameters_ShouldReturnTrueAndRenameDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/olddir/";
        const string newName = "newdir";
        vfs.CreateDirectory(directoryPath);
        vfs.CreateFile("/test/olddir/file.txt", "content");

        // Act
        var result = vfs.TryRenameDirectory(directoryPath, newName);

        // Assert
        Assert.True(result);
        Assert.False(vfs.DirectoryExists(directoryPath));
        Assert.True(vfs.DirectoryExists("/test/newdir/"));
        Assert.True(vfs.FileExists("/test/newdir/file.txt"));
    }

    [Fact]
    public void TryRenameDirectory_WithNonExistingDirectory_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/nonexistent/";
        const string newName = "newdir";

        // Act
        var result = vfs.TryRenameDirectory(directoryPath, newName);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryReadFile_WithExistingFile_ShouldReturnTrueAndReadContent()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        var result = vfs.TryReadFile(filePath, out var readContent);

        // Assert
        Assert.True(result);
        Assert.Equal(content, readContent);
    }

    [Fact]
    public void TryReadFile_WithNonExistingFile_ShouldReturnFalseAndNullContent()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";

        // Act
        var result = vfs.TryReadFile(filePath, out var readContent);

        // Assert
        Assert.False(result);
        Assert.Null(readContent);
    }

    [Fact]
    public void TryReadFile_WithDirectoryPath_ShouldReturnFalseAndNullContent()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.TryReadFile(directoryPath, out var readContent);

        // Assert
        Assert.False(result);
        Assert.Null(readContent);
    }

    [Fact]
    public void TryWriteFile_WithExistingFile_ShouldReturnTrueAndUpdateContent()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string originalContent = "original content";
        const string newContent = "updated content";
        vfs.CreateFileWithDirectories(filePath, originalContent);

        // Act
        var result = vfs.TryWriteFile(filePath, newContent);

        // Assert
        Assert.True(result);
        var updatedFile = vfs.GetFile(filePath);
        Assert.Equal(newContent, updatedFile.Content);
    }

    [Fact]
    public void TryWriteFile_WithNonExistingFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";
        const string content = "new content";

        // Act
        var result = vfs.TryWriteFile(filePath, content);

        // Assert
        Assert.False(result);
        Assert.False(vfs.FileExists(filePath));
    }

    [Fact]
    public void TryWriteFile_WithDirectoryPath_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.TryWriteFile(directoryPath, "content");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryWriteFile_WithNullContent_ShouldReturnTrueAndSetNullContent()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "original");

        // Act
        var result = vfs.TryWriteFile(filePath, null!);

        // Assert
        Assert.True(result);
        var updatedFile = vfs.GetFile(filePath);
        Assert.Null(updatedFile.Content);
    }
}