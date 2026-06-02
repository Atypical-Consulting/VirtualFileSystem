#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs')

## VFSFileRenamedArgs\(VFSFilePath, string, string, VFSFilePath\) Constructor

Initializes a new instance of the [VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs') class\.

```csharp
public VFSFileRenamedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath path, string oldName, string newName, Atypical.VirtualFileSystem.Core.VFSFilePath newPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.VFSFileRenamedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath,string,string,Atypical.VirtualFileSystem.Core.VFSFilePath).path'></a>

`path` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The \(old\) path of the renamed file\.

<a name='Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.VFSFileRenamedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath,string,string,Atypical.VirtualFileSystem.Core.VFSFilePath).oldName'></a>

`oldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The old name of the renamed file\.

<a name='Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.VFSFileRenamedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath,string,string,Atypical.VirtualFileSystem.Core.VFSFilePath).newName'></a>

`newName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new name of the renamed file \(the file name only, not the full path\)\.

<a name='Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.VFSFileRenamedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath,string,string,Atypical.VirtualFileSystem.Core.VFSFilePath).newPath'></a>

`newPath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The new path of the renamed file\.