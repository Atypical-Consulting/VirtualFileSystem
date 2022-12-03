#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFSIndex](VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex')

## VFSIndex(IRootNode) Constructor

Initializes a new instance of the [VFSIndex](VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex') class.  
- the vfs index is a dictionary of vfs paths and vfs nodes  
- the vfs index is used to store the nodes of the virtual file system  
- the vfs index is sorted by the vfs paths  
- the vfs index is case insensitive

```csharp
public VFSIndex(Atypical.VirtualFileSystem.Core.Contracts.IRootNode rootNode);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSIndex.VFSIndex(Atypical.VirtualFileSystem.Core.Contracts.IRootNode).rootNode'></a>

`rootNode` [IRootNode](IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode')

The root node of the virtual file system.