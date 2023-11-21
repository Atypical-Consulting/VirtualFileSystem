namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents the deletion operations of the virtual file system.
/// </summary>
public interface IVFSDelete
{
    /// <summary>
    ///     Event triggered when a directory is deleted.
    /// </summary>
    public event Action<VFSDirectoryDeletedArgs> DirectoryDeleted;

    /// <summary>
    ///     Event triggered when a file is deleted.
    /// </summary>
    public event Action<VFSFileDeletedArgs> FileDeleted;
    
    /// <summary>
    ///     Deletes a directory node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem DeleteDirectory(VFSDirectoryPath directoryPath);

    /// <summary>
    ///     Deletes a file node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem DeleteFile(VFSFilePath filePath);
}