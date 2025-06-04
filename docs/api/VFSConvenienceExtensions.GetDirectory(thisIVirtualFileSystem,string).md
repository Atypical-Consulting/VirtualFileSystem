#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSConvenienceExtensions](VFSConvenienceExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSConvenienceExtensions')

## VFSConvenienceExtensions\.GetDirectory\(this IVirtualFileSystem, string\) Method

Gets a directory by its path using a string path\.

```csharp
public static Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode GetDirectory(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.GetDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.GetDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).directoryPath'></a>

`directoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The directory path as a string\.

#### Returns
[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')  
The directory node\.