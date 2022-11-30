// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents a factory for creating <see cref="IVirtualFileSystem" /> instances.
///     This interface is implemented by the <see cref="VirtualFileSystemFactory" /> class.
/// </summary>
public interface IVirtualFileSystemFactory
{
    /// <summary>
    ///     Creates a new instance of <see cref="IVirtualFileSystem" />.
    /// </summary>
    /// <returns>The new instance of <see cref="IVirtualFileSystem" />.</returns>
    IVirtualFileSystem CreateFileSystem();
}