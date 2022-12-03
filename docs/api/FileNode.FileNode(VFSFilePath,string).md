#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical.VirtualFileSystem.Core.Models').[FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode')

## FileNode(VFSFilePath, string) Constructor

Initializes a new instance of the [FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode') class.  
Creates a new file node.  
The file is created with the current date and time as creation and last modification date.

```csharp
public FileNode(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.FileNode.FileNode(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,string).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

The path of the file.

<a name='Atypical.VirtualFileSystem.Core.Models.FileNode.FileNode(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,string).content'></a>

`content` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The content of the file.