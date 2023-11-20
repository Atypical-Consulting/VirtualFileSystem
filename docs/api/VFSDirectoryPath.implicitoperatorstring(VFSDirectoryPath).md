#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath')

## VFSDirectoryPath.implicit operator string(VFSDirectoryPath) Operator

Implicit conversion to string  
This allows you to use a [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath') as a string.

```csharp
public static string implicit operator string(Atypical.VirtualFileSystem.Core.VFSDirectoryPath path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSDirectoryPath.op_Implicitstring(Atypical.VirtualFileSystem.Core.VFSDirectoryPath).path'></a>

`path` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath')

The path to convert.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The string representation of the path.