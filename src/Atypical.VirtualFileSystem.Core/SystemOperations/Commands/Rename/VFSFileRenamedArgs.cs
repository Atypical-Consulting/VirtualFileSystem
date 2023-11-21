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
    /// <param name="oldPath">The old path of the renamed file.</param>
    /// <param name="newPath">The new path of the renamed file.</param>
    public VFSFileRenamedArgs(VFSFilePath oldPath, VFSFilePath newPath)
    {
        OldPath = oldPath;
        NewPath = newPath;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the old path of the renamed file.
    /// </summary>
    public VFSFilePath OldPath { get; }

    /// <summary>
    /// Gets the new path of the renamed file.
    /// </summary>
    public VFSFilePath NewPath { get; }

    /// <summary>
    /// Gets the timestamp when the file was renamed.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "File was renamed from path '{0}' to path '{1}' at '{2}'.";

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