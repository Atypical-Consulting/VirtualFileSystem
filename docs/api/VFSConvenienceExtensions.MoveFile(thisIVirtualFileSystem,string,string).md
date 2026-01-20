#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSConvenienceExtensions](VFSConvenienceExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSConvenienceExtensions')

## VFSConvenienceExtensions\.MoveFile\(this IVirtualFileSystem, string, string\) Method

Moves a file from source to destination using string paths\.

```csharp
public static Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem MoveFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.MoveFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.MoveFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).sourceFilePath'></a>

`sourceFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The source file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.MoveFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).destinationFilePath'></a>

`destinationFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The destination file path as a string\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The virtual file system for method chaining\.