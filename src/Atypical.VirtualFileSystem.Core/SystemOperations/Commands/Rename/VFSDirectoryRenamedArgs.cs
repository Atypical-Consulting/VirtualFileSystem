// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides data for the DirectoryRenamed event.
/// </summary>
public sealed class VFSDirectoryRenamedArgs : VFSEventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VFSDirectoryRenamedArgs"/> class.
    /// </summary>
    /// <param name="oldPath">The old path of the renamed directory.</param>
    /// <param name="newPath">The new path of the renamed directory.</param>
    public VFSDirectoryRenamedArgs(VFSDirectoryPath oldPath, VFSDirectoryPath newPath)
    {
        OldPath = oldPath;
        NewPath = newPath;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the old path of the renamed directory.
    /// </summary>
    public VFSDirectoryPath OldPath { get; }

    /// <summary>
    /// Gets the new path of the renamed directory.
    /// </summary>
    public VFSDirectoryPath NewPath { get; }

    /// <summary>
    /// Gets the timestamp when the directory was renamed.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "Directory was renamed from path '{0}' to path '{1}' at '{2}'.";

    /// <inheritdoc />
    public override string Message
        => string.Format(MessageTemplate, OldPath, NewPath, Timestamp);

    /// <inheritdoc />
    public override string MessageWithMarkup
        => ToMarkup("blue", OldPath, NewPath, Timestamp);

    /// <inheritdoc />
    public override string ToString()
        => Message;
}