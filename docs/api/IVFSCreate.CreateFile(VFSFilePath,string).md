#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVFSCreate](IVFSCreate.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSCreate')

## IVFSCreate\.CreateFile\(VFSFilePath, string\) Method

Creates a file node at the specified path\.
The path must be absolute\.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath,string).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The path of the file node\.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath,string).content'></a>

`content` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The content of the file node\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The file system\.