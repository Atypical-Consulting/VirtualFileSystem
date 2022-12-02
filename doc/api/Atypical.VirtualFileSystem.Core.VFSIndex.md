#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')

## VFSIndex Class

Represents the index of the virtual file system.  
- a vfs index is a dictionary of vfs paths and vfs nodes  
- the vfs index is used to store the nodes of the virtual file system  
This class cannot be inherited.

```csharp
public sealed class VFSIndex : System.Collections.Generic.SortedDictionary<string, Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Collections.Generic.SortedDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2')[IVirtualFileSystemNode](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedDictionary-2 'System.Collections.Generic.SortedDictionary`2') &#129106; VFSIndex

| Constructors | |
| :--- | :--- |
| [VFSIndex(IRootNode)](Atypical.VirtualFileSystem.Core.VFSIndex.VFSIndex(Atypical.VirtualFileSystem.Core.Contracts.IRootNode).md 'Atypical.VirtualFileSystem.Core.VFSIndex.VFSIndex(Atypical.VirtualFileSystem.Core.Contracts.IRootNode)') | Initializes a new instance of the [VFSIndex](Atypical.VirtualFileSystem.Core.VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex') class.<br/>- the vfs index is a dictionary of vfs paths and vfs nodes<br/>- the vfs index is used to store the nodes of the virtual file system<br/>- the vfs index is sorted by the vfs paths<br/>- the vfs index is case insensitive |
