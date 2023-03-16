#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Abstractions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Abstractions 'Atypical.VirtualFileSystem.Core.Abstractions')

## VFSPath Class

Represents a file system entry (file or directory) in the virtual file system.

```csharp
public abstract class VFSPath :
System.IEquatable<Atypical.VirtualFileSystem.Core.Abstractions.VFSPath>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VFSPath

Derived  
&#8627; [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')  
&#8627; [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFSPath(string)](VFSPath.VFSPath(string).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.VFSPath(string)') | Creates a new instance of [VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath'). |

| Properties | |
| :--- | :--- |
| [Depth](VFSPath.Depth.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Depth') | Gets the depth of the file system entry.<br/>The root directory has a depth of 0.<br/>The depth of a file is the depth of its parent directory plus one.<br/>The depth of a directory is the depth of its parent directory plus one. |
| [HasParent](VFSPath.HasParent.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.HasParent') | Indicates whether the path has a parent directory. |
| [IsRoot](VFSPath.IsRoot.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.IsRoot') | Gets a value indicating whether the directory is the root directory. |
| [Name](VFSPath.Name.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Name') | Gets the name of the file system entry.<br/>The name of the root directory is [ROOT_PATH](VFSConstants.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFSConstants.ROOT_PATH').<br/>The name of a file is the name of the file with its extension. |
| [Parent](VFSPath.Parent.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Parent') | Gets the path of the parent directory. |
| [Value](VFSPath.Value.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Value') | Gets the path of the file system entry with the VFS prefix. |

| Methods | |
| :--- | :--- |
| [Equals(VFSPath)](VFSPath.Equals(VFSPath).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Equals(Atypical.VirtualFileSystem.Core.Abstractions.VFSPath)') | Indicates whether the current object is equal to another object of the same type. |
| [GetAbsoluteParentPath(int)](VFSPath.GetAbsoluteParentPath(int).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int)') | Gets the absolute path of the parent directory with depth [depthFromRoot](VFSPath.GetAbsoluteParentPath(int).md#Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).depthFromRoot 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int).depthFromRoot').<br/>The root directory has a depth of 0.<br/>The depth of a file is the depth of its parent directory plus one.<br/>The depth of a directory is the depth of its parent directory plus one. |
| [GetHashCode()](VFSPath.GetHashCode().md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetHashCode()') | Serves as the default hash function. |
