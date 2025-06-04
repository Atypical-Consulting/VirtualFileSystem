#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVFSMove](IVFSMove.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove')

## IVFSMove\.MoveFile\(VFSFilePath, VFSFilePath\) Method

Moves a file node from the source path to the destination path\.
Both paths must be absolute\.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath sourceFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath destinationFilePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSMove.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.VFSFilePath).sourceFilePath'></a>

`sourceFilePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The source path of the file node\.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSMove.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.VFSFilePath).destinationFilePath'></a>

`destinationFilePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The destination path of the file node\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The file system\.