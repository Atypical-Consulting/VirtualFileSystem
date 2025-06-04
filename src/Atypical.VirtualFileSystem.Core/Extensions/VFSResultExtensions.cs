// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides Result pattern extension methods for IVirtualFileSystem operations.
/// These methods return Result objects instead of throwing exceptions, enabling functional error handling.
/// </summary>
public static class VFSResultExtensions
{
    /// <summary>
    /// Creates a file and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The file content.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result CreateFileResult(this IVirtualFileSystem vfs, string filePath, string? content = null)
    {
        try
        {
            vfs.CreateFile(filePath, content);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Creates a file with auto-created directories and returns a Result.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The file content.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result CreateFileWithDirectoriesResult(this IVirtualFileSystem vfs, string filePath, string? content = null)
    {
        try
        {
            vfs.CreateFileWithDirectories(filePath, content);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Creates a directory and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result CreateDirectoryResult(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            vfs.CreateDirectory(directoryPath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Creates a directory recursively and returns a Result.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result CreateDirectoryRecursivelyResult(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            vfs.CreateDirectoryRecursively(directoryPath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Deletes a file and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result DeleteFileResult(this IVirtualFileSystem vfs, string filePath)
    {
        try
        {
            if (!vfs.FileExists(filePath))
                return Result.Failure($"File '{filePath}' does not exist.");
                
            vfs.DeleteFile(filePath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Deletes a directory and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result DeleteDirectoryResult(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            if (!vfs.DirectoryExists(directoryPath))
                return Result.Failure($"Directory '{directoryPath}' does not exist.");
                
            vfs.DeleteDirectory(directoryPath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Gets a file and returns a Result containing the file or an error.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>A Result containing the file node or an error message.</returns>
    public static Result<IFileNode> GetFileResult(this IVirtualFileSystem vfs, string filePath)
    {
        try
        {
            return vfs.TryGetFile(filePath, out var file)
                ? Result<IFileNode>.Success(file)
                : Result<IFileNode>.Failure($"File '{filePath}' not found.");
        }
        catch (Exception ex)
        {
            return Result<IFileNode>.Failure(ex);
        }
    }

    /// <summary>
    /// Gets a directory and returns a Result containing the directory or an error.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <returns>A Result containing the directory node or an error message.</returns>
    public static Result<IDirectoryNode> GetDirectoryResult(this IVirtualFileSystem vfs, string directoryPath)
    {
        try
        {
            return vfs.TryGetDirectory(directoryPath, out var directory)
                ? Result<IDirectoryNode>.Success(directory)
                : Result<IDirectoryNode>.Failure($"Directory '{directoryPath}' not found.");
        }
        catch (Exception ex)
        {
            return Result<IDirectoryNode>.Failure(ex);
        }
    }

    /// <summary>
    /// Reads file content and returns a Result containing the content or an error.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <returns>A Result containing the file content or an error message.</returns>
    public static Result<string> ReadFileResult(this IVirtualFileSystem vfs, string filePath)
    {
        return vfs.GetFileResult(filePath).Map(file => file.Content);
    }

    /// <summary>
    /// Writes file content and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="content">The content to write.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result WriteFileResult(this IVirtualFileSystem vfs, string filePath, string content)
    {
        var fileResult = vfs.GetFileResult(filePath);
        if (fileResult.IsFailure)
            return Result.Failure(fileResult.Error);
            
        fileResult.Value.Content = content;
        return Result.Success();
    }

    /// <summary>
    /// Moves a file and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceFilePath">The source file path as a string.</param>
    /// <param name="destinationFilePath">The destination file path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result MoveFileResult(this IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath)
    {
        try
        {
            if (!vfs.FileExists(sourceFilePath))
                return Result.Failure($"Source file '{sourceFilePath}' does not exist.");
                
            vfs.MoveFile(sourceFilePath, destinationFilePath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Moves a directory and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceDirectoryPath">The source directory path as a string.</param>
    /// <param name="destinationDirectoryPath">The destination directory path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result MoveDirectoryResult(this IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath)
    {
        try
        {
            if (!vfs.DirectoryExists(sourceDirectoryPath))
                return Result.Failure($"Source directory '{sourceDirectoryPath}' does not exist.");
                
            vfs.MoveDirectory(sourceDirectoryPath, destinationDirectoryPath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Copies a file and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceFilePath">The source file path as a string.</param>
    /// <param name="destinationFilePath">The destination file path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result CopyFileResult(this IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath)
    {
        try
        {
            vfs.CopyFile(sourceFilePath, destinationFilePath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Copies a directory and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="sourceDirectoryPath">The source directory path as a string.</param>
    /// <param name="destinationDirectoryPath">The destination directory path as a string.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result CopyDirectoryResult(this IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath)
    {
        try
        {
            vfs.CopyDirectory(sourceDirectoryPath, destinationDirectoryPath);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Renames a file and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="filePath">The file path as a string.</param>
    /// <param name="newName">The new file name.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result RenameFileResult(this IVirtualFileSystem vfs, string filePath, string newName)
    {
        try
        {
            if (!vfs.FileExists(filePath))
                return Result.Failure($"File '{filePath}' does not exist.");
                
            vfs.RenameFile(filePath, newName);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Renames a directory and returns a Result indicating success or failure.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="directoryPath">The directory path as a string.</param>
    /// <param name="newName">The new directory name.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result RenameDirectoryResult(this IVirtualFileSystem vfs, string directoryPath, string newName)
    {
        try
        {
            if (!vfs.DirectoryExists(directoryPath))
                return Result.Failure($"Directory '{directoryPath}' does not exist.");
                
            vfs.RenameDirectory(directoryPath, newName);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Creates multiple files and returns a Result with the collection of successful paths.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="files">Collection of file path and content pairs.</param>
    /// <param name="createDirectories">Whether to auto-create parent directories.</param>
    /// <returns>A Result containing successful file paths or an error message.</returns>
    public static Result<IEnumerable<string>> CreateFilesResult(this IVirtualFileSystem vfs, 
        IEnumerable<(string path, string content)> files, bool createDirectories = true)
    {
        try
        {
            var successfulPaths = new List<string>();
            var errors = new List<string>();
            
            foreach (var (path, content) in files)
            {
                var result = createDirectories 
                    ? vfs.CreateFileWithDirectoriesResult(path, content)
                    : vfs.CreateFileResult(path, content);
                    
                if (result.IsSuccess)
                    successfulPaths.Add(path);
                else
                    errors.Add($"{path}: {result.Error}");
            }
            
            if (errors.Any())
                return Result<IEnumerable<string>>.Failure($"Some files failed to create: {string.Join(", ", errors)}");
                
            return Result<IEnumerable<string>>.Success(successfulPaths);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<string>>.Failure(ex);
        }
    }

    /// <summary>
    /// Executes an operation and returns a Result, converting any exception to a failure.
    /// </summary>
    /// <param name="operation">The operation to execute.</param>
    /// <returns>A Result indicating success or containing an error message.</returns>
    public static Result Execute(Action operation)
    {
        try
        {
            operation();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    /// <summary>
    /// Executes an operation that returns a value and returns a Result.
    /// </summary>
    /// <typeparam name="T">The return type.</typeparam>
    /// <param name="operation">The operation to execute.</param>
    /// <returns>A Result containing the value or an error message.</returns>
    public static Result<T> Execute<T>(Func<T> operation)
    {
        try
        {
            var result = operation();
            return Result<T>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<T>.Failure(ex);
        }
    }
}