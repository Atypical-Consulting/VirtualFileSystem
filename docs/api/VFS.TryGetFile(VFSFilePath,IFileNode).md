#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.TryGetFile\(VFSFilePath, IFileNode\) Method

Try to get a file node by its path\.
The path must be absolute\.

```csharp
public bool TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, out Atypical.VirtualFileSystem.Core.Contracts.IFileNode? file);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The path of the file node\.

<a name='Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).file'></a>

`file` [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')

The file node\.

Implements [TryGetFile\(VFSFilePath, IFileNode\)](IVirtualFileSystem.TryGetFile(VFSFilePath,IFileNode).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.TryGetFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode\)')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the file node exists; otherwise, `false`\.