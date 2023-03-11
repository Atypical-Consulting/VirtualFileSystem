namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
    : IVirtualFileSystem
{
    public VFSPath GetRootPath()
        => this.Root.Path;
    
    /// <inheritdoc cref="IVirtualFileSystem.IsEmpty()" />
    public bool IsEmpty()
        => this.Index.Count == 0;

    /// <inheritdoc cref="IVirtualFileSystem.GetDirectory(VFSDirectoryPath)" />
    public IDirectoryNode GetDirectory(VFSDirectoryPath directoryPath)
        // if the path is the root path, return the root node
        => directoryPath.IsRoot
            ? this.Root
            : (IDirectoryNode)this.Index[directoryPath.Value];

    /// <inheritdoc cref="IVirtualFileSystem.GetDirectory(string)" />
    public IDirectoryNode GetDirectory(string directoryPath)
        => GetDirectory(new VFSDirectoryPath(directoryPath));

    /// <inheritdoc cref="IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,out IDirectoryNode?)" />
    public bool TryGetDirectory(VFSDirectoryPath directoryPath, out IDirectoryNode? directory)
    {
        try
        {
            directory = GetDirectory(directoryPath);
            return true;
        }
        catch (KeyNotFoundException)
        {
            directory = null;
            return false;
        }
    }

    /// <inheritdoc cref="IVirtualFileSystem.TryGetDirectory(string,out IDirectoryNode?)" />
    public bool TryGetDirectory(string path, out IDirectoryNode? directory)
        => TryGetDirectory(new VFSDirectoryPath(path), out directory);
    
    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories()" />
    public IEnumerable<IDirectoryNode> FindDirectories()
        => this.Index.Values
            .OfType<IDirectoryNode>();

    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories(Regex)" />
    public IEnumerable<IDirectoryNode> FindDirectories(
        Regex regexPattern)
        => FindDirectories()
            .Where(f => regexPattern.IsMatch(f.Path.Value));
    
    public IEnumerable<IDirectoryNode> SelectDirectories(
        Func<IDirectoryNode, bool> predicate)
        => FindDirectories()
            .Where(predicate);

    /// <inheritdoc cref="IVirtualFileSystem.GetFile(VFSFilePath)" />
    public IFileNode GetFile(VFSFilePath filePath)
        => (IFileNode)this.Index[filePath.Value];

    /// <inheritdoc cref="IVirtualFileSystem.GetFile(string)" />
    public IFileNode GetFile(string filePath)
        => GetFile(new VFSFilePath(filePath));

    /// <inheritdoc cref="IVirtualFileSystem.TryGetFile(VFSFilePath,out IFileNode?)" />
    public bool TryGetFile(VFSFilePath filePath, out IFileNode? file)
    {
        try
        {
            file = GetFile(filePath);
            return true;
        }
        catch (KeyNotFoundException)
        {
            file = null;
            return false;
        }
    }

    /// <inheritdoc cref="IVirtualFileSystem.TryGetFile(string,out IFileNode?)" />
    public bool TryGetFile(string filePath, out IFileNode? file)
        => TryGetFile(new VFSFilePath(filePath), out file);

    /// <inheritdoc cref="IVirtualFileSystem.FindFiles()" />
    public IEnumerable<IFileNode> FindFiles()
        => this.Index.Values.OfType<IFileNode>();

    /// <inheritdoc cref="IVirtualFileSystem.FindFiles(Regex)" />
    public IEnumerable<IFileNode> FindFiles(Regex regexPattern)
        => FindFiles().Where(f => regexPattern.IsMatch(f.Path.Value));

    public string GetTree()
    {
        var sb = new StringBuilder();

        sb.AppendLine(this.Root.Name);

        foreach (var node in this.Index.Values)
        {
            var depth = node.Path.Depth;

            // get all brothers of the node
            var brothers = GetBrothers(node);

            // check if the node is the last node on its level
            var isLastNodeOfLevel = brothers.Last() == node;

            while (depth > 1)
            {
                var parent = node.Path.GetAbsoluteParentPath(1).Value;
                var isLastNodeOfLevelParent = GetBrothers(GetDirectory(parent)).Last() == GetDirectory(parent);

                sb.Append(isLastNodeOfLevelParent ? STR_INDENT_CLEAR : STR_INDENT_FILL);
                depth--;
            }

            sb.Append(isLastNodeOfLevel ? STR_INDENT_ENTRY_LAST : STR_INDENT_ENTRY_MIDDLE);
            sb.AppendLine(node.Path.Name);
        }

        return sb.ToString().Trim().ReplaceLineEndings();
    }

    /// <summary>
    ///     Get all brothers of the node
    ///     (all nodes on the same level including the node itself)
    /// </summary>
    /// <param name="node">The node</param>
    /// <returns>All brothers of the node</returns>
    private List<IVirtualFileSystemNode> GetBrothers(IVirtualFileSystemNode node)
    {
        var brothers = this.Index.Values
            .Where(n => n.Path.Parent == node.Path.Parent)
            .ToList();

        return brothers;
    }
}