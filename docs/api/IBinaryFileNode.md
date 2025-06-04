#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models')

## IBinaryFileNode Interface

Interface for binary file nodes that support both text and binary content\.

```csharp
public interface IBinaryFileNode : Atypical.VirtualFileSystem.Core.Contracts.IFileNode, Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode')

Implements [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode')

| Properties | |
| :--- | :--- |
| [BinaryContent](IBinaryFileNode.BinaryContent.md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.BinaryContent') | Gets or sets the binary content of the file\. |
| [IsBinary](IBinaryFileNode.IsBinary.md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.IsBinary') | Gets a value indicating whether this file contains binary data\. |
| [SizeInBytes](IBinaryFileNode.SizeInBytes.md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.SizeInBytes') | Gets the size of the binary content in bytes\. |

| Methods | |
| :--- | :--- |
| [SetBinaryContent\(byte\[\]\)](IBinaryFileNode.SetBinaryContent(byte[]).md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.SetBinaryContent\(byte\[\]\)') | Sets the content from binary data\. |
| [SetContentFromBase64\(string\)](IBinaryFileNode.SetContentFromBase64(string).md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.SetContentFromBase64\(string\)') | Sets the content from a base64 encoded string\. |
| [SetTextContent\(string\)](IBinaryFileNode.SetTextContent(string).md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.SetTextContent\(string\)') | Sets the content from a text string and clears binary content\. |
| [ToBase64String\(\)](IBinaryFileNode.ToBase64String().md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.ToBase64String\(\)') | Gets the binary content as a base64 encoded string\. |
