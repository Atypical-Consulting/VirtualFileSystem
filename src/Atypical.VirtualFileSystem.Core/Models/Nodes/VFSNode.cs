// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents a node in a virtual file system.
///     A node can be a file or a directory.
/// </summary>
public abstract record VFSNode : IVirtualFileSystemNode
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSNode" /> class.
    ///     This constructor is used by derived classes.
    /// </summary>
    /// <param name="path">The path of the node.</param>
    protected VFSNode(VFSPath path)
    {
        ArgumentNullException.ThrowIfNull(path);

        // set timestamps
        var now = DateTime.UtcNow;
        Path = path;
        CreationTime = now;
        LastAccessTime = now;
        LastWriteTime = now;
    }

    /// <inheritdoc cref="IVirtualFileSystemNode.CreationTime" />
    public VFSPath Path { get; init; }

    /// <inheritdoc cref="IVirtualFileSystemNode.CreationTime" />
    public DateTimeOffset CreationTime { get; }

    /// <inheritdoc cref="IVirtualFileSystemNode.LastAccessTime" />
    public DateTimeOffset LastAccessTime { get; }

    /// <inheritdoc cref="IVirtualFileSystemNode.LastWriteTime" />
    public DateTimeOffset LastWriteTime { get; private init; }

    /// <inheritdoc cref="IVirtualFileSystemNode.IsDirectory" />
    public abstract bool IsDirectory { get; }

    /// <inheritdoc cref="IVirtualFileSystemNode.IsFile" />
    public abstract bool IsFile { get; }

    /// <inheritdoc cref="IVirtualFileSystemNode.UpdatePath" />
    public virtual IVirtualFileSystemNode UpdatePath(VFSPath path)
    {
        ArgumentNullException.ThrowIfNull(path);
        return this with {
            Path = path,
            LastWriteTime = DateTime.UtcNow
        };
    }
}