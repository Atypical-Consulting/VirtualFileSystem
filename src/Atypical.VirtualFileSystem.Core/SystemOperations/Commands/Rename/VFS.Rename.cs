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

        // Get all paths that start with the directory path (files and subdirectories)
        var pathsToRename = Index.GetPathsStartingWith(directoryPath).ToList();

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

        // update the directory in the index
        Index.Remove(directoryPath);
        Index[newPath] = updatedDirectoryNode;

        // Rename all files and subdirectories within the directory
        foreach (var oldPath in pathsToRename)
        {
            // Skip the directory itself as we already handled it
            if (oldPath.Value == directoryPath.Value)
                continue;
                
            // Calculate the new path by replacing the old directory prefix with new directory prefix
            var relativePath = oldPath.Value[directoryPath.Value.Length..];
            var newPathValue = newPath.Value + relativePath;
            
            // Handle files and directories separately due to different indexer types
            if (oldPath is VFSFilePath oldFilePath)
            {
                var node = Index[oldFilePath];
                var newFilePath = new VFSFilePath(newPathValue);
                var updatedFileNode = node.UpdatePath(newFilePath);
                
                // Update parent directory references
                if (TryGetDirectory(oldFilePath.Parent, out var oldFileParent))
                    oldFileParent.RemoveChild(node);
                    
                if (TryGetDirectory(newFilePath.Parent, out var newFileParent))
                    newFileParent.AddChild(updatedFileNode);
                    
                Index.Remove(oldFilePath);
                Index[newFilePath] = updatedFileNode;
            }
            else if (oldPath is VFSDirectoryPath oldDirPath)
            {
                var node = Index[oldDirPath];
                var newDirPath = new VFSDirectoryPath(newPathValue);
                var updatedDirNode = node.UpdatePath(newDirPath);
                
                // Update parent directory references
                if (TryGetDirectory(oldDirPath.Parent, out var oldDirParent))
                    oldDirParent.RemoveChild(node);
                    
                if (TryGetDirectory(newDirPath.Parent, out var newDirParent))
                    newDirParent.AddChild(updatedDirNode);
                    
                Index.Remove(oldDirPath);
                Index[newDirPath] = updatedDirNode;
            }
        }

        DirectoryRenamed?.Invoke(new VFSDirectoryRenamedArgs(directoryPath, oldName, newName, newPath));
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