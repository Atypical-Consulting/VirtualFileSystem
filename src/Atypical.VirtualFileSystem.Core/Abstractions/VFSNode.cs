// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Abstractions;

/// <summary>
///     Represents a node in a virtual file system.
///     A node can be a file or a directory.
/// </summary>
public abstract record VFSNode
    : IVirtualFileSystemNode
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSNode"/> class.
    ///     This constructor is used by derived classes.
    /// </summary>
    /// <param name="path">The path of the node.</param>
    protected VFSNode(VFSPath path)
    {
        ArgumentNullException.ThrowIfNull(path);

        // set timestamps
        var now = DateTime.UtcNow;
        CreationTime = now;
        LastAccessTime = now;
        LastWriteTime = now;
    }

    /// <inheritdoc cref="IVirtualFileSystemNode.CreationTime"/>
    public abstract VFSPath Path { get; }
    
    /// <inheritdoc cref="IVirtualFileSystemNode.CreationTime"/>
    public DateTimeOffset CreationTime { get; }
    
    /// <inheritdoc cref="IVirtualFileSystemNode.LastAccessTime"/>
    public DateTimeOffset LastAccessTime { get; }

    /// <inheritdoc cref="IVirtualFileSystemNode.LastWriteTime"/>
    public DateTimeOffset LastWriteTime { get; }
    
    /// <inheritdoc cref="IVirtualFileSystemNode.IsDirectory"/>
    public abstract bool IsDirectory { get; }
    
    /// <inheritdoc cref="IVirtualFileSystemNode.IsFile"/>
    public abstract bool IsFile { get; }
}