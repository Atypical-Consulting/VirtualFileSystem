// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides data for the FileMoved event.
/// </summary>
public sealed class VFSFileMovedArgs : VFSEventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VFSFileMovedArgs"/> class.
    /// </summary>
    /// <param name="sourcePath">The source path of the moved file.</param>
    /// <param name="destinationPath">The destination path of the moved file.</param>
    public VFSFileMovedArgs(VFSFilePath sourcePath, VFSFilePath destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the source path of the moved file.
    /// </summary>
    public VFSFilePath SourcePath { get; }

    /// <summary>
    /// Gets the destination path of the moved file.
    /// </summary>
    public VFSFilePath DestinationPath { get; }

    /// <summary>
    /// Gets the timestamp when the file was moved.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "File was moved from path '{0}' to path '{1}' at '{2}'.";

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