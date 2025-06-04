#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSafeExtensions](VFSSafeExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions')

## VFSSafeExtensions\.TryDeleteDirectory\(this IVirtualFileSystem, string\) Method

Safely deletes a directory without throwing exceptions\.

```csharp
public static bool TryDeleteDirectory(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryDeleteDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryDeleteDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).directoryPath'></a>

`directoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The directory path as a string\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the directory was deleted successfully, false otherwise\.