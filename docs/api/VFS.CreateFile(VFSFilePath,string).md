#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.CreateFile(VFSFilePath, string) Method

Creates a file node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,string).filePath'></a>

`filePath` [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')

The path of the file node.

<a name='Atypical.VirtualFileSystem.Core.VFS.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,string).content'></a>

`content` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The content of the file node.

Implements [CreateFile(VFSFilePath, string)](IVirtualFileSystem.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, string)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.