#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSIndex](VFSIndex.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex')

## VFSIndex\.TryGetFile\(VFSFilePath, IFileNode\) Method

Tries to get the file node at the specified file path\.

```csharp
public bool TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, out Atypical.VirtualFileSystem.Core.Contracts.IFileNode fileNode);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSIndex.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The file path\.

<a name='Atypical.VirtualFileSystem.Core.VFSIndex.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).fileNode'></a>

`fileNode` [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')

The file node\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the file node exists; otherwise, `false`\.