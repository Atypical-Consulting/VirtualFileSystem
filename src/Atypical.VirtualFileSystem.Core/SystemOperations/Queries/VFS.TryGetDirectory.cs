namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,out IDirectoryNode?)" />
    public bool TryGetDirectory(
        VFSDirectoryPath? directoryPath,
        [NotNullWhen(true)] out IDirectoryNode? directory)
    {
        try
        {
            if (directoryPath is null)
            {
                directory = null;
                return false;
            }
            
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