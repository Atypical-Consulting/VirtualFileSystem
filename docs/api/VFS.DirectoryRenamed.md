#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.DirectoryRenamed Event

Event triggered when a directory is renamed\.

```csharp
public event Action<VFSDirectoryRenamedArgs>? DirectoryRenamed;
```

Implements [DirectoryRenamed](IVFSRename.DirectoryRenamed.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSRename\.DirectoryRenamed')

#### Event Type
[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[VFSDirectoryRenamedArgs](VFSDirectoryRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryRenamedArgs')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')