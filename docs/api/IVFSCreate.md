#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IVFSCreate Interface

Represents the creation operations of the virtual file system.

```csharp
public interface IVFSCreate
```

Derived  
&#8627; [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
&#8627; [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

| Methods | |
| :--- | :--- |
| [CreateDirectory(VFSDirectoryPath)](IVFSCreate.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateFile(VFSFilePath, string)](IVFSCreate.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |

| Events | |
| :--- | :--- |
| [DirectoryCreated](IVFSCreate.DirectoryCreated.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.DirectoryCreated') | Event triggered when a directory is created. |
| [FileCreated](IVFSCreate.FileCreated.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.FileCreated') | Event triggered when a file is created. |
