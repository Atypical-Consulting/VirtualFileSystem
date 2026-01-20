#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSafeExtensions](VFSSafeExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions')

## VFSSafeExtensions\.TryMoveDirectory\(this IVirtualFileSystem, string, string\) Method

Safely moves a directory without throwing exceptions\.

```csharp
public static bool TryMoveDirectory(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryMoveDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryMoveDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).sourceDirectoryPath'></a>

`sourceDirectoryPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The source directory path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSafeExtensions.TryMoveDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).destinationDirectoryPath'></a>

`destinationDirectoryPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The destination directory path as a string\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the directory was moved successfully, false otherwise\.