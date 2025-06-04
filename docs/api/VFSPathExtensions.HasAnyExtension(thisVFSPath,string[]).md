#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.HasAnyExtension\(this VFSPath, string\[\]\) Method

Checks if the path has any of the specified extensions\.

```csharp
public static bool HasAnyExtension(this Atypical.VirtualFileSystem.Core.VFSPath path, params string[] extensions);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.HasAnyExtension(thisAtypical.VirtualFileSystem.Core.VFSPath,string[]).path'></a>

`path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The VFS path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.HasAnyExtension(thisAtypical.VirtualFileSystem.Core.VFSPath,string[]).extensions'></a>

`extensions` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The extensions to check \(with or without leading dots\)\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the path has any of the specified extensions\.