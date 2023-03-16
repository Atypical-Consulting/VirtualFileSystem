namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.GetFile(VFSFilePath)" />
    public IFileNode GetFile(VFSFilePath filePath)
        => (IFileNode)this.Index[filePath.Value];

    /// <inheritdoc cref="IVirtualFileSystem.GetFile(string)" />
    public IFileNode GetFile(string filePath)
        => GetFile(new VFSFilePath(filePath));
}
