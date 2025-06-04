#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.CreateDirectoryRecursivelyResult\(this IVirtualFileSystem, string\) Method

Creates a directory recursively and returns a Result\.

```csharp
public static Atypical.VirtualFileSystem.Core.Models.Result CreateDirectoryRecursivelyResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CreateDirectoryRecursivelyResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CreateDirectoryRecursivelyResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).directoryPath'></a>

`directoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The directory path as a string\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
A Result indicating success or containing an error message\.