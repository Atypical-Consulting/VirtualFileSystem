#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.GetFileResult\(this IVirtualFileSystem, string\) Method

Gets a file and returns a Result containing the file or an error\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> GetFileResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.GetFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.GetFileResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
A Result containing the file node or an error message\.