#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.DirectoryMoved Event

Event triggered when a directory is moved\.

```csharp
public event Action<VFSDirectoryMovedArgs>? DirectoryMoved;
```

Implements [DirectoryMoved](IVFSMove.DirectoryMoved.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove\.DirectoryMoved')

#### Event Type
[System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[VFSDirectoryMovedArgs](VFSDirectoryMovedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')