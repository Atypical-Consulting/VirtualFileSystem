// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents a virtual file system.
///     This class cannot be inherited.
/// </summary>
public partial record VFS : IVirtualFileSystem
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFS" /> class.
    /// </summary>
    public VFS()
    {
        Root = new RootNode();
        Index = new VFSIndex();
    }

    /// <inheritdoc cref="IVirtualFileSystem.Root" />
    public IRootNode Root { get; }
    
    /// <inheritdoc cref="IVirtualFileSystem.RootPath" />
    public VFSPath RootPath
        => Root.Path;

    /// <inheritdoc cref="IVirtualFileSystem.Index" />
    public VFSIndex Index { get; }
    
    /// <inheritdoc cref="IVirtualFileSystem.Directories" />
    public IEnumerable<IDirectoryNode> Directories
        => Index.Directories;
    
    /// <inheritdoc cref="IVirtualFileSystem.Files" />
    public IEnumerable<IFileNode> Files
        => Index.Files;
    
    /// <inheritdoc cref="IVirtualFileSystem.IsEmpty" />
    public bool IsEmpty
        => Index.IsEmpty;

    private void AddToIndex(IVirtualFileSystemNode node)
    {
        var added = Index.TryAdd(node.Path, node);

        if (!added)
            ThrowVirtualNodeAlreadyExists(node);

        if (node.Path.Parent is not null 
            && !Index.ContainsKey(node.Path.Parent)
            && node.Path.Parent != Root.Path)
            CreateDirectory(node.Path.Parent);
    }

    /// <summary>
    ///     Returns a string that represents the current object.
    /// </summary> 
    public override string ToString()
        => Index.ToString();
}
