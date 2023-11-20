namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
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