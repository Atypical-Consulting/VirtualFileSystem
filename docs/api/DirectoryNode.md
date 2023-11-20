#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## DirectoryNode Class

Represents a directory in the virtual file system.

```csharp
public class DirectoryNode : Atypical.VirtualFileSystem.Core.Abstractions.VFSNode,
Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode,
System.IEquatable<Atypical.VirtualFileSystem.Core.DirectoryNode>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode') &#129106; DirectoryNode

Derived  
&#8627; [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.RootNode')

Implements [IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.DirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [DirectoryNode(VFSDirectoryPath)](DirectoryNode.DirectoryNode(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.DirectoryNode.DirectoryNode(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Initializes a new instance of the [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.DirectoryNode') class.<br/>Creates a new directory node.<br/>The directory is created with the current date and time as creation and last modification date. |

| Properties | |
| :--- | :--- |
| [Directories](DirectoryNode.Directories.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.Directories') | Gets the child directories of the node. |
| [Files](DirectoryNode.Files.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.Files') | Gets the child files of the node. |
| [IsDirectory](DirectoryNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.IsDirectory') | Indicates whether the node is a directory. |
| [IsFile](DirectoryNode.IsFile.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.IsFile') | Indicates whether the node is a file. |

| Methods | |
| :--- | :--- |
| [AddChild(IDirectoryNode)](DirectoryNode.AddChild(IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.DirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Adds a child directory to the current directory. |
| [AddChild(IFileNode)](DirectoryNode.AddChild(IFileNode).md 'Atypical.VirtualFileSystem.Core.DirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Adds a child file to the current directory. |
| [ToString()](DirectoryNode.ToString().md 'Atypical.VirtualFileSystem.Core.DirectoryNode.ToString()') | Returns a string that represents the path of the directory. |
