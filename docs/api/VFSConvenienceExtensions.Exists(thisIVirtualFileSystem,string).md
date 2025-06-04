#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSConvenienceExtensions](VFSConvenienceExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSConvenienceExtensions')

## VFSConvenienceExtensions\.Exists\(this IVirtualFileSystem, string\) Method

Checks if a file or directory exists at the specified path\.

```csharp
public static bool Exists(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.Exists(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.Exists(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).path'></a>

`path` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The path to check as a string\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the path exists, false otherwise\.