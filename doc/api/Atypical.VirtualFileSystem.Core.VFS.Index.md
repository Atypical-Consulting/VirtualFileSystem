#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core').[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.Index Property

Gets the file index of the file system.  
Basically, this is a dictionary that maps file paths to file nodes.  
This is useful for quickly finding a file node by its path.

```csharp
public Atypical.VirtualFileSystem.Core.VFSIndex Index { get; }
```

Implements [Index](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Index.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Index')

#### Property Value
[VFSIndex](Atypical.VirtualFileSystem.Core.VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex')