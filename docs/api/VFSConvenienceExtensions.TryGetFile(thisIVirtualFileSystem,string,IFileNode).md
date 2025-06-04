#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSConvenienceExtensions](VFSConvenienceExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSConvenienceExtensions')

## VFSConvenienceExtensions\.TryGetFile\(this IVirtualFileSystem, string, IFileNode\) Method

Tries to get a file by its path using a string path\.

```csharp
public static bool TryGetFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, out Atypical.VirtualFileSystem.Core.Contracts.IFileNode? file);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.TryGetFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.TryGetFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.TryGetFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).file'></a>

`file` [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')

The file node if found\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the file exists, false otherwise\.