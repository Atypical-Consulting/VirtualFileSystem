#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.MoveFile\(VFSFilePath, VFSFilePath\) Method

Moves a file node from the source path to the destination path\.
Both paths must be absolute\.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath sourceFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath destinationFilePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.VFSFilePath).sourceFilePath'></a>

`sourceFilePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The source path of the file node\.

<a name='Atypical.VirtualFileSystem.Core.VFS.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.VFSFilePath).destinationFilePath'></a>

`destinationFilePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The destination path of the file node\.

Implements [MoveFile\(VFSFilePath, VFSFilePath\)](IVFSMove.MoveFile(VFSFilePath,VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove\.MoveFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The file system\.