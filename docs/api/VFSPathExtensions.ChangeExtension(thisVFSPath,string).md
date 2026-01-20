#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.ChangeExtension\(this VFSPath, string\) Method

Changes the extension of a VFS path\.

```csharp
public static string ChangeExtension(this Atypical.VirtualFileSystem.Core.VFSPath path, string newExtension);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.ChangeExtension(thisAtypical.VirtualFileSystem.Core.VFSPath,string).path'></a>

`path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The VFS path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.ChangeExtension(thisAtypical.VirtualFileSystem.Core.VFSPath,string).newExtension'></a>

`newExtension` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new extension \(with or without leading dot\)\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A new path with the changed extension\.