#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.DirectoryCreated Event

Event triggered when a directory is created\.

```csharp
public event Action<VFSDirectoryCreatedArgs>? DirectoryCreated;
```

Implements [DirectoryCreated](IVFSCreate.DirectoryCreated.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSCreate\.DirectoryCreated')

#### Event Type
[System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[VFSDirectoryCreatedArgs](VFSDirectoryCreatedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryCreatedArgs')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')