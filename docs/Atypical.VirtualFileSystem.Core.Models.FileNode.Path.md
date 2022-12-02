#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Models](Atypical.VirtualFileSystem.Core.Models.md 'Atypical.VirtualFileSystem.Core.Models').[FileNode](Atypical.VirtualFileSystem.Core.Models.FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode')

## FileNode.Path Property

Gets the full path of the node.  
The path is the path from the root of the file system to the node.  
For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".  
The path of the node with the path "./temp/" is "./temp/".

```csharp
public virtual Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath Path { get; }
```

Implements [Path](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Path.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Path')

#### Property Value
[VFSFilePath](Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')  
The full path of the node.