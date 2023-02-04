// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents the index of the virtual file system.
///     - a vfs index is a dictionary of vfs paths and vfs nodes
///     - the vfs index is used to store the nodes of the virtual file system
///     This class cannot be inherited.
/// </summary>
public sealed class VFSIndex
    : SortedDictionary<string, IVirtualFileSystemNode>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSIndex" /> class.
    ///     - the vfs index is a dictionary of vfs paths and vfs nodes
    ///     - the vfs index is used to store the nodes of the virtual file system
    ///     - the vfs index is sorted by the vfs paths
    ///     - the vfs index is case insensitive
    /// </summary>
    public VFSIndex()
    {
    }
}