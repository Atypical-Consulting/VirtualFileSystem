#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IRootNode Interface

Represents the root of a virtual file system.  
This is the entry point for all operations on the file system.

```csharp
public interface IRootNode :
Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.RootNode')

Implements [IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')