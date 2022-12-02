#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.DeleteDirectory(string) Method

Deletes a directory node at the specified path.  
The path must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem DeleteDirectory(string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(string).directoryPath'></a>

`directoryPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the directory node.

Implements [DeleteDirectory(string)](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(string)')

#### Returns
[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.