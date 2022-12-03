#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Abstractions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Abstractions 'Atypical.VirtualFileSystem.Core.Abstractions')

## VFSNode Class

Represents a node in a virtual file system.  
A node can be a file or a directory.

```csharp
public abstract class VFSNode :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode,
System.IEquatable<Atypical.VirtualFileSystem.Core.Abstractions.VFSNode>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VFSNode

Derived  
&#8627; [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode')  
&#8627; [FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode')

Implements [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFSNode(VFSPath)](VFSNode.VFSNode(VFSPath).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.VFSNode(Atypical.VirtualFileSystem.Core.Abstractions.VFSPath)') | Initializes a new instance of the [VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode') class.<br/>This constructor is used by derived classes. |

| Properties | |
| :--- | :--- |
| [CreationTime](VFSNode.CreationTime.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.CreationTime') | Gets the creation time of the node. |
| [IsDirectory](VFSNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.IsDirectory') | Indicates whether the node is a directory. |
| [IsFile](VFSNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.IsFile') | Indicates whether the node is a file. |
| [LastAccessTime](VFSNode.LastAccessTime.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.LastAccessTime') | Gets the last access time of the node. |
| [LastWriteTime](VFSNode.LastWriteTime.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.LastWriteTime') | Gets the last write time of the node. |
| [Path](VFSNode.Path.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.Path') | Gets the creation time of the node. |
