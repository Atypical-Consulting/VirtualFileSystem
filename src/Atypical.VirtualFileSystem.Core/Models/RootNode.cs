// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Models;

/// <summary>
///     Represents the root directory of the virtual file system.
/// </summary>
public record RootNode
    : DirectoryNode, IRootNode
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RootNode" /> class.
    /// </summary>
    public RootNode()
        : base(new VFSRootPath())
    {
    }

    public override string ToString()
    {
        return Path.ToString();
    }
}