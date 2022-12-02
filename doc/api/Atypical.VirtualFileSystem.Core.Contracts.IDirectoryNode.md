#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts')

## IDirectoryNode Interface

Represents a directory in a virtual file system.  
This is an in-memory representation of a directory.  
It is not a representation of a directory on a physical file system.

```csharp
public interface IDirectoryNode :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [IRootNode](Atypical.VirtualFileSystem.Core.Contracts.IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode')  
&#8627; [DirectoryNode](Atypical.VirtualFileSystem.Core.Models.DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode')  
&#8627; [RootNode](Atypical.VirtualFileSystem.Core.Models.RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode')

Implements [IVirtualFileSystemNode](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')