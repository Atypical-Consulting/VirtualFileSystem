#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## FileNode Class

Represents a file in the virtual file system\.

```csharp
public record FileNode : Atypical.VirtualFileSystem.Core.VFSNode, Atypical.VirtualFileSystem.Core.Contracts.IFileNode, Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode, System.IEquatable<Atypical.VirtualFileSystem.Core.FileNode>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [VFSNode](VFSNode.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode') &#129106; FileNode

Derived  
&#8627; [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode')

Implements [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [FileNode\(VFSFilePath, string\)](FileNode.FileNode(VFSFilePath,string).md 'Atypical\.VirtualFileSystem\.Core\.FileNode\.FileNode\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, string\)') | Initializes a new instance of the [FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode') class\. Creates a new file node\. The file is created with the current date and time as creation and last modification date\. |

| Properties | |
| :--- | :--- |
| [Content](FileNode.Content.md 'Atypical\.VirtualFileSystem\.Core\.FileNode\.Content') | Gets the content of the file as a string\. The encoding is in UTF\-8\. |
| [IsDirectory](FileNode.IsDirectory.md 'Atypical\.VirtualFileSystem\.Core\.FileNode\.IsDirectory') | Indicates whether the node is a directory\. |
| [IsFile](FileNode.IsFile.md 'Atypical\.VirtualFileSystem\.Core\.FileNode\.IsFile') | Indicates whether the node is a file\. |

| Methods | |
| :--- | :--- |
| [ToString\(\)](FileNode.ToString().md 'Atypical\.VirtualFileSystem\.Core\.FileNode\.ToString\(\)') | Returns a string that represents the path of the file\. |
