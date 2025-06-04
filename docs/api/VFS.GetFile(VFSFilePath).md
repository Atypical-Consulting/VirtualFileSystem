#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.GetFile\(VFSFilePath\) Method

Gets a file node by its path\.
The path must be absolute\.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IFileNode GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The path of the file node\.

Implements [GetFile\(VFSFilePath\)](IVirtualFileSystem.GetFile(VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.GetFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)')

#### Returns
[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')  
The file node\.