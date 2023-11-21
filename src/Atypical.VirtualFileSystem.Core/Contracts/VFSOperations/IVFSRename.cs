namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents the rename operations of the virtual file system.
/// </summary>
public interface IVFSRename
{
    /// <summary>
    /// Event triggered when a directory is renamed.
    /// </summary>
    event Action<VFSDirectoryRenamedArgs> DirectoryRenamed;
    
    /// <summary>
    /// Event triggered when a file is renamed.
    /// </summary>
    event Action<VFSFileRenamedArgs> FileRenamed;
    
    /// <summary>
    ///     Renames a directory node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <param name="newDir">The new name of the directory node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem RenameDirectory(VFSDirectoryPath directoryPath, string newDir);

    // RenameFile
    /// <summary>
    ///     Renames a file node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <param name="newName">The new name of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem RenameFile(VFSFilePath filePath, string newName);
}