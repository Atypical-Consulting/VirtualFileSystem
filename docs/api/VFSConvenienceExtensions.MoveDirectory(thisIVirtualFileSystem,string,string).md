#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSConvenienceExtensions](VFSConvenienceExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSConvenienceExtensions')

## VFSConvenienceExtensions\.MoveDirectory\(this IVirtualFileSystem, string, string\) Method

Moves a directory from source to destination using string paths\.

```csharp
public static Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem MoveDirectory(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.MoveDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.MoveDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).sourceDirectoryPath'></a>

`sourceDirectoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The source directory path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.MoveDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).destinationDirectoryPath'></a>

`destinationDirectoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The destination directory path as a string\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The virtual file system for method chaining\.