namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
    : IVirtualFileSystem
{
    /// <inheritdoc cref="IVirtualFileSystem.CreateDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem CreateDirectory(VFSDirectoryPath directoryPath)
    {
        if (directoryPath.IsRoot)
            ThrowCannotCreateRootDirectory();

        if (directoryPath.Parent == null)
            ThrowCannotCreateDirectoryWithoutParent();
        
        var directory = new DirectoryNode(directoryPath);
        this.AddToIndex(directory);

        this.TryGetDirectory(directoryPath.Parent, out var parent);
        parent?.AddChild(directory);

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.CreateDirectory(string)" />
    public IVirtualFileSystem CreateDirectory(string directoryPath)
        => CreateDirectory(new VFSDirectoryPath(directoryPath));

    /// <inheritdoc cref="IVirtualFileSystem.DeleteDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem DeleteDirectory(VFSDirectoryPath directoryPath)
    {
        if (directoryPath.IsRoot)
            ThrowCannotDeleteRootDirectory();

        // try to get the directory
        var found = this.TryGetDirectory(directoryPath, out _);
        if (!found)
            ThrowVirtualDirectoryNotFound(directoryPath);

        // find the path and its children in the index
        var paths = this.Index.Keys
            .Where(p => p.StartsWith(directoryPath.Value))
            .OrderByDescending(p => p.Length)
            .ToList();

        // remove the paths from the index
        foreach (var p in paths)
            this.Index.Remove(p);

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.DeleteDirectory(string)" />
    public IVirtualFileSystem DeleteDirectory(string directoryPath)
        => DeleteDirectory(new VFSDirectoryPath(directoryPath));

    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(VFSFilePath,string?)" />
    public IVirtualFileSystem CreateFile(VFSFilePath filePath, string? content = null)
    {
        if (filePath.Parent == null)
            ThrowCannotCreateDirectoryWithoutParent();
        
        var file = new FileNode(filePath, content);
        this.AddToIndex(file);

        this.TryGetDirectory(filePath.Parent, out var parent);
        parent?.AddChild(file);

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(string,string?)" />
    public IVirtualFileSystem CreateFile(string filePath, string? content = null)
        => CreateFile(new VFSFilePath(filePath), content);

    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(VFSFilePath)" />
    public IVirtualFileSystem DeleteFile(VFSFilePath filePath)
    {
        // try to get the file
        var found = this.TryGetFile(filePath, out _);
        if (!found)
            ThrowVirtualFileNotFound(filePath);

        // remove the file from the index
        this.Index.Remove(filePath.Value);

        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(string)" />
    public IVirtualFileSystem DeleteFile(string filePath)
        => DeleteFile(new VFSFilePath(filePath));

    [DoesNotReturn]
    private static void ThrowVirtualFileNotFound(VFSFilePath filePath)
    {
        var message = $"The file '{filePath}' does not exist in the index.";
        throw new VFSException(message);
    }
    
    [DoesNotReturn]
    private static void ThrowVirtualDirectoryNotFound(VFSDirectoryPath directoryPath)
    {
        var message = $"The directory '{directoryPath}' does not exist in the index.";
        throw new VFSException(message);
    }

    [DoesNotReturn]
    private static void ThrowCannotDeleteRootDirectory()
    {
        const string message = "Cannot delete the root directory.";
        throw new VFSException(message);
    }
    
    [DoesNotReturn]
    private static void ThrowCannotCreateRootDirectory()
    {
        const string message = "Cannot create the root directory.";
        throw new VFSException(message);
    }

    [DoesNotReturn]
    private static void ThrowCannotCreateDirectoryWithoutParent()
    {
        const string message = "Cannot create a directory without a parent.";
        throw new VFSException(message);
    }
}