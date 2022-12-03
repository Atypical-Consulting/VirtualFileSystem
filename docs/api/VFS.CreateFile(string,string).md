#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.CreateFile(string, string) Method

Creates a file node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateFile(string filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.CreateFile(string,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the file node.

<a name='Atypical.VirtualFileSystem.Core.VFS.CreateFile(string,string).content'></a>

`content` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The content of the file node.

Implements [CreateFile(string, string)](IVirtualFileSystem.CreateFile(string,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(string, string)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.