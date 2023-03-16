namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories()" />
    public IEnumerable<IDirectoryNode> FindDirectories()
        => this.Index.Values
            .OfType<IDirectoryNode>();

    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories(Regex)" />
    public IEnumerable<IDirectoryNode> FindDirectories(
        Regex regexPattern)
        => SelectDirectories(f => regexPattern.IsMatch(f.Path.Value));

    /// <inheritdoc cref="IVirtualFileSystem.SelectDirectories(Func{IDirectoryNode,bool})" />
    public IEnumerable<IDirectoryNode> SelectDirectories(
        Func<IDirectoryNode, bool> predicate)
        => FindDirectories()
            .Where(predicate);
}