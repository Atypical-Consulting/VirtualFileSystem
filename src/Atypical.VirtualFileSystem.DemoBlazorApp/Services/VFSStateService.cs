using Atypical.VirtualFileSystem.Core.Contracts;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

public class VFSStateService
{
    private IVirtualFileSystemNode? _selectedNode;
    private bool _isLoading;
    private string? _lastErrorMessage;
    
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

    public event Action<IVirtualFileSystemNode?>? OnSelectedNodeChanged;
    public event Action? OnDataChanged;
    public event Action? OnStateChanged;
    public event Action<string?>? OnErrorChanged;

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
}