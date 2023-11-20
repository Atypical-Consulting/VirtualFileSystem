namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides helper methods for throwing exceptions related to the virtual file system.
/// </summary>
public partial record VFS
{
    /// <summary>
    /// Throws a VFSException indicating that a virtual file was not found.
    /// </summary>
    /// <param name="filePath">The path of the file that was not found.</param>
    [DoesNotReturn]
    private static void ThrowVirtualFileNotFound(VFSFilePath filePath)
        => ThrowVFSException($"The file '{filePath}' does not exist in the index.");

    /// <summary>
    /// Throws a VFSException indicating that a virtual directory was not found.
    /// </summary>
    /// <param name="directoryPath">The path of the directory that was not found.</param>
    [DoesNotReturn]
    private static void ThrowVirtualDirectoryNotFound(VFSDirectoryPath directoryPath)
        => ThrowVFSException($"The directory '{directoryPath}' does not exist in the index.");

    /// <summary>
    /// Throws a VFSException indicating that the root directory cannot be deleted.
    /// </summary>
    [DoesNotReturn]
    private static void ThrowCannotDeleteRootDirectory()
        => ThrowVFSException("Cannot delete the root directory.");

    /// <summary>
    /// Throws a VFSException indicating that the root directory cannot be created.
    /// </summary>
    [DoesNotReturn]
    private static void ThrowCannotCreateRootDirectory()
        => ThrowVFSException("Cannot create the root directory.");

    /// <summary>
    /// Throws a VFSException indicating that a directory cannot be created without a parent.
    /// </summary>
    [DoesNotReturn]
    private static void ThrowCannotCreateDirectoryWithoutParent()
        => ThrowVFSException("Cannot create a directory without a parent.");

    /// <summary>
    /// Throws a VFSException indicating that a virtual node already exists.
    /// </summary>
    /// <param name="node">The node that already exists.</param>
    /// <exception cref="VirtualFileSystemException">The node already exists.</exception>
    [DoesNotReturn]
    private static void ThrowVirtualNodeAlreadyExists(IVirtualFileSystemNode node) 
        => ThrowVFSException($"The node '{node.Path}' already exists in the index.");

    /// <summary>
    /// Throws a VFSException with the provided message.
    /// </summary>
    /// <param name="message">The message to include in the exception.</param>
    [DoesNotReturn]
    private static void ThrowVFSException(string message)
        => throw new VirtualFileSystemException(message);
}