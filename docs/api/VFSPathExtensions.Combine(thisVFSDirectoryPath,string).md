#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.Combine\(this VFSDirectoryPath, string\) Method

Combines a directory path with a relative path\.

```csharp
public static string Combine(this Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath, string relativePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.Combine(thisAtypical.VirtualFileSystem.Core.VFSDirectoryPath,string).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The base directory path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.Combine(thisAtypical.VirtualFileSystem.Core.VFSDirectoryPath,string).relativePath'></a>

`relativePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The relative path to combine\.

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')  
The combined path\.