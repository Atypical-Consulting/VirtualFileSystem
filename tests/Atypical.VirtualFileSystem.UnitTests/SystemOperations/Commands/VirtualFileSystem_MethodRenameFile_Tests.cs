namespace VirtualFileSystem.UnitTests.SystemOperations.Commands;

public class VirtualFileSystem_MethodRenameFile_Tests : VirtualFileSystemTestsBase
{
    private readonly IVirtualFileSystem _vfs = CreateVFS();
    private readonly VFSFilePath _filePath = new("dir1/dir2/dir3/file.txt");
    private const string NewFilePath = "new_file.txt";

    private void Act()
        => _vfs.RenameFile(_filePath, NewFilePath);

    [Fact]
    public void RenameFile_renames_a_file()
    {
        // Arrange
        _vfs.CreateFile(_filePath);
        var indexLength = _vfs.Index.Count;
        var tree = _vfs.GetTree();

        // Act
        Act();

        // Assert
        _vfs.Index.Count.Should().Be(indexLength);
        _vfs.Index.RawIndex.Should().NotContainKey(new VFSFilePath("vfs://dir1/dir2/dir3/file.txt"));
        _vfs.Index.RawIndex.Should().ContainKey(new VFSFilePath("vfs://dir1/dir2/dir3/new_file.txt"));
        _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/new_file.txt")].IsFile.Should().BeTrue();
        _vfs.GetTree().Should().NotBe(tree);
    }
        
    [Fact]
    public void RenameFile_updates_the_file_path()
    {
        // Arrange
        _vfs.CreateFile(_filePath);

        // Act
        Act();

        // Assert
        _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/new_file.txt")].Path.Value
            .Should().Be("vfs://dir1/dir2/dir3/new_file.txt");
    }
        
    [Fact]
    public void RenameFile_updates_the_last_write_time()
    {
        // Arrange
        _vfs.CreateFile(_filePath);
        var creationTime = _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/file.txt")].CreationTime;
        var lastAccessTime = _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/file.txt")].LastAccessTime;
        var lastWriteTime = _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/file.txt")].LastWriteTime;

        // Act
        Thread.Sleep(100);
        Act();

        // Assert
        _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/new_file.txt")].CreationTime.Should().Be(creationTime);
        _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/new_file.txt")].LastAccessTime.Should().Be(lastAccessTime);
        _vfs.Index[new VFSFilePath("vfs://dir1/dir2/dir3/new_file.txt")].LastWriteTime.Should().NotBe(lastWriteTime);
    }
        
    [Fact]
    public void RenameFile_throws_an_exception_if_the_file_does_not_exist()
    {
        // Act
        Action action = () => Act();

        // Assert
        action.Should()
            .Throw<VirtualFileSystemException>()
            .WithMessage("The file 'vfs://dir1/dir2/dir3/file.txt' does not exist in the index.");
    }
    
    [Fact]
    public void RenameFile_raises_a_FileRenamed_event()
    {
        // Arrange
        _vfs.CreateFile(_filePath);
        var eventRaised = false;

        _vfs.FileRenamed += args => 
        {
            eventRaised = true;
            args.Path.Should().Be(_filePath);
            args.NewName.Should().Be("vfs://dir1/dir2/dir3/new_file.txt");
        };

        // Act
        Act();

        // Assert
        eventRaised.Should().BeTrue();
    }
    
    [Fact]
    public void RenameFile_adds_a_change_to_the_ChangeHistory()
    {
        // Arrange
        _vfs.CreateFile(_filePath);

        // Act
        Act();

        // Retrieve the change from the UndoStack
        var change = _vfs.ChangeHistory.UndoStack.First();
        
        // Assert
        _vfs.ChangeHistory.UndoStack.Should().ContainEquivalentOf(change);
        _vfs.ChangeHistory.UndoStack.Should().HaveCount(5);
        _vfs.ChangeHistory.RedoStack.Should().BeEmpty();
    }
}