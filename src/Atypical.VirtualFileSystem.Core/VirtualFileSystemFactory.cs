// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents a factory for creating <see cref="IVirtualFileSystem" /> instances.
/// </summary>
public class VirtualFileSystemFactory : IVirtualFileSystemFactory
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VirtualFileSystemFactory" /> class.
    /// </summary>
    public VirtualFileSystemFactory()
    {
    }

    /// <inheritdoc />
    public IVirtualFileSystem CreateFileSystem()
    {
        return new VFS();
    }
}