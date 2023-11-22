// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVFSDelete.DirectoryDeleted" />
    public event Action<VFSDirectoryDeletedArgs>? DirectoryDeleted;
    
    /// <inheritdoc cref="IVFSDelete.FileDeleted" />
    public event Action<VFSFileDeletedArgs>? FileDeleted;
    
    /// <inheritdoc cref="IVFSDelete.DeleteDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem DeleteDirectory(VFSDirectoryPath directoryPath)
    {
        // cannot delete the root directory
        if (directoryPath.IsRoot)
            ThrowCannotDeleteRootDirectory();

        // try to get the directory
        if (!Index.TryGetDirectory(directoryPath, out var directoryNode))
            ThrowVirtualDirectoryNotFound(directoryPath);

        // Remove the directory from its parent directory
        if (TryGetDirectory(directoryPath.Parent, out var parent))
            parent.RemoveChild(directoryNode);

        // find the path and its children in the index
        var paths = Index.GetPathsStartingWith(directoryPath);

        // remove the paths from the index
        foreach (var p in paths)
            Index.Remove(p);

        DirectoryDeleted?.Invoke(new VFSDirectoryDeletedArgs(directoryPath));
        return this;
    }
    
    /// <inheritdoc cref="IVFSDelete.DeleteFile(VFSFilePath)" />
    public IVirtualFileSystem DeleteFile(VFSFilePath filePath)
    {
        if (!Index.TryGetFile(filePath, out var fileNode))
            ThrowVirtualFileNotFound(filePath);

        // Remove the file from its parent directory
        if (TryGetDirectory(filePath.Parent, out var parent))
            parent.RemoveChild(fileNode);

        // remove the file from the index
        Index.Remove(filePath);

        FileDeleted?.Invoke(new VFSFileDeletedArgs(filePath, fileNode.Content));
        return this;
    }
}