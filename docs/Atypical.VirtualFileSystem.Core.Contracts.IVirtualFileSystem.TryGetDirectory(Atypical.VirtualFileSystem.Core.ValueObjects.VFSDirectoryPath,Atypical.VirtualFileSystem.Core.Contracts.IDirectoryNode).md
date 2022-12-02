#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath, IDirectoryNode) Method

Try to get a directory node by its path.  
The path must be absolute.  
If the directory node does not exist, this method returns `false`  
and [directory](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`.

```csharp
bool TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath directoryPath, out Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode? directory);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')

The path of the directory node.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory'></a>

`directory` [IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')

The directory node.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the directory node exists; otherwise, `false`.