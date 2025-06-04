#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSafeExtensions](VFSSafeExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions')

## VFSSafeExtensions\.TryDeleteFile\(this IVirtualFileSystem, string\) Method

Safely deletes a file without throwing exceptions\.

```csharp
public static bool TryDeleteFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryDeleteFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryDeleteFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the file was deleted successfully, false otherwise\.