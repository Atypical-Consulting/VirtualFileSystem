#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.TryGetFile(VFSFilePath, IFileNode) Method

Try to get a file node by its path.  
The path must be absolute.

```csharp
public bool TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath filePath, out Atypical.VirtualFileSystem.Core.Contracts.IFileNode? file);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).filePath'></a>

`filePath` [VFSFilePath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

The path of the file node.

<a name='Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).file'></a>

`file` [IFileNode](Atypical.VirtualFileSystem.Core.Contracts.IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')

The file node.

Implements [TryGetFile(VFSFilePath, IFileNode)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the file node exists; otherwise, `false`.