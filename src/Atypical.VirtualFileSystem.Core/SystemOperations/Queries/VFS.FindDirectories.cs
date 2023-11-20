namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories(Func{IDirectoryNode,bool})" />
    public IEnumerable<IDirectoryNode> FindDirectories(
        Func<IDirectoryNode, bool> predicate)
        => Index.Directories.Where(predicate);
    
    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories(Regex)" />
    public IEnumerable<IDirectoryNode> FindDirectories(Regex regexPattern)
        => FindDirectories(f => f.Path.IsMatch(regexPattern));
}