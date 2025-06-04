using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Extensions;
using Xunit;

namespace Atypical.VirtualFileSystem.UnitTests.Extensions;

public class VFSSearchExtensionsTests
{
    [Fact]
    public void WithExtension_ShouldFilterFilesByExtension()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "readme")
           .CreateFileWithDirectories("/docs/guide.md", "guide")
           .CreateFileWithDirectories("/src/main.cs", "main");

        // Act
        var txtFiles = vfs.Files.WithExtension("txt").ToList();
        var mdFiles = vfs.Files.WithExtension(".md").ToList(); // With leading dot

        // Assert
        Assert.Single(txtFiles);
        Assert.Equal("vfs://docs/readme.txt", txtFiles[0].Path.Value);
        
        Assert.Single(mdFiles);
        Assert.Equal("vfs://docs/guide.md", mdFiles[0].Path.Value);
    }

    [Fact]
    public void WithExtensions_ShouldFilterFilesByMultipleExtensions()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "readme")
           .CreateFileWithDirectories("/docs/guide.md", "guide")
           .CreateFileWithDirectories("/src/main.cs", "main")
           .CreateFileWithDirectories("/assets/image.png", "binary");

        // Act
        var docFiles = vfs.Files.WithExtensions("txt", "md").ToList();

        // Assert
        Assert.Equal(2, docFiles.Count);
        Assert.Contains(docFiles, f => f.Path.Value == "vfs://docs/readme.txt");
        Assert.Contains(docFiles, f => f.Path.Value == "vfs://docs/guide.md");
    }

    [Fact]
    public void ContainingText_ShouldFilterFilesByContent()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "This is a README file")
           .CreateFileWithDirectories("/docs/guide.md", "This is a guide")
           .CreateFileWithDirectories("/src/main.cs", "Main method implementation");

        // Act
        var filesWithThis = vfs.Files.ContainingText("This").ToList();
        var filesWithMain = vfs.Files.ContainingText("Main", ignoreCase: false).ToList();

        // Assert
        Assert.Equal(2, filesWithThis.Count);
        Assert.Contains(filesWithThis, f => f.Path.Value == "vfs://docs/readme.txt");
        Assert.Contains(filesWithThis, f => f.Path.Value == "vfs://docs/guide.md");
        
        Assert.Single(filesWithMain);
        Assert.Equal("vfs://src/main.cs", filesWithMain[0].Path.Value);
    }

    [Fact]
    public void ContainingPattern_ShouldFilterFilesByRegexPattern()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "Email: test@example.com")
           .CreateFileWithDirectories("/docs/guide.md", "Contact: info@company.org")
           .CreateFileWithDirectories("/src/main.cs", "No email here");

        // Act
        var emailFiles = vfs.Files.ContainingPattern(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b").ToList();

        // Assert
        Assert.Equal(2, emailFiles.Count);
        Assert.Contains(emailFiles, f => f.Path.Value == "vfs://docs/readme.txt");
        Assert.Contains(emailFiles, f => f.Path.Value == "vfs://docs/guide.md");
    }

    [Fact]
    public void WithNameContaining_ShouldFilterFilesByName()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "content")
           .CreateFileWithDirectories("/docs/test_readme.md", "content")
           .CreateFileWithDirectories("/src/main.cs", "content");

        // Act
        var readmeFiles = vfs.Files.WithNameContaining("readme").ToList();

        // Assert
        Assert.Equal(2, readmeFiles.Count);
        Assert.Contains(readmeFiles, f => f.Path.Value == "vfs://docs/readme.txt");
        Assert.Contains(readmeFiles, f => f.Path.Value == "vfs://docs/test_readme.md");
    }

    [Fact]
    public void WithNameStartingWith_ShouldFilterFilesByPrefix()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/test_file1.txt", "content")
           .CreateFileWithDirectories("/docs/test_file2.md", "content")
           .CreateFileWithDirectories("/docs/main.cs", "content");

        // Act
        var testFiles = vfs.Files.WithNameStartingWith("test_").ToList();

        // Assert
        Assert.Equal(2, testFiles.Count);
        Assert.Contains(testFiles, f => f.Path.Value == "vfs://docs/test_file1.txt");
        Assert.Contains(testFiles, f => f.Path.Value == "vfs://docs/test_file2.md");
    }

    [Fact]
    public void WithNameEndingWith_ShouldFilterFilesBySuffix()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/backup_file.bak", "content")
           .CreateFileWithDirectories("/docs/config.bak", "content")
           .CreateFileWithDirectories("/docs/main.cs", "content");

        // Act
        var backupFiles = vfs.Files.WithNameEndingWith(".bak").ToList();

        // Assert
        Assert.Equal(2, backupFiles.Count);
        Assert.Contains(backupFiles, f => f.Path.Value == "vfs://docs/backup_file.bak");
        Assert.Contains(backupFiles, f => f.Path.Value == "vfs://docs/config.bak");
    }

    [Fact]
    public void InDirectory_ShouldFilterFilesByDirectory()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "content")
           .CreateFileWithDirectories("/docs/subdir/guide.md", "content")
           .CreateFileWithDirectories("/src/main.cs", "content");

        // Act
        var docsFiles = vfs.Files.InDirectory("/docs", recursive: false).ToList();
        var docsFilesRecursive = vfs.Files.InDirectory("/docs", recursive: true).ToList();

        // Assert
        Assert.Single(docsFiles);
        Assert.Equal("vfs://docs/readme.txt", docsFiles[0].Path.Value);
        
        Assert.Equal(2, docsFilesRecursive.Count);
        Assert.Contains(docsFilesRecursive, f => f.Path.Value == "vfs://docs/readme.txt");
        Assert.Contains(docsFilesRecursive, f => f.Path.Value == "vfs://docs/subdir/guide.md");
    }

    [Fact]
    public void WithSizeInRange_ShouldFilterFilesBySize()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/small.txt", "hi")        // 2 chars
           .CreateFileWithDirectories("/medium.txt", "hello")    // 5 chars
           .CreateFileWithDirectories("/large.txt", "hello world"); // 11 chars

        // Act
        var smallFiles = vfs.Files.WithSizeInRange(0, 3).ToList();
        var mediumFiles = vfs.Files.WithSizeInRange(4, 6).ToList();

        // Assert
        Assert.Single(smallFiles);
        Assert.Equal("vfs://small.txt", smallFiles[0].Path.Value);
        
        Assert.Single(mediumFiles);
        Assert.Equal("vfs://medium.txt", mediumFiles[0].Path.Value);
    }

    [Fact]
    public void CreatedBetween_ShouldFilterFilesByCreationTime()
    {
        // Arrange
        var vfs = new VFS();
        var startTime = DateTime.Now.AddHours(-2);
        var endTime = DateTime.Now.AddHours(-1);
        
        vfs.CreateFileWithDirectories("/old.txt", "content")
           .CreateFileWithDirectories("/new.txt", "content");

        // Act
        var recentFiles = vfs.Files.CreatedBetween(startTime, DateTime.Now).ToList();

        // Assert
        Assert.Equal(2, recentFiles.Count); // Both files should be recent
    }

    [Fact]
    public void WithNameContaining_Directories_ShouldFilterDirectoriesByName()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateDirectory("/test_docs/")
           .CreateDirectory("/docs_backup/")
           .CreateDirectory("/src/");

        // Act
        var docsDirectories = vfs.Directories.WithNameContaining("docs").ToList();

        // Assert
        Assert.Equal(2, docsDirectories.Count);
        Assert.Contains(docsDirectories, d => d.Path.Value == "vfs://test_docs");
        Assert.Contains(docsDirectories, d => d.Path.Value == "vfs://docs_backup");
    }

    [Fact]
    public void AtDepth_ShouldFilterDirectoriesByDepth()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateDirectory("/level1/")                    // depth 1
           .CreateDirectory("/level1/level2/")             // depth 2
           .CreateDirectory("/level1/level2/level3/")      // depth 3
           .CreateDirectory("/another_level1/");           // depth 1

        // Act
        var depth1Dirs = vfs.Directories.AtDepth(1).ToList();
        var depth2Dirs = vfs.Directories.AtDepth(2).ToList();

        // Assert
        Assert.Equal(2, depth1Dirs.Count);
        Assert.Contains(depth1Dirs, d => d.Path.Value == "vfs://level1");
        Assert.Contains(depth1Dirs, d => d.Path.Value == "vfs://another_level1");
        
        Assert.Single(depth2Dirs);
        Assert.Equal("vfs://level1/level2", depth2Dirs[0].Path.Value);
    }

    [Fact]
    public void WithMinFileCount_ShouldFilterDirectoriesByFileCount()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateDirectory("/empty/")
           .CreateDirectory("/single/")
           .CreateDirectory("/multiple/")
           .CreateFile("/single/file1.txt", "content")
           .CreateFile("/multiple/file1.txt", "content")
           .CreateFile("/multiple/file2.txt", "content");

        // Act
        var dirsWithFiles = vfs.Directories.WithMinFileCount(1).ToList();
        var dirsWithMultipleFiles = vfs.Directories.WithMinFileCount(2).ToList();

        // Assert
        Assert.Equal(2, dirsWithFiles.Count);
        Assert.Contains(dirsWithFiles, d => d.Path.Value == "vfs://single");
        Assert.Contains(dirsWithFiles, d => d.Path.Value == "vfs://multiple");
        
        Assert.Single(dirsWithMultipleFiles);
        Assert.Equal("vfs://multiple", dirsWithMultipleFiles[0].Path.Value);
    }

    [Fact]
    public void Empty_ShouldFilterEmptyDirectories()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateDirectory("/empty/")
           .CreateDirectory("/with_files/")
           .CreateDirectory("/with_subdirs/")
           .CreateFile("/with_files/file.txt", "content")
           .CreateDirectory("/with_subdirs/subdir/");

        // Act
        var emptyDirs = vfs.Directories.Empty().ToList();

        // Assert
        Assert.Equal(2, emptyDirs.Count);
        Assert.Contains(emptyDirs, d => d.Path.Value == "vfs://empty");
        Assert.Contains(emptyDirs, d => d.Path.Value == "vfs://with_subdirs/subdir");
    }

    [Fact]
    public void FindFilesByGlob_ShouldMatchGlobPatterns()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "content")
           .CreateFileWithDirectories("/docs/guide.txt", "content")
           .CreateFileWithDirectories("/docs/config.json", "content")
           .CreateFileWithDirectories("/src/main.cs", "content");

        // Act
        var txtFiles = vfs.FindFilesByGlob("vfs://**/*.txt").ToList();
        var docsFiles = vfs.FindFilesByGlob("vfs://docs/*").ToList();
        var allTxtFiles = vfs.FindFilesByGlob("vfs://**/*.txt").ToList();

        // Assert
        Assert.Equal(2, txtFiles.Count);
        Assert.Contains(txtFiles, f => f.Path.Value == "vfs://docs/readme.txt");
        Assert.Contains(txtFiles, f => f.Path.Value == "vfs://docs/guide.txt");
        
        Assert.Equal(3, docsFiles.Count);
        
        Assert.Equal(2, allTxtFiles.Count);
    }

    [Fact]
    public void FindDirectoriesByGlob_ShouldMatchGlobPatterns()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateDirectory("/test_docs/")
           .CreateDirectory("/docs/")
           .CreateDirectory("/src/test/")
           .CreateDirectory("/backup/");

        // Act
        var testDirs = vfs.FindDirectoriesByGlob("vfs://*test*").ToList();
        var allTestDirs = vfs.FindDirectoriesByGlob("vfs://**/*test*").ToList();

        // Assert
        Assert.Single(testDirs);
        Assert.Equal("vfs://test_docs", testDirs[0].Path.Value);
        
        Assert.Single(allTestDirs);
        Assert.Contains(allTestDirs, d => d.Path.Value == "vfs://src/test");
    }

    [Fact]
    public void FluentChaining_ShouldWorkCorrectly()
    {
        // Arrange
        var vfs = new VFS();
        vfs.CreateFileWithDirectories("/docs/readme.txt", "This is a README file")
           .CreateFileWithDirectories("/docs/guide.txt", "This is a guide")
           .CreateFileWithDirectories("/docs/config.json", "Configuration data")
           .CreateFileWithDirectories("/src/test.cs", "This is test code");

        // Act
        var result = vfs.Files
            .WithExtension("txt")
            .ContainingText("This")
            .InDirectory("/docs")
            .ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, f => f.Path.Value == "vfs://docs/readme.txt");
        Assert.Contains(result, f => f.Path.Value == "vfs://docs/guide.txt");
    }
}