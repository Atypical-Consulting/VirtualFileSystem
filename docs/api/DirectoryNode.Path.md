#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical.VirtualFileSystem.Core.Models').[DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode')

## DirectoryNode.Path Property

Gets the full path of the node.  
The path is the path from the root of the file system to the node.  
For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".  
The path of the node with the path "./temp/" is "./temp/".

```csharp
public virtual Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath Path { get; }
```

Implements [Path](IVirtualFileSystemNode.Path.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Path')

#### Property Value
[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')  
The full path of the node.