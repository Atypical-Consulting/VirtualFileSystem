// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents a node in a virtual file system.
///     A node can be a file or a directory.
/// </summary>
public interface IVirtualFileSystemNode
{
    /// <summary>
    ///     Gets the full path of the node.
    ///     The path is the path from the root of the file system to the node.
    ///     For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".
    ///     The path of the node with the path "./temp/" is "./temp/".
    /// </summary>
    /// <value>
    ///     The full path of the node.
    /// </value>
    VFSPath Path { get; }

    /// <summary>
    ///     Gets the name of the virtual file system node.
    ///     The name is the last part of the path.
    ///     For example, the name of the file "vfs://temp/file.txt" is "file.txt".
    ///     The name of the directory "vfs://temp" is "temp".
    /// </summary>
    public string Name
        => Path.Name;

    /// <summary>
    ///     Gets the creation time of the node.
    /// </summary>
    DateTimeOffset CreationTime { get; }

    /// <summary>
    ///     Gets the last access time of the node.
    /// </summary>
    DateTimeOffset LastAccessTime { get; }

    /// <summary>
    ///     Gets the last write time of the node.
    /// </summary>
    DateTimeOffset LastWriteTime { get; }

    /// <summary>
    ///     Indicates whether the node is a directory.
    /// </summary>
    bool IsDirectory { get; }

    /// <summary>
    ///     Indicates whether the node is a file.
    /// </summary>
    bool IsFile { get; }

    /// <summary>
    ///     Updates the path of the node.
    /// </summary>
    /// <param name="path">The new path of the node.</param>
    internal IVirtualFileSystemNode UpdatePath(VFSPath path);
}