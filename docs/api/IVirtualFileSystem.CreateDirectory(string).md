#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.CreateDirectory(string) Method

Creates a directory node at the specified path.  
The path must be absolute.

```csharp
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateDirectory(string directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(string).directoryPath'></a>

`directoryPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path of the directory node.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')  
The file system.