// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents a file in a virtual file system.
///     This is the base interface for all file types.
/// </summary>
public interface IFileNode : IVirtualFileSystemNode
{
    /// <summary>
    ///     Gets the content of the file as a string.
    ///     The encoding is in UTF-8.
    /// </summary>
    public string Content { get; set; }
}