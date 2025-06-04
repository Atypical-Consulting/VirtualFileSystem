#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.RenameFileResult\(this IVirtualFileSystem, string, string\) Method

Renames a file and returns a Result indicating success or failure\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result RenameFileResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.RenameFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.RenameFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.RenameFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).newName'></a>

`newName` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The new file name\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
A Result indicating success or containing an error message\.