#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

## IVirtualFileSystem\.TryGetFile\(VFSFilePath, IFileNode\) Method

Try to get a file node by its path\.
The path must be absolute\.

```csharp
bool TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, out Atypical.VirtualFileSystem.Core.Contracts.IFileNode? file);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The path of the file node\.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).file'></a>

`file` [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')

The file node\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
`true` if the file node exists; otherwise, `false`\.