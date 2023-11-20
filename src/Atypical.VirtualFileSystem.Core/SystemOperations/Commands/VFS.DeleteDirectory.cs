namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.DeleteDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem DeleteDirectory(VFSDirectoryPath directoryPath)
    {
        // cannot delete the root directory
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
}