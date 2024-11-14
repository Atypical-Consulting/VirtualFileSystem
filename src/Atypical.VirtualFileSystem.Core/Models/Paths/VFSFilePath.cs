// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents a file system entry in the virtual file system.
///     A file is a first-class citizen in the virtual file system.
/// </summary>
public record VFSFilePath : VFSPath
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSFilePath" /> class.
    ///     The file path is relative to the root of the virtual file system.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    public VFSFilePath(string path)
        : base(path)
    {
    }

    /// <summary>
    ///     Returns a string that represents the current object.
    ///     The file path is relative to the root of the virtual file system.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
        => Value;

    /// <summary>
    ///     Implicit conversion to string
    ///     This allows you to use a <see cref="VFSFilePath" /> as a string.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>The string representation of the path.</returns>
    public static implicit operator string(VFSFilePath path)
        => path.Value;
}