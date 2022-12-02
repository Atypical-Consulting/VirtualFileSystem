#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.ValueObjects](Atypical.VirtualFileSystem.Core.ValueObjects.md 'Atypical.VirtualFileSystem.Core.ValueObjects')

## VFSRootPath Class

Represents the root directory of the virtual file system.

```csharp
public class VFSRootPath : Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,
System.IEquatable<Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath') &#129106; [VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath') &#129106; VFSRootPath

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFSRootPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFSRootPath()](Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.VFSRootPath().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.VFSRootPath()') | Represents the root directory of the virtual file system. |

| Methods | |
| :--- | :--- |
| [ToString()](Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.ToString().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.ToString()') | Returns a string that represents the current object.<br/>The string representation of the root directory is the constant [ROOT_PATH](Atypical.VirtualFileSystem.Core.VFSConstants.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFSConstants.ROOT_PATH'). |

| Operators | |
| :--- | :--- |
| [implicit operator string(VFSRootPath)](Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.op_Implicitstring(Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.op_Implicit string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath)') | Implicit conversion to string<br/>This allows you to use a [VFSRootPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath') as a string. |
