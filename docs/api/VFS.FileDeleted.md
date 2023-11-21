#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.FileDeleted Event

Event triggered when a file is deleted.

```csharp
public event Action<VFSFileDeletedArgs>? FileDeleted;
```

Implements [FileDeleted](IVFSDelete.FileDeleted.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.FileDeleted')

#### Event Type
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[VFSFileDeletedArgs](VFSFileDeletedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')