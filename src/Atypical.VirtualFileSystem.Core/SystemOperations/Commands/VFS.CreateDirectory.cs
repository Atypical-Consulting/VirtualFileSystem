namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.CreateDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem CreateDirectory(VFSDirectoryPath directoryPath)
    {
        if (directoryPath.IsRoot)
            ThrowCannotCreateRootDirectory();

        if (directoryPath.Parent is null)
            ThrowCannotCreateDirectoryWithoutParent();

        var directory = new DirectoryNode(directoryPath);
        AddToIndex(directory);

        TryGetDirectory(directoryPath.Parent, out var parent);
        parent?.AddChild(directory);

        return this;
    }
}