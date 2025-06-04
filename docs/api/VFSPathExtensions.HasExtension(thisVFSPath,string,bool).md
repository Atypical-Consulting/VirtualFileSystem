#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.HasExtension\(this VFSPath, string, bool\) Method

Checks if the path has a specific extension\.

```csharp
public static bool HasExtension(this Atypical.VirtualFileSystem.Core.VFSPath path, string extension, bool ignoreCase=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.HasExtension(thisAtypical.VirtualFileSystem.Core.VFSPath,string,bool).path'></a>

`path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The VFS path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.HasExtension(thisAtypical.VirtualFileSystem.Core.VFSPath,string,bool).extension'></a>

`extension` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The extension to check \(with or without leading dot\)\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.HasExtension(thisAtypical.VirtualFileSystem.Core.VFSPath,string,bool).ignoreCase'></a>

`ignoreCase` [System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')

Whether to ignore case\. Default is true\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the path has the specified extension\.