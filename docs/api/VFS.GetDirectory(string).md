#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.GetDirectory(string) Method

Gets a file node by its path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode GetDirectory(string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.GetDirectory(string).directoryPath'></a>

`directoryPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the file node.

Implements [GetDirectory(string)](IVirtualFileSystem.GetDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(string)')

#### Returns
[IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')  
The file node.