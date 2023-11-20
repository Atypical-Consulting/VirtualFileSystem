#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.MoveFile(string, string) Method

Moves a file node from the source path to the destination path.  
Both paths must be absolute.

```csharp
public Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem MoveFile(string sourceFilePath, string destinationFilePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.MoveFile(string,string).sourceFilePath'></a>

`sourceFilePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The source path of the file node.

<a name='Atypical.VirtualFileSystem.Core.VFS.MoveFile(string,string).destinationFilePath'></a>

`destinationFilePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The destination path of the file node.

Implements [MoveFile(string, string)](IVirtualFileSystem.MoveFile(string,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.MoveFile(string, string)')

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.