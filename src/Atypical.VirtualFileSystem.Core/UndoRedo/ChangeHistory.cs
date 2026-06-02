namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Represents a history of changes in a virtual file system.
/// </summary>
public sealed class ChangeHistory
    : IChangeHistory, IDisposable
{
    private readonly IVirtualFileSystem _vfs;
    private readonly Stack<VFSEventArgs> _undoStack = new();
    private readonly Stack<VFSEventArgs> _redoStack = new();
    private bool _disposed;
    private bool _undoingOrRedoing;

    /// <inheritdoc see="IChangeHistory.UndoStack" />
    public IReadOnlyCollection<VFSEventArgs> UndoStack
        => ImmutableList<VFSEventArgs>.Empty.AddRange(_undoStack);
    
    /// <inheritdoc see="IChangeHistory.RedoStack" />
    public IReadOnlyCollection<VFSEventArgs> RedoStack
        => ImmutableList<VFSEventArgs>.Empty.AddRange(_redoStack);
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ChangeHistory"/> class.
    /// </summary>
    /// <param name="vfs">The virtual file system to track changes of.</param>
    public ChangeHistory(IVirtualFileSystem vfs)
    {
        _vfs = vfs;

        // Subscribe to VFS events
        _vfs.DirectoryCreated += OnChange;
        _vfs.FileCreated += OnChange;
        _vfs.DirectoryDeleted += OnChange;
        _vfs.FileDeleted += OnChange;
        _vfs.DirectoryMoved += OnChange;
        _vfs.FileMoved += OnChange;
        _vfs.DirectoryRenamed += OnChange;
        _vfs.FileRenamed += OnChange;
    }
    
    /// <summary>
    /// Finalizes an instance of the <see cref="ChangeHistory"/> class.
    /// </summary>
    ~ChangeHistory()
    {
        Dispose(false);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="ChangeHistory"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    public void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        
        if (disposing)
        {
            // Unsubscribe from VFS events
            _vfs.DirectoryCreated -= OnChange;
            _vfs.FileCreated -= OnChange;
            _vfs.DirectoryDeleted -= OnChange;
            _vfs.FileDeleted -= OnChange;
            _vfs.DirectoryMoved -= OnChange;
            _vfs.FileMoved -= OnChange;
            _vfs.DirectoryRenamed -= OnChange;
            _vfs.FileRenamed -= OnChange;
        }

        _disposed = true;
    }
    
    /// <inheritdoc see="IChangeHistory.OnChange" />
    public void OnChange(VFSEventArgs args)
    {
        if (_undoingOrRedoing)
            return;

        AddChange(args);
    }

    /// <inheritdoc see="IChangeHistory.AddChange" />
    public void AddChange(VFSEventArgs change)
    {
        _undoStack.Push(change);
        _redoStack.Clear(); // Once a new change is made, the redo stack is cleared
    }

    /// <inheritdoc see="IChangeHistory.Undo" />
    public IVirtualFileSystem Undo()
    {
        if (!_undoStack.TryPop(out var change))
            return _vfs;

        _undoingOrRedoing = true;

        try
        {
            // Perform the undo operation based on the type of change
            // /!\ Be vigilant about the inverse of each operation
            switch (change)
            {
                case VFSDirectoryCreatedArgs directoryCreated:
                    _vfs.DeleteDirectory(directoryCreated.Path);
                    break;
                case VFSDirectoryDeletedArgs directoryDeleted:
                    RestoreDeletedSubtree(directoryDeleted);
                    break;
                case VFSDirectoryMovedArgs directoryMoved:
                    _vfs.MoveDirectory(directoryMoved.DestinationPath, directoryMoved.SourcePath);
                    break;
                case VFSDirectoryRenamedArgs directoryRenamed:
                    _vfs.RenameDirectory(directoryRenamed.NewPath, directoryRenamed.OldName);
                    break;
                case VFSFileCreatedArgs fileCreated:
                    _vfs.DeleteFile(fileCreated.Path);
                    break;
                case VFSFileDeletedArgs fileDeleted:
                    _vfs.CreateFile(fileDeleted.Path, fileDeleted.Content);
                    break;
                case VFSFileMovedArgs fileMoved:
                    _vfs.MoveFile(fileMoved.DestinationPath, fileMoved.SourcePath);
                    break;
                case VFSFileRenamedArgs fileRenamed:
                    _vfs.RenameFile(fileRenamed.NewPath, fileRenamed.OldName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(change));
            }
        }
        catch
        {
            // The inverse failed; keep the change on the undo stack so it is not lost.
            _undoStack.Push(change);
            throw;
        }
        finally
        {
            // Always re-enable tracking, even if the inverse threw, so history
            // does not get permanently stuck.
            _undoingOrRedoing = false;
        }

        _redoStack.Push(change);

        return _vfs;
    }

    // Restores a directory and its descendants captured at deletion time.
    // Directories are recreated shallowest-first so parents exist before children,
    // then files are restored with their original content.
    private void RestoreDeletedSubtree(VFSDirectoryDeletedArgs directoryDeleted)
    {
        foreach (var dir in directoryDeleted.DeletedNodes
                     .Where(n => n.IsDirectory)
                     .OrderBy(n => n.Path.Depth))
            if (!_vfs.Index.ContainsKey(dir.Path))
                _vfs.CreateDirectory((VFSDirectoryPath)dir.Path);

        foreach (var file in directoryDeleted.DeletedNodes.Where(n => !n.IsDirectory))
            _vfs.CreateFile((VFSFilePath)file.Path, file.Content);
    }

    /// <inheritdoc see="IChangeHistory.Redo" />
    public IVirtualFileSystem Redo()
    {
        if (!_redoStack.TryPop(out var change))
            return _vfs;

        _undoingOrRedoing = true;

        try
        {
            // Perform the redo operation based on the type of change
            switch (change)
            {
                case VFSDirectoryCreatedArgs directoryCreated:
                    _vfs.CreateDirectory(directoryCreated.Path);
                    break;
                case VFSFileCreatedArgs fileCreated:
                    _vfs.CreateFile(fileCreated.Path, fileCreated.Content);
                    break;
                case VFSDirectoryDeletedArgs directoryDeleted:
                    _vfs.DeleteDirectory(directoryDeleted.Path);
                    break;
                case VFSFileDeletedArgs fileDeleted:
                    _vfs.DeleteFile(fileDeleted.Path);
                    break;
                case VFSDirectoryMovedArgs directoryMoved:
                    _vfs.MoveDirectory(directoryMoved.SourcePath, directoryMoved.DestinationPath);
                    break;
                case VFSFileMovedArgs fileMoved:
                    _vfs.MoveFile(fileMoved.SourcePath, fileMoved.DestinationPath);
                    break;
                case VFSDirectoryRenamedArgs directoryRenamed:
                    _vfs.RenameDirectory(directoryRenamed.Path, directoryRenamed.NewName);
                    break;
                case VFSFileRenamedArgs fileRenamed:
                    _vfs.RenameFile(fileRenamed.Path, fileRenamed.NewName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(change));
            }
        }
        catch
        {
            // The redo failed; keep the change on the redo stack so it is not lost.
            _redoStack.Push(change);
            throw;
        }
        finally
        {
            _undoingOrRedoing = false;
        }

        _undoStack.Push(change);

        return _vfs;
    }
}