namespace Atypical.VirtualFileSystem.Core;

public partial record VFS
{
    /// <inheritdoc cref="IVirtualFileSystem.TryGetFile(VFSFilePath,out IFileNode?)" />
    public bool TryGetFile(VFSFilePath filePath, out IFileNode? file)
    {
        try
        {
            file = GetFile(filePath);
            return true;
        }
        catch (KeyNotFoundException)
        {
            file = null;
            return false;
        }
    }
}