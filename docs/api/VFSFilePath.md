#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFSFilePath Class

Represents a file system entry in the virtual file system.  
A file is a first-class citizen in the virtual file system.

```csharp
public class VFSFilePath : Atypical.VirtualFileSystem.Core.VFSPath,
System.IEquatable<Atypical.VirtualFileSystem.Core.VFSFilePath>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.VFSPath') &#129106; VFSFilePath

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFSFilePath(string)](VFSFilePath.VFSFilePath(string).md 'Atypical.VirtualFileSystem.Core.VFSFilePath.VFSFilePath(string)') | Initializes a new instance of the [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath') class.<br/>The file path is relative to the root of the virtual file system. |

| Methods | |
| :--- | :--- |
| [ToString()](VFSFilePath.ToString().md 'Atypical.VirtualFileSystem.Core.VFSFilePath.ToString()') | Returns a string that represents the current object.<br/>The file path is relative to the root of the virtual file system. |

| Operators | |
| :--- | :--- |
| [implicit operator VFSFilePath(string)](VFSFilePath.implicitoperatorVFSFilePath(string).md 'Atypical.VirtualFileSystem.Core.VFSFilePath.op_Implicit Atypical.VirtualFileSystem.Core.VFSFilePath(string)') | Implicit conversion from string.<br/>This allows you to use a string as a [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath'). |
| [implicit operator string(VFSFilePath)](VFSFilePath.implicitoperatorstring(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFSFilePath.op_Implicit string(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Implicit conversion to string<br/>This allows you to use a [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath') as a string. |
