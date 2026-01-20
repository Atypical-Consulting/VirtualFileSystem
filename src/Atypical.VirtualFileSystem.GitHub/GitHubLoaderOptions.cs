// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Specifies the loading strategy for GitHub repository content.
/// </summary>
public enum GitHubLoadingStrategy
{
    /// <summary>
    /// Load all file content immediately.
    /// Best for small repositories or when all content is needed.
    /// </summary>
    Eager,

    /// <summary>
    /// Load file content on demand when accessed.
    /// Best for large repositories where only some files are needed.
    /// </summary>
    Lazy,

    /// <summary>
    /// Load only file metadata (path, size) without content.
    /// Best for exploring repository structure.
    /// </summary>
    MetadataOnly
}

/// <summary>
/// Configuration options for loading GitHub repositories into the VFS.
/// </summary>
/// <param name="AccessToken">
/// GitHub Personal Access Token for authentication.
/// Using a token increases the rate limit from 60 to 5000 requests per hour.
/// Set to null for anonymous access.
/// </param>
/// <param name="Branch">
/// The branch or tag to load. Set to null to use the repository's default branch.
/// </param>
/// <param name="SubPath">
/// Only load files from this subdirectory. Set to null to load the entire repository.
/// Example: "src/libraries" to only load files under src/libraries/.
/// </param>
/// <param name="TargetPath">
/// The VFS path where the repository will be loaded.
/// Defaults to "/" (root). Set to "/github/owner/repo" to load into a subdirectory.
/// </param>
/// <param name="MaxFileSize">
/// Maximum file size in bytes to load. Files larger than this are skipped.
/// Defaults to 1MB (1,048,576 bytes). Set to 0 for no limit.
/// </param>
/// <param name="IncludeExtensions">
/// Only include files with these extensions. Case-insensitive.
/// Set to null to include all extensions.
/// Example: [".cs", ".csproj", ".json"]
/// </param>
/// <param name="ExcludeExtensions">
/// Exclude files with these extensions. Case-insensitive.
/// Takes precedence over IncludeExtensions.
/// Example: [".exe", ".dll", ".pdb"]
/// </param>
/// <param name="ExcludePatterns">
/// Glob patterns for paths to exclude.
/// Example: ["**/node_modules/**", "**/bin/**", "**/obj/**"]
/// </param>
/// <param name="IncludeBinaryFiles">
/// Whether to include binary files. Defaults to true.
/// Binary files are detected by extension (e.g., .png, .exe, .zip).
/// </param>
/// <param name="Strategy">
/// The loading strategy to use. Defaults to Eager.
/// </param>
/// <param name="ProgressCallback">
/// Optional callback for progress reporting during loading.
/// Called with (currentFile, totalFiles, currentPath).
/// </param>
public sealed record GitHubLoaderOptions(
    string? AccessToken = null,
    string? Branch = null,
    string? SubPath = null,
    string TargetPath = "/",
    long MaxFileSize = 1_048_576,
    HashSet<string>? IncludeExtensions = null,
    HashSet<string>? ExcludeExtensions = null,
    List<string>? ExcludePatterns = null,
    bool IncludeBinaryFiles = true,
    GitHubLoadingStrategy Strategy = GitHubLoadingStrategy.Eager,
    Action<int, int, string>? ProgressCallback = null)
{
    /// <summary>
    /// Gets the default options for loading a GitHub repository.
    /// </summary>
    public static GitHubLoaderOptions Default { get; } = new();

    /// <summary>
    /// Gets options optimized for loading source code files only.
    /// Excludes binary files and common build output directories.
    /// </summary>
    public static GitHubLoaderOptions SourceCodeOnly { get; } = new(
        IncludeBinaryFiles: false,
        ExcludePatterns:
        [
            "**/node_modules/**",
            "**/bin/**",
            "**/obj/**",
            "**/.git/**",
            "**/packages/**",
            "**/dist/**",
            "**/build/**"
        ]
    );

    /// <summary>
    /// Gets options for loading only C# source files.
    /// </summary>
    public static GitHubLoaderOptions CSharpOnly { get; } = new(
        IncludeExtensions: [".cs", ".csproj", ".sln", ".props", ".targets"],
        IncludeBinaryFiles: false,
        ExcludePatterns:
        [
            "**/bin/**",
            "**/obj/**"
        ]
    );

    /// <summary>
    /// Gets options for metadata-only loading (no file content).
    /// </summary>
    public static GitHubLoaderOptions MetadataOnlyPreset { get; } = new(
        Strategy: GitHubLoadingStrategy.MetadataOnly
    );

    /// <summary>
    /// Known binary file extensions.
    /// </summary>
    internal static readonly HashSet<string> BinaryExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        // Images
        ".png", ".jpg", ".jpeg", ".gif", ".ico", ".webp", ".bmp", ".tiff", ".svg",
        // Executables and libraries
        ".exe", ".dll", ".so", ".dylib", ".bin", ".com",
        // Archives
        ".zip", ".tar", ".gz", ".7z", ".rar", ".bz2", ".xz",
        // Media
        ".mp3", ".mp4", ".wav", ".avi", ".mov", ".wmv", ".flac", ".ogg",
        // Documents
        ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx",
        // Fonts
        ".ttf", ".otf", ".woff", ".woff2", ".eot",
        // Database
        ".db", ".sqlite", ".mdb",
        // Other
        ".pdb", ".nupkg", ".snupkg"
    };

    /// <summary>
    /// Determines if a file extension represents a binary file.
    /// </summary>
    /// <param name="extension">The file extension including the leading dot.</param>
    /// <returns>True if the extension represents a binary file.</returns>
    public static bool IsBinaryExtension(string extension)
        => BinaryExtensions.Contains(extension);
}
