#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.CreateFileResult\(this IVirtualFileSystem, string, string\) Method

Creates a file and returns a Result indicating success or failure\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result CreateFileResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CreateFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CreateFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.CreateFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).content'></a>

`content` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file content\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
A Result indicating success or containing an error message\.