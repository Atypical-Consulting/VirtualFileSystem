using System.Collections.Immutable;

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
        
        // Perform the undo operation based on the type of change
        // /!\ Be vigilant about the inverse of each operation
        switch (change)
        {
            case VFSDirectoryCreatedArgs directoryCreated:
                _vfs.DeleteDirectory(directoryCreated.Path);
                break;
            case VFSDirectoryDeletedArgs directoryDeleted:
                // For directory deleted, you need to restore the directory. 
                // However, the VFSDirectoryDeletedArgs does not contain enough information to restore the directory.
                // You may need to modify your event args to contain more information or change your design.
                throw new NotImplementedException();
            case VFSDirectoryMovedArgs directoryMoved:
                _vfs.MoveDirectory(directoryMoved.DestinationPath, directoryMoved.SourcePath);
                break;
            case VFSDirectoryRenamedArgs directoryRenamed:
                _vfs.RenameDirectory(directoryRenamed.Path, directoryRenamed.OldName);
                break;
            case VFSFileCreatedArgs fileCreated:
                _vfs.DeleteFile(fileCreated.Path);
                break;
            case VFSFileDeletedArgs fileDeleted:
                // For file deleted, you need to restore the file. 
                // However, the VFSFileDeletedArgs does not contain enough information to restore the file.
                // You may need to modify your event args to contain more information or change your design.
                throw new NotImplementedException();
            case VFSFileMovedArgs fileMoved:
                _vfs.MoveFile(fileMoved.DestinationPath, fileMoved.SourcePath);
                break;
            case VFSFileRenamedArgs fileRenamed:
                _vfs.RenameFile(fileRenamed.Path, fileRenamed.OldName);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(change));
        }
        
        _undoingOrRedoing = false;
        _redoStack.Push(change);

        return _vfs;
    }

    /// <inheritdoc see="IChangeHistory.Redo" />
    public IVirtualFileSystem Redo()
    {
        if (!_redoStack.TryPop(out var change))
            return _vfs;
        
        _undoingOrRedoing = true;
        
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
        
        _undoingOrRedoing = false;
        _undoStack.Push(change);
        
        return _vfs;
    }
}