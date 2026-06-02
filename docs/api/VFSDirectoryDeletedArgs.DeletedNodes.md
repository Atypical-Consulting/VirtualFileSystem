#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs')

## VFSDirectoryDeletedArgs\.DeletedNodes Property

Gets the snapshot of the directory and its descendants that were removed,
used to restore the subtree on undo\.

```csharp
public System.Collections.Immutable.ImmutableArray<Atypical.VirtualFileSystem.Core.VFSNodeSnapshot> DeletedNodes { get; }
```

#### Property Value
[System\.Collections\.Immutable\.ImmutableArray&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')[VFSNodeSnapshot](VFSNodeSnapshot.md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')