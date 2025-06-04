// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Extensions;

/// <summary>
/// Provides path manipulation and utility extension methods for VFS paths.
/// </summary>
public static class VFSPathExtensions
{
    /// <summary>
    /// Gets the file extension from a VFS path.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <returns>The file extension including the leading dot, or empty string if no extension.</returns>
    public static string GetExtension(this VFSPath path)
    {
        var name = path.Name;
        var lastDotIndex = name.LastIndexOf('.');
        return lastDotIndex >= 0 ? name.Substring(lastDotIndex) : string.Empty;
    }

    /// <summary>
    /// Gets the file name without extension from a VFS path.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <returns>The file name without extension.</returns>
    public static string GetFileNameWithoutExtension(this VFSPath path)
    {
        var name = path.Name;
        var lastDotIndex = name.LastIndexOf('.');
        return lastDotIndex >= 0 ? name.Substring(0, lastDotIndex) : name;
    }

    /// <summary>
    /// Gets the parent directory at the specified level up.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <param name="levels">Number of levels to go up. Default is 1.</param>
    /// <returns>The parent directory at the specified level.</returns>
    /// <exception cref="InvalidOperationException">Thrown when there's no parent at the specified level.</exception>
    public static VFSDirectoryPath GetParent(this VFSPath path, int levels = 1)
    {
        if (levels < 0)
            throw new ArgumentException("Levels must be non-negative.", nameof(levels));
        
        if (levels == 0)
            return path as VFSDirectoryPath ?? path.Parent ?? throw new InvalidOperationException("Path has no parent.");
        
        var current = path.Parent;
        for (int i = 1; i < levels && current?.Parent != null; i++)
        {
            current = current.Parent;
        }
        
        return current ?? throw new InvalidOperationException($"Path has no parent at level {levels}.");
    }

    /// <summary>
    /// Checks if the path has a specific extension.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <param name="extension">The extension to check (with or without leading dot).</param>
    /// <param name="ignoreCase">Whether to ignore case. Default is true.</param>
    /// <returns>True if the path has the specified extension.</returns>
    public static bool HasExtension(this VFSPath path, string extension, bool ignoreCase = true)
    {
        var normalizedExtension = extension.StartsWith('.') ? extension : $".{extension}";
        var pathExtension = path.GetExtension();
        
        return ignoreCase 
            ? string.Equals(pathExtension, normalizedExtension, StringComparison.OrdinalIgnoreCase)
            : string.Equals(pathExtension, normalizedExtension, StringComparison.Ordinal);
    }

    /// <summary>
    /// Checks if the path has any of the specified extensions.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <param name="extensions">The extensions to check (with or without leading dots).</param>
    /// <returns>True if the path has any of the specified extensions.</returns>
    public static bool HasAnyExtension(this VFSPath path, params string[] extensions)
    {
        return extensions.Any(ext => path.HasExtension(ext));
    }

    /// <summary>
    /// Changes the extension of a VFS path.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <param name="newExtension">The new extension (with or without leading dot).</param>
    /// <returns>A new path with the changed extension.</returns>
    public static string ChangeExtension(this VFSPath path, string newExtension)
    {
        var normalizedExtension = newExtension.StartsWith('.') ? newExtension : $".{newExtension}";
        var nameWithoutExt = path.GetFileNameWithoutExtension();
        var parentPath = path.Parent?.Value ?? "/";
        
        return $"{parentPath.TrimEnd('/')}/{nameWithoutExt}{normalizedExtension}";
    }

    /// <summary>
    /// Combines a directory path with a relative path.
    /// </summary>
    /// <param name="directoryPath">The base directory path.</param>
    /// <param name="relativePath">The relative path to combine.</param>
    /// <returns>The combined path.</returns>
    public static string Combine(this VFSDirectoryPath directoryPath, string relativePath)
    {
        var basePath = directoryPath.Value.TrimEnd('/');
        var relPath = relativePath.TrimStart('/');
        return $"{basePath}/{relPath}";
    }

    /// <summary>
    /// Gets the relative path from one directory to another.
    /// </summary>
    /// <param name="from">The source directory path.</param>
    /// <param name="to">The target path.</param>
    /// <returns>The relative path from source to target.</returns>
    public static string GetRelativePath(this VFSDirectoryPath from, VFSPath to)
    {
        var fromParts = from.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var toParts = to.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);
        
        // Find common prefix length
        int commonLength = 0;
        int minLength = Math.Min(fromParts.Length, toParts.Length);
        
        for (int i = 0; i < minLength; i++)
        {
            if (string.Equals(fromParts[i], toParts[i], StringComparison.OrdinalIgnoreCase))
                commonLength++;
            else
                break;
        }
        
        // Build relative path
        var relativeParts = new List<string>();
        
        // Add ".." for each remaining part in from path
        for (int i = commonLength; i < fromParts.Length; i++)
        {
            relativeParts.Add("..");
        }
        
        // Add remaining parts of to path
        for (int i = commonLength; i < toParts.Length; i++)
        {
            relativeParts.Add(toParts[i]);
        }
        
        return relativeParts.Any() ? string.Join("/", relativeParts) : ".";
    }

    /// <summary>
    /// Checks if a path is a descendant of another path.
    /// </summary>
    /// <param name="ancestorPath">The potential ancestor path.</param>
    /// <param name="descendantPath">The potential descendant path.</param>
    /// <returns>True if descendantPath is under ancestorPath.</returns>
    public static bool IsAncestorOf(this VFSPath ancestorPath, VFSPath descendantPath)
    {
        var ancestorValue = ancestorPath.Value.TrimEnd('/') + "/";
        var descendantValue = descendantPath.Value.TrimEnd('/') + "/";
        
        return descendantValue.StartsWith(ancestorValue, StringComparison.OrdinalIgnoreCase) && 
               descendantValue.Length > ancestorValue.Length;
    }

    /// <summary>
    /// Checks if a path is a child (direct descendant) of another path.
    /// </summary>
    /// <param name="parentPath">The potential parent path.</param>
    /// <param name="childPath">The potential child path.</param>
    /// <returns>True if childPath is a direct child of parentPath.</returns>
    public static bool IsDirectChildOf(this VFSPath parentPath, VFSPath childPath)
    {
        return childPath.Parent?.Value.Equals(parentPath.Value, StringComparison.OrdinalIgnoreCase) == true;
    }

    /// <summary>
    /// Gets all ancestor paths from the current path up to the root.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <returns>Collection of ancestor paths from immediate parent to root.</returns>
    public static IEnumerable<VFSDirectoryPath> GetAncestors(this VFSPath path)
    {
        var current = path.Parent;
        while (current != null && !current.IsRoot)
        {
            yield return current;
            current = current.Parent;
        }
    }

    /// <summary>
    /// Checks if the path matches a glob pattern.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <param name="pattern">The glob pattern (e.g., "*.txt", "test*", "**/config.*").</param>
    /// <returns>True if the path matches the pattern.</returns>
    public static bool MatchesGlob(this VFSPath path, string pattern)
    {
        // Create a simple glob regex without dependency on VFSSearchExtensions
        var regexPattern = System.Text.RegularExpressions.Regex.Escape(pattern)
            .Replace(@"\*\*", ".*")  // ** matches any path
            .Replace(@"\*", "[^/]*") // * matches anything except path separator
            .Replace(@"\?", ".");    // ? matches single character
        
        var regex = new System.Text.RegularExpressions.Regex($"^{regexPattern}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        return regex.IsMatch(path.Value);
    }

    /// <summary>
    /// Normalizes a path by removing redundant separators and resolving relative components.
    /// </summary>
    /// <param name="path">The path to normalize.</param>
    /// <returns>The normalized path.</returns>
    public static string Normalize(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return "/";
        
        // Split path into components
        var components = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var normalized = new List<string>();
        
        foreach (var component in components)
        {
            switch (component)
            {
                case ".":
                    // Current directory - skip
                    continue;
                case "..":
                    // Parent directory - remove last component if exists
                    if (normalized.Count > 0)
                        normalized.RemoveAt(normalized.Count - 1);
                    break;
                default:
                    normalized.Add(component);
                    break;
            }
        }
        
        // Build final path
        var result = "/" + string.Join("/", normalized);
        
        // Ensure directory paths end with /
        if (path.EndsWith('/') && !result.EndsWith('/') && result != "/")
            result += "/";
            
        return result;
    }

    /// <summary>
    /// Gets the depth of the path (number of directory levels from root).
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <returns>The depth of the path.</returns>
    public static int GetDepth(this VFSPath path)
    {
        return path.Depth;
    }

    /// <summary>
    /// Checks if the path is at a specific depth.
    /// </summary>
    /// <param name="path">The VFS path.</param>
    /// <param name="depth">The depth to check.</param>
    /// <returns>True if the path is at the specified depth.</returns>
    public static bool IsAtDepth(this VFSPath path, int depth)
    {
        return path.Depth == depth;
    }
}