#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Abstractions](Atypical.VirtualFileSystem.Core.Abstractions.md 'Atypical.VirtualFileSystem.Core.Abstractions').[VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')

## VFSPath.GetAbsoluteParentPath(int) Method

Gets the absolute path of the parent directory with depth [depthFromRoot](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).md#Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).depthFromRoot 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).depthFromRoot').  
The root directory has a depth of 0.  
The depth of a file is the depth of its parent directory plus one.  
The depth of a directory is the depth of its parent directory plus one.

```csharp
public Atypical.VirtualFileSystem.Core.Abstractions.VFSPath GetAbsoluteParentPath(int depthFromRoot);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).depthFromRoot'></a>

`depthFromRoot` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The depth of the parent directory from the root directory.

#### Returns
[VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')  
The absolute path of the parent directory with depth [depthFromRoot](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).md#Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).depthFromRoot 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).depthFromRoot').

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the depth is negative.