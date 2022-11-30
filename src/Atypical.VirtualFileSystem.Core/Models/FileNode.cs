// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Models;

/// <summary>
///     Represents a file in the virtual file system.
/// </summary>
public record FileNode
    : VFSNode, IFileNode
{
    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameterInConstructor")]
    public FileNode(VFSFilePath path, string? content = null)
        : base(path)
    {
        Path = path;
        Content = content ?? string.Empty;
    }
    

    public string Name
        => Path.Name;
    
    public string Content { get; set; }

    public override VFSFilePath Path { get; }

    public override bool IsDirectory
        => false;

    public override bool IsFile
        => true;

    public override string ToString()
    {
        return Path.ToString();
    }
}