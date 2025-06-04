#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

## VFSFilePath\.implicit operator string\(VFSFilePath\) Operator

Implicit conversion to string
This allows you to use a [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath') as a string\.

```csharp
public static string implicit operator string(Atypical.VirtualFileSystem.Core.VFSFilePath path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSFilePath.op_Implicitstring(Atypical.VirtualFileSystem.Core.VFSFilePath).path'></a>

`path` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The path to convert\.

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')  
The string representation of the path\.