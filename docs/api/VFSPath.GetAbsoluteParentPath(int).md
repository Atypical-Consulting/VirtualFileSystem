#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

## VFSPath\.GetAbsoluteParentPath\(int\) Method

Gets the absolute path of the parent directory with depth [depthFromRoot](VFSPath.GetAbsoluteParentPath(int).md#Atypical.VirtualFileSystem.Core.VFSPath.GetAbsoluteParentPath(int).depthFromRoot 'Atypical\.VirtualFileSystem\.Core\.VFSPath\.GetAbsoluteParentPath\(int\)\.depthFromRoot')\.
The root directory has a depth of 0\.
The depth of a file is the depth of its parent directory plus one\.
The depth of a directory is the depth of its parent directory plus one\.

```csharp
public Atypical.VirtualFileSystem.Core.VFSDirectoryPath GetAbsoluteParentPath(int depthFromRoot);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSPath.GetAbsoluteParentPath(int).depthFromRoot'></a>

`depthFromRoot` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The depth of the parent directory from the root directory\.

#### Returns
[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')  
The absolute path of the parent directory with depth [depthFromRoot](VFSPath.GetAbsoluteParentPath(int).md#Atypical.VirtualFileSystem.Core.VFSPath.GetAbsoluteParentPath(int).depthFromRoot 'Atypical\.VirtualFileSystem\.Core\.VFSPath\.GetAbsoluteParentPath\(int\)\.depthFromRoot')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System\.ArgumentOutOfRangeException')  
Thrown when the depth is negative\.