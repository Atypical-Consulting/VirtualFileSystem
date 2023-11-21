// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides data for the DirectoryMoved event.
/// </summary>
public sealed class VFSDirectoryMovedArgs : VFSEventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VFSDirectoryMovedArgs"/> class.
    /// </summary>
    /// <param name="sourcePath">The source path of the moved directory.</param>
    /// <param name="destinationPath">The destination path of the moved directory.</param>
    public VFSDirectoryMovedArgs(VFSDirectoryPath sourcePath, VFSDirectoryPath destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the source path of the moved directory.
    /// </summary>
    public VFSDirectoryPath SourcePath { get; }

    /// <summary>
    /// Gets the destination path of the moved directory.
    /// </summary>
    public VFSDirectoryPath DestinationPath { get; }

    /// <summary>
    /// Gets the timestamp when the directory was moved.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "Directory was moved from path '{0}' to path '{1}' at '{2}'.";

    /// <inheritdoc />
    public override string Message
        => string.Format(MessageTemplate, SourcePath, DestinationPath, Timestamp);

    /// <inheritdoc />
    public override string MessageWithMarkup
        => ToMarkup("yellow", SourcePath, DestinationPath, Timestamp);

    /// <inheritdoc />
    public override string ToString()
        => Message;
}