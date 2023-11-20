namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
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