using System.Collections.Concurrent;
using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.DemoBlazorApp.Models;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Tracks GitHub metadata for files imported from repositories.
/// Enables PR creation by maintaining the mapping between VFS paths and GitHub sources.
/// </summary>
public sealed class GitHubMetadataTracker : IDisposable
{
    private readonly IVirtualFileSystem _vfs;
    private readonly ConcurrentDictionary<string, GitHubFileMetadata> _metadataByPath = new(StringComparer.OrdinalIgnoreCase);
    private bool _isSubscribed;

    /// <summary>
    /// Event fired when metadata changes (file tracked, untracked, or moved).
    /// </summary>
    public event Action? OnMetadataChanged;

    public GitHubMetadataTracker(IVirtualFileSystem vfs)
    {
        _vfs = vfs;
    }

    /// <summary>
    /// Subscribes to VFS events to automatically handle file moves and deletes.
    /// </summary>
    public void SubscribeToVfsEvents()
    {
        if (_isSubscribed) return;
        _isSubscribed = true;

        _vfs.FileDeleted += OnFileDeleted;
        _vfs.FileMoved += OnFileMoved;
        _vfs.FileRenamed += OnFileRenamed;
        _vfs.DirectoryDeleted += OnDirectoryDeleted;
        _vfs.DirectoryMoved += OnDirectoryMoved;
    }

    /// <summary>
    /// Tracks a file with its GitHub metadata.
    /// </summary>
    /// <param name="vfsPath">The VFS path of the file.</param>
    /// <param name="metadata">The GitHub metadata.</param>
    public void TrackFile(string vfsPath, GitHubFileMetadata metadata)
    {
        var normalizedPath = NormalizePath(vfsPath);
        _metadataByPath[normalizedPath] = metadata;
        OnMetadataChanged?.Invoke();
    }

    /// <summary>
    /// Gets the GitHub metadata for a file if it exists.
    /// </summary>
    /// <param name="vfsPath">The VFS path of the file.</param>
    /// <returns>The metadata if found, null otherwise.</returns>
    public GitHubFileMetadata? GetMetadata(string vfsPath)
    {
        var normalizedPath = NormalizePath(vfsPath);
        return _metadataByPath.TryGetValue(normalizedPath, out var metadata) ? metadata : null;
    }

    /// <summary>
    /// Checks if a file is tracked as a GitHub file.
    /// </summary>
    /// <param name="vfsPath">The VFS path of the file.</param>
    /// <returns>True if the file is from GitHub.</returns>
    public bool IsGitHubFile(string vfsPath)
    {
        var normalizedPath = NormalizePath(vfsPath);
        return _metadataByPath.ContainsKey(normalizedPath);
    }

    /// <summary>
    /// Removes tracking for a file.
    /// </summary>
    /// <param name="vfsPath">The VFS path of the file.</param>
    public void UntrackFile(string vfsPath)
    {
        var normalizedPath = NormalizePath(vfsPath);
        if (_metadataByPath.TryRemove(normalizedPath, out _))
        {
            OnMetadataChanged?.Invoke();
        }
    }

    /// <summary>
    /// Updates the path for a tracked file (after move or rename).
    /// </summary>
    /// <param name="oldPath">The old VFS path.</param>
    /// <param name="newPath">The new VFS path.</param>
    public void UpdatePath(string oldPath, string newPath)
    {
        var normalizedOldPath = NormalizePath(oldPath);
        var normalizedNewPath = NormalizePath(newPath);

        if (_metadataByPath.TryRemove(normalizedOldPath, out var metadata))
        {
            _metadataByPath[normalizedNewPath] = metadata;
            OnMetadataChanged?.Invoke();
        }
    }

    /// <summary>
    /// Gets all tracked files for a specific repository.
    /// </summary>
    /// <param name="owner">The repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <returns>Dictionary of VFS paths to metadata for the repository.</returns>
    public IReadOnlyDictionary<string, GitHubFileMetadata> GetFilesForRepository(string owner, string repository)
    {
        var key = $"{owner}/{repository}";
        return _metadataByPath
            .Where(kvp => kvp.Value.RepositoryKey.Equals(key, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    /// <summary>
    /// Gets all tracked files grouped by repository.
    /// </summary>
    /// <returns>Dictionary of repository keys to their file metadata.</returns>
    public IReadOnlyDictionary<string, List<(string VfsPath, GitHubFileMetadata Metadata)>> GetAllFilesGroupedByRepository()
    {
        return _metadataByPath
            .GroupBy(kvp => kvp.Value.RepositoryKey)
            .ToDictionary(
                g => g.Key,
                g => g.Select(kvp => (kvp.Key, kvp.Value)).ToList()
            );
    }

    /// <summary>
    /// Gets the total count of tracked files.
    /// </summary>
    public int TrackedFileCount => _metadataByPath.Count;

    /// <summary>
    /// Clears all tracked metadata.
    /// </summary>
    public void ClearAll()
    {
        _metadataByPath.Clear();
        OnMetadataChanged?.Invoke();
    }

    private void OnFileDeleted(VFSEventArgs args)
    {
        if (args is VFSFileDeletedArgs fileArgs)
        {
            UntrackFile(fileArgs.Path.Value);
        }
    }

    private void OnFileMoved(VFSEventArgs args)
    {
        if (args is VFSFileMovedArgs moveArgs)
        {
            UpdatePath(moveArgs.SourcePath.Value, moveArgs.DestinationPath.Value);
        }
    }

    private void OnFileRenamed(VFSEventArgs args)
    {
        if (args is VFSFileRenamedArgs renameArgs)
        {
            // Compute old and new full paths from the renamed file
            var path = renameArgs.Path.Value;
            var parentDir = path.LastIndexOf('/') >= 0 ? path[..path.LastIndexOf('/')] : "";
            var oldPath = string.IsNullOrEmpty(parentDir) ? renameArgs.OldName : $"{parentDir}/{renameArgs.OldName}";
            var newPath = string.IsNullOrEmpty(parentDir) ? renameArgs.NewName : $"{parentDir}/{renameArgs.NewName}";
            UpdatePath(oldPath, newPath);
        }
    }

    private void OnDirectoryDeleted(VFSEventArgs args)
    {
        if (args is VFSDirectoryDeletedArgs dirArgs)
        {
            var prefix = NormalizePath(dirArgs.Path.Value);
            var keysToRemove = _metadataByPath.Keys
                .Where(k => k.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var key in keysToRemove)
            {
                _metadataByPath.TryRemove(key, out _);
            }

            if (keysToRemove.Count > 0)
            {
                OnMetadataChanged?.Invoke();
            }
        }
    }

    private void OnDirectoryMoved(VFSEventArgs args)
    {
        if (args is VFSDirectoryMovedArgs moveArgs)
        {
            var oldPrefix = NormalizePath(moveArgs.SourcePath.Value);
            var newPrefix = NormalizePath(moveArgs.DestinationPath.Value);

            var entriesToUpdate = _metadataByPath
                .Where(kvp => kvp.Key.StartsWith(oldPrefix, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var (oldPath, metadata) in entriesToUpdate)
            {
                _metadataByPath.TryRemove(oldPath, out _);
                var newPath = newPrefix + oldPath[oldPrefix.Length..];
                _metadataByPath[newPath] = metadata;
            }

            if (entriesToUpdate.Count > 0)
            {
                OnMetadataChanged?.Invoke();
            }
        }
    }

    private static string NormalizePath(string path)
    {
        // Ensure consistent path format
        return path.TrimEnd('/');
    }

    public void Dispose()
    {
        if (_isSubscribed)
        {
            _vfs.FileDeleted -= OnFileDeleted;
            _vfs.FileMoved -= OnFileMoved;
            _vfs.FileRenamed -= OnFileRenamed;
            _vfs.DirectoryDeleted -= OnDirectoryDeleted;
            _vfs.DirectoryMoved -= OnDirectoryMoved;
        }
    }
}
