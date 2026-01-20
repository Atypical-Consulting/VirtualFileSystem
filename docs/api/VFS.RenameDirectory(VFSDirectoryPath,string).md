#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.RenameDirectory\(VFSDirectoryPath, string\) Method

Renames a directory\.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,string).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The directory path\.

<a name='Atypical.VirtualFileSystem.Core.VFS.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,string).newName'></a>

`newName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new name\.

Implements [RenameDirectory\(VFSDirectoryPath, string\)](IVFSRename.RenameDirectory(VFSDirectoryPath,string).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSRename\.RenameDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, string\)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The virtual file system\.