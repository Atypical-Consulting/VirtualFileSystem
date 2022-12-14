#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.DeleteFile(VFSFilePath) Method

Deletes a file node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

The path of the file node.

Implements [DeleteFile(VFSFilePath)](IVirtualFileSystem.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.