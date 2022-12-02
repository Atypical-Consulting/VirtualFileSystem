#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.DeleteFile(string) Method

Deletes a file node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem DeleteFile(string filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.DeleteFile(string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the file node.

Implements [DeleteFile(string)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(string)')

#### Returns
[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.