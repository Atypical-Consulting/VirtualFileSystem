// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides safe extension methods for IVirtualFileSystem that don't throw exceptions.
/// These methods return boolean success indicators instead of throwing exceptions.
/// </summary>
public static class VFSSafeExtensions
{
    /// <summary>
    /// Safely creates a file without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The file content.</param>
    /// <returns>True if the file was created successfully, false otherwise.</returns>
    public static bool TryCreateFile(this IVirtualFileSystem vfs, string filePath, string? content = null)
    {
        try
        {
            vfs.CreateFile(filePath, content);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely creates a directory without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>True if the directory was created successfully, false otherwise.</returns>
    public static bool TryCreateDirectory(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            vfs.CreateDirectory(directoryPath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely deletes a file without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>True if the file was deleted successfully, false otherwise.</returns>
    public static bool TryDeleteFile(this IVirtualFileSystem vfs, string filePath)
    {
        try
        {
            if (vfs.FileExists(filePath))
            {
                vfs.DeleteFile(filePath);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely deletes a directory without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>True if the directory was deleted successfully, false otherwise.</returns>
    public static bool TryDeleteDirectory(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            if (vfs.DirectoryExists(directoryPath))
            {
                vfs.DeleteDirectory(directoryPath);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely moves a file without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceFilePath">The source file path as a string.</param>
    /// <param name="destinationFilePath">The destination file path as a string.</param>
    /// <returns>True if the file was moved successfully, false otherwise.</returns>
    public static bool TryMoveFile(this IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath)
    {
        try
        {
            if (vfs.FileExists(sourceFilePath))
            {
                vfs.MoveFile(sourceFilePath, destinationFilePath);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely moves a directory without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceDirectoryPath">The source directory path as a string.</param>
    /// <param name="destinationDirectoryPath">The destination directory path as a string.</param>
    /// <returns>True if the directory was moved successfully, false otherwise.</returns>
    public static bool TryMoveDirectory(this IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath)
    {
        try
        {
            if (vfs.DirectoryExists(sourceDirectoryPath))
            {
                vfs.MoveDirectory(sourceDirectoryPath, destinationDirectoryPath);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely renames a file without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="newName">The new file name.</param>
    /// <returns>True if the file was renamed successfully, false otherwise.</returns>
    public static bool TryRenameFile(this IVirtualFileSystem vfs, string filePath, string newName)
    {
        try
        {
            if (vfs.FileExists(filePath))
            {
                vfs.RenameFile(filePath, newName);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely renames a directory without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <param name="newName">The new directory name.</param>
    /// <returns>True if the directory was renamed successfully, false otherwise.</returns>
    public static bool TryRenameDirectory(this IVirtualFileSystem vfs, string directoryPath, string newName)
    {
        try
        {
            if (vfs.DirectoryExists(directoryPath))
            {
                vfs.RenameDirectory(directoryPath, newName);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely reads file content without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The file content if successful.</param>
    /// <returns>True if the file content was read successfully, false otherwise.</returns>
    public static bool TryReadFile(this IVirtualFileSystem vfs, string filePath, out string? content)
    {
        content = null;
        try
        {
            if (vfs.TryGetFile(filePath, out var file))
            {
                content = file.Content;
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Safely writes file content without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The content to write.</param>
    /// <returns>True if the file content was written successfully, false otherwise.</returns>
    public static bool TryWriteFile(this IVirtualFileSystem vfs, string filePath, string content)
    {
        try
        {
            if (vfs.TryGetFile(filePath, out var file))
            {
                file.Content = content;
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
}