#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.CreateDirectory(VFSDirectoryPath) Method

Creates a directory node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')

The path of the directory node.

Implements [CreateDirectory(VFSDirectoryPath)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')

#### Returns
[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.