#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

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

Implements [DeleteDirectory(string)](IVirtualFileSystem.DeleteDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(string)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.