#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSAdvancedExtensions](VFSAdvancedExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions')

## VFSAdvancedExtensions\.TryCreateDirectoryRecursively\(this IVirtualFileSystem, string\) Method

Safely creates a directory and automatically creates any missing parent directories\.

```csharp
public static bool TryCreateDirectoryRecursively(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCreateDirectoryRecursively(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCreateDirectoryRecursively(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string).directoryPath'></a>

`directoryPath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The directory path as a string\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the directories were created successfully, false otherwise\.