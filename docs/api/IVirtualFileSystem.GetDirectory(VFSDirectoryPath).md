#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

## IVirtualFileSystem\.GetDirectory\(VFSDirectoryPath\) Method

Gets a directory node by its path\.
The path must be absolute\.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The path of the directory node\.

#### Returns
[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')  
The directory node\.