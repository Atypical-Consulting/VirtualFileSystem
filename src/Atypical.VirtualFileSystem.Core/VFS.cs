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
public partial record VFS
    : IVirtualFileSystem
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

    /// <inheritdoc cref="IVirtualFileSystem.Index" />
    public VFSIndex Index { get; }

    /// <summary>
    ///     Returns the index as an ASCII tree.
    /// </summary>
    /// <returns>
    ///     The index as an ASCII tree.
    ///     <para />
    ///     The root directory is always the first line.
    /// </returns>
    public override string ToString()
    {
        var files = Index.Values.Count(x => x.IsFile);
        var directories = Index.Values.Count(x => x.IsDirectory);

        return new StringBuilder()
            .Append("VFS:")
            .Append($" {files} files")
            .Append(',')
            .Append($" {directories} directories")
            .ToString();
    }
    
    internal void AddToIndex(IVirtualFileSystemNode node)
    {
        var added = Index.TryAdd(node.Path.Value, node);

        if (!added)
            ThrowVirtualNodeAlreadyExists(node);

        if (node.Path.Parent is not null 
            && !Index.ContainsKey(node.Path.Parent.Value)
            && node.Path.Parent != Root.Path)
            CreateDirectory(node.Path.Parent);
    }

    [DoesNotReturn]
    private static void ThrowVirtualNodeAlreadyExists(IVirtualFileSystemNode node)
    {
        var message = $"The node '{node.Path}' already exists in the index.";
        throw new VFSException(message);
    }
}
