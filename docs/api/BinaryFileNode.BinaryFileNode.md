#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode')

## BinaryFileNode Constructors

| Overloads | |
| :--- | :--- |
| [BinaryFileNode\(VFSFilePath, byte\[\]\)](BinaryFileNode.BinaryFileNode.md#Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,byte[]) 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.BinaryFileNode\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, byte\[\]\)') | Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode') class with binary content\. |
| [BinaryFileNode\(VFSFilePath, string\)](BinaryFileNode.BinaryFileNode.md#Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string) 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode\.BinaryFileNode\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, string\)') | Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode') class\. |

<a name='Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,byte[])'></a>

## BinaryFileNode\(VFSFilePath, byte\[\]\) Constructor

Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode') class with binary content\.

```csharp
public BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, byte[]? binaryContent);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,byte[]).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The file path\.

<a name='Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,byte[]).binaryContent'></a>

`binaryContent` [System\.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System\.Byte')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The binary content of the file\.

<a name='Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string)'></a>

## BinaryFileNode\(VFSFilePath, string\) Constructor

Initializes a new instance of the [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode') class\.

```csharp
public BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The file path\.

<a name='Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.BinaryFileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string).content'></a>

`content` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The text content of the file\.