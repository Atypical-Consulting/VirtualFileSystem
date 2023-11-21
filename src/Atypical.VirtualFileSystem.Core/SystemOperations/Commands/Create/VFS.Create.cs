// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVFSCreate.DirectoryCreated" />
    public event Action<VFSDirectoryCreatedArgs>? DirectoryCreated;
    
    /// <inheritdoc cref="IVFSCreate.FileCreated" />
    public event Action<VFSFileCreatedArgs>? FileCreated;
    
    /// <inheritdoc cref="IVirtualFileSystem.CreateDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem CreateDirectory(VFSDirectoryPath directoryPath)
    {
        if (directoryPath.IsRoot)
            ThrowCannotCreateRootDirectory();

        if (directoryPath.Parent is null)
            ThrowCannotCreateDirectoryWithoutParent();

        var directory = new DirectoryNode(directoryPath);
        AddToIndex(directory);

        TryGetDirectory(directoryPath.Parent, out var parent);
        parent?.AddChild(directory);
        
        DirectoryCreated?.Invoke(new VFSDirectoryCreatedArgs(directoryPath));
        return this;
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(VFSFilePath,string?)" />
    public IVirtualFileSystem CreateFile(VFSFilePath filePath, string? content = null)
    {
        if (filePath.Parent is null)
            ThrowCannotCreateDirectoryWithoutParent();

        var file = new FileNode(filePath, content);
        AddToIndex(file);

        TryGetDirectory(filePath.Parent, out var parent);
        parent?.AddChild(file);
        
        FileCreated?.Invoke(new VFSFileCreatedArgs(filePath));
        return this;
    }
}