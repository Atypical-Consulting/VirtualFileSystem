// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

using Atypical.VirtualFileSystem.Core.Contracts;
using Spectre.Console.Rendering;

namespace Atypical.VirtualFileSystem.DemoCli.Extensions;

public static class TreeExtensions
{
    /// <summary>
    /// Populate a tree node with the contents of a virtual file system
    /// </summary>
    /// <param name="treeNode">The tree node to populate</param>
    /// <param name="vfs">The virtual file system to use as the source</param>
    /// <returns>The populated tree node</returns>
    public static IRenderable FillTree(this Tree treeNode, IVirtualFileSystem vfs)
        => FillTree(treeNode, vfs.Root);
    
    /// <summary>
    /// Recursive method to populate tree nodes
    /// </summary>
    /// <param name="treeNode">The tree node to populate</param>
    /// <param name="directoryNode">The directory node to use as the source</param>
    private static Tree FillTree(this Tree treeNode, IDirectoryNode directoryNode)
    {
        foreach (var dir in directoryNode.Directories)
        {
            var tree = new Tree(dir.Name);
            treeNode.AddNode(tree);
            FillTree(tree, dir); // Call FillTree recursively for subdirectories
        }

        foreach (var file in directoryNode.Files)
        {
            var tree = new Tree(file.Name);
            treeNode.AddNode(tree);
        }
        
        return treeNode;
    }
}