#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IVFSDelete Interface

Represents the deletion operations of the virtual file system.

```csharp
public interface IVFSDelete
```

Derived  
&#8627; [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
&#8627; [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

| Methods | |
| :--- | :--- |
| [DeleteDirectory(VFSDirectoryPath)](IVFSDelete.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.DeleteDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(VFSFilePath)](IVFSDelete.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.DeleteFile(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Deletes a file node at the specified path.<br/>The path must be absolute. |

| Events | |
| :--- | :--- |
| [DirectoryDeleted](IVFSDelete.DirectoryDeleted.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.DirectoryDeleted') | Event triggered when a directory is deleted. |
| [FileDeleted](IVFSDelete.FileDeleted.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.FileDeleted') | Event triggered when a file is deleted. |
