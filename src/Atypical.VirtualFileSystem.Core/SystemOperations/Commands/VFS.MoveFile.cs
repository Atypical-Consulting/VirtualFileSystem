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
        
        var updatedFileNode = fileNode.UpdatePath(destinationFilePath);

        Index.Remove(sourceFilePath);
        Index[destinationFilePath] = updatedFileNode;

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.MoveFile(string, string)" />
    public IVirtualFileSystem MoveFile(
        string sourceFilePath,
        string destinationFilePath)
        => MoveFile(new VFSFilePath(sourceFilePath), new VFSFilePath(destinationFilePath));
}