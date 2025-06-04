#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.CopyDirectoryResult\(this IVirtualFileSystem, string, string\) Method

Copies a directory and returns a Result indicating success or failure\.

```csharp
public static Atypical.VirtualFileSystem.Core.Models.Result CopyDirectoryResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CopyDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CopyDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).sourceDirectoryPath'></a>

`sourceDirectoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The source directory path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CopyDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).destinationDirectoryPath'></a>

`destinationDirectoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The destination directory path as a string\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
A Result indicating success or containing an error message\.