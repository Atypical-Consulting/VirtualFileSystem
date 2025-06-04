#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.IsDirectChildOf\(this VFSPath, VFSPath\) Method

Checks if a path is a child \(direct descendant\) of another path\.

```csharp
public static bool IsDirectChildOf(this Atypical.VirtualFileSystem.Core.VFSPath parentPath, Atypical.VirtualFileSystem.Core.VFSPath childPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.IsDirectChildOf(thisAtypical.VirtualFileSystem.Core.VFSPath,Atypical.VirtualFileSystem.Core.VFSPath).parentPath'></a>

`parentPath` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The potential parent path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.IsDirectChildOf(thisAtypical.VirtualFileSystem.Core.VFSPath,Atypical.VirtualFileSystem.Core.VFSPath).childPath'></a>

`childPath` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The potential child path\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if childPath is a direct child of parentPath\.