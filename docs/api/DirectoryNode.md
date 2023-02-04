#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical.VirtualFileSystem.Core.Models')

## DirectoryNode Class

Represents a directory in the virtual file system.

```csharp
public class DirectoryNode : Atypical.VirtualFileSystem.Core.Abstractions.VFSNode,
Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode,
System.IEquatable<Atypical.VirtualFileSystem.Core.Models.DirectoryNode>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode') &#129106; DirectoryNode

Derived  
&#8627; [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode')

Implements [IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [DirectoryNode(VFSDirectoryPath)](DirectoryNode.DirectoryNode(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.DirectoryNode(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Initializes a new instance of the [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode') class.<br/>Creates a new directory node.<br/>The directory is created with the current date and time as creation and last modification date. |

| Properties | |
| :--- | :--- |
| [Directories](DirectoryNode.Directories.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.Directories') | Gets the child directories of the node. |
| [Files](DirectoryNode.Files.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.Files') | Gets the child files of the node. |
| [IsDirectory](DirectoryNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.IsDirectory') | Indicates whether the node is a directory. |
| [IsFile](DirectoryNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.IsFile') | Indicates whether the node is a file. |
| [Path](DirectoryNode.Path.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.Path') | Gets the full path of the node.<br/>The path is the path from the root of the file system to the node.<br/>For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".<br/>The path of the node with the path "./temp/" is "./temp/". |

| Methods | |
| :--- | :--- |
| [AddChild(IDirectoryNode)](DirectoryNode.AddChild(IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Adds a child directory to the current directory. |
| [AddChild(IFileNode)](DirectoryNode.AddChild(IFileNode).md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Adds a child file to the current directory. |
| [ToString()](DirectoryNode.ToString().md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.ToString()') | Returns a string that represents the path of the directory. |
