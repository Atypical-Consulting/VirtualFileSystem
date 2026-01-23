#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.DirectoryDeleted Event

Event triggered when a directory is deleted\.

```csharp
public event Action<VFSDirectoryDeletedArgs>? DirectoryDeleted;
```

Implements [DirectoryDeleted](IVFSDelete.DirectoryDeleted.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSDelete\.DirectoryDeleted')

#### Event Type
[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')