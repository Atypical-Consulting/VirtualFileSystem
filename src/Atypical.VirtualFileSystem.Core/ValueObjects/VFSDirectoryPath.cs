// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.ValueObjects;

/// <summary>
///     Represents a directory in the virtual file system.
///     A directory is a first-class citizen in the virtual file system.
///     It can contain files and other directories.
/// </summary>
public record VFSDirectoryPath : VFSPath
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSDirectoryPath" /> class.
    ///     The file path is relative to the root of the virtual file system.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    public VFSDirectoryPath(string path)
        : base(path)
    {
        // cannot ends with a file extension
        var lastSegment = Value.Split('/').Last();
        if (lastSegment.Contains('.'))
            throw new ArgumentException("The path must not contain a file extension.", nameof(path));
    }

    /// <summary>
    ///     Returns a string that represents the current object.
    ///     The string representation of the directory path is the path itself.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => Value;

    /// <summary>
    ///     Implicit conversion to string
    ///     This allows you to use a <see cref="VFSDirectoryPath" /> as a string.
    /// </summary>
    /// <param name="path">The path to convert.</param>
    /// <returns>The string representation of the path.</returns>
    public static implicit operator string(VFSDirectoryPath path) => path.Value;
}