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
        this.AddToIndex(directory);

        this.TryGetDirectory(directoryPath.Parent, out var parent);
        parent?.AddChild(directory);

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.CreateDirectory(string)" />
    public IVirtualFileSystem CreateDirectory(string directoryPath)
        => CreateDirectory(new VFSDirectoryPath(directoryPath));
}