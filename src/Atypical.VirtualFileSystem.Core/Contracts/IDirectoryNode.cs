// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents a directory in a virtual file system.
///     This is an in-memory representation of a directory.
///     It is not a representation of a directory on a physical file system.
/// </summary>
public interface IDirectoryNode : IVirtualFileSystemNode
{
    /// <summary>
    ///     Gets the child directories of the node.
    /// </summary>
    IEnumerable<IDirectoryNode> Directories { get; }

    /// <summary>
    ///     Gets the child files of the node.
    /// </summary>
    IEnumerable<IFileNode> Files { get; }
    
    /// <summary>x
    ///     Adds a child node to the current directory.
    /// </summary>
    /// <param name="node">The child node to add.</param>
    void AddChild(IVirtualFileSystemNode node);
    
    /// <summary>
    ///     Removes a child node from the current directory.
    /// </summary>
    /// <param name="node">The child node to remove.</param>
    void RemoveChild(IVirtualFileSystemNode node);
}
