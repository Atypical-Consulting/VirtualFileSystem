#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts')

## IVFSMove Interface

Represents the move operations of the virtual file system\.

```csharp
public interface IVFSMove
```

Derived  
&#8627; [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
&#8627; [VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

| Methods | |
| :--- | :--- |
| [MoveDirectory\(VFSDirectoryPath, VFSDirectoryPath\)](IVFSMove.MoveDirectory(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove\.MoveDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Moves a directory from one location to another\. |
| [MoveFile\(VFSFilePath, VFSFilePath\)](IVFSMove.MoveFile(VFSFilePath,VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove\.MoveFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Moves a file node from the source path to the destination path\. Both paths must be absolute\. |

| Events | |
| :--- | :--- |
| [DirectoryMoved](IVFSMove.DirectoryMoved.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove\.DirectoryMoved') | Event triggered when a directory is moved\. |
| [FileMoved](IVFSMove.FileMoved.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove\.FileMoved') | Event triggered when a file is moved\. |
