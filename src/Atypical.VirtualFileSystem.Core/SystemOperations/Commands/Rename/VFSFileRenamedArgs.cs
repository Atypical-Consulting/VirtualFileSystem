// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides data for the FileRenamed event.
/// </summary>
public sealed class VFSFileRenamedArgs : VFSEventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VFSFileRenamedArgs"/> class.
    /// </summary>
    /// <param name="path">The path of the renamed file.</param>
    /// <param name="oldName">The old name of the renamed file.</param>
    /// <param name="newName">The new name of the renamed file.</param>
    public VFSFileRenamedArgs(VFSFilePath path, string oldName, string newName)
    {
        Path = path;
        OldName = oldName;
        NewName = newName;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the source path of the renamed file.
    /// </summary>
    public VFSFilePath Path { get; }
    
    /// <summary>
    /// Gets the old name of the renamed file.
    /// </summary>
    public string OldName { get; }

    /// <summary>
    /// Gets the new name of the renamed file.
    /// </summary>
    public string NewName { get; }

    /// <summary>
    /// Gets the timestamp when the file was renamed.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "File was renamed from path '{0}' to path '{1}' at '{2}'.";

    /// <inheritdoc />
    public override string Message
        => string.Format(MessageTemplate, Path, NewName, Timestamp);

    /// <inheritdoc />
    public override string MessageWithMarkup
        => ToMarkup("blue", Path, NewName, Timestamp);

    /// <inheritdoc />
    public override string ToString()
        => Message;
}