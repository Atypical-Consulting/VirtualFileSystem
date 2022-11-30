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
    /// <summary>
    ///     Returns a string that represents the current object.
    ///     The string representation of the root directory is the constant <see cref="ROOT_PATH" />.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => Value;

    /// <summary>
    ///     Implicit conversion to string
    ///     This allows you to use a <see cref="VFSRootPath" /> as a string.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>The string representation of the path.</returns>
    public static implicit operator string(VFSRootPath path) => path.Value;
}