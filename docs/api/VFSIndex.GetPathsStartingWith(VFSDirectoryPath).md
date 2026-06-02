#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSIndex](VFSIndex.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex')

## VFSIndex\.GetPathsStartingWith\(VFSDirectoryPath\) Method

Gets the directory itself and all of its descendants \(files and subdirectories\)\.

```csharp
public System.Collections.Immutable.ImmutableArray<Atypical.VirtualFileSystem.Core.VFSPath> GetPathsStartingWith(Atypical.VirtualFileSystem.Core.VFSDirectoryPath directoryPath);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSIndex.GetPathsStartingWith(Atypical.VirtualFileSystem.Core.VFSDirectoryPath).directoryPath'></a>

`directoryPath` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

#### Returns
[System\.Collections\.Immutable\.ImmutableArray&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')[VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')

### Remarks
Matching is anchored on a directory\-separator boundary so that a directory
such as `vfs://docs` does not wrongly capture sibling paths that merely
share its name as a prefix \(e\.g\. `vfs://docs2`\)\. Comparison is
case\-insensitive, consistent with the index ordering \([Atypical\.VirtualFileSystem\.Core\.VFSPathComparer](https://learn.microsoft.com/en-us/dotnet/api/atypical.virtualfilesystem.core.vfspathcomparer 'Atypical\.VirtualFileSystem\.Core\.VFSPathComparer')\)\.