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

        // Remove the directory from its old parent directory
        if (TryGetDirectory(sourceDirectoryPath.Parent, out var oldParent))
            oldParent.RemoveChild(directoryNode);

        var updatedDirectoryNode = directoryNode.UpdatePath(destinationDirectoryPath);

        // Add the directory to its new parent directory
        if (TryGetDirectory(destinationDirectoryPath.Parent, out var newParent))
            newParent.AddChild(updatedDirectoryNode);

        Index.Remove(sourceDirectoryPath);
        Index[destinationDirectoryPath] = updatedDirectoryNode;

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