#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.WriteFileResult\(this IVirtualFileSystem, string, string\) Method

Writes file content and returns a Result indicating success or failure\.

```csharp
public static Atypical.VirtualFileSystem.Core.Models.Result WriteFileResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, string content);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.WriteFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.WriteFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.WriteFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).content'></a>

`content` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The content to write\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
A Result indicating success or containing an error message\.