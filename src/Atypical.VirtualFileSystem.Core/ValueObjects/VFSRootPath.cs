// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.ValueObjects;

/// <summary>
///     Represents the root directory of the virtual file system.
/// </summary>
public record VFSRootPath()
    : VFSDirectoryPath(ROOT_PATH)
{
    public override string ToString()
    {
        return Value;
    }
    
    /// <summary>
    ///     Implicit conversion to string
    ///     This allows you to use a <see cref="VFSRootPath"/> as a string.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>The string representation of the path.</returns>
    public static implicit operator string(VFSRootPath path)
    {
        return path.Value;
    }
}