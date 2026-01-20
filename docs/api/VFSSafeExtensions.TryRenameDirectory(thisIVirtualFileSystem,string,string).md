#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSafeExtensions](VFSSafeExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions')

## VFSSafeExtensions\.TryRenameDirectory\(this IVirtualFileSystem, string, string\) Method

Safely renames a directory without throwing exceptions\.

```csharp
public static bool TryRenameDirectory(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryRenameDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryRenameDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).directoryPath'></a>

`directoryPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryRenameDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).newName'></a>

`newName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new directory name\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the directory was renamed successfully, false otherwise\.