// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVFSRename.DirectoryRenamed" />
    public event Action<VFSDirectoryRenamedArgs>? DirectoryRenamed;
    
    /// <inheritdoc cref="IVFSRename.FileRenamed" />
    public event Action<VFSFileRenamedArgs>? FileRenamed;
    
    /// <summary>
    /// Renames a directory.
    /// </summary>
    /// <param name="directoryPath">The directory path.</param>
    /// <param name="newName">The new name.</param>
    /// <returns>The virtual file system.</returns>
    public IVirtualFileSystem RenameDirectory(
        VFSDirectoryPath directoryPath,
        string newName)
    {
        if (!Index.TryGetDirectory(directoryPath, out var directoryNode))
            ThrowVirtualDirectoryNotFound(directoryPath);

        // Remove the directory from its old parent directory
        if (TryGetDirectory(directoryPath.Parent, out var oldParent))
            oldParent.RemoveChild(directoryNode);

        // update the directory node with the new path
        var oldName = directoryNode.Name;
        var newPath = new VFSDirectoryPath($"{directoryPath.Parent}/{newName}");
        var updatedDirectoryNode = directoryNode.UpdatePath(newPath);

        // Add the directory to its old parent directory with the new name
        if (TryGetDirectory(newPath.Parent, out var newParent))
            newParent.AddChild(updatedDirectoryNode);

        // update the index
        Index.Remove(directoryPath);
        Index[newPath] = updatedDirectoryNode;

        DirectoryRenamed?.Invoke(new VFSDirectoryRenamedArgs(directoryPath, oldName, newName));
        return this;
    }
    
    /// <inheritdoc cref="IVFSRename.RenameFile(VFSFilePath, string)" />
    public IVirtualFileSystem RenameFile(
        VFSFilePath filePath,
        string newName)
    {
        if (!Index.TryGetFile(filePath, out var fileNode))
            ThrowVirtualFileNotFound(filePath);

        // Remove the file from its old parent directory
        if (TryGetDirectory(filePath.Parent, out var oldParent))
            oldParent.RemoveChild(fileNode);

        // update the file node with the new path
        var oldName = fileNode.Name;
        var newFilePath = new VFSFilePath($"{filePath.Parent}/{newName}");
        var updatedFileNode = fileNode.UpdatePath(newFilePath);

        // Add the file to its new parent directory
        if (TryGetDirectory(newFilePath.Parent, out var newParent))
            newParent.AddChild(updatedFileNode);

        // update the index
        Index.Remove(filePath);
        Index[newFilePath] = updatedFileNode;

        FileRenamed?.Invoke(new VFSFileRenamedArgs(filePath, oldName, newFilePath));
        return this;
    }
}