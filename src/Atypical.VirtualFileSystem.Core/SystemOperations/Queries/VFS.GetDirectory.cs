namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.GetDirectory(VFSDirectoryPath)" />
    public IDirectoryNode GetDirectory(VFSDirectoryPath directoryPath)
        // if the path is the root path, return the root node
        => directoryPath.IsRoot
            ? Root
            : Index.GetDirectory(directoryPath);
}