#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.FileRenamed Event

Event triggered when a file is renamed\.

```csharp
public event Action<VFSFileRenamedArgs>? FileRenamed;
```

Implements [FileRenamed](IVFSRename.FileRenamed.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSRename\.FileRenamed')

#### Event Type
[System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')