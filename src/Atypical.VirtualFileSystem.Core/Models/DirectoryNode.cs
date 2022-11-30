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

    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor")]
    public DirectoryNode(VFSDirectoryPath directoryPath)
        : base(directoryPath)
    {
        Path = directoryPath;
    }

    public override VFSDirectoryPath Path { get; }

    public override bool IsDirectory
        => true;

    public override bool IsFile
        => false;

    public ReadOnlyCollection<IFileNode> Files
        => _files.AsReadOnly();

    public ReadOnlyCollection<IDirectoryNode> Directories
        => _directories.AsReadOnly();

    public override string ToString()
    {
        return Path.ToString();
    }
}