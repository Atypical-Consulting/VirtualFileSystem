// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides fluent search extension methods for IVirtualFileSystem and file/directory collections.
/// </summary>
public static class VFSSearchExtensions
{
    /// <summary>
    /// Filters files by extension.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="extension">The file extension (with or without leading dot).</param>
    /// <returns>Files with the specified extension.</returns>
    public static IEnumerable<IFileNode> WithExtension(this IEnumerable<IFileNode> files, string extension)
    {
        var normalizedExtension = extension.StartsWith('.') ? extension : $".{extension}";
        return files.Where(f => f.Path.Value.EndsWith(normalizedExtension, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Filters files by multiple extensions.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="extensions">The file extensions (with or without leading dots).</param>
    /// <returns>Files with any of the specified extensions.</returns>
    public static IEnumerable<IFileNode> WithExtensions(this IEnumerable<IFileNode> files, params string[] extensions)
    {
        var normalizedExtensions = extensions.Select(ext => ext.StartsWith('.') ? ext : $".{ext}").ToArray();
        return files.Where(f => normalizedExtensions.Any(ext => 
            f.Path.Value.EndsWith(ext, StringComparison.OrdinalIgnoreCase)));
    }

    /// <summary>
    /// Filters files by content containing specific text.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="text">The text to search for.</param>
    /// <param name="ignoreCase">Whether to ignore case. Default is true.</param>
    /// <returns>Files containing the specified text.</returns>
    public static IEnumerable<IFileNode> ContainingText(this IEnumerable<IFileNode> files, string text, bool ignoreCase = true)
    {
        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        return files.Where(f => f.Content.Contains(text, comparison));
    }

    /// <summary>
    /// Filters files by content matching a regular expression.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="pattern">The regular expression pattern.</param>
    /// <param name="options">Regular expression options. Default is IgnoreCase.</param>
    /// <returns>Files with content matching the pattern.</returns>
    public static IEnumerable<IFileNode> ContainingPattern(this IEnumerable<IFileNode> files, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
    {
        var regex = new Regex(pattern, options);
        return files.Where(f => regex.IsMatch(f.Content));
    }

    /// <summary>
    /// Filters files by name containing specific text.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="nameText">The text to search for in file names.</param>
    /// <param name="ignoreCase">Whether to ignore case. Default is true.</param>
    /// <returns>Files with names containing the specified text.</returns>
    public static IEnumerable<IFileNode> WithNameContaining(this IEnumerable<IFileNode> files, string nameText, bool ignoreCase = true)
    {
        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        return files.Where(f => f.Path.Name.Contains(nameText, comparison));
    }

    /// <summary>
    /// Filters files by name starting with specific text.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="prefix">The prefix to search for.</param>
    /// <param name="ignoreCase">Whether to ignore case. Default is true.</param>
    /// <returns>Files with names starting with the specified prefix.</returns>
    public static IEnumerable<IFileNode> WithNameStartingWith(this IEnumerable<IFileNode> files, string prefix, bool ignoreCase = true)
    {
        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        return files.Where(f => f.Path.Name.StartsWith(prefix, comparison));
    }

    /// <summary>
    /// Filters files by name ending with specific text.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="suffix">The suffix to search for.</param>
    /// <param name="ignoreCase">Whether to ignore case. Default is true.</param>
    /// <returns>Files with names ending with the specified suffix.</returns>
    public static IEnumerable<IFileNode> WithNameEndingWith(this IEnumerable<IFileNode> files, string suffix, bool ignoreCase = true)
    {
        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        return files.Where(f => f.Path.Name.EndsWith(suffix, comparison));
    }

    /// <summary>
    /// Filters files by directory path.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="directoryPath">The directory path to search in.</param>
    /// <param name="recursive">Whether to include subdirectories. Default is false.</param>
    /// <returns>Files in the specified directory.</returns>
    public static IEnumerable<IFileNode> InDirectory(this IEnumerable<IFileNode> files, string directoryPath, bool recursive = false)
    {
        // Normalize the input path and ensure it has VFS prefix
        var cleanPath = directoryPath.TrimEnd('/');
        if (!cleanPath.StartsWith("vfs://"))
        {
            cleanPath = cleanPath.TrimStart('/');
            cleanPath = $"vfs://{cleanPath}";
        }
        var normalizedPath = cleanPath + "/";
        
        if (recursive)
        {
            return files.Where(f => f.Path.Value.StartsWith(normalizedPath, StringComparison.OrdinalIgnoreCase));
        }
        else
        {
            return files.Where(f => 
            {
                var filePath = f.Path.Value;
                if (!filePath.StartsWith(normalizedPath, StringComparison.OrdinalIgnoreCase))
                    return false;
                
                // Check if it's a direct child (no additional path separators)
                var relativePath = filePath[normalizedPath.Length..];
                return !relativePath.Contains('/');
            });
        }
    }

    /// <summary>
    /// Filters files by size range.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="minSize">Minimum file size (content length). Default is 0.</param>
    /// <param name="maxSize">Maximum file size (content length). Default is int.MaxValue.</param>
    /// <returns>Files within the specified size range.</returns>
    public static IEnumerable<IFileNode> WithSizeInRange(this IEnumerable<IFileNode> files, int minSize = 0, int maxSize = int.MaxValue)
    {
        return files.Where(f => f.Content.Length >= minSize && f.Content.Length <= maxSize);
    }

    /// <summary>
    /// Filters files by creation time range.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="from">Start of time range. Default is DateTime.MinValue.</param>
    /// <param name="to">End of time range. Default is DateTime.MaxValue.</param>
    /// <returns>Files created within the specified time range.</returns>
    public static IEnumerable<IFileNode> CreatedBetween(this IEnumerable<IFileNode> files, DateTime? from = null, DateTime? to = null)
    {
        var fromDate = from ?? DateTime.MinValue;
        var toDate = to ?? DateTime.MaxValue;
        return files.Where(f => f.CreationTime >= fromDate && f.CreationTime <= toDate);
    }

    /// <summary>
    /// Filters files modified within a specific time range.
    /// </summary>
    /// <param name="files">The files to filter.</param>
    /// <param name="from">Start of time range. Default is DateTime.MinValue.</param>
    /// <param name="to">End of time range. Default is DateTime.MaxValue.</param>
    /// <returns>Files modified within the specified time range.</returns>
    public static IEnumerable<IFileNode> ModifiedBetween(this IEnumerable<IFileNode> files, DateTime? from = null, DateTime? to = null)
    {
        var fromDate = from ?? DateTime.MinValue;
        var toDate = to ?? DateTime.MaxValue;
        return files.Where(f => f.LastWriteTime >= fromDate && f.LastWriteTime <= toDate);
    }

    /// <summary>
    /// Filters directories by name containing specific text.
    /// </summary>
    /// <param name="directories">The directories to filter.</param>
    /// <param name="nameText">The text to search for in directory names.</param>
    /// <param name="ignoreCase">Whether to ignore case. Default is true.</param>
    /// <returns>Directories with names containing the specified text.</returns>
    public static IEnumerable<IDirectoryNode> WithNameContaining(this IEnumerable<IDirectoryNode> directories, string nameText, bool ignoreCase = true)
    {
        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        return directories.Where(d => d.Path.Name.Contains(nameText, comparison));
    }

    /// <summary>
    /// Filters directories by path depth.
    /// </summary>
    /// <param name="directories">The directories to filter.</param>
    /// <param name="depth">The exact depth to filter by.</param>
    /// <returns>Directories at the specified depth.</returns>
    public static IEnumerable<IDirectoryNode> AtDepth(this IEnumerable<IDirectoryNode> directories, int depth)
    {
        return directories.Where(d => d.Path.Depth == depth);
    }

    /// <summary>
    /// Filters directories containing a minimum number of files.
    /// </summary>
    /// <param name="directories">The directories to filter.</param>
    /// <param name="minFileCount">The minimum number of files.</param>
    /// <returns>Directories containing at least the specified number of files.</returns>
    public static IEnumerable<IDirectoryNode> WithMinFileCount(this IEnumerable<IDirectoryNode> directories, int minFileCount)
    {
        return directories.Where(d => d.Files.Count() >= minFileCount);
    }

    /// <summary>
    /// Filters directories that are empty (no files or subdirectories).
    /// </summary>
    /// <param name="directories">The directories to filter.</param>
    /// <returns>Empty directories.</returns>
    public static IEnumerable<IDirectoryNode> Empty(this IEnumerable<IDirectoryNode> directories)
    {
        return directories.Where(d => !d.Files.Any() && !d.Directories.Any());
    }

    /// <summary>
    /// Searches files using glob pattern matching.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="pattern">The glob pattern (e.g., "*.txt", "test*.md", "**/config.*").</param>
    /// <returns>Files matching the glob pattern.</returns>
    public static IEnumerable<IFileNode> FindFilesByGlob(this IVirtualFileSystem vfs, string pattern)
    {
        var regex = GlobToRegex(pattern);
        return vfs.Files.Where(f => regex.IsMatch(f.Path.Value));
    }

    /// <summary>
    /// Searches directories using glob pattern matching.
    /// </summary>
    /// <param name="vfs">The virtual file system.</param>
    /// <param name="pattern">The glob pattern (e.g., "*test*", "src/**", "**/temp").</param>
    /// <returns>Directories matching the glob pattern.</returns>
    public static IEnumerable<IDirectoryNode> FindDirectoriesByGlob(this IVirtualFileSystem vfs, string pattern)
    {
        var regex = GlobToRegex(pattern);
        return vfs.Directories.Where(d => regex.IsMatch(d.Path.Value));
    }

    /// <summary>
    /// Converts a glob pattern to a regular expression.
    /// </summary>
    /// <param name="pattern">The glob pattern.</param>
    /// <returns>A compiled regular expression.</returns>
    private static Regex GlobToRegex(string pattern)
    {
        // Escape regex special characters except for our glob patterns
        var regexPattern = Regex.Escape(pattern)
            .Replace(@"\*\*", ".*")  // ** matches any path
            .Replace(@"\*", "[^/]*") // * matches anything except path separator
            .Replace(@"\?", ".");    // ? matches single character
        
        return new Regex($"^{regexPattern}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }
}