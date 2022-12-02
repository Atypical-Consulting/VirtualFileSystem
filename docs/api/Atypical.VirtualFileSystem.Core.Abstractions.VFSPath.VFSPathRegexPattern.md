#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Abstractions](Atypical.VirtualFileSystem.Core.Abstractions.md 'Atypical.VirtualFileSystem.Core.Abstractions').[VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')

## VFSPath.VFSPathRegexPattern Field

Regex pattern for matching a valid file system path.

```csharp
private const string VFSPathRegexPattern = ^vfs://(?<path>([a-zA-Z0-9_\-\.]+/)*[a-zA-Z0-9_\-\.]+)$;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')