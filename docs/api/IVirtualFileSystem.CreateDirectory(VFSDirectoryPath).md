#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.CreateDirectory(VFSDirectoryPath) Method

Creates a directory node at the specified path.  
The path must be absolute.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')

The path of the directory node.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.