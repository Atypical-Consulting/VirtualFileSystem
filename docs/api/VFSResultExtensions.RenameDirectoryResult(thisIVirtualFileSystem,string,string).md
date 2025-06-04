#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.RenameDirectoryResult\(this IVirtualFileSystem, string, string\) Method

Renames a directory and returns a Result indicating success or failure\.

```csharp
public static Atypical.VirtualFileSystem.Core.Models.Result RenameDirectoryResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.RenameDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.RenameDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).directoryPath'></a>

`directoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The directory path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.RenameDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).newName'></a>

`newName` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The new directory name\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
A Result indicating success or containing an error message\.