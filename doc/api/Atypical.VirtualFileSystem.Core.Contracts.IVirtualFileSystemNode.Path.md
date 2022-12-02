#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystemNode](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')

## IVirtualFileSystemNode.Path Property

Gets the full path of the node.  
The path is the path from the root of the file system to the node.  
For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".  
The path of the node with the path "./temp/" is "./temp/".

```csharp
Atypical.VirtualFileSystem.Core.Abstractions.VFSPath Path { get; }
```

#### Property Value
[VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')  
The full path of the node.