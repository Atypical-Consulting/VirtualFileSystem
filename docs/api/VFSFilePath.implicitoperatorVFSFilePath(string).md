#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

## VFSFilePath\.implicit operator VFSFilePath\(string\) Operator

Implicit conversion from string\.
This allows you to use a string as a [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')\.

```csharp
public static Atypical.VirtualFileSystem.Core.VFSFilePath implicit operator Atypical.VirtualFileSystem.Core.VFSFilePath(string path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSFilePath.op_ImplicitAtypical.VirtualFileSystem.Core.VFSFilePath(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to convert\.

#### Returns
[VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')  
The file path\.