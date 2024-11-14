// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Provides data for the FileCreated event.
/// </summary>
public sealed class VFSFileCreatedArgs : VFSEventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VFSFileCreatedArgs"/> class.
    /// </summary>
    /// <param name="path">The path of the created file.</param>
    /// <param name="content">The content of the created file.</param>
    public VFSFileCreatedArgs(VFSFilePath path, string content)
    {
        Path = path;
        Content = content;
        Timestamp = DateTimeOffset.Now;
    }
    
    /// <summary>
    /// Gets the path of the created file.
    /// </summary>
    public VFSFilePath Path { get; }
    
    /// <summary>
    /// Gets the content of the created file.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Gets the timestamp when the file was created.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string MessageTemplate
        => "File with path '{0}' was created at '{1}'.";

    /// <inheritdoc />
    public override string Message
        => string.Format(MessageTemplate, Path, Timestamp);

    /// <inheritdoc />
    public override string MessageWithMarkup
        => ToMarkup("green", Path, Timestamp);

    /// <inheritdoc />
    public override string ToString()
        => Message;
}