// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides data for the DirectoryDeleted event.
/// </summary>
public sealed class VFSDirectoryDeletedArgs : VFSEventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VFSDirectoryDeletedArgs"/> class.
    /// </summary>
    /// <param name="path">The path of the deleted directory.</param>
    public VFSDirectoryDeletedArgs(VFSDirectoryPath path)
    {
        Path = path;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the path of the deleted directory.
    /// </summary>
    public VFSDirectoryPath Path { get; }

    /// <summary>
    /// Gets the timestamp when the directory was deleted.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "Directory with path '{0}' was deleted at '{1}'.";

    /// <inheritdoc />
    public override string Message
        => string.Format(MessageTemplate, Path, Timestamp);

    /// <inheritdoc />
    public override string MessageWithMarkup
        => ToMarkup("red", Path, Timestamp);

    /// <inheritdoc />
    public override string ToString()
        => Message;
}