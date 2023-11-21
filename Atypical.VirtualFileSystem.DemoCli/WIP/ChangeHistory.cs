using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;

namespace Atypical.VirtualFileSystem.DemoCli.WIP;

public class ChangeHistory
{
    private readonly IVirtualFileSystem _vfs;
    private readonly Stack<VFSEventArgs> _undoStack = new();
    private readonly Stack<VFSEventArgs> _redoStack = new();
    
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
    
    private void OnChange(VFSEventArgs args)
    {
        AddChange(args);
    }
    
    public void AddChange(VFSEventArgs change)
    {
        _undoStack.Push(change);
        _redoStack.Clear(); // Once a new change is made, the redo stack is cleared
    }

    public IVirtualFileSystem Undo()
    {
        if (!_undoStack.TryPop(out var change))
            return _vfs;
        
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
            
        _redoStack.Push(change);

        return _vfs;
    }

    public IVirtualFileSystem Redo()
    {
        if (!_redoStack.TryPop(out var change))
            return _vfs;
        
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

        _undoStack.Push(change);
        return _vfs;
    }
}