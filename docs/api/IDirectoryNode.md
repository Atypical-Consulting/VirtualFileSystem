#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IDirectoryNode Interface

Represents a directory in a virtual file system.  
This is an in-memory representation of a directory.  
It is not a representation of a directory on a physical file system.

```csharp
public interface IDirectoryNode :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [IRootNode](IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode')  
&#8627; [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode')  
&#8627; [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode')

Implements [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')