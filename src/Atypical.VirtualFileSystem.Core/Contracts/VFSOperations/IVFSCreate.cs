namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents the creation operations of the virtual file system.
/// </summary>
public interface IVFSCreate
{
    /// <summary>
    ///     Event triggered when a directory is created.
    /// </summary>
    event Action<VFSDirectoryCreatedArgs>? DirectoryCreated;
    
    /// <summary>
    ///     Event triggered when a file is created.
    /// </summary> 
    event Action<VFSFileCreatedArgs>? FileCreated;
    
    /// <summary>
    ///     Creates a directory node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem CreateDirectory(VFSDirectoryPath directoryPath);

    /// <summary>
    ///     Creates a file node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <param name="content">The content of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem CreateFile(VFSFilePath filePath, string? content = null);
}