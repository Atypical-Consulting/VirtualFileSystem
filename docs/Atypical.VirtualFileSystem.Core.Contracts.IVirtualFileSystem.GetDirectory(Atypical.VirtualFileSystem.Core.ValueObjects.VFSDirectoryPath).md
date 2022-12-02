#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.GetDirectory(VFSDirectoryPath) Method

Gets a directory node by its path.  
The path must be absolute.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')

The path of the directory node.

#### Returns
[IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')  
The directory node.