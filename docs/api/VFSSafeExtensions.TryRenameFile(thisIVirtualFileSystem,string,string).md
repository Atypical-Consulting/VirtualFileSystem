#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSafeExtensions](VFSSafeExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions')

## VFSSafeExtensions\.TryRenameFile\(this IVirtualFileSystem, string, string\) Method

Safely renames a file without throwing exceptions\.

```csharp
public static bool TryRenameFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryRenameFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryRenameFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryRenameFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).newName'></a>

`newName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new file name\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the file was renamed successfully, false otherwise\.