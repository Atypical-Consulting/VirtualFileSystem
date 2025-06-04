#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSafeExtensions](VFSSafeExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions')

## VFSSafeExtensions\.TryCreateFile\(this IVirtualFileSystem, string, string\) Method

Safely creates a file without throwing exceptions\.

```csharp
public static bool TryCreateFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryCreateFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryCreateFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryCreateFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).content'></a>

`content` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file content\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the file was created successfully, false otherwise\.