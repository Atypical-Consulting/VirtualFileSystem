// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.ValueObjects;

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

    public override string ToString()
    {
        return Value;
    }
    
    /// <summary>
    ///     Implicit conversion to string
    ///     This allows you to use a <see cref="VFSFilePath" /> as a string.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>The string representation of the path.</returns>
    public static implicit operator string(VFSFilePath path)
    {
        return path.Value;
    }
}