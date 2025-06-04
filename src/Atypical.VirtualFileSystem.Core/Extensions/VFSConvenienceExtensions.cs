// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides convenience extension methods for IVirtualFileSystem to simplify common operations.
/// These methods accept string paths directly and handle common use cases with less boilerplate.
/// </summary>
public static class VFSConvenienceExtensions
{
    /// <summary>
    /// Creates a file with the specified path and content using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The file content. Defaults to empty string if null.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateFile(this IVirtualFileSystem vfs, string filePath, string? content = null)
        => vfs.CreateFile(new VFSFilePath(filePath), content);

    /// <summary>
    /// Creates a directory with the specified path using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateDirectory(this IVirtualFileSystem vfs, string directoryPath)
        => vfs.CreateDirectory(new VFSDirectoryPath(directoryPath));

    /// <summary>
    /// Deletes a file with the specified path using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem DeleteFile(this IVirtualFileSystem vfs, string filePath)
        => vfs.DeleteFile(new VFSFilePath(filePath));

    /// <summary>
    /// Deletes a directory with the specified path using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem DeleteDirectory(this IVirtualFileSystem vfs, string directoryPath)
        => vfs.DeleteDirectory(new VFSDirectoryPath(directoryPath));

    /// <summary>
    /// Moves a file from source to destination using string paths.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceFilePath">The source file path as a string.</param>
    /// <param name="destinationFilePath">The destination file path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem MoveFile(this IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath)
        => vfs.MoveFile(new VFSFilePath(sourceFilePath), new VFSFilePath(destinationFilePath));

    /// <summary>
    /// Moves a directory from source to destination using string paths.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceDirectoryPath">The source directory path as a string.</param>
    /// <param name="destinationDirectoryPath">The destination directory path as a string.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem MoveDirectory(this IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath)
        => vfs.MoveDirectory(new VFSDirectoryPath(sourceDirectoryPath), new VFSDirectoryPath(destinationDirectoryPath));

    /// <summary>
    /// Renames a file using string paths.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="newName">The new file name.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem RenameFile(this IVirtualFileSystem vfs, string filePath, string newName)
        => vfs.RenameFile(new VFSFilePath(filePath), newName);

    /// <summary>
    /// Renames a directory using string paths.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <param name="newName">The new directory name.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem RenameDirectory(this IVirtualFileSystem vfs, string directoryPath, string newName)
        => vfs.RenameDirectory(new VFSDirectoryPath(directoryPath), newName);

    /// <summary>
    /// Gets a file by its path using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>The file node.</returns>
    public static IFileNode GetFile(this IVirtualFileSystem vfs, string filePath)
        => vfs.GetFile(new VFSFilePath(filePath));

    /// <summary>
    /// Gets a directory by its path using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>The directory node.</returns>
    public static IDirectoryNode GetDirectory(this IVirtualFileSystem vfs, string directoryPath)
        => vfs.GetDirectory(new VFSDirectoryPath(directoryPath));

    /// <summary>
    /// Tries to get a file by its path using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="file">The file node if found.</param>
    /// <returns>True if the file exists, false otherwise.</returns>
    public static bool TryGetFile(this IVirtualFileSystem vfs, string filePath, out IFileNode? file)
        => vfs.TryGetFile(new VFSFilePath(filePath), out file);

    /// <summary>
    /// Tries to get a directory by its path using a string path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <param name="directory">The directory node if found.</param>
    /// <returns>True if the directory exists, false otherwise.</returns>
    public static bool TryGetDirectory(this IVirtualFileSystem vfs, string directoryPath, out IDirectoryNode? directory)
        => vfs.TryGetDirectory(new VFSDirectoryPath(directoryPath), out directory);

    /// <summary>
    /// Checks if a file or directory exists at the specified path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="path">The path to check as a string.</param>
    /// <returns>True if the path exists, false otherwise.</returns>
    public static bool Exists(this IVirtualFileSystem vfs, string path)
    {
        // Try as directory first for paths ending with slash
        if (path.EndsWith("/"))
        {
            try
            {
                if (vfs.TryGetDirectory(path, out _))
                    return true;
            }
            catch
            {
                // Continue to check as file
            }
        }
        
        try
        {
            // Try as file
            if (vfs.TryGetFile(path, out _))
                return true;
            
            // Try as directory (if not already tried)
            if (!path.EndsWith("/") && vfs.TryGetDirectory(path, out _))
                return true;
            
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if a file exists at the specified path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>True if the file exists, false otherwise.</returns>
    public static bool FileExists(this IVirtualFileSystem vfs, string filePath)
    {
        try
        {
            return vfs.TryGetFile(filePath, out _);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if a directory exists at the specified path.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>True if the directory exists, false otherwise.</returns>
    public static bool DirectoryExists(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            return vfs.TryGetDirectory(directoryPath, out _);
        }
        catch
        {
            return false;
        }
    }
}