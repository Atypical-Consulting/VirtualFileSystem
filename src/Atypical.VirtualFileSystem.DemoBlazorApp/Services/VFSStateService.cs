using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.DemoBlazorApp.Models;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

public class VFSStateService
{
    private IVirtualFileSystemNode? _selectedNode;
    private bool _isLoading;
    private string? _lastErrorMessage;
    private string _currentPath = "vfs://";
    private ViewMode _viewMode = ViewMode.Grid;
    private SortOption _sortBy = SortOption.Name;
    private bool _sortAscending = true;
    private bool _showPreviewPanel = true;

    // Selected node
    public IVirtualFileSystemNode? SelectedNode
    {
        get => _selectedNode;
        set
        {
            if (_selectedNode != value)
            {
                _selectedNode = value;
                OnSelectedNodeChanged?.Invoke(value);
                NotifyStateChanged();
            }
        }
    }

    // Loading state
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                NotifyStateChanged();
            }
        }
    }

    // Error handling
    public string? LastErrorMessage
    {
        get => _lastErrorMessage;
        set
        {
            if (_lastErrorMessage != value)
            {
                _lastErrorMessage = value;
                OnErrorChanged?.Invoke(value);
                NotifyStateChanged();
            }
        }
    }

    // Current directory path (for navigation)
    public string CurrentPath
    {
        get => _currentPath;
        set
        {
            if (_currentPath != value)
            {
                _currentPath = value;
                OnCurrentPathChanged?.Invoke();
                NotifyStateChanged();
            }
        }
    }

    // View preferences
    public ViewMode ViewMode
    {
        get => _viewMode;
        set
        {
            if (_viewMode != value)
            {
                _viewMode = value;
                OnViewModeChanged?.Invoke();
                NotifyStateChanged();
            }
        }
    }

    public SortOption SortBy
    {
        get => _sortBy;
        set
        {
            if (_sortBy != value)
            {
                _sortBy = value;
                OnSortChanged?.Invoke();
                NotifyStateChanged();
            }
        }
    }

    public bool SortAscending
    {
        get => _sortAscending;
        set
        {
            if (_sortAscending != value)
            {
                _sortAscending = value;
                OnSortChanged?.Invoke();
                NotifyStateChanged();
            }
        }
    }

    public bool ShowPreviewPanel
    {
        get => _showPreviewPanel;
        set
        {
            if (_showPreviewPanel != value)
            {
                _showPreviewPanel = value;
                NotifyStateChanged();
            }
        }
    }

    // Multi-select
    private readonly HashSet<string> _selectedItems = [];
    public IReadOnlySet<string> SelectedItems => _selectedItems;

    public void SelectItem(string path, bool addToSelection = false)
    {
        if (!addToSelection)
        {
            _selectedItems.Clear();
        }
        _selectedItems.Add(path);
        OnSelectionChanged?.Invoke();
        NotifyStateChanged();
    }

    public void DeselectItem(string path)
    {
        _selectedItems.Remove(path);
        OnSelectionChanged?.Invoke();
        NotifyStateChanged();
    }

    public void ToggleItemSelection(string path)
    {
        if (_selectedItems.Contains(path))
            _selectedItems.Remove(path);
        else
            _selectedItems.Add(path);
        OnSelectionChanged?.Invoke();
        NotifyStateChanged();
    }

    public void ClearSelection()
    {
        _selectedItems.Clear();
        OnSelectionChanged?.Invoke();
        NotifyStateChanged();
    }

    public bool IsItemSelected(string path) => _selectedItems.Contains(path);

    // Starred/favorite items
    private readonly HashSet<string> _starredPaths = [];
    public IReadOnlySet<string> StarredPaths => _starredPaths;

    public void ToggleStar(string path)
    {
        if (_starredPaths.Contains(path))
            _starredPaths.Remove(path);
        else
            _starredPaths.Add(path);
        OnItemStarred?.Invoke(path);
        NotifyStateChanged();
    }

    public bool IsStarred(string path) => _starredPaths.Contains(path);

    // Events
    public event Action<IVirtualFileSystemNode?>? OnSelectedNodeChanged;
    public event Action? OnDataChanged;
    public event Action? OnStateChanged;
    public event Action<string?>? OnErrorChanged;
    public event Action? OnCurrentPathChanged;
    public event Action? OnViewModeChanged;
    public event Action? OnSortChanged;
    public event Action? OnSelectionChanged;
    public event Action<string>? OnItemStarred;

    public void NotifyDataChanged()
    {
        OnDataChanged?.Invoke();
        NotifyStateChanged();
    }

    public void NotifyStateChanged()
    {
        OnStateChanged?.Invoke();
    }

    public void ClearError()
    {
        LastErrorMessage = null;
    }

    public void SetError(string errorMessage)
    {
        LastErrorMessage = errorMessage;
    }

    // Navigation helper
    public void NavigateTo(string path)
    {
        CurrentPath = path;
        ClearSelection();
    }

    public void NavigateUp()
    {
        if (CurrentPath == "vfs://" || CurrentPath == "vfs:/")
            return;

        var parentPath = System.IO.Path.GetDirectoryName(CurrentPath.TrimEnd('/'))?.Replace('\\', '/');
        if (string.IsNullOrEmpty(parentPath))
            parentPath = "vfs://";
        else if (!parentPath.StartsWith("vfs://"))
            parentPath = "vfs:/" + parentPath.TrimStart('/');

        CurrentPath = parentPath;
        ClearSelection();
    }
}
