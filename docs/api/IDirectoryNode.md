#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IDirectoryNode Interface

Represents a directory in a virtual file system.  
This is an in-memory representation of a directory.  
It is not a representation of a directory on a physical file system.

```csharp
public interface IDirectoryNode :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [IRootNode](IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode')  
&#8627; [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.DirectoryNode')  
&#8627; [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.RootNode')

Implements [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')

| Properties | |
| :--- | :--- |
| [Directories](IDirectoryNode.Directories.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.Directories') | Gets the child directories of the node. |
| [Files](IDirectoryNode.Files.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.Files') | Gets the child files of the node. |

| Methods | |
| :--- | :--- |
| [AddChild(IDirectoryNode)](IDirectoryNode.AddChild(IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Adds a child directory to the current directory. |
| [AddChild(IFileNode)](IDirectoryNode.AddChild(IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Adds a child file to the current directory. |
