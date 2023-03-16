namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.IsEmpty()" />
    public bool IsEmpty()
        => this.Index.Count == 0;
}