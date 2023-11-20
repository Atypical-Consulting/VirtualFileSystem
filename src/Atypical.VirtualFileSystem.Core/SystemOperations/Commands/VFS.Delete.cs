namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.DeleteDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem DeleteDirectory(VFSDirectoryPath directoryPath)
    {
        // cannot delete the root directory
        if (directoryPath.IsRoot)
            ThrowCannotDeleteRootDirectory();

        // try to get the directory
        if (!Index.TryGetValue(directoryPath, out var directoryNode))
            ThrowVirtualDirectoryNotFound(directoryPath);

        // Remove the directory from its parent directory
        if (TryGetDirectory(directoryPath.Parent, out var parent))
            parent.RemoveChild(directoryNode);

        // find the path and its children in the index
        var paths = Index.GetPathsStartingWith(directoryPath);

        // remove the paths from the index
        foreach (var p in paths)
            Index.Remove(p);

        return this;
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(VFSFilePath)" />
    public IVirtualFileSystem DeleteFile(VFSFilePath filePath)
    {
        if (!Index.TryGetValue(filePath, out var fileNode))
            ThrowVirtualFileNotFound(filePath);

        // Remove the file from its parent directory
        if (TryGetDirectory(filePath.Parent, out var parent))
            parent.RemoveChild(fileNode);

        // remove the file from the index
        Index.Remove(filePath);

        return this;
    }
}