#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSAdvancedExtensions](VFSAdvancedExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions')

## VFSAdvancedExtensions\.TryCopyFile\(this IVirtualFileSystem, string, string\) Method

Safely copies a file from source to destination, creating parent directories if needed\.

```csharp
public static bool TryCopyFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string sourceFilePath, string destinationFilePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCopyFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCopyFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).sourceFilePath'></a>

`sourceFilePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The source file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.TryCopyFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,string).destinationFilePath'></a>

`destinationFilePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The destination file path as a string\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the file was copied successfully, false otherwise\.