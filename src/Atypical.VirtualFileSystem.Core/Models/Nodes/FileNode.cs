// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents a file in the virtual file system.
/// </summary>
public record FileNode
    : VFSNode, IFileNode
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FileNode" /> class.
    ///     Creates a new file node.
    ///     The file is created with the current date and time as creation and last modification date.
    /// </summary>
    /// <param name="filePath">The path of the file.</param>
    /// <param name="content">The content of the file.</param>
    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor")]
    public FileNode(VFSFilePath filePath, string? content = null)
        : base(filePath)
    {
        Path = filePath;
        Content = content ?? string.Empty;
    }

    /// <inheritdoc cref="IFileNode.Content" />
    public string Content { get; set; }

    /// <inheritdoc cref="IVirtualFileSystemNode.IsDirectory" />
    public override bool IsDirectory
        => false;

    /// <inheritdoc cref="IVirtualFileSystemNode.IsFile" />
    public override bool IsFile
        => true;

    /// <summary>
    ///     Returns a string that represents the path of the file.
    /// </summary>
    /// <returns>A string that represents the path of the file.</returns>
    public override string ToString()
        => Path.ToString();
}