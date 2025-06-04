// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVFSMove.DirectoryMoved" />
    public event Action<VFSDirectoryMovedArgs>? DirectoryMoved;
    
    /// <inheritdoc cref="IVFSMove.FileMoved" />
    public event Action<VFSFileMovedArgs>? FileMoved;
    
    /// <inheritdoc cref="IVFSMove.MoveDirectory(VFSDirectoryPath, VFSDirectoryPath)" />
    public IVirtualFileSystem MoveDirectory(
        VFSDirectoryPath sourceDirectoryPath,
        VFSDirectoryPath destinationDirectoryPath)
    {
        if (!Index.TryGetDirectory(sourceDirectoryPath, out var directoryNode))
            ThrowVirtualDirectoryNotFound(sourceDirectoryPath);

        // Get all paths that start with the source directory path (files and subdirectories)
        var pathsToMove = Index.GetPathsStartingWith(sourceDirectoryPath).ToList();

        // Remove the directory from its old parent directory
        if (TryGetDirectory(sourceDirectoryPath.Parent, out var oldParent))
            oldParent.RemoveChild(directoryNode);

        var updatedDirectoryNode = directoryNode.UpdatePath(destinationDirectoryPath);

        // Add the directory to its new parent directory
        if (TryGetDirectory(destinationDirectoryPath.Parent, out var newParent))
            newParent.AddChild(updatedDirectoryNode);

        // Update the directory in the index
        Index.Remove(sourceDirectoryPath);
        Index[destinationDirectoryPath] = updatedDirectoryNode;

        // Move all files and subdirectories within the directory
        foreach (var oldPath in pathsToMove)
        {
            // Skip the directory itself as we already handled it
            if (oldPath.Value == sourceDirectoryPath.Value)
                continue;
                
            // Calculate the new path by replacing the source prefix with destination prefix
            var relativePath = oldPath.Value[sourceDirectoryPath.Value.Length..];
            var newPathValue = destinationDirectoryPath.Value + relativePath;
            
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

        DirectoryMoved?.Invoke(new VFSDirectoryMovedArgs(sourceDirectoryPath, destinationDirectoryPath));
        return this;
    }
    
    /// <inheritdoc cref="IVFSMove.MoveFile(VFSFilePath, VFSFilePath)" />
    public IVirtualFileSystem MoveFile(
        VFSFilePath sourceFilePath,
        VFSFilePath destinationFilePath)
    {
        if (!Index.TryGetFile(sourceFilePath, out var fileNode))
            ThrowVirtualFileNotFound(sourceFilePath);

        // Remove the file from its old parent directory
        if (TryGetDirectory(sourceFilePath.Parent, out var oldParent)) 
            oldParent.RemoveChild(fileNode);

        var updatedFileNode = fileNode.UpdatePath(destinationFilePath);

        // Add the file to its new parent directory
        if (TryGetDirectory(destinationFilePath.Parent, out var newParent)) 
            newParent.AddChild(updatedFileNode);

        Index.Remove(sourceFilePath);
        Index[destinationFilePath] = updatedFileNode;

        FileMoved?.Invoke(new VFSFileMovedArgs(sourceFilePath, destinationFilePath));
        return this;
    }
}