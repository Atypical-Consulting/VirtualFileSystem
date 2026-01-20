#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.GetRelativePath\(this VFSDirectoryPath, VFSPath\) Method

Gets the relative path from one directory to another\.

```csharp
public static string GetRelativePath(this Atypical.VirtualFileSystem.Core.VFSDirectoryPath from, Atypical.VirtualFileSystem.Core.VFSPath to);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.GetRelativePath(thisAtypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.VFSPath).from'></a>

`from` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The source directory path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.GetRelativePath(thisAtypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.VFSPath).to'></a>

`to` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The target path\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The relative path from source to target\.