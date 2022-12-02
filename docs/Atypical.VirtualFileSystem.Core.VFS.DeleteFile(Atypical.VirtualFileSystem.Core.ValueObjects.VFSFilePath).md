#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.DeleteFile(VFSFilePath) Method

Deletes a file node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).filePath'></a>

`filePath` [VFSFilePath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

The path of the file node.

Implements [DeleteFile(VFSFilePath)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)')

#### Returns
[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.