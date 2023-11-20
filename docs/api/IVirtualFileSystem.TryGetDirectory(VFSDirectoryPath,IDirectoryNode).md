#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath, IDirectoryNode) Method

Try to get a directory node by its path.  
The path must be absolute.  
If the directory node does not exist, this method returns `false`  
and [directory](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`.

```csharp
bool TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath, out Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode? directory);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath')

The path of the directory node.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory'></a>

`directory` [IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')

The directory node.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the directory node exists; otherwise, `false`.