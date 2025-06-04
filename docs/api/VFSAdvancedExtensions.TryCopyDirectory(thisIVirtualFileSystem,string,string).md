#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSAdvancedExtensions](VFSAdvancedExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions')

## VFSAdvancedExtensions\.TryCopyDirectory\(this IVirtualFileSystem, string, string\) Method

Safely copies a directory and all its contents recursively\.

```csharp
public static bool TryCopyDirectory(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string sourceDirectoryPath, string destinationDirectoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCopyDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCopyDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).sourceDirectoryPath'></a>

`sourceDirectoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The source directory path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCopyDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).destinationDirectoryPath'></a>

`destinationDirectoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The destination directory path as a string\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the directory was copied successfully, false otherwise\.