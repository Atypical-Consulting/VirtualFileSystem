using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Extensions;
using Xunit;

namespace Atypical.VirtualFileSystem.UnitTests.Extensions;

public class VFSAdvancedExtensionsTests
{
    [Fact]
    public void CreateFileWithDirectories_WithNestedPath_ShouldCreateFileAndDirectories()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/deeply/nested/path/file.txt";
        const string content = "test content";

        // Act
        var result = vfs.CreateFileWithDirectories(filePath, content);

        // Assert
        Assert.Same(vfs, result); // Fluent interface
        Assert.True(vfs.FileExists(filePath));
        Assert.True(vfs.DirectoryExists("/deeply/"));
        Assert.True(vfs.DirectoryExists("/deeply/nested/"));
        Assert.True(vfs.DirectoryExists("/deeply/nested/path/"));
        
        var createdFile = vfs.GetFile(filePath);
        Assert.Equal(content, createdFile.Content);
    }

    [Fact]
    public void CreateFileWithDirectories_WithExistingDirectories_ShouldCreateFileOnly()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/existing/directory/file.txt";
        const string content = "test content";
        vfs.CreateDirectory("/existing/");
        vfs.CreateDirectory("/existing/directory/");

        // Act
        var result = vfs.CreateFileWithDirectories(filePath, content);

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.FileExists(filePath));
        var createdFile = vfs.GetFile(filePath);
        Assert.Equal(content, createdFile.Content);
    }

    [Fact]
    public void CreateFileWithDirectories_WithNullContent_ShouldCreateFileWithEmptyContent()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/directory/file.txt";

        // Act
        var result = vfs.CreateFileWithDirectories(filePath, null);

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.FileExists(filePath));
        var createdFile = vfs.GetFile(filePath);
        Assert.Equal(string.Empty, createdFile.Content);
    }

    [Fact]
    public void CreateFileWithDirectories_WithRootFile_ShouldCreateFileAtRoot()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/rootfile.txt";
        const string content = "root content";

        // Act
        var result = vfs.CreateFileWithDirectories(filePath, content);

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.FileExists(filePath));
        var createdFile = vfs.GetFile(filePath);
        Assert.Equal(content, createdFile.Content);
    }

    [Fact]
    public void TryCreateFileWithDirectories_WithValidPath_ShouldReturnTrueAndCreateFile()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/deeply/nested/file.txt";
        const string content = "test content";

        // Act
        var result = vfs.TryCreateFileWithDirectories(filePath, content);

        // Assert
        Assert.True(result);
        Assert.True(vfs.FileExists(filePath));
        Assert.True(vfs.DirectoryExists("/deeply/nested/"));
    }

    [Fact]
    public void TryCreateFileWithDirectories_WithExistingFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/existing.txt";
        vfs.CreateFileWithDirectories(filePath, "original");

        // Act
        var result = vfs.TryCreateFileWithDirectories(filePath, "new content");

        // Assert
        Assert.False(result);
        var existingFile = vfs.GetFile(filePath);
        Assert.Equal("original", existingFile.Content);
    }

    [Fact]
    public void CreateDirectoryRecursively_WithDeepPath_ShouldCreateAllDirectories()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/level1/level2/level3/level4/";

        // Act
        var result = vfs.CreateDirectoryRecursively(directoryPath);

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.DirectoryExists("/level1/"));
        Assert.True(vfs.DirectoryExists("/level1/level2/"));
        Assert.True(vfs.DirectoryExists("/level1/level2/level3/"));
        Assert.True(vfs.DirectoryExists("/level1/level2/level3/level4/"));
    }

    [Fact]
    public void CreateDirectoryRecursively_WithExistingDirectories_ShouldNotFail()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/existing/nested/path/";
        vfs.CreateDirectory("/existing/");
        vfs.CreateDirectory("/existing/nested/");

        // Act
        var result = vfs.CreateDirectoryRecursively(directoryPath);

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.DirectoryExists(directoryPath));
    }

    [Fact]
    public void CreateDirectoryRecursively_WithRootPath_ShouldNotFail()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var result = vfs.CreateDirectoryRecursively("/");

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.DirectoryExists("/"));
    }

    [Fact]
    public void TryCreateDirectoryRecursively_WithValidPath_ShouldReturnTrueAndCreateDirectories()
    {
        // Arrange
        var vfs = new VFS();
        const string directoryPath = "/deep/nested/structure/";

        // Act
        var result = vfs.TryCreateDirectoryRecursively(directoryPath);

        // Assert
        Assert.True(result);
        Assert.True(vfs.DirectoryExists("/deep/"));
        Assert.True(vfs.DirectoryExists("/deep/nested/"));
        Assert.True(vfs.DirectoryExists("/deep/nested/structure/"));
    }

    [Fact]
    public void TryCreateDirectoryRecursively_WithInvalidPath_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string invalidPath = ""; // Invalid empty path

        // Act
        var result = vfs.TryCreateDirectoryRecursively(invalidPath);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CopyFile_WithValidPaths_ShouldCopyFileAndCreateDirectories()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/nested/copy.txt";
        const string content = "file content";
        vfs.CreateFileWithDirectories(sourcePath, content);

        // Act
        var result = vfs.CopyFile(sourcePath, destinationPath);

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.FileExists(sourcePath)); // Original still exists
        Assert.True(vfs.FileExists(destinationPath));
        Assert.True(vfs.DirectoryExists("/destination/nested/"));
        
        var originalFile = vfs.GetFile(sourcePath);
        var copiedFile = vfs.GetFile(destinationPath);
        Assert.Equal(content, originalFile.Content);
        Assert.Equal(content, copiedFile.Content);
    }

    [Fact]
    public void CopyFile_WithSamePath_ShouldThrowException()
    {
        // Arrange
        var vfs = new VFS();
        const string filePath = "/test/file.txt";
        vfs.CreateFileWithDirectories(filePath, "content");

        // Act & Assert
        Assert.Throws<VirtualFileSystemException>(() => vfs.CopyFile(filePath, filePath));
    }

    [Fact]
    public void TryCopyFile_WithValidPaths_ShouldReturnTrueAndCopyFile()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/copy.txt";
        const string content = "file content";
        vfs.CreateFileWithDirectories(sourcePath, content);

        // Act
        var result = vfs.TryCopyFile(sourcePath, destinationPath);

        // Assert
        Assert.True(result);
        Assert.True(vfs.FileExists(sourcePath));
        Assert.True(vfs.FileExists(destinationPath));
        
        var copiedFile = vfs.GetFile(destinationPath);
        Assert.Equal(content, copiedFile.Content);
    }

    [Fact]
    public void TryCopyFile_WithNonExistingSource_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/nonexistent/file.txt";
        const string destinationPath = "/destination/copy.txt";

        // Act
        var result = vfs.TryCopyFile(sourcePath, destinationPath);

        // Assert
        Assert.False(result);
        Assert.False(vfs.FileExists(destinationPath));
    }

    [Fact]
    public void TryCopyFile_WithExistingDestination_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/file.txt";
        const string destinationPath = "/destination/existing.txt";
        vfs.CreateFileWithDirectories(sourcePath, "source content");
        vfs.CreateFileWithDirectories(destinationPath, "destination content");

        // Act
        var result = vfs.TryCopyFile(sourcePath, destinationPath);

        // Assert
        Assert.False(result);
        var destinationFile = vfs.GetFile(destinationPath);
        Assert.Equal("destination content", destinationFile.Content);
    }

    [Fact]
    public void CopyDirectory_WithValidPaths_ShouldCopyDirectoryAndAllContents()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/dir/";
        const string destinationPath = "/destination/copied_dir/";
        
        // Create source directory with nested structure
        vfs.CreateDirectory(sourcePath);
        vfs.CreateFile("/source/dir/file1.txt", "content1");
        vfs.CreateFile("/source/dir/file2.txt", "content2");
        vfs.CreateDirectory("/source/dir/subdir/");
        vfs.CreateFile("/source/dir/subdir/file3.txt", "content3");

        // Act
        var result = vfs.CopyDirectory(sourcePath, destinationPath);

        // Assert
        Assert.Same(vfs, result);
        
        // Original directory still exists
        Assert.True(vfs.DirectoryExists(sourcePath));
        Assert.True(vfs.FileExists("/source/dir/file1.txt"));
        
        // Copied directory and contents exist
        Assert.True(vfs.DirectoryExists(destinationPath));
        Assert.True(vfs.FileExists("/destination/copied_dir/file1.txt"));
        Assert.True(vfs.FileExists("/destination/copied_dir/file2.txt"));
        Assert.True(vfs.DirectoryExists("/destination/copied_dir/subdir/"));
        Assert.True(vfs.FileExists("/destination/copied_dir/subdir/file3.txt"));
        
        // Content is copied correctly
        var copiedFile = vfs.GetFile("/destination/copied_dir/subdir/file3.txt");
        Assert.Equal("content3", copiedFile.Content);
    }

    [Fact]
    public void CopyDirectory_WithEmptyDirectory_ShouldCopyEmptyDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/empty/";
        const string destinationPath = "/destination/empty_copy/";
        vfs.CreateDirectory(sourcePath);

        // Act
        var result = vfs.CopyDirectory(sourcePath, destinationPath);

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.DirectoryExists(sourcePath));
        Assert.True(vfs.DirectoryExists(destinationPath));
    }

    [Fact]
    public void TryCopyDirectory_WithValidPaths_ShouldReturnTrueAndCopyDirectory()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/source/dir/";
        const string destinationPath = "/destination/copied/";
        vfs.CreateDirectory(sourcePath);
        vfs.CreateFile("/source/dir/file.txt", "content");

        // Act
        var result = vfs.TryCopyDirectory(sourcePath, destinationPath);

        // Assert
        Assert.True(result);
        Assert.True(vfs.DirectoryExists(destinationPath));
        Assert.True(vfs.FileExists("/destination/copied/file.txt"));
    }

    [Fact]
    public void TryCopyDirectory_WithNonExistingSource_ShouldReturnFalse()
    {
        // Arrange
        var vfs = new VFS();
        const string sourcePath = "/nonexistent/dir/";
        const string destinationPath = "/destination/copied/";

        // Act
        var result = vfs.TryCopyDirectory(sourcePath, destinationPath);

        // Assert
        Assert.False(result);
        Assert.False(vfs.DirectoryExists(destinationPath));
    }

    [Fact]
    public void GetAllFilesRecursive_WithMultipleFiles_ShouldReturnAllFiles()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/root/file1.txt", "content1");
        vfs.CreateFileWithDirectories("/root/dir1/file2.txt", "content2");
        vfs.CreateFileWithDirectories("/root/dir1/subdir/file3.txt", "content3");
        vfs.CreateFileWithDirectories("/other/file4.txt", "content4");

        // Act
        var allFiles = vfs.GetAllFilesRecursive().ToList();

        // Assert
        Assert.Equal(4, allFiles.Count);
        Assert.Contains(allFiles, f => f.Path.Value == "vfs://root/file1.txt");
        Assert.Contains(allFiles, f => f.Path.Value == "vfs://root/dir1/file2.txt");
        Assert.Contains(allFiles, f => f.Path.Value == "vfs://root/dir1/subdir/file3.txt");
        Assert.Contains(allFiles, f => f.Path.Value == "vfs://other/file4.txt");
    }

    [Fact]
    public void GetAllFilesRecursive_WithEmptyFileSystem_ShouldReturnEmptyCollection()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var allFiles = vfs.GetAllFilesRecursive().ToList();

        // Assert
        Assert.Empty(allFiles);
    }

    [Fact]
    public void GetAllDirectoriesRecursive_WithMultipleDirectories_ShouldReturnAllDirectories()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateDirectory("/root/");
        vfs.CreateDirectory("/root/dir1/");
        vfs.CreateDirectory("/root/dir1/subdir/");
        vfs.CreateDirectory("/other/");

        // Act
        var allDirectories = vfs.GetAllDirectoriesRecursive().ToList();

        // Assert
        Assert.Equal(4, allDirectories.Count);
        Assert.Contains(allDirectories, d => d.Path.Value == "vfs://root");
        Assert.Contains(allDirectories, d => d.Path.Value == "vfs://root/dir1");
        Assert.Contains(allDirectories, d => d.Path.Value == "vfs://root/dir1/subdir");
        Assert.Contains(allDirectories, d => d.Path.Value == "vfs://other");
    }

    [Fact]
    public void GetAllDirectoriesRecursive_WithEmptyFileSystem_ShouldReturnEmptyCollection()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var allDirectories = vfs.GetAllDirectoriesRecursive().ToList();

        // Assert
        Assert.Empty(allDirectories);
    }

    [Fact]
    public void GetFilesRecursive_WithSpecificDirectory_ShouldReturnFilesInThatDirectoryAndSubdirectories()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/target/file1.txt", "content1");
        vfs.CreateFileWithDirectories("/target/subdir/file2.txt", "content2");
        vfs.CreateFileWithDirectories("/target/subdir/deep/file3.txt", "content3");
        vfs.CreateFileWithDirectories("/other/file4.txt", "content4"); // Should not be included

        // Act
        var targetFiles = vfs.GetFilesRecursive("/target/").ToList();

        // Assert
        Assert.Equal(3, targetFiles.Count);
        Assert.Contains(targetFiles, f => f.Path.Value == "vfs://target/file1.txt");
        Assert.Contains(targetFiles, f => f.Path.Value == "vfs://target/subdir/file2.txt");
        Assert.Contains(targetFiles, f => f.Path.Value == "vfs://target/subdir/deep/file3.txt");
        Assert.DoesNotContain(targetFiles, f => f.Path.Value == "vfs://other/file4.txt");
    }

    [Fact]
    public void GetFilesRecursive_WithNonExistingDirectory_ShouldReturnEmptyCollection()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var files = vfs.GetFilesRecursive("/nonexistent/").ToList();

        // Assert
        Assert.Empty(files);
    }

    [Fact]
    public void GetDirectoriesRecursive_WithSpecificDirectory_ShouldReturnDirectoriesInThatDirectoryAndSubdirectories()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateDirectory("/target/");
        vfs.CreateDirectory("/target/subdir1/");
        vfs.CreateDirectory("/target/subdir1/deep/");
        vfs.CreateDirectory("/target/subdir2/");
        vfs.CreateDirectory("/other/"); // Should not be included

        // Act
        var targetDirectories = vfs.GetDirectoriesRecursive("/target/").ToList();

        // Assert
        Assert.Equal(3, targetDirectories.Count);
        Assert.Contains(targetDirectories, d => d.Path.Value == "vfs://target/subdir1");
        Assert.Contains(targetDirectories, d => d.Path.Value == "vfs://target/subdir1/deep");
        Assert.Contains(targetDirectories, d => d.Path.Value == "vfs://target/subdir2");
        Assert.DoesNotContain(targetDirectories, d => d.Path.Value == "vfs://other");
    }

    [Fact]
    public void GetDirectoriesRecursive_WithNonExistingDirectory_ShouldReturnEmptyCollection()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var directories = vfs.GetDirectoriesRecursive("/nonexistent/").ToList();

        // Assert
        Assert.Empty(directories);
    }

    [Fact]
    public void MethodChaining_ShouldWorkCorrectly()
    {
        // Arrange
        var vfs = new VFS();

        // Act
        var result = vfs
            .CreateFileWithDirectories("/docs/readme.txt", "readme content")
            .CreateDirectoryRecursively("/deeply/nested/structure/")
            .CopyFile("/docs/readme.txt", "/deeply/nested/structure/copy.txt");

        // Assert
        Assert.Same(vfs, result);
        Assert.True(vfs.FileExists("/docs/readme.txt"));
        Assert.True(vfs.DirectoryExists("/deeply/nested/structure/"));
        Assert.True(vfs.FileExists("/deeply/nested/structure/copy.txt"));
        
        var copiedFile = vfs.GetFile("/deeply/nested/structure/copy.txt");
        Assert.Equal("readme content", copiedFile.Content);
    }
}