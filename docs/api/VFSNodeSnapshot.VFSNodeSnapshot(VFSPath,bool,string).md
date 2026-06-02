#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSNodeSnapshot](VFSNodeSnapshot.md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot')

## VFSNodeSnapshot\(VFSPath, bool, string\) Constructor

Captures the state of a node that was removed during a directory deletion,
so the deletion can be reversed by the change history\.

```csharp
public VFSNodeSnapshot(Atypical.VirtualFileSystem.Core.VFSPath Path, bool IsDirectory, string? Content);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSNodeSnapshot.VFSNodeSnapshot(Atypical.VirtualFileSystem.Core.VFSPath,bool,string).Path'></a>

`Path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The path of the deleted node\.

<a name='Atypical.VirtualFileSystem.Core.VFSNodeSnapshot.VFSNodeSnapshot(Atypical.VirtualFileSystem.Core.VFSPath,bool,string).IsDirectory'></a>

`IsDirectory` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

`true` if the node was a directory; otherwise `false`\.

<a name='Atypical.VirtualFileSystem.Core.VFSNodeSnapshot.VFSNodeSnapshot(Atypical.VirtualFileSystem.Core.VFSPath,bool,string).Content'></a>

`Content` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file content, or `null` for directories\.