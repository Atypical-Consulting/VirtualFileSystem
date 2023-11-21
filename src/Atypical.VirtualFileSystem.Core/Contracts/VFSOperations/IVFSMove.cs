namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents the move operations of the virtual file system.
/// </summary>
public interface IVFSMove
{
    /// <summary>
    ///     Event triggered when a directory is moved.
    /// </summary>
    public event Action<VFSDirectoryMovedArgs> DirectoryMoved;

    /// <summary>
    ///     Event triggered when a file is moved.
    /// </summary>
    public event Action<VFSFileMovedArgs> FileMoved;
    
    /// <summary>
    /// Moves a directory from one location to another.
    /// </summary>
    /// <param name="sourceDirectoryPath">The source directory path.</param>
    /// <param name="destinationDirectoryPath">The destination directory path.</param>
    /// <returns>The virtual file system.</returns>
    IVirtualFileSystem MoveDirectory(VFSDirectoryPath sourceDirectoryPath, VFSDirectoryPath destinationDirectoryPath);
    
    /// <summary>
    ///     Moves a file node from the source path to the destination path.
    ///     Both paths must be absolute.
    /// </summary>
    /// <param name="sourceFilePath">The source path of the file node.</param>
    /// <param name="destinationFilePath">The destination path of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem MoveFile(VFSFilePath sourceFilePath, VFSFilePath destinationFilePath);
}