#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.ValueObjects](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.ValueObjects 'Atypical.VirtualFileSystem.Core.ValueObjects')

## VFSDirectoryPath Class

Represents a directory in the virtual file system.  
A directory is a first-class citizen in the virtual file system.  
It can contain files and other directories.

```csharp
public class VFSDirectoryPath : Atypical.VirtualFileSystem.Core.Abstractions.VFSPath,
System.IEquatable<Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath') &#129106; VFSDirectoryPath

Derived  
&#8627; [VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFSDirectoryPath(string)](VFSDirectoryPath.VFSDirectoryPath(string).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.VFSDirectoryPath(string)') | Initializes a new instance of the [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath') class.<br/>The file path is relative to the root of the virtual file system. |

| Methods | |
| :--- | :--- |
| [ToString()](VFSDirectoryPath.ToString().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.ToString()') | Returns a string that represents the current object.<br/>The string representation of the directory path is the path itself. |

| Operators | |
| :--- | :--- |
| [implicit operator string(VFSDirectoryPath)](VFSDirectoryPath.implicitoperatorstring(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.op_Implicit string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Implicit conversion to string<br/>This allows you to use a [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath') as a string. |
