#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSIndex](VFSIndex.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex')

## VFSIndex\.TryGetDirectory\(VFSDirectoryPath, IDirectoryNode\) Method

Tries to get the directory node at the specified directory path\.

```csharp
public bool TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath, out Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode directoryNode);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSIndex.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The directory path\.

<a name='Atypical.VirtualFileSystem.Core.VFSIndex.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directoryNode'></a>

`directoryNode` [IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')

The directory node\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the directory node exists; otherwise, `false`\.