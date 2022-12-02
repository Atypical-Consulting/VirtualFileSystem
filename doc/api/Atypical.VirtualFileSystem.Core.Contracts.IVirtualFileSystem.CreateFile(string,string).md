#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.CreateFile(string, string) Method

Creates a file node at the specified path.  
The path must be absolute.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateFile(string filePath, string? content=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(string,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the file node.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(string,string).content'></a>

`content` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The content of the file node.

#### Returns
[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.