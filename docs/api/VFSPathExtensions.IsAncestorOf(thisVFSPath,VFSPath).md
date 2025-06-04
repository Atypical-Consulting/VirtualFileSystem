#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.IsAncestorOf\(this VFSPath, VFSPath\) Method

Checks if a path is a descendant of another path\.

```csharp
public static bool IsAncestorOf(this Atypical.VirtualFileSystem.Core.VFSPath ancestorPath, Atypical.VirtualFileSystem.Core.VFSPath descendantPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.IsAncestorOf(thisAtypical.VirtualFileSystem.Core.VFSPath,Atypical.VirtualFileSystem.Core.VFSPath).ancestorPath'></a>

`ancestorPath` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The potential ancestor path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.IsAncestorOf(thisAtypical.VirtualFileSystem.Core.VFSPath,Atypical.VirtualFileSystem.Core.VFSPath).descendantPath'></a>

`descendantPath` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The potential descendant path\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if descendantPath is under ancestorPath\.