using Atypical.VirtualFileSystem.Core.Contracts;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

public class VFSStateService
{
    private IVirtualFileSystemNode? _selectedNode;
    
    public IVirtualFileSystemNode? SelectedNode 
    { 
        get => _selectedNode;
        set
        {
            _selectedNode = value;
            OnSelectedNodeChanged?.Invoke(value);
        }
    }

    public event Action<IVirtualFileSystemNode?>? OnSelectedNodeChanged;
    public event Action? OnDataChanged;

    public void NotifyDataChanged()
    {
        OnDataChanged?.Invoke();
    }
}