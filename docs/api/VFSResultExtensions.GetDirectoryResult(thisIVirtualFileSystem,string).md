#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.GetDirectoryResult\(this IVirtualFileSystem, string\) Method

Gets a directory and returns a Result containing the directory or an error\.

```csharp
public static Atypical.VirtualFileSystem.Core.Models.Result<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> GetDirectoryResult(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.GetDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.GetDirectoryResult(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).directoryPath'></a>

`directoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The directory path as a string\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Models\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')  
A Result containing the directory node or an error message\.