#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.Index Property

Gets the file index of the file system\.
Basically, this is a dictionary that maps file paths to file nodes\.
This is useful for quickly finding a file node by its path\.

```csharp
public Atypical.VirtualFileSystem.Core.VFSIndex Index { get; }
```

Implements [Index](IVirtualFileSystem.Index.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.Index')

#### Property Value
[VFSIndex](VFSIndex.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex')