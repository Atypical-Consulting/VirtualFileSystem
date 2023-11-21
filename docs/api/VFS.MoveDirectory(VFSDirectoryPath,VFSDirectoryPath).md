#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.MoveDirectory(VFSDirectoryPath, VFSDirectoryPath) Method

Moves a directory from one location to another.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem MoveDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath sourceDirectoryPath, Atypical.VirtualFileSystem.Core.VFSDirectoryPath destinationDirectoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.MoveDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.VFSDirectoryPath).sourceDirectoryPath'></a>

`sourceDirectoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath')

The source directory path.

<a name='Atypical.VirtualFileSystem.Core.VFS.MoveDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.VFSDirectoryPath).destinationDirectoryPath'></a>

`destinationDirectoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath')

The destination directory path.

Implements [MoveDirectory(VFSDirectoryPath, VFSDirectoryPath)](IVFSMove.MoveDirectory(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove.MoveDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The virtual file system.