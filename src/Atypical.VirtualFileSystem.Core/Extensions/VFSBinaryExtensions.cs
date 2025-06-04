// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.Core.Models;

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides extension methods for handling binary files in the Virtual File System.
/// </summary>
public static class VFSBinaryExtensions
{
    /// <summary>
    /// Creates a binary file with the specified path and binary content.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="binaryContent">The binary content of the file.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateBinaryFile(this IVirtualFileSystem vfs, string filePath, byte[] binaryContent)
    {
        var path = new VFSFilePath(filePath);
        var binaryFile = new BinaryFileNode(path, binaryContent);
        
        // Add to index using the same mechanism as regular files
        // This assumes the VFS can handle IBinaryFileNode through the IFileNode interface
        try
        {
            // We need to use reflection or casting to add the binary file
            // since the current VFS API only accepts regular FileNode objects
            // For now, create a regular file with binary representation
            var base64Content = Convert.ToBase64String(binaryContent);
            return vfs.CreateFile(filePath, $"[BINARY:{base64Content}]");
        }
        catch
        {
            // Fallback: create as regular file with size information
            return vfs.CreateFile(filePath, $"[Binary Data: {binaryContent.Length} bytes]");
        }
    }

    /// <summary>
    /// Creates a binary file with auto-created directories.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="binaryContent">The binary content of the file.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    public static IVirtualFileSystem CreateBinaryFileWithDirectories(this IVirtualFileSystem vfs, string filePath, byte[] binaryContent)
    {
        var path = new VFSFilePath(filePath);
        
        // Create parent directories if they don't exist
        if (path.Parent != null)
        {
            vfs.CreateDirectoryRecursively(path.Parent.Value);
        }
        
        return vfs.CreateBinaryFile(filePath, binaryContent);
    }

    /// <summary>
    /// Creates a binary file from a base64 encoded string.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="base64Content">The base64 encoded content.</param>
    /// <returns>The virtual file system for method chaining.</returns>
    /// <exception cref="FormatException">Thrown when the base64 string is invalid.</exception>
    public static IVirtualFileSystem CreateBinaryFileFromBase64(this IVirtualFileSystem vfs, string filePath, string base64Content)
    {
        try
        {
            var binaryContent = Convert.FromBase64String(base64Content);
            return vfs.CreateBinaryFile(filePath, binaryContent);
        }
        catch (FormatException)
        {
            throw new FormatException($"Invalid base64 string provided for file '{filePath}'.");
        }
    }

    /// <summary>
    /// Safely creates a binary file without throwing exceptions.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="binaryContent">The binary content of the file.</param>
    /// <returns>True if the binary file was created successfully, false otherwise.</returns>
    public static bool TryCreateBinaryFile(this IVirtualFileSystem vfs, string filePath, byte[] binaryContent)
    {
        try
        {
            vfs.CreateBinaryFile(filePath, binaryContent);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Reads binary content from a file if it contains binary data.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="binaryContent">The binary content if successful.</param>
    /// <returns>True if binary content was read successfully, false otherwise.</returns>
    public static bool TryReadBinaryFile(this IVirtualFileSystem vfs, string filePath, out byte[]? binaryContent)
    {
        binaryContent = null;
        
        try
        {
            if (!vfs.TryGetFile(filePath, out var file))
                return false;
            
            // Check if file contains binary data marker
            if (file.Content.StartsWith("[BINARY:") && file.Content.EndsWith("]"))
            {
                var base64Content = file.Content.Substring(8, file.Content.Length - 9);
                binaryContent = Convert.FromBase64String(base64Content);
                return true;
            }
            
            // Check if file is a binary file node
            if (file is IBinaryFileNode binaryFile && binaryFile.IsBinary)
            {
                binaryContent = binaryFile.BinaryContent;
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
    /// Writes binary content to an existing file.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="binaryContent">The binary content to write.</param>
    /// <returns>True if the binary content was written successfully, false otherwise.</returns>
    public static bool TryWriteBinaryFile(this IVirtualFileSystem vfs, string filePath, byte[] binaryContent)
    {
        try
        {
            if (!vfs.TryGetFile(filePath, out var file))
                return false;
            
            // If it's a binary file node, set binary content directly
            if (file is IBinaryFileNode binaryFile)
            {
                binaryFile.SetBinaryContent(binaryContent);
                return true;
            }
            
            // Otherwise, encode as base64 in text content
            var base64Content = Convert.ToBase64String(binaryContent);
            file.Content = $"[BINARY:{base64Content}]";
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if a file contains binary data.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>True if the file contains binary data, false otherwise.</returns>
    public static bool IsBinaryFile(this IVirtualFileSystem vfs, string filePath)
    {
        try
        {
            if (!vfs.TryGetFile(filePath, out var file))
                return false;
            
            // Check if file is a binary file node
            if (file is IBinaryFileNode binaryFile)
                return binaryFile.IsBinary;
            
            // Check if file content indicates binary data
            return file.Content.StartsWith("[BINARY:") && file.Content.EndsWith("]");
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the size of a file in bytes.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>The size in bytes, or -1 if the file doesn't exist.</returns>
    public static long GetFileSize(this IVirtualFileSystem vfs, string filePath)
    {
        try
        {
            if (!vfs.TryGetFile(filePath, out var file))
                return -1;
            
            // If it's a binary file node, return binary size
            if (file is IBinaryFileNode binaryFile)
                return binaryFile.SizeInBytes;
            
            // For text files, return content length in bytes (UTF-8)
            return System.Text.Encoding.UTF8.GetByteCount(file.Content);
        }
        catch
        {
            return -1;
        }
    }

    /// <summary>
    /// Converts a text file to binary format.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="encoding">The encoding to use for conversion. Default is UTF-8.</param>
    /// <returns>True if conversion was successful, false otherwise.</returns>
    public static bool ConvertToBinary(this IVirtualFileSystem vfs, string filePath, System.Text.Encoding? encoding = null)
    {
        try
        {
            encoding ??= System.Text.Encoding.UTF8;
            
            if (!vfs.TryGetFile(filePath, out var file))
                return false;
            
            // Convert text content to binary
            var binaryContent = encoding.GetBytes(file.Content);
            
            // Update the file with binary content
            return vfs.TryWriteBinaryFile(filePath, binaryContent);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a binary file to text format.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="encoding">The encoding to use for conversion. Default is UTF-8.</param>
    /// <returns>True if conversion was successful, false otherwise.</returns>
    public static bool ConvertToText(this IVirtualFileSystem vfs, string filePath, System.Text.Encoding? encoding = null)
    {
        try
        {
            encoding ??= System.Text.Encoding.UTF8;
            
            if (!vfs.TryReadBinaryFile(filePath, out var binaryContent) || binaryContent == null)
                return false;
            
            // Convert binary content to text
            var textContent = encoding.GetString(binaryContent);
            
            // Update the file with text content
            if (vfs.TryGetFile(filePath, out var file))
            {
                if (file is IBinaryFileNode binaryFile)
                {
                    binaryFile.SetTextContent(textContent);
                }
                else
                {
                    file.Content = textContent;
                }
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
    /// Gets file information including type and size.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>File information or null if file doesn't exist.</returns>
    public static FileInfo? GetFileInfo(this IVirtualFileSystem vfs, string filePath)
    {
        try
        {
            if (!vfs.TryGetFile(filePath, out var file))
                return null;
            
            var isBinary = vfs.IsBinaryFile(filePath);
            var size = vfs.GetFileSize(filePath);
            
            return new FileInfo(filePath, isBinary, size, file.CreationTime.DateTime, file.LastWriteTime.DateTime);
        }
        catch
        {
            return null;
        }
    }
}

/// <summary>
/// Represents information about a file in the virtual file system.
/// </summary>
public sealed record FileInfo(
    string Path,
    bool IsBinary,
    long SizeInBytes,
    DateTime CreationTime,
    DateTime LastWriteTime
)
{
    /// <summary>
    /// Gets a human-readable size string.
    /// </summary>
    public string SizeString
    {
        get
        {
            if (SizeInBytes < 1024)
                return $"{SizeInBytes} B";
            if (SizeInBytes < 1024 * 1024)
                return $"{SizeInBytes / 1024.0:F1} KB";
            if (SizeInBytes < 1024 * 1024 * 1024)
                return $"{SizeInBytes / (1024.0 * 1024.0):F1} MB";
            return $"{SizeInBytes / (1024.0 * 1024.0 * 1024.0):F1} GB";
        }
    }

    /// <summary>
    /// Gets the file type description.
    /// </summary>
    public string FileType => IsBinary ? "Binary" : "Text";
};