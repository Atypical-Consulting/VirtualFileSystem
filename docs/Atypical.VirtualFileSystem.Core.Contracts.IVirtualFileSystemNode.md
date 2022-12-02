#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts')

## IVirtualFileSystemNode Interface

Represents a node in a virtual file system.  
A node can be a file or a directory.

```csharp
public interface IVirtualFileSystemNode
```

Derived  
&#8627; [VFSNode](Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode')  
&#8627; [IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')  
&#8627; [IFileNode](Atypical.VirtualFileSystem.Core.Contracts.IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')  
&#8627; [IRootNode](Atypical.VirtualFileSystem.Core.Contracts.IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode')  
&#8627; [DirectoryNode](Atypical.VirtualFileSystem.Core.Models.DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode')  
&#8627; [FileNode](Atypical.VirtualFileSystem.Core.Models.FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode')  
&#8627; [RootNode](Atypical.VirtualFileSystem.Core.Models.RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode')

| Properties | |
| :--- | :--- |
| [CreationTime](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.CreationTime.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.CreationTime') | Gets the creation time of the node. |
| [IsDirectory](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.IsDirectory') | Indicates whether the node is a directory. |
| [IsFile](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.IsFile') | Indicates whether the node is a file. |
| [LastAccessTime](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.LastAccessTime.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.LastAccessTime') | Gets the last access time of the node. |
| [LastWriteTime](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.LastWriteTime.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.LastWriteTime') | Gets the last write time of the node. |
| [Name](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Name.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Name') | Gets the name of the virtual file system node.<br/>The name is the last part of the path.<br/>For example, the name of the file "vfs://temp/file.txt" is "file.txt".<br/>The name of the directory "vfs://temp" is "temp". |
| [Path](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Path.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Path') | Gets the full path of the node.<br/>The path is the path from the root of the file system to the node.<br/>For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".<br/>The path of the node with the path "./temp/" is "./temp/". |
