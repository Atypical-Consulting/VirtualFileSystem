#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.FileCreated Event

Event triggered when a file is created\.

```csharp
public event Action<VFSFileCreatedArgs>? FileCreated;
```

Implements [FileCreated](IVFSCreate.FileCreated.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSCreate\.FileCreated')

#### Event Type
[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[VFSFileCreatedArgs](VFSFileCreatedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileCreatedArgs')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')