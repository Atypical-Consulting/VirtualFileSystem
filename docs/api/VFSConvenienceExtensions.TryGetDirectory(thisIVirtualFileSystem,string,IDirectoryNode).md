#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSConvenienceExtensions](VFSConvenienceExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSConvenienceExtensions')

## VFSConvenienceExtensions\.TryGetDirectory\(this IVirtualFileSystem, string, IDirectoryNode\) Method

Tries to get a directory by its path using a string path\.

```csharp
public static bool TryGetDirectory(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath, out Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode? directory);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.TryGetDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.TryGetDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directoryPath'></a>

`directoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The directory path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSConvenienceExtensions.TryGetDirectory(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory'></a>

`directory` [IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')

The directory node if found\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the directory exists, false otherwise\.