#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.RenameFile(VFSFilePath, string) Method

Renames a file node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath,string).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath')

The path of the file node.

<a name='Atypical.VirtualFileSystem.Core.VFS.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath,string).newName'></a>

`newName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The new name of the file node.

Implements [RenameFile(VFSFilePath, string)](IVFSRename.RenameFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.