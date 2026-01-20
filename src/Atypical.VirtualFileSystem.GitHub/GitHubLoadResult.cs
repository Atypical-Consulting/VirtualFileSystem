// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Represents the reason a file was skipped during loading.
/// </summary>
public enum SkipReason
{
    /// <summary>
    /// File exceeded the maximum file size limit.
    /// </summary>
    TooLarge,

    /// <summary>
    /// File extension was not in the include list.
    /// </summary>
    ExtensionNotIncluded,

    /// <summary>
    /// File extension was in the exclude list.
    /// </summary>
    ExtensionExcluded,

    /// <summary>
    /// File path matched an exclude pattern.
    /// </summary>
    PatternExcluded,

    /// <summary>
    /// Binary files were excluded by configuration.
    /// </summary>
    BinaryExcluded,

    /// <summary>
    /// Failed to load file content.
    /// </summary>
    LoadError
}

/// <summary>
/// Information about a file that was skipped during loading.
/// </summary>
/// <param name="Path">The path of the skipped file.</param>
/// <param name="Reason">The reason the file was skipped.</param>
/// <param name="Size">The file size in bytes, if known.</param>
/// <param name="ErrorMessage">Additional error message, if applicable.</param>
public sealed record GitHubSkippedFile(
    string Path,
    SkipReason Reason,
    long? Size = null,
    string? ErrorMessage = null);

/// <summary>
/// Result of loading a GitHub repository into the VFS.
/// </summary>
/// <param name="RepositoryOwner">The owner of the loaded repository.</param>
/// <param name="RepositoryName">The name of the loaded repository.</param>
/// <param name="Branch">The branch that was loaded.</param>
/// <param name="CommitSha">The SHA of the commit that was loaded.</param>
/// <param name="FilesLoaded">The number of files successfully loaded.</param>
/// <param name="DirectoriesCreated">The number of directories created.</param>
/// <param name="TotalBytesLoaded">The total size of loaded files in bytes.</param>
/// <param name="SkippedFiles">List of files that were skipped during loading.</param>
/// <param name="LoadDuration">The time taken to load the repository.</param>
/// <param name="TargetPath">The VFS path where the repository was loaded.</param>
public sealed record GitHubLoadResult(
    string RepositoryOwner,
    string RepositoryName,
    string Branch,
    string CommitSha,
    int FilesLoaded,
    int DirectoriesCreated,
    long TotalBytesLoaded,
    IReadOnlyList<GitHubSkippedFile> SkippedFiles,
    TimeSpan LoadDuration,
    string TargetPath)
{
    /// <summary>
    /// Gets the full repository name in "owner/repo" format.
    /// </summary>
    public string FullRepositoryName => $"{RepositoryOwner}/{RepositoryName}";

    /// <summary>
    /// Gets the number of files that were skipped.
    /// </summary>
    public int FilesSkipped => SkippedFiles.Count;

    /// <summary>
    /// Gets a value indicating whether any files were skipped.
    /// </summary>
    public bool HasSkippedFiles => SkippedFiles.Count > 0;

    /// <summary>
    /// Gets a human-readable summary of the load operation.
    /// </summary>
    public string Summary
    {
        get
        {
            var sizeStr = FormatBytes(TotalBytesLoaded);
            var result = $"Loaded {FilesLoaded} files ({sizeStr}) from {FullRepositoryName}@{Branch} in {LoadDuration.TotalSeconds:F2}s";

            if (HasSkippedFiles)
            {
                result += $" ({FilesSkipped} files skipped)";
            }

            return result;
        }
    }

    /// <summary>
    /// Gets the skipped files grouped by skip reason.
    /// </summary>
    public IReadOnlyDictionary<SkipReason, IReadOnlyList<GitHubSkippedFile>> SkippedFilesByReason
        => SkippedFiles
            .GroupBy(f => f.Reason)
            .ToDictionary(g => g.Key, g => (IReadOnlyList<GitHubSkippedFile>)g.ToList());

    private static string FormatBytes(long bytes)
    {
        if (bytes < 1024)
            return $"{bytes} B";
        if (bytes < 1024 * 1024)
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:F1} KB", bytes / 1024.0);
        if (bytes < 1024 * 1024 * 1024)
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:F1} MB", bytes / (1024.0 * 1024.0));
        return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:F1} GB", bytes / (1024.0 * 1024.0 * 1024.0));
    }
}
