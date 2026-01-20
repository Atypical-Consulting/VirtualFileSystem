using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.Core.Extensions;
using Atypical.VirtualFileSystem.DemoBlazorApp.Models;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Service for managing soft-deleted items (recycle bin)
/// </summary>
public class RecycleBinService
{
    private readonly List<DeletedItem> _deletedItems = [];

    public IReadOnlyList<DeletedItem> DeletedItems => _deletedItems.AsReadOnly();

    public event Action? OnChange;

    /// <summary>
    /// Move an item to the recycle bin
    /// </summary>
    public void MoveToRecycleBin(IVirtualFileSystem vfs, string path)
    {
        var isDirectory = vfs.DirectoryExists(path);
        var isFile = vfs.FileExists(path);

        if (!isDirectory && !isFile)
            return;

        string? content = null;
        if (isFile)
        {
            if (vfs.TryGetFile(path, out var fileNode))
            {
                content = fileNode?.Content;
            }
        }

        var deletedItem = new DeletedItem
        {
            OriginalPath = path,
            Name = System.IO.Path.GetFileName(path.TrimEnd('/')) ?? path,
            IsDirectory = isDirectory,
            DeletedAt = DateTime.Now,
            Content = content
        };

        _deletedItems.Insert(0, deletedItem);

        // Actually delete from VFS
        if (isDirectory)
        {
            vfs.DeleteDirectory(path);
        }
        else
        {
            vfs.DeleteFile(path);
        }

        OnChange?.Invoke();
    }

    /// <summary>
    /// Restore an item from the recycle bin
    /// </summary>
    public bool Restore(IVirtualFileSystem vfs, Guid itemId)
    {
        var item = _deletedItems.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
            return false;

        try
        {
            if (item.IsDirectory)
            {
                vfs.CreateDirectory(item.OriginalPath);
            }
            else
            {
                // Ensure parent directory exists
                var parentPath = System.IO.Path.GetDirectoryName(item.OriginalPath)?.Replace('\\', '/');
                if (!string.IsNullOrEmpty(parentPath) && parentPath != "vfs:/")
                {
                    if (!vfs.DirectoryExists(parentPath))
                    {
                        vfs.CreateDirectory(parentPath);
                    }
                }

                vfs.CreateFile(item.OriginalPath, item.Content ?? string.Empty);
            }

            _deletedItems.Remove(item);
            OnChange?.Invoke();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Permanently delete an item from the recycle bin
    /// </summary>
    public void PermanentlyDelete(Guid itemId)
    {
        var item = _deletedItems.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            _deletedItems.Remove(item);
            OnChange?.Invoke();
        }
    }

    /// <summary>
    /// Empty the recycle bin
    /// </summary>
    public void EmptyRecycleBin()
    {
        _deletedItems.Clear();
        OnChange?.Invoke();
    }

    /// <summary>
    /// Get the count of items in the recycle bin
    /// </summary>
    public int Count => _deletedItems.Count;
}
