namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.GetTree()" />
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
    private IEnumerable<IVirtualFileSystemNode> GetBrothers(IVirtualFileSystemNode node)
    {
        var brothers = this.Index.Values
            .Where(n => n.Path.Parent == node.Path.Parent);

        return brothers;
    }
}