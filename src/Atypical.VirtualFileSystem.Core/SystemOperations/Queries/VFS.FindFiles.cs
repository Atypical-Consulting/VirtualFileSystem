namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.FindFiles()" />
    public IEnumerable<IFileNode> FindFiles()
        => this.Index.Values.OfType<IFileNode>();

    /// <inheritdoc cref="IVirtualFileSystem.FindFiles(Regex)" />
    public IEnumerable<IFileNode> FindFiles(Regex regexPattern)
        => FindFiles().Where(f => regexPattern.IsMatch(f.Path.Value));
}