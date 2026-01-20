#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVFSRename](IVFSRename.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSRename')

## IVFSRename\.RenameFile\(VFSFilePath, string\) Method

Renames a file node at the specified path\.
The path must be absolute\.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath,string).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The path of the file node\.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath,string).newName'></a>

`newName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new name of the file node\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The file system\.