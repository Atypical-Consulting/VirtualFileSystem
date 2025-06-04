// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides advanced extension methods for IVirtualFileSystem with smart behavior like auto-creating parent directories.
/// </summary>
public static class VFSAdvancedExtensions
{
    /// <summary>
    /// Creates a file and automatically creates any missing parent directories.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The file content.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateFileWithDirectories(this IVirtualFileSystem vfs, string filePath, string? content = null)
    {
        var path = new VFSFilePath(filePath);
        
        // Create parent directories if they don't exist
        EnsureParentDirectoriesExist(vfs, path.Parent);
        
        return vfs.CreateFile(filePath, content);
    }

    /// <summary>
    /// Safely creates a file and automatically creates any missing parent directories.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The file content.</param>
    /// <returns>True if the file and directories were created successfully, false otherwise.</returns>
    public static bool TryCreateFileWithDirectories(this IVirtualFileSystem vfs, string filePath, string? content = null)
    {
        try
        {
            vfs.CreateFileWithDirectories(filePath, content);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Creates a directory and automatically creates any missing parent directories.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateDirectoryRecursively(this IVirtualFileSystem vfs, string directoryPath)
    {
        var path = new VFSDirectoryPath(directoryPath);
        
        // Create parent directories if they don't exist
        EnsureParentDirectoriesExist(vfs, path.Parent);
        
        // Create the target directory if it doesn't exist
        if (!vfs.DirectoryExists(directoryPath))
        {
            vfs.CreateDirectory(directoryPath);
        }
        
        return vfs;
    }

    /// <summary>
    /// Safely creates a directory and automatically creates any missing parent directories.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>True if the directories were created successfully, false otherwise.</returns>
    public static bool TryCreateDirectoryRecursively(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            vfs.CreateDirectoryRecursively(directoryPath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Copies a file from source to destination, creating parent directories if needed.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceFilePath">The source file path as a string.</param>
    /// <param name="destinationFilePath">The destination file path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CopyFile(this IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath)
    {
        if (!vfs.FileExists(sourceFilePath))
            throw new FileNotFoundException($"Source file '{sourceFilePath}' not found.");

        var sourceFile = vfs.GetFile(sourceFilePath);
        return vfs.CreateFileWithDirectories(destinationFilePath, sourceFile.Content);
    }

    /// <summary>
    /// Safely copies a file from source to destination, creating parent directories if needed.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceFilePath">The source file path as a string.</param>
    /// <param name="destinationFilePath">The destination file path as a string.</param>
    /// <returns>True if the file was copied successfully, false otherwise.</returns>
    public static bool TryCopyFile(this IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath)
    {
        try
        {
            vfs.CopyFile(sourceFilePath, destinationFilePath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Copies a directory and all its contents recursively.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceDirectoryPath">The source directory path as a string.</param>
    /// <param name="destinationDirectoryPath">The destination directory path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CopyDirectory(this IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath)
    {
        if (!vfs.DirectoryExists(sourceDirectoryPath))
            throw new DirectoryNotFoundException($"Source directory '{sourceDirectoryPath}' not found.");

        var sourceDir = vfs.GetDirectory(sourceDirectoryPath);
        
        // Create destination directory
        vfs.CreateDirectoryRecursively(destinationDirectoryPath);
        
        // Copy all files
        foreach (var file in sourceDir.Files)
        {
            var relativePath = file.Path.Value.Substring(sourceDirectoryPath.Length).TrimStart('/');
            var destinationFilePath = $"{destinationDirectoryPath.TrimEnd('/')}/{relativePath}";
            vfs.CopyFile(file.Path.Value, destinationFilePath);
        }
        
        // Copy all subdirectories recursively
        foreach (var subDir in sourceDir.Directories)
        {
            var relativePath = subDir.Path.Value.Substring(sourceDirectoryPath.Length).TrimStart('/');
            var destinationSubDirPath = $"{destinationDirectoryPath.TrimEnd('/')}/{relativePath}";
            vfs.CopyDirectory(subDir.Path.Value, destinationSubDirPath);
        }
        
        return vfs;
    }

    /// <summary>
    /// Safely copies a directory and all its contents recursively.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceDirectoryPath">The source directory path as a string.</param>
    /// <param name="destinationDirectoryPath">The destination directory path as a string.</param>
    /// <returns>True if the directory was copied successfully, false otherwise.</returns>
    public static bool TryCopyDirectory(this IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath)
    {
        try
        {
            vfs.CopyDirectory(sourceDirectoryPath, destinationDirectoryPath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Gets all files in the file system recursively.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <returns>All files in the file system.</returns>
    public static IEnumerable<IFileNode> GetAllFilesRecursive(this IVirtualFileSystem vfs)
        => vfs.Files;

    /// <summary>
    /// Gets all directories in the file system recursively.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <returns>All directories in the file system.</returns>
    public static IEnumerable<IDirectoryNode> GetAllDirectoriesRecursive(this IVirtualFileSystem vfs)
        => vfs.Directories;

    /// <summary>
    /// Gets all files in a specific directory recursively.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>All files in the specified directory and its subdirectories.</returns>
    public static IEnumerable<IFileNode> GetFilesRecursive(this IVirtualFileSystem vfs, string directoryPath)
    {
        if (!vfs.DirectoryExists(directoryPath))
            yield break;

        var directory = vfs.GetDirectory(directoryPath);
        
        // Return files in current directory
        foreach (var file in directory.Files)
            yield return file;
        
        // Recursively get files from subdirectories
        foreach (var subDir in directory.Directories)
        {
            foreach (var file in vfs.GetFilesRecursive(subDir.Path.Value))
                yield return file;
        }
    }

    /// <summary>
    /// Gets all directories in a specific directory recursively.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>All directories in the specified directory and its subdirectories.</returns>
    public static IEnumerable<IDirectoryNode> GetDirectoriesRecursive(this IVirtualFileSystem vfs, string directoryPath)
    {
        if (!vfs.DirectoryExists(directoryPath))
            yield break;

        var directory = vfs.GetDirectory(directoryPath);
        
        // Return subdirectories in current directory
        foreach (var subDir in directory.Directories)
        {
            yield return subDir;
            
            // Recursively get subdirectories
            foreach (var nestedDir in vfs.GetDirectoriesRecursive(subDir.Path.Value))
                yield return nestedDir;
        }
    }

    /// <summary>
    /// Ensures that all parent directories exist for the given path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path to ensure.</param>
    private static void EnsureParentDirectoriesExist(IVirtualFileSystem vfs, VFSDirectoryPath? directoryPath)
    {
        if (directoryPath == null || directoryPath.IsRoot)
            return;

        // Recursively ensure parent directories exist
        EnsureParentDirectoriesExist(vfs, directoryPath.Parent);
        
        // Create this directory if it doesn't exist
        if (!vfs.DirectoryExists(directoryPath.Value))
        {
            vfs.CreateDirectory(directoryPath.Value);
        }
    }
}