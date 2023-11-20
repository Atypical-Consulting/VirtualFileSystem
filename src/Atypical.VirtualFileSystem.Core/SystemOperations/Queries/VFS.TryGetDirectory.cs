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
}