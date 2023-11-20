namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(VFSFilePath,string?)" />
    public IVirtualFileSystem CreateFile(VFSFilePath filePath, string? content = null)
    {
        if (filePath.Parent is null)
            ThrowCannotCreateDirectoryWithoutParent();

        var file = new FileNode(filePath, content);
        this.AddToIndex(file);

        this.TryGetDirectory(filePath.Parent, out var parent);
        parent?.AddChild(file);

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(string,string?)" />
    public IVirtualFileSystem CreateFile(string filePath, string? content = null)
        => CreateFile(new VFSFilePath(filePath), content);
}