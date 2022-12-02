#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.GetFile(string) Method

Gets a file node by its path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IFileNode GetFile(string filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.GetFile(string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the file node.

Implements [GetFile(string)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(string)')

#### Returns
[IFileNode](Atypical.VirtualFileSystem.Core.Contracts.IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')  
The file node.