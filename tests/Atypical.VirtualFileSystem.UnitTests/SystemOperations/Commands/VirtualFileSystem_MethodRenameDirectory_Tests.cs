namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodRenameDirectory_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private readonly VFSDirectoryPath _directoryPath = new("dir1/dir2/dir3");
    private const string NewDirectoryPath = "new_dir";

    private void Act()
        => _vfs.RenameDirectory(_directoryPath, NewDirectoryPath);

    [Fact]
    public void RenameDirectory_renames_a_directory()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var indexLength = _vfs.Index.Count;
        var tree = _vfs.GetTree();

        // Act
        Act();

        // Assert
        _vfs.Index.Count.Should().Be(indexLength);
        _vfs.Index.RawIndex.Should().NotContainKey(new VFSDirectoryPath("vfs://dir1/dir2/dir3"));
        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://dir1/dir2/new_dir"));
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].IsDirectory.Should().BeTrue();
        _vfs.GetTree().Should().NotBe(tree);
    }
        
    [Fact]
    public void RenameDirectory_updates_the_directory_path()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);

        // Act
        Act();

        // Assert
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].Path.Value
            .Should().Be("vfs://dir1/dir2/new_dir");
    }
        
    [Fact]
    public void RenameDirectory_updates_the_last_write_time()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var creationTime = _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].CreationTime;
        var lastAccessTime = _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastAccessTime;
        var lastWriteTime = _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/dir3")].LastWriteTime;

        // Act
        Thread.Sleep(100);
        Act();

        // Assert
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].CreationTime.Should().Be(creationTime);
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].LastAccessTime.Should().Be(lastAccessTime);
        _vfs.Index[new VFSDirectoryPath("vfs://dir1/dir2/new_dir")].LastWriteTime.Should().NotBe(lastWriteTime);
    }
    
    [Fact]
    public void RenameDirectory_throws_an_exception_if_the_directory_does_not_exist()
    {
        // Act
        Action action = () => Act();

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The directory 'vfs://dir1/dir2/dir3' does not exist in the index.");
    }
    
    [Fact]
    public void RenameDirectory_raises_a_DirectoryRenamed_event()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var eventRaised = false;

        _vfs.DirectoryRenamed += args => 
        {
            eventRaised = true;
            args.Path.Should().Be(_directoryPath);
            args.NewName.Should().Be("new_dir");
        };

        // Act
        Act();

        // Assert
        eventRaised.Should().BeTrue();
    }
    
    [Fact]
    public void RenameDirectory_adds_a_change_to_the_ChangeHistory()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);

        // Act
        Act();

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();

        // Assert
        _vfs.ChangeHistory.UndoStack.Should().ContainEquivalentOf(change);
        _vfs.ChangeHistory.UndoStack.Should().HaveCount(4);
        _vfs.ChangeHistory.RedoStack.Should().BeEmpty();
    }

    [Fact]
    public void RenameDirectory_can_be_undone_and_redone()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var originalPath = _directoryPath;
        var newPath = new VFSDirectoryPath("dir1/dir2/new_dir");

        // Act - Rename directory
        Act();

        // Assert - Directory should be renamed
        _vfs.Index.RawIndex.Should().NotContainKey(originalPath);
        _vfs.Index.RawIndex.Should().ContainKey(newPath);

        // Act - Undo rename
        _vfs.ChangeHistory.Undo();

        // Assert - Directory should be back to original name
        _vfs.Index.RawIndex.Should().ContainKey(originalPath);
        _vfs.Index.RawIndex.Should().NotContainKey(newPath);

        // Act - Redo rename
        _vfs.ChangeHistory.Redo();

        // Assert - Directory should be renamed again
        _vfs.Index.RawIndex.Should().NotContainKey(originalPath);
        _vfs.Index.RawIndex.Should().ContainKey(newPath);
    }

    [Fact]
    public void RenameDirectory_updates_nested_file_paths()
    {
        // Arrange
        _vfs.CreateDirectory(_directoryPath);
        var nestedFilePath = new VFSFilePath("dir1/dir2/dir3/file.txt");
        var deepNestedFilePath = new VFSFilePath("dir1/dir2/dir3/subdir/nested.txt");
        _vfs.CreateFile(nestedFilePath, "content1");
        _vfs.CreateDirectory(new VFSDirectoryPath("dir1/dir2/dir3/subdir"));
        _vfs.CreateFile(deepNestedFilePath, "content2");
        var indexLength = _vfs.Index.Count;

        // Act
        Act();

        // Assert
        _vfs.Index.Count.Should().Be(indexLength);

        // Verify old paths no longer exist
        _vfs.Index.RawIndex.Should().NotContainKey(nestedFilePath);
        _vfs.Index.RawIndex.Should().NotContainKey(deepNestedFilePath);

        // Verify new paths exist
        var newNestedFilePath = new VFSFilePath("dir1/dir2/new_dir/file.txt");
        var newDeepNestedFilePath = new VFSFilePath("dir1/dir2/new_dir/subdir/nested.txt");
        _vfs.Index.RawIndex.Should().ContainKey(newNestedFilePath);
        _vfs.Index.RawIndex.Should().ContainKey(newDeepNestedFilePath);

        // Verify file contents are preserved
        _vfs.Index[newNestedFilePath].As<IFileNode>().Content.Should().Be("content1");
        _vfs.Index[newDeepNestedFilePath].As<IFileNode>().Content.Should().Be("content2");

        // Verify file paths are updated
        _vfs.Index[newNestedFilePath].Path.Value.Should().Be("vfs://dir1/dir2/new_dir/file.txt");
        _vfs.Index[newDeepNestedFilePath].Path.Value.Should().Be("vfs://dir1/dir2/new_dir/subdir/nested.txt");
    }

    [Fact]
    public void RenameDirectory_handles_deeply_nested_structure()
    {
        // Arrange - Create deeply nested structure: /a/b/c/d/e with files at each level
        var deepPath = new VFSDirectoryPath("a/b/c/d/e");
        _vfs.CreateDirectory(deepPath);

        // Create files at various levels
        var fileAtB = new VFSFilePath("a/b/file_b.txt");
        var fileAtC = new VFSFilePath("a/b/c/file_c.txt");
        var fileAtD = new VFSFilePath("a/b/c/d/file_d.txt");
        var fileAtE = new VFSFilePath("a/b/c/d/e/file_e.txt");

        _vfs.CreateFile(fileAtB, "content_b");
        _vfs.CreateFile(fileAtC, "content_c");
        _vfs.CreateFile(fileAtD, "content_d");
        _vfs.CreateFile(fileAtE, "content_e");

        // Create additional subdirectories at different levels
        var subdirAtC = new VFSDirectoryPath("a/b/c/subdir_c");
        var subdirAtE = new VFSDirectoryPath("a/b/c/d/e/subdir_e");
        _vfs.CreateDirectory(subdirAtC);
        _vfs.CreateDirectory(subdirAtE);

        // Create files in subdirectories
        var fileInSubdirC = new VFSFilePath("a/b/c/subdir_c/nested.txt");
        var fileInSubdirE = new VFSFilePath("a/b/c/d/e/subdir_e/deep.txt");
        _vfs.CreateFile(fileInSubdirC, "nested_content");
        _vfs.CreateFile(fileInSubdirE, "deep_content");

        var indexLength = _vfs.Index.Count;

        // Act - Rename directory 'c' to 'renamed_c'
        var pathToRename = new VFSDirectoryPath("a/b/c");
        _vfs.RenameDirectory(pathToRename, "renamed_c");

        // Assert
        _vfs.Index.Count.Should().Be(indexLength);

        // Verify old paths no longer exist
        _vfs.Index.RawIndex.Should().NotContainKey(new VFSDirectoryPath("vfs://a/b/c"));
        _vfs.Index.RawIndex.Should().NotContainKey(fileAtC);
        _vfs.Index.RawIndex.Should().NotContainKey(fileAtD);
        _vfs.Index.RawIndex.Should().NotContainKey(fileAtE);
        _vfs.Index.RawIndex.Should().NotContainKey(subdirAtC);
        _vfs.Index.RawIndex.Should().NotContainKey(subdirAtE);
        _vfs.Index.RawIndex.Should().NotContainKey(fileInSubdirC);
        _vfs.Index.RawIndex.Should().NotContainKey(fileInSubdirE);

        // Verify new paths exist
        var newFileAtC = new VFSFilePath("a/b/renamed_c/file_c.txt");
        var newFileAtD = new VFSFilePath("a/b/renamed_c/d/file_d.txt");
        var newFileAtE = new VFSFilePath("a/b/renamed_c/d/e/file_e.txt");
        var newSubdirAtC = new VFSDirectoryPath("a/b/renamed_c/subdir_c");
        var newSubdirAtE = new VFSDirectoryPath("a/b/renamed_c/d/e/subdir_e");
        var newFileInSubdirC = new VFSFilePath("a/b/renamed_c/subdir_c/nested.txt");
        var newFileInSubdirE = new VFSFilePath("a/b/renamed_c/d/e/subdir_e/deep.txt");

        _vfs.Index.RawIndex.Should().ContainKey(new VFSDirectoryPath("vfs://a/b/renamed_c"));
        _vfs.Index.RawIndex.Should().ContainKey(newFileAtC);
        _vfs.Index.RawIndex.Should().ContainKey(newFileAtD);
        _vfs.Index.RawIndex.Should().ContainKey(newFileAtE);
        _vfs.Index.RawIndex.Should().ContainKey(newSubdirAtC);
        _vfs.Index.RawIndex.Should().ContainKey(newSubdirAtE);
        _vfs.Index.RawIndex.Should().ContainKey(newFileInSubdirC);
        _vfs.Index.RawIndex.Should().ContainKey(newFileInSubdirE);

        // Verify file contents are preserved
        _vfs.Index[fileAtB].As<IFileNode>().Content.Should().Be("content_b"); // Not affected by rename
        _vfs.Index[newFileAtC].As<IFileNode>().Content.Should().Be("content_c");
        _vfs.Index[newFileAtD].As<IFileNode>().Content.Should().Be("content_d");
        _vfs.Index[newFileAtE].As<IFileNode>().Content.Should().Be("content_e");
        _vfs.Index[newFileInSubdirC].As<IFileNode>().Content.Should().Be("nested_content");
        _vfs.Index[newFileInSubdirE].As<IFileNode>().Content.Should().Be("deep_content");

        // Verify file paths are correctly updated
        _vfs.Index[newFileAtC].Path.Value.Should().Be("vfs://a/b/renamed_c/file_c.txt");
        _vfs.Index[newFileAtD].Path.Value.Should().Be("vfs://a/b/renamed_c/d/file_d.txt");
        _vfs.Index[newFileAtE].Path.Value.Should().Be("vfs://a/b/renamed_c/d/e/file_e.txt");
        _vfs.Index[newFileInSubdirC].Path.Value.Should().Be("vfs://a/b/renamed_c/subdir_c/nested.txt");
        _vfs.Index[newFileInSubdirE].Path.Value.Should().Be("vfs://a/b/renamed_c/d/e/subdir_e/deep.txt");

        // Verify directory paths are correctly updated
        _vfs.Index[new VFSDirectoryPath("vfs://a/b/renamed_c")].Path.Value.Should().Be("vfs://a/b/renamed_c");
        _vfs.Index[newSubdirAtC].Path.Value.Should().Be("vfs://a/b/renamed_c/subdir_c");
        _vfs.Index[newSubdirAtE].Path.Value.Should().Be("vfs://a/b/renamed_c/d/e/subdir_e");
    }
}