using Atypical.VirtualFileSystem.Core;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Service for tracking recently accessed files
/// </summary>
public class RecentFilesService
{
    private const int MaxRecentFiles = 20;
    private readonly List<RecentFileEntry> _recentFiles = [];

    public IReadOnlyList<RecentFileEntry> RecentFiles => _recentFiles.AsReadOnly();

    public event Action? OnChange;

    public void RecordAccess(string path, bool isDirectory)
    {
        // Remove existing entry for this path
        _recentFiles.RemoveAll(r => r.Path == path);

        // Add new entry at the beginning
        _recentFiles.Insert(0, new RecentFileEntry
        {
            Path = path,
            IsDirectory = isDirectory,
            AccessedAt = DateTime.Now,
            Name = System.IO.Path.GetFileName(path.TrimEnd('/')) ?? path
        });

        // Trim to max size
        while (_recentFiles.Count > MaxRecentFiles)
        {
            _recentFiles.RemoveAt(_recentFiles.Count - 1);
        }

        OnChange?.Invoke();
    }

    public void RemoveEntry(string path)
    {
        _recentFiles.RemoveAll(r => r.Path == path);
        OnChange?.Invoke();
    }

    public void Clear()
    {
        _recentFiles.Clear();
        OnChange?.Invoke();
    }
}

/// <summary>
/// Represents a recently accessed file
/// </summary>
public class RecentFileEntry
{
    public required string Path { get; init; }
    public required string Name { get; init; }
    public required bool IsDirectory { get; init; }
    public required DateTime AccessedAt { get; init; }
}
