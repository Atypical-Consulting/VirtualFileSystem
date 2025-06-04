#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBinaryExtensions](VFSBinaryExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions')

## VFSBinaryExtensions\.GetFileSize\(this IVirtualFileSystem, string\) Method

Gets the size of a file in bytes\.

```csharp
public static long GetFileSize(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.GetFileSize(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.GetFileSize(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

#### Returns
[System\.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System\.Int64')  
The size in bytes, or \-1 if the file doesn't exist\.