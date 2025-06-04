#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

## IVirtualFileSystem\.Index Property

Gets the file index of the file system\.
Basically, this is a dictionary that maps file paths to file nodes\.
This is useful for quickly finding a file node by its path\.

```csharp
Atypical.VirtualFileSystem.Core.VFSIndex Index { get; }
```

#### Property Value
[VFSIndex](VFSIndex.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex')