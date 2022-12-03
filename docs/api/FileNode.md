#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical.VirtualFileSystem.Core.Models')

## FileNode Class

Represents a file in the virtual file system.

```csharp
public class FileNode : Atypical.VirtualFileSystem.Core.Abstractions.VFSNode,
Atypical.VirtualFileSystem.Core.Contracts.IFileNode,
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode,
System.IEquatable<Atypical.VirtualFileSystem.Core.Models.FileNode>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode') &#129106; FileNode

Implements [IFileNode](IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [FileNode(VFSFilePath, string)](FileNode.FileNode(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Models.FileNode.FileNode(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, string)') | Initializes a new instance of the [FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode') class.<br/>Creates a new file node.<br/>The file is created with the current date and time as creation and last modification date. |

| Properties | |
| :--- | :--- |
| [Content](FileNode.Content.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.Content') | Gets the content of the file as a string.<br/>The encoding is in UTF-8. |
| [IsDirectory](FileNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.IsDirectory') | Indicates whether the node is a directory. |
| [IsFile](FileNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.IsFile') | Indicates whether the node is a file. |
| [Path](FileNode.Path.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.Path') | Gets the full path of the node.<br/>The path is the path from the root of the file system to the node.<br/>For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".<br/>The path of the node with the path "./temp/" is "./temp/". |

| Methods | |
| :--- | :--- |
| [ToString()](FileNode.ToString().md 'Atypical.VirtualFileSystem.Core.Models.FileNode.ToString()') | Returns a string that represents the path of the file. |
