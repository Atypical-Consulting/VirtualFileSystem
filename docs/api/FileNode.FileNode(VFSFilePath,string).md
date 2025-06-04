#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode')

## FileNode\(VFSFilePath, string\) Constructor

Initializes a new instance of the [FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode') class\.
Creates a new file node\.
The file is created with the current date and time as creation and last modification date\.

```csharp
public FileNode(Atypical.VirtualFileSystem.Core.VFSFilePath filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.FileNode.FileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')

The path of the file\.

<a name='Atypical.VirtualFileSystem.Core.FileNode.FileNode(Atypical.VirtualFileSystem.Core.VFSFilePath,string).content'></a>

`content` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The content of the file\.