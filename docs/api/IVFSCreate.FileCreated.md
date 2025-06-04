#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVFSCreate](IVFSCreate.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSCreate')

## IVFSCreate\.FileCreated Event

Event triggered when a file is created\.

```csharp
event Action<VFSFileCreatedArgs>? FileCreated;
```

#### Event Type
[System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[VFSFileCreatedArgs](VFSFileCreatedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileCreatedArgs')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')