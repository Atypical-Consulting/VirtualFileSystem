#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.ValueObjects](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.ValueObjects 'Atypical.VirtualFileSystem.Core.ValueObjects').[VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath')

## VFSRootPath.implicit operator string(VFSRootPath) Operator

Implicit conversion to string  
This allows you to use a [VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath') as a string.

```csharp
public static string implicit operator string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.op_Implicitstring(Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath).path'></a>

`path` [VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath')

The path to convert.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The string representation of the path.