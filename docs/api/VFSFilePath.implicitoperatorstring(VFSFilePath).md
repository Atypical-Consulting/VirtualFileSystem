#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.ValueObjects](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.ValueObjects 'Atypical.VirtualFileSystem.Core.ValueObjects').[VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

## VFSFilePath.implicit operator string(VFSFilePath) Operator

Implicit conversion to string  
This allows you to use a [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath') as a string.

```csharp
public static string implicit operator string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.op_Implicitstring(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).path'></a>

`path` [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

The path to convert.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The string representation of the path.