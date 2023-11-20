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
    
    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(VFSFilePath,string?)" />
    public IVirtualFileSystem CreateFile(VFSFilePath filePath, string? content = null)
    {
        if (filePath.Parent is null)
            ThrowCannotCreateDirectoryWithoutParent();

        var file = new FileNode(filePath, content);
        AddToIndex(file);

        TryGetDirectory(filePath.Parent, out var parent);
        parent?.AddChild(file);

        return this;
    }
}