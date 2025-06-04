#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.IsAtDepth\(this VFSPath, int\) Method

Checks if the path is at a specific depth\.

```csharp
public static bool IsAtDepth(this Atypical.VirtualFileSystem.Core.VFSPath path, int depth);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.IsAtDepth(thisAtypical.VirtualFileSystem.Core.VFSPath,int).path'></a>

`path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The VFS path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.IsAtDepth(thisAtypical.VirtualFileSystem.Core.VFSPath,int).depth'></a>

`depth` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The depth to check\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the path is at the specified depth\.