// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Models;

/// <summary>
///     Represents a directory in the virtual file system.
/// </summary>
public record DirectoryNode
    : VFSNode, IDirectoryNode
{
    private readonly List<IDirectoryNode> _directories = new();
    private readonly List<IFileNode> _files = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="DirectoryNode" /> class.
    ///     Creates a new directory node.
    ///     The directory is created with the current date and time as creation and last modification date.
    /// </summary>
    /// <param name="directoryPath">The path of the directory.</param>
    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor")]
    public DirectoryNode(VFSDirectoryPath directoryPath)
        : base(directoryPath)
    {
        Path = directoryPath;
    }

    /// <inheritdoc cref="IVirtualFileSystemNode.Path" />
    public override VFSDirectoryPath Path { get; }

    /// <inheritdoc cref="IVirtualFileSystemNode.Directories" />
    public ReadOnlyCollection<IDirectoryNode> Directories
        => _directories.AsReadOnly();

    /// <inheritdoc cref="IVirtualFileSystemNode.Files" />
    public ReadOnlyCollection<IFileNode> Files
        => _files.AsReadOnly();

    /// <inheritdoc cref="IVirtualFileSystemNode.IsDirectory" />
    public override bool IsDirectory
        => true;

    /// <inheritdoc cref="IVirtualFileSystemNode.IsFile" />
    public override bool IsFile
        => false;

    /// <summary>
    ///     Returns a string that represents the path of the directory.
    /// </summary>
    /// <returns>A string that represents the path of the directory.</returns>
    public override string ToString() => Path.ToString();
}