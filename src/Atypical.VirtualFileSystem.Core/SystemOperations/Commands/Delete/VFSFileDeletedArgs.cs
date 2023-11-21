// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides data for the FileDeleted event.
/// </summary>
public sealed class VFSFileDeletedArgs : VFSEventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VFSFileDeletedArgs"/> class.
    /// </summary>
    /// <param name="path">The path of the deleted file.</param>
    public VFSFileDeletedArgs(VFSFilePath path)
    {
        Path = path;
        Timestamp = DateTimeOffset.Now;
    }

    /// <summary>
    /// Gets the path of the deleted file.
    /// </summary>
    public VFSFilePath Path { get; }

    /// <summary>
    /// Gets the timestamp when the file was deleted.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "File with path '{0}' was deleted at '{1}'.";

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