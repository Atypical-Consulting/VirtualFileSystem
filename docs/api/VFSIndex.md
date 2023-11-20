#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFSIndex Class

Represents the index of the virtual file system.  
- a vfs index is a dictionary of vfs paths and vfs nodes  
- the vfs index is used to store the nodes of the virtual file system  
This class cannot be inherited.

```csharp
public sealed class VFSIndex
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VFSIndex

| Constructors | |
| :--- | :--- |
| [VFSIndex()](VFSIndex.VFSIndex().md 'Atypical.VirtualFileSystem.Core.VFSIndex.VFSIndex()') | Initializes a new instance of the [VFSIndex](VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex') class.<br/>- the vfs index is a dictionary of vfs paths and vfs nodes<br/>- the vfs index is used to store the nodes of the virtual file system<br/>- the vfs index is sorted by the vfs paths<br/>- the vfs index is case insensitive |
