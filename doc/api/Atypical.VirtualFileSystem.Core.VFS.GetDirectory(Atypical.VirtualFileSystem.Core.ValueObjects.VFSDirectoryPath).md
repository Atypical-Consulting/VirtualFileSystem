#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.GetDirectory(VFSDirectoryPath) Method

Gets a directory node by its path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')

The path of the directory node.

Implements [GetDirectory(VFSDirectoryPath)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')

#### Returns
[IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')  
The directory node.