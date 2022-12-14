// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
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
}
