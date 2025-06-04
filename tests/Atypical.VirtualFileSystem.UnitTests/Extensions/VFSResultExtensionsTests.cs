using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Extensions;
using Xunit;

namespace Atypical.VirtualFileSystem.UnitTests.Extensions;

public class VFSResultExtensionsTests
{
    [Fact]
    public void CreateFileResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";

        // Act
        var result = vfs.CreateFileResult(filePath, content);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(vfs.FileExists(filePath));
    }

    [Fact]
    public void CreateFileResult_Failure_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        
        // Create file first, then try to create again
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act
        var result = vfs.CreateFileResult(filePath, "new content");

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("already exists", result.Error, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void CreateFileWithDirectoriesResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/deep/nested/path/file.txt";
        const string content = "test content";

        // Act
        var result = vfs.CreateFileWithDirectoriesResult(filePath, content);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(vfs.FileExists(filePath));
        Assert.True(vfs.DirectoryExists("/deep/nested/path/"));
    }

    [Fact]
    public void CreateDirectoryResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";

        // Act
        var result = vfs.CreateDirectoryResult(directoryPath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void CreateDirectoryRecursivelyResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/deep/nested/directory/";

        // Act
        var result = vfs.CreateDirectoryRecursivelyResult(directoryPath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(vfs.DirectoryExists(directoryPath));
        Assert.True(vfs.DirectoryExists("/deep/nested/"));
    }

    [Fact]
    public void DeleteFileResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act
        var result = vfs.DeleteFileResult(filePath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(vfs.FileExists(filePath));
    }

    [Fact]
    public void DeleteFileResult_FileNotExists_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";

        // Act
        var result = vfs.DeleteFileResult(filePath);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("does not exist", result.Error);
    }

    [Fact]
    public void DeleteDirectoryResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.DeleteDirectoryResult(directoryPath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void DeleteDirectoryResult_DirectoryNotExists_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/nonexistent/";

        // Act
        var result = vfs.DeleteDirectoryResult(directoryPath);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("does not exist", result.Error);
    }

    [Fact]
    public void GetFileResult_Success_ShouldReturnFileNode()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        var result = vfs.GetFileResult(filePath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(content, result.Value.Content);
    }

    [Fact]
    public void GetFileResult_FileNotExists_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";

        // Act
        var result = vfs.GetFileResult(filePath);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("not found", result.Error);
    }

    [Fact]
    public void GetDirectoryResult_Success_ShouldReturnDirectoryNode()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/directory/";
        vfs.CreateDirectory(directoryPath);

        // Act
        var result = vfs.GetDirectoryResult(directoryPath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }

    [Fact]
    public void GetDirectoryResult_DirectoryNotExists_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/test/nonexistent/";

        // Act
        var result = vfs.GetDirectoryResult(directoryPath);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("not found", result.Error);
    }

    [Fact]
    public void ReadFileResult_Success_ShouldReturnFileContent()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        var result = vfs.ReadFileResult(filePath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(content, result.Value);
    }

    [Fact]
    public void WriteFileResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string originalContent = "original content";
        const string newContent = "new content";
        vfs.CreateFileWithDirectories(filePath, originalContent);

        // Act
        var result = vfs.WriteFileResult(filePath, newContent);

        // Assert
        Assert.True(result.IsSuccess);
        var file = vfs.GetFile(filePath);
        Assert.Equal(newContent, file.Content);
    }

    [Fact]
    public void MoveFileResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(sourcePath, content);

        // Act
        var result = vfs.MoveFileResult(sourcePath, destinationPath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(vfs.FileExists(sourcePath));
        Assert.True(vfs.FileExists(destinationPath));
    }

    [Fact]
    public void MoveFileResult_SourceNotExists_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/nonexistent.txt";
        const string destinationPath = "/destination/file.txt";

        // Act
        var result = vfs.MoveFileResult(sourcePath, destinationPath);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("does not exist", result.Error);
    }

    [Fact]
    public void CopyFileResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(sourcePath, content);

        // Act
        var result = vfs.CopyFileResult(sourcePath, destinationPath);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(vfs.FileExists(sourcePath));
        Assert.True(vfs.FileExists(destinationPath));
        Assert.Equal(content, vfs.GetFile(destinationPath).Content);
    }

    [Fact]
    public void RenameFileResult_Success_ShouldReturnSuccessResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/oldfile.txt";
        const string newName = "newfile.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        var result = vfs.RenameFileResult(filePath, newName);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(vfs.FileExists(filePath));
        Assert.True(vfs.FileExists("/test/newfile.txt"));
    }

    [Fact]
    public void RenameFileResult_FileNotExists_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/nonexistent.txt";
        const string newName = "newfile.txt";

        // Act
        var result = vfs.RenameFileResult(filePath, newName);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("does not exist", result.Error);
    }

    [Fact]
    public void CreateFilesResult_AllSuccess_ShouldReturnAllPaths()
    {
        // Arrange
        var vfs = new VFS();
        var files = new[]
        {
            ("/test/file1.txt", "content1"),
            ("/test/file2.txt", "content2"),
            ("/test/file3.txt", "content3")
        };

        // Act
        var result = vfs.CreateFilesResult(files);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(3, result.Value.Count());
        Assert.All(files, file => Assert.True(vfs.FileExists(file.Item1)));
    }

    [Fact]
    public void CreateFilesResult_SomeFailures_ShouldReturnFailureResult()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/test/existing.txt", "existing");
        
        var files = new[]
        {
            ("/test/new1.txt", "content1"),
            ("/test/existing.txt", "content2"), // This should fail
            ("/test/new2.txt", "content3")
        };

        // Act
        var result = vfs.CreateFilesResult(files);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("Some files failed to create", result.Error);
    }

    [Fact]
    public void ResultChaining_WithOnSuccess_ShouldExecuteAction()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";
        bool actionExecuted = false;

        // Act
        var result = vfs.CreateFileResult(filePath, content)
            .OnSuccess(() => actionExecuted = true);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(actionExecuted);
    }

    [Fact]
    public void ResultChaining_WithOnFailure_ShouldExecuteAction()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "existing");
        
        string? errorMessage = null;

        // Act
        var result = vfs.CreateFileResult(filePath, "new content")
            .OnFailure(error => errorMessage = error);

        // Assert
        Assert.True(result.IsFailure);
        Assert.NotNull(errorMessage);
        Assert.Contains("already exists", errorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ResultMapping_ShouldTransformValue()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        const string content = "test content";
        vfs.CreateFileWithDirectories(filePath, content);

        // Act
        var result = vfs.GetFileResult(filePath)
            .Map(file => file.Content.Length);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(content.Length, result.Value);
    }

    [Fact]
    public void Execute_Success_ShouldReturnSuccessResult()
    {
        // Arrange & Act
        var result = VFSResultExtensions.Execute(() => {
            // Some operation that doesn't throw
            var x = 1 + 1;
        });

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Execute_Exception_ShouldReturnFailureResult()
    {
        // Arrange & Act
        var result = VFSResultExtensions.Execute(() => {
            throw new InvalidOperationException("Test exception");
        });

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("Test exception", result.Error);
    }

    [Fact]
    public void ExecuteWithReturn_Success_ShouldReturnValueResult()
    {
        // Arrange & Act
        var result = VFSResultExtensions.Execute(() => 42);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void ExecuteWithReturn_Exception_ShouldReturnFailureResult()
    {
        // Arrange & Act
        var result = VFSResultExtensions.Execute<int>(() => {
            throw new InvalidOperationException("Test exception");
        });

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains("Test exception", result.Error);
    }
}