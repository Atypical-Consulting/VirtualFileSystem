namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.FindFiles(Func{IFileNode,bool})" />
    public IEnumerable<IFileNode> FindFiles(
        Func<IFileNode, bool> predicate)
        => Index.Files.Where(predicate);

    /// <inheritdoc cref="IVirtualFileSystem.FindFiles(Regex)" />
    public IEnumerable<IFileNode> FindFiles(Regex regexPattern)
        => FindFiles(f => f.Path.IsMatch(regexPattern));
}