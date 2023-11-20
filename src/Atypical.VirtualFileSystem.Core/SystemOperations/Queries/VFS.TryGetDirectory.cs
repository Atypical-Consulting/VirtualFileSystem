namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,out IDirectoryNode?)" />
    public bool TryGetDirectory(VFSDirectoryPath directoryPath, out IDirectoryNode? directory)
    {
        try
        {
            directory = GetDirectory(directoryPath);
            return true;
        }
        catch (KeyNotFoundException)
        {
            directory = null;
            return false;
        }
    }

    /// <inheritdoc cref="IVirtualFileSystem.TryGetDirectory(string,out IDirectoryNode?)" />
    public bool TryGetDirectory(string path, out IDirectoryNode? directory)
        => TryGetDirectory(new VFSDirectoryPath(path), out directory);
}