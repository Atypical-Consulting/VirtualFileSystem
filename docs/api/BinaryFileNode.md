#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models')

## BinaryFileNode Class

Represents a binary file node in the virtual file system\.
Extends the standard file node to support binary content in addition to text\.

```csharp
public sealed record BinaryFileNode : Atypical.VirtualFileSystem.Core.FileNode, Atypical.VirtualFileSystem.Core.Models.IBinaryFileNode, Atypical.VirtualFileSystem.Core.Contracts.IFileNode, Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode, System.IEquatable<Atypical.VirtualFileSystem.Core.Models.BinaryFileNode>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [VFSNode](VFSNode.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode') &#129106; [FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode') &#129106; BinaryFileNode

Implements [IBinaryFileNode](IBinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode'), [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode'), [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [BinaryFileNode\(VFSFilePath, byte\[\]\)](BinaryFileNode.BinaryFileNode.md#Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,byte[]) 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.BinaryFileNode\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, byte\[\]\)') | Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode') class with binary content\. |
| [BinaryFileNode\(VFSFilePath, string\)](BinaryFileNode.BinaryFileNode.md#Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string) 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.BinaryFileNode\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, string\)') | Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode') class\. |

| Properties | |
| :--- | :--- |
| [BinaryContent](BinaryFileNode.BinaryContent.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.BinaryContent') | Gets or sets the binary content of the file\. |
| [IsBinary](BinaryFileNode.IsBinary.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.IsBinary') | Gets a value indicating whether this file contains binary data\. |
| [SizeInBytes](BinaryFileNode.SizeInBytes.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.SizeInBytes') | Gets the size of the binary content in bytes\. |

| Methods | |
| :--- | :--- |
| [Copy\(VFSFilePath\)](BinaryFileNode.Copy(VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.Copy\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Creates a copy of the current binary file node\. |
| [SetBinaryContent\(byte\[\]\)](BinaryFileNode.SetBinaryContent(byte[]).md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.SetBinaryContent\(byte\[\]\)') | Sets the content from binary data and updates the text representation\. |
| [SetContentFromBase64\(string\)](BinaryFileNode.SetContentFromBase64(string).md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.SetContentFromBase64\(string\)') | Sets the content from a base64 encoded string\. |
| [SetTextContent\(string\)](BinaryFileNode.SetTextContent(string).md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.SetTextContent\(string\)') | Sets the content from a text string and clears binary content\. |
| [ToBase64String\(\)](BinaryFileNode.ToBase64String().md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.ToBase64String\(\)') | Gets the binary content as a base64 encoded string\. |
| [ToString\(\)](BinaryFileNode.ToString().md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.ToString\(\)') | Returns a string representation of the binary file node\. |
