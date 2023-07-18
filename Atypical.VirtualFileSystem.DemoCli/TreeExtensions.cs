using Atypical.VirtualFileSystem.Core.Contracts;
using Spectre.Console;

namespace Atypical.VirtualFileSystem.DemoCli;

public static class TreeExtensions
{
    /// <summary>
    /// Recursive method to populate tree nodes
    /// </summary>
    /// <param name="treeNode">The tree node to populate</param>
    /// <param name="directoryNode">The directory node to use as the source</param>
    public static void FillTree(this Tree treeNode, IDirectoryNode directoryNode)
    {
        foreach (IDirectoryNode dir in directoryNode.Directories)
        {
            var tree = new Tree(dir.Name);
            treeNode.AddNode(tree);
            FillTree(tree, dir); // Call FillTree recursively for subdirectories
        }

        foreach (IFileNode file in directoryNode.Files)
        {
            var tree = new Tree(file.Name);
            treeNode.AddNode(tree);
        }
    }
}