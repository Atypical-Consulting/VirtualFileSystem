namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.RenameFile(VFSFilePath, string)" />
    public IVirtualFileSystem RenameFile(
        VFSFilePath filePath,
        string newName)
    {
        if (!Index.TryGetValue(filePath, out var fileNode))
            ThrowVirtualFileNotFound(filePath);

        // Remove the file from its old parent directory
        if (TryGetDirectory(filePath.Parent, out var oldParent))
            oldParent.RemoveChild(fileNode);

        // update the file node with the new path
        var newFilePath = new VFSFilePath($"{filePath.Parent}/{newName}");
        var updatedFileNode = fileNode.UpdatePath(newFilePath);

        // Add the file to its new parent directory
        if (TryGetDirectory(newFilePath.Parent, out var newParent))
            newParent.AddChild(updatedFileNode);

        // update the index
        Index.Remove(filePath);
        Index[newFilePath] = updatedFileNode;

        return this;
    }
}