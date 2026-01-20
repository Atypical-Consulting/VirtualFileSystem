using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.DemoBlazorApp.Models;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Service that wraps the ChangeHistory to provide UI-friendly undo/redo functionality.
/// </summary>
public class UndoRedoService
{
    private readonly IVirtualFileSystem _vfs;
    private readonly ToastService _toast;
    private readonly VFSStateService _stateService;
    private readonly HashSet<string> _recentlyAffectedPaths = new();
    private readonly object _lock = new();

    /// <summary>
    /// Event raised when the history changes (undo/redo performed or new operation added).
    /// </summary>
    public event Action? OnHistoryChanged;

    /// <summary>
    /// Event raised when a path is affected by an undo/redo operation.
    /// </summary>
    public event Action<string>? OnPathAffected;

    public UndoRedoService(
        IVirtualFileSystem vfs,
        ToastService toast,
        VFSStateService stateService)
    {
        _vfs = vfs;
        _toast = toast;
        _stateService = stateService;

        // Subscribe to VFS events to notify UI of history changes
        _vfs.DirectoryCreated += _ => NotifyHistoryChanged();
        _vfs.FileCreated += _ => NotifyHistoryChanged();
        _vfs.DirectoryDeleted += _ => NotifyHistoryChanged();
        _vfs.FileDeleted += _ => NotifyHistoryChanged();
        _vfs.DirectoryMoved += _ => NotifyHistoryChanged();
        _vfs.FileMoved += _ => NotifyHistoryChanged();
        _vfs.DirectoryRenamed += _ => NotifyHistoryChanged();
        _vfs.FileRenamed += _ => NotifyHistoryChanged();
    }

    /// <summary>
    /// Gets whether there are operations to undo.
    /// </summary>
    public bool CanUndo => _vfs.ChangeHistory.UndoStack.Count > 0;

    /// <summary>
    /// Gets whether there are operations to redo.
    /// </summary>
    public bool CanRedo => _vfs.ChangeHistory.RedoStack.Count > 0;

    /// <summary>
    /// Gets the count of undoable operations.
    /// </summary>
    public int UndoCount => _vfs.ChangeHistory.UndoStack.Count;

    /// <summary>
    /// Gets the count of redoable operations.
    /// </summary>
    public int RedoCount => _vfs.ChangeHistory.RedoStack.Count;

    /// <summary>
    /// Performs an undo operation.
    /// </summary>
    public void Undo()
    {
        if (!CanUndo)
        {
            _toast.ShowWarning("Nothing to undo");
            return;
        }

        var nextUndo = _vfs.ChangeHistory.UndoStack.FirstOrDefault();
        if (nextUndo == null) return;

        try
        {
            _vfs.ChangeHistory.Undo();

            var entry = HistoryEntry.FromEventArgs(nextUndo);
            var affectedPath = entry.AffectedPath;

            // Track the affected path for highlighting
            TrackAffectedPath(affectedPath);

            _toast.ShowInfo($"Undone: {entry.Description}");
            _stateService.NotifyDataChanged();
            NotifyHistoryChanged();
        }
        catch (NotImplementedException)
        {
            _toast.ShowError("Cannot undo: deleted items cannot be restored from history");
        }
        catch (Exception ex)
        {
            _toast.ShowError($"Undo failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Performs a redo operation.
    /// </summary>
    public void Redo()
    {
        if (!CanRedo)
        {
            _toast.ShowWarning("Nothing to redo");
            return;
        }

        var nextRedo = _vfs.ChangeHistory.RedoStack.FirstOrDefault();
        if (nextRedo == null) return;

        try
        {
            _vfs.ChangeHistory.Redo();

            var entry = HistoryEntry.FromEventArgs(nextRedo);
            var affectedPath = entry.AffectedPath;

            // Track the affected path for highlighting
            TrackAffectedPath(affectedPath);

            _toast.ShowInfo($"Redone: {entry.Description}");
            _stateService.NotifyDataChanged();
            NotifyHistoryChanged();
        }
        catch (Exception ex)
        {
            _toast.ShowError($"Redo failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets the history as a list of HistoryEntry items.
    /// </summary>
    public IEnumerable<HistoryEntry> GetHistory()
    {
        return _vfs.ChangeHistory.UndoStack
            .Select(HistoryEntry.FromEventArgs)
            .ToList();
    }

    /// <summary>
    /// Gets the redo stack as a list of HistoryEntry items.
    /// </summary>
    public IEnumerable<HistoryEntry> GetRedoHistory()
    {
        return _vfs.ChangeHistory.RedoStack
            .Select(HistoryEntry.FromEventArgs)
            .ToList();
    }

    /// <summary>
    /// Checks if a path was recently affected by an undo/redo operation.
    /// </summary>
    public bool IsRecentlyAffected(string path)
    {
        lock (_lock)
        {
            return _recentlyAffectedPaths.Contains(path);
        }
    }

    /// <summary>
    /// Clears the recently affected paths list.
    /// </summary>
    public void ClearRecentlyAffected()
    {
        lock (_lock)
        {
            _recentlyAffectedPaths.Clear();
        }
    }

    private void TrackAffectedPath(string path)
    {
        if (string.IsNullOrEmpty(path)) return;

        lock (_lock)
        {
            _recentlyAffectedPaths.Add(path);
        }

        OnPathAffected?.Invoke(path);

        // Clear the affected path after animation duration (2 seconds)
        _ = Task.Run(async () =>
        {
            await Task.Delay(2000);
            lock (_lock)
            {
                _recentlyAffectedPaths.Remove(path);
            }
        });
    }

    private void NotifyHistoryChanged()
    {
        OnHistoryChanged?.Invoke();
    }
}
