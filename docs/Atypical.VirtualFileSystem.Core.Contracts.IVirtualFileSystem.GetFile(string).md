#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.GetFile(string) Method

Gets a file node by its path.  
The path must be absolute.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IFileNode GetFile(string filePath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the file node.

#### Returns
[IFileNode](Atypical.VirtualFileSystem.Core.Contracts.IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')  
The file node.