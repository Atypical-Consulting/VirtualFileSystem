#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.CopyFileResult\(this IVirtualFileSystem, string, string\) Method

Copies a file and returns a Result indicating success or failure\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result CopyFileResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CopyFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CopyFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).sourceFilePath'></a>

`sourceFilePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The source file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CopyFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).destinationFilePath'></a>

`destinationFilePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The destination file path as a string\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
A Result indicating success or containing an error message\.