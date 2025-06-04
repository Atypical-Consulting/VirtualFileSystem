#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.GetDirectory\(VFSDirectoryPath\) Method

Gets a directory node by its path\.
The path must be absolute\.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The path of the directory node\.

Implements [GetDirectory\(VFSDirectoryPath\)](IVirtualFileSystem.GetDirectory(VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.GetDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)')

#### Returns
[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')  
The directory node\.