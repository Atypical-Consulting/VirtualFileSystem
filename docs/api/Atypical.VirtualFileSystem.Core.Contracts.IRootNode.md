#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts')

## IRootNode Interface

Represents the root of a virtual file system.  
This is the entry point for all operations on the file system.

```csharp
public interface IRootNode :
Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [RootNode](Atypical.VirtualFileSystem.Core.Models.RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode')

Implements [IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode'), [IVirtualFileSystemNode](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')