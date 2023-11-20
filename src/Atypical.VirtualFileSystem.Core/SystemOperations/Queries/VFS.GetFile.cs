namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.GetFile(VFSFilePath)" />
    public IFileNode GetFile(VFSFilePath filePath)
        => Index.GetFile(filePath);
}
