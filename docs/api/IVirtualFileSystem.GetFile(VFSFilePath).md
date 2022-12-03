#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.GetFile(VFSFilePath) Method

Gets a file node by its path.  
The path must be absolute.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IFileNode GetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

The path of the file node.

#### Returns
[IFileNode](IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')  
The file node.