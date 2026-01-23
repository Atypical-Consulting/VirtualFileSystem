#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## BinaryFileNode Class

Represents a binary file node in the virtual file system\.
Extends the standard file node to support binary content in addition to text\.

```csharp
public sealed record BinaryFileNode : Atypical.VirtualFileSystem.Core.FileNode, Atypical.VirtualFileSystem.Core.IBinaryFileNode, Atypical.VirtualFileSystem.Core.Contracts.IFileNode, Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [VFSNode](VFSNode.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; BinaryFileNode

Implements [IBinaryFileNode](IBinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.IBinaryFileNode'), [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode')

| Constructors | |
| :--- | :--- |
| [BinaryFileNode\(VFSFilePath, byte\[\]\)](BinaryFileNode.BinaryFileNode.md#Atypical.VirtualFileSystem.Core.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,byte[]) 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.BinaryFileNode\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, byte\[\]\)') | Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode') class with binary content\. |
| [BinaryFileNode\(VFSFilePath, string\)](BinaryFileNode.BinaryFileNode.md#Atypical.VirtualFileSystem.Core.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string) 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.BinaryFileNode\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, string\)') | Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode') class\. |

| Properties | |
| :--- | :--- |
| [BinaryContent](BinaryFileNode.BinaryContent.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.BinaryContent') | Gets or sets the binary content of the file\. |
| [IsBinary](BinaryFileNode.IsBinary.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.IsBinary') | Gets a value indicating whether this file contains binary data\. |
| [SizeInBytes](BinaryFileNode.SizeInBytes.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.SizeInBytes') | Gets the size of the binary content in bytes\. |

| Methods | |
| :--- | :--- |
| [Copy\(VFSFilePath\)](BinaryFileNode.Copy(VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.Copy\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Creates a copy of the current binary file node\. |
| [SetBinaryContent\(byte\[\]\)](BinaryFileNode.SetBinaryContent(byte[]).md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.SetBinaryContent\(byte\[\]\)') | Sets the content from binary data and updates the text representation\. |
| [SetContentFromBase64\(string\)](BinaryFileNode.SetContentFromBase64(string).md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.SetContentFromBase64\(string\)') | Sets the content from a base64 encoded string\. |
| [SetTextContent\(string\)](BinaryFileNode.SetTextContent(string).md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.SetTextContent\(string\)') | Sets the content from a text string and clears binary content\. |
| [ToBase64String\(\)](BinaryFileNode.ToBase64String().md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.ToBase64String\(\)') | Gets the binary content as a base64 encoded string\. |
| [ToString\(\)](BinaryFileNode.ToString().md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode\.ToString\(\)') | Returns a string representation of the binary file node\. |
