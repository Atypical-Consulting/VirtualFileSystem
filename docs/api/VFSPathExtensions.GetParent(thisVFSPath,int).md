#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.GetParent\(this VFSPath, int\) Method

Gets the parent directory at the specified level up\.

```csharp
public static Atypical.VirtualFileSystem.Core.VFSDirectoryPath GetParent(this Atypical.VirtualFileSystem.Core.VFSPath path, int levels=1);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.GetParent(thisAtypical.VirtualFileSystem.Core.VFSPath,int).path'></a>

`path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The VFS path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.GetParent(thisAtypical.VirtualFileSystem.Core.VFSPath,int).levels'></a>

`levels` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of levels to go up\. Default is 1\.

#### Returns
[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')  
The parent directory at the specified level\.

#### Exceptions

[System\.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System\.InvalidOperationException')  
Thrown when there's no parent at the specified level\.