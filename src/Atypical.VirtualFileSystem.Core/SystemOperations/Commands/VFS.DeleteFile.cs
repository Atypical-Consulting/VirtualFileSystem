namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(VFSFilePath)" />
    public IVirtualFileSystem DeleteFile(VFSFilePath filePath)
    {
        // try to get the file
        var found = this.TryGetFile(filePath, out _);
        if (!found)
            ThrowVirtualFileNotFound(filePath);

        // remove the file from the index
        this.Index.Remove(filePath.Value);

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(string)" />
    public IVirtualFileSystem DeleteFile(string filePath)
        => DeleteFile(new VFSFilePath(filePath));
}