#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.RenameFile(string, string) Method

Renames a file node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem RenameFile(string filePath, string newName);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.RenameFile(string,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the file node.

<a name='Atypical.VirtualFileSystem.Core.VFS.RenameFile(string,string).newName'></a>

`newName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The new name of the file node.

Implements [RenameFile(string, string)](IVirtualFileSystem.RenameFile(string,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.RenameFile(string, string)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.