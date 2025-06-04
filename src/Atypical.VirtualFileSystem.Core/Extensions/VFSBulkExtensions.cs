// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides bulk operation extension methods for IVirtualFileSystem for efficient batch processing.
/// </summary>
public static class VFSBulkExtensions
{
    /// <summary>
    /// Creates multiple files efficiently in a single operation.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="files">Collection of file path and content pairs.</param>
    /// <param name="createDirectories">Whether to auto-create parent directories. Default is true.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string path, string content)> files, bool createDirectories = true)
    {
        foreach (var (path, content) in files)
        {
            if (createDirectories)
                vfs.CreateFileWithDirectories(path, content);
            else
                vfs.CreateFile(path, content);
        }
        return vfs;
    }

    /// <summary>
    /// Creates multiple files efficiently in a single operation using a dictionary.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="files">Dictionary with file paths as keys and content as values.</param>
    /// <param name="createDirectories">Whether to auto-create parent directories. Default is true.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateFiles(this IVirtualFileSystem vfs, 
        IDictionary<string, string> files, bool createDirectories = true)
    {
        return vfs.CreateFiles(files.Select(kvp => (kvp.Key, kvp.Value)), createDirectories);
    }

    /// <summary>
    /// Safely creates multiple files without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="files">Collection of file path and content pairs.</param>
    /// <param name="createDirectories">Whether to auto-create parent directories. Default is true.</param>
    /// <returns>Collection of successfully created file paths.</returns>
    public static IEnumerable<string> TryCreateFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string path, string content)> files, bool createDirectories = true)
    {
        var successfulPaths = new List<string>();
        
        foreach (var (path, content) in files)
        {
            bool success = createDirectories 
                ? vfs.TryCreateFileWithDirectories(path, content)
                : vfs.TryCreateFile(path, content);
                
            if (success)
                successfulPaths.Add(path);
        }
        
        return successfulPaths;
    }

    /// <summary>
    /// Creates multiple directories efficiently in a single operation.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPaths">Collection of directory paths to create.</param>
    /// <param name="createRecursively">Whether to auto-create parent directories. Default is true.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateDirectories(this IVirtualFileSystem vfs, 
        IEnumerable<string> directoryPaths, bool createRecursively = true)
    {
        foreach (var path in directoryPaths)
        {
            if (createRecursively)
                vfs.CreateDirectoryRecursively(path);
            else
                vfs.CreateDirectory(path);
        }
        return vfs;
    }

    /// <summary>
    /// Safely creates multiple directories without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPaths">Collection of directory paths to create.</param>
    /// <param name="createRecursively">Whether to auto-create parent directories. Default is true.</param>
    /// <returns>Collection of successfully created directory paths.</returns>
    public static IEnumerable<string> TryCreateDirectories(this IVirtualFileSystem vfs, 
        IEnumerable<string> directoryPaths, bool createRecursively = true)
    {
        var successfulPaths = new List<string>();
        
        foreach (var path in directoryPaths)
        {
            bool success = createRecursively 
                ? vfs.TryCreateDirectoryRecursively(path)
                : vfs.TryCreateDirectory(path);
                
            if (success)
                successfulPaths.Add(path);
        }
        
        return successfulPaths;
    }

    /// <summary>
    /// Deletes multiple files efficiently in a single operation.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePaths">Collection of file paths to delete.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem DeleteFiles(this IVirtualFileSystem vfs, IEnumerable<string> filePaths)
    {
        foreach (var path in filePaths)
        {
            if (vfs.FileExists(path))
                vfs.DeleteFile(path);
        }
        return vfs;
    }

    /// <summary>
    /// Safely deletes multiple files without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePaths">Collection of file paths to delete.</param>
    /// <returns>Collection of successfully deleted file paths.</returns>
    public static IEnumerable<string> TryDeleteFiles(this IVirtualFileSystem vfs, IEnumerable<string> filePaths)
    {
        var successfulPaths = new List<string>();
        
        foreach (var path in filePaths)
        {
            if (vfs.TryDeleteFile(path))
                successfulPaths.Add(path);
        }
        
        return successfulPaths;
    }

    /// <summary>
    /// Deletes multiple directories efficiently in a single operation.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPaths">Collection of directory paths to delete.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem DeleteDirectories(this IVirtualFileSystem vfs, IEnumerable<string> directoryPaths)
    {
        foreach (var path in directoryPaths)
        {
            if (vfs.DirectoryExists(path))
                vfs.DeleteDirectory(path);
        }
        return vfs;
    }

    /// <summary>
    /// Safely deletes multiple directories without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPaths">Collection of directory paths to delete.</param>
    /// <returns>Collection of successfully deleted directory paths.</returns>
    public static IEnumerable<string> TryDeleteDirectories(this IVirtualFileSystem vfs, IEnumerable<string> directoryPaths)
    {
        return directoryPaths
            .Where(vfs.TryDeleteDirectory)
            .ToList();
    }

    /// <summary>
    /// Moves multiple files efficiently in a single operation.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="moves">Collection of source and destination path pairs.</param>
    /// <param name="createDirectories">Whether to auto-create destination directories. Default is true.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem MoveFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string source, string destination)> moves, bool createDirectories = true)
    {
        foreach (var (source, destination) in moves)
        {
            if (!vfs.FileExists(source))
                continue;
                
            if (createDirectories)
            {
                var destPath = new VFSFilePath(destination);
                if (destPath.Parent != null)
                    vfs.CreateDirectoryRecursively(destPath.Parent.Value);
            }
            
            vfs.MoveFile(source, destination);
        }
        return vfs;
    }

    /// <summary>
    /// Safely moves multiple files without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="moves">Collection of source and destination path pairs.</param>
    /// <param name="createDirectories">Whether to auto-create destination directories. Default is true.</param>
    /// <returns>Collection of successfully moved file source paths.</returns>
    public static IEnumerable<string> TryMoveFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string source, string destination)> moves, bool createDirectories = true)
    {
        var successfulPaths = new List<string>();
        
        foreach (var (source, destination) in moves)
        {
            try
            {
                if (!vfs.FileExists(source))
                    continue;
                    
                if (createDirectories)
                {
                    var destPath = new VFSFilePath(destination);
                    if (destPath.Parent != null)
                        vfs.CreateDirectoryRecursively(destPath.Parent.Value);
                }
                
                vfs.MoveFile(source, destination);
                successfulPaths.Add(source);
            }
            catch
            {
                // Continue with next file
            }
        }
        
        return successfulPaths;
    }

    /// <summary>
    /// Copies multiple files efficiently in a single operation.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="copies">Collection of source and destination path pairs.</param>
    /// <param name="createDirectories">Whether to auto-create destination directories. Default is true.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CopyFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string source, string destination)> copies, bool createDirectories = true)
    {
        foreach (var (source, destination) in copies)
        {
            if (createDirectories)
                vfs.CopyFile(source, destination);
            else if (vfs.FileExists(source))
            {
                var sourceFile = vfs.GetFile(source);
                vfs.CreateFile(destination, sourceFile.Content);
            }
        }
        return vfs;
    }

    /// <summary>
    /// Safely copies multiple files without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="copies">Collection of source and destination path pairs.</param>
    /// <param name="createDirectories">Whether to auto-create destination directories. Default is true.</param>
    /// <returns>Collection of successfully copied file source paths.</returns>
    public static IEnumerable<string> TryCopyFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string source, string destination)> copies, bool createDirectories = true)
    {
        var successfulPaths = new List<string>();
        
        foreach (var (source, destination) in copies)
        {
            bool success = createDirectories 
                ? vfs.TryCopyFile(source, destination)
                : vfs.TryCreateFile(destination, vfs.TryReadFile(source, out var content) ? content : null);
                
            if (success)
                successfulPaths.Add(source);
        }
        
        return successfulPaths;
    }

    /// <summary>
    /// Updates content of multiple files efficiently in a single operation.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="updates">Collection of file path and new content pairs.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem UpdateFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string path, string content)> updates)
    {
        foreach (var (path, content) in updates)
        {
            if (vfs.TryGetFile(path, out var file))
                file.Content = content;
        }
        return vfs;
    }

    /// <summary>
    /// Safely updates content of multiple files without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="updates">Collection of file path and new content pairs.</param>
    /// <returns>Collection of successfully updated file paths.</returns>
    public static IEnumerable<string> TryUpdateFiles(this IVirtualFileSystem vfs, 
        IEnumerable<(string path, string content)> updates)
    {
        var successfulPaths = new List<string>();
        
        foreach (var (path, content) in updates)
        {
            if (vfs.TryWriteFile(path, content))
                successfulPaths.Add(path);
        }
        
        return successfulPaths;
    }
}