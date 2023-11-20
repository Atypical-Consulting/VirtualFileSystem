namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.MoveDirectory(VFSDirectoryPath, VFSDirectoryPath)" />
    public IVirtualFileSystem MoveDirectory(
        VFSDirectoryPath sourceDirectoryPath,
        VFSDirectoryPath destinationDirectoryPath)
    {
        if (!Index.TryGetValue(sourceDirectoryPath, out var directoryNode))
            ThrowVirtualDirectoryNotFound(sourceDirectoryPath);

        // Remove the directory from its old parent directory
        if (TryGetDirectory(sourceDirectoryPath.Parent, out var oldParent))
            oldParent.RemoveChild(directoryNode);

        var updatedDirectoryNode = directoryNode.UpdatePath(destinationDirectoryPath);

        // Add the directory to its new parent directory
        if (TryGetDirectory(destinationDirectoryPath.Parent, out var newParent))
            newParent.AddChild(updatedDirectoryNode);

        Index.Remove(sourceDirectoryPath);
        Index[destinationDirectoryPath] = updatedDirectoryNode;

        return this;
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.MoveFile(VFSFilePath, VFSFilePath)" />
    public IVirtualFileSystem MoveFile(
        VFSFilePath sourceFilePath,
        VFSFilePath destinationFilePath)
    {
        if (!Index.TryGetValue(sourceFilePath, out var fileNode))
            ThrowVirtualFileNotFound(sourceFilePath);

        // Remove the file from its old parent directory
        if (TryGetDirectory(sourceFilePath.Parent, out var oldParent)) 
            oldParent.RemoveChild(fileNode);

        var updatedFileNode = fileNode.UpdatePath(destinationFilePath);

        // Add the file to its new parent directory
        if (TryGetDirectory(destinationFilePath.Parent, out var newParent)) 
            newParent.AddChild(updatedFileNode);

        Index.Remove(sourceFilePath);
        Index[destinationFilePath] = updatedFileNode;

        return this;
    }
}