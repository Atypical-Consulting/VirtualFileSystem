#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.TryGetDirectory(string, IDirectoryNode) Method

Try to get a directory node by its path.  
The path must be absolute.  
If the directory node does not exist, this method returns `false`  
and [directory](IVirtualFileSystem.TryGetDirectory(string,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`.

```csharp
bool TryGetDirectory(string directoryPath, out Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode? directory);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directoryPath'></a>

`directoryPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the directory node.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory'></a>

`directory` [IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')

The directory node.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the directory node exists; otherwise, `false`.