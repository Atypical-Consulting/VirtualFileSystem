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

        // update the file node with the new path
        var newFilePath = new VFSFilePath($"{filePath.Parent}/{newName}");
        var updatedFileNode = fileNode.UpdatePath(newFilePath);
        
        // update the index
        Index.Remove(filePath);
        Index[newFilePath] = updatedFileNode;
        
        // update the parent directory
        var parentDirectoryPath = filePath.Parent;
        var parentDirectoryNode = Index[parentDirectoryPath];

        return this;
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.RenameFile(string, string)" />
    public IVirtualFileSystem RenameFile(
        string filePath,
        string newName)
        => RenameFile(new VFSFilePath(filePath), newName);
}