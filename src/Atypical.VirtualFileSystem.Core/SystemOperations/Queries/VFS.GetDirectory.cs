namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.GetDirectory(VFSDirectoryPath)" />
    public IDirectoryNode GetDirectory(VFSDirectoryPath directoryPath)
        // if the path is the root path, return the root node
        => directoryPath.IsRoot
            ? this.Root
            : (IDirectoryNode)this.Index[directoryPath];

    /// <inheritdoc cref="IVirtualFileSystem.GetDirectory(string)" />
    public IDirectoryNode GetDirectory(string directoryPath)
        => GetDirectory(new VFSDirectoryPath(directoryPath));
}