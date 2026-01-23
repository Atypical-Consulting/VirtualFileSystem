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
}