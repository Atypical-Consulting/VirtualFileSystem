#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVFSRename](IVFSRename.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSRename')

## IVFSRename\.RenameDirectory\(VFSDirectoryPath, string\) Method

Renames a directory node at the specified path\.
The path must be absolute\.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath, string newDir);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,string).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The path of the directory node\.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,string).newDir'></a>

`newDir` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new name of the directory node\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The file system\.