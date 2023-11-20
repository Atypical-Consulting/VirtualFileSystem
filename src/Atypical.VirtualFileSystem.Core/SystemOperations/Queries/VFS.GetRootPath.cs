namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.GetRootPath()" />
    public VFSPath GetRootPath()
        => this.Root.Path;
}