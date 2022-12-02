#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.TryGetDirectory(string, IDirectoryNode) Method

Try to get a directory node by its path.  
The path must be absolute.  
If the directory node does not exist, this method returns `false`  
and [directory](Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).md#Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`.

```csharp
public bool TryGetDirectory(string path, out Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode? directory);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory'></a>

`directory` [IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')

The directory node.

Implements [TryGetDirectory(string, IDirectoryNode)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the directory node exists; otherwise, `false`.