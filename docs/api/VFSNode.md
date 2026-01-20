#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSNode Class

Represents a node in a virtual file system\.
A node can be a file or a directory\.

```csharp
public abstract record VFSNode : Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode, System.IEquatable<Atypical.VirtualFileSystem.Core.VFSNode>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VFSNode

Derived  
&#8627; [DirectoryNode](DirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.DirectoryNode')  
&#8627; [FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode')

Implements [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[VFSNode](VFSNode.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [VFSNode\(VFSPath\)](VFSNode.VFSNode(VFSPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.VFSNode\(Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Initializes a new instance of the [VFSNode](VFSNode.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode') class\. This constructor is used by derived classes\. |

| Properties | |
| :--- | :--- |
| [CreationTime](VFSNode.CreationTime.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.CreationTime') | Gets the creation time of the node\. |
| [IsDirectory](VFSNode.IsDirectory.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.IsDirectory') | Indicates whether the node is a directory\. |
| [IsFile](VFSNode.IsFile.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.IsFile') | Indicates whether the node is a file\. |
| [LastAccessTime](VFSNode.LastAccessTime.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.LastAccessTime') | Gets the last access time of the node\. |
| [LastWriteTime](VFSNode.LastWriteTime.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.LastWriteTime') | Gets the last write time of the node\. |
| [Path](VFSNode.Path.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.Path') | Gets the creation time of the node\. |

| Methods | |
| :--- | :--- |
| [UpdatePath\(VFSPath\)](VFSNode.UpdatePath(VFSPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSNode\.UpdatePath\(Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Updates the path of the node\. |
