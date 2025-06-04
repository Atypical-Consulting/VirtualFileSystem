#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSConvenienceExtensions](VFSConvenienceExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSConvenienceExtensions')

## VFSConvenienceExtensions\.GetFile\(this IVirtualFileSystem, string\) Method

Gets a file by its path using a string path\.

```csharp
public static Atypical.VirtualFileSystem.Core.Contracts.IFileNode GetFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.GetFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.GetFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

#### Returns
[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')  
The file node\.