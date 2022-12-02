#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.ValueObjects](Atypical.VirtualFileSystem.Core.ValueObjects.md 'Atypical.VirtualFileSystem.Core.ValueObjects').[VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')

## VFSDirectoryPath.implicit operator string(VFSDirectoryPath) Operator

Implicit conversion to string  
This allows you to use a [VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath') as a string.

```csharp
public static string implicit operator string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.op_Implicitstring(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).path'></a>

`path` [VFSDirectoryPath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')

The path to convert.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The string representation of the path.