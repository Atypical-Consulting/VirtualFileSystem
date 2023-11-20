namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(VFSFilePath)" />
    public IVirtualFileSystem DeleteFile(VFSFilePath filePath)
    {
        // try to get the file
        var found = TryGetFile(filePath, out _);
        if (!found)
            ThrowVirtualFileNotFound(filePath);

        // remove the file from the index
        Index.Remove(filePath);

        return this;
    }
}