#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.ValueObjects](Atypical.VirtualFileSystem.Core.ValueObjects.md 'Atypical.VirtualFileSystem.Core.ValueObjects')

## VFSFilePath Class

Represents a file system entry in the virtual file system.  
A file is a first-class citizen in the virtual file system.

```csharp
public class VFSFilePath : Atypical.VirtualFileSystem.Core.Abstractions.VFSPath,
System.IEquatable<Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath') &#129106; VFSFilePath

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFSFilePath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFSFilePath(string)](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.VFSFilePath(string).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.VFSFilePath(string)') | Initializes a new instance of the [VFSFilePath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath') class.<br/>The file path is relative to the root of the virtual file system. |

| Methods | |
| :--- | :--- |
| [ToString()](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.ToString().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.ToString()') | Returns a string that represents the current object.<br/>The file path is relative to the root of the virtual file system. |

| Operators | |
| :--- | :--- |
| [implicit operator string(VFSFilePath)](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.op_Implicitstring(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.op_Implicit string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)') | Implicit conversion to string<br/>This allows you to use a [VFSFilePath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath') as a string. |
