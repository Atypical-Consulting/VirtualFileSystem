#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IVFSRename Interface

Represents the rename operations of the virtual file system.

```csharp
public interface IVFSRename
```

Derived  
&#8627; [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
&#8627; [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

| Methods | |
| :--- | :--- |
| [RenameDirectory(VFSDirectoryPath, string)](IVFSRename.RenameDirectory(VFSDirectoryPath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, string)') | Renames a directory node at the specified path.<br/>The path must be absolute. |
| [RenameFile(VFSFilePath, string)](IVFSRename.RenameFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)') | Renames a file node at the specified path.<br/>The path must be absolute. |

| Events | |
| :--- | :--- |
| [DirectoryRenamed](IVFSRename.DirectoryRenamed.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.DirectoryRenamed') | Event triggered when a directory is renamed. |
| [FileRenamed](IVFSRename.FileRenamed.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.FileRenamed') | Event triggered when a file is renamed. |
