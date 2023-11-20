namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
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