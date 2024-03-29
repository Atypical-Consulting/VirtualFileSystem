#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.CreateDirectory(VFSDirectoryPath) Method

Creates a directory node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath')

The path of the directory node.

Implements [CreateDirectory(VFSDirectoryPath)](IVFSCreate.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.