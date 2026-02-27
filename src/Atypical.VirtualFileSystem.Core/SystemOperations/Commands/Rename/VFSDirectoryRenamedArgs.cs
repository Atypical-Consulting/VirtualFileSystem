// Copyright (c) 2022-2024, Atypical Consulting SRL
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
    /// <param name="path">The path of the renamed directory.</param>
    /// <param name="oldName">The old name of the renamed directory.</param>
    /// <param name="newName">The new name of the renamed directory.</param>
    /// <param name="newPath">The new path of the renamed directory.</param>
    public VFSDirectoryRenamedArgs(VFSDirectoryPath path, string oldName, string newName, VFSDirectoryPath newPath)
    {
        Path = path;
        OldName = oldName;
        NewName = newName;
        NewPath = newPath;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the old path of the renamed directory.
    /// </summary>
    public VFSDirectoryPath Path { get; }
    
    /// <summary>
    /// Gets the old name of the renamed directory.
    /// </summary>
    public string OldName { get; }

    /// <summary>
    /// Gets the new name of the renamed directory.
    /// </summary>
    public string NewName { get; }

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
        => string.Format(MessageTemplate, Path, NewPath, Timestamp);

    /// <inheritdoc />
    public override string MessageWithMarkup
        => ToMarkup("blue", Path, NewPath, Timestamp);

    /// <inheritdoc />
    public override string ToString()
        => Message;
}