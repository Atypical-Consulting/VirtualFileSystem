#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.MoveFile(string, string) Method

Moves a file node from the source path to the destination path.  
Both paths must be absolute.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem MoveFile(string sourceFilePath, string destinationFilePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.MoveFile(string,string).sourceFilePath'></a>

`sourceFilePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The source path of the file node.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.MoveFile(string,string).destinationFilePath'></a>

`destinationFilePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The destination path of the file node.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.