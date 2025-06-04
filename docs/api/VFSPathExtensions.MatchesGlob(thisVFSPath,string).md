#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.MatchesGlob\(this VFSPath, string\) Method

Checks if the path matches a glob pattern\.

```csharp
public static bool MatchesGlob(this Atypical.VirtualFileSystem.Core.VFSPath path, string pattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.MatchesGlob(thisAtypical.VirtualFileSystem.Core.VFSPath,string).path'></a>

`path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The VFS path\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.MatchesGlob(thisAtypical.VirtualFileSystem.Core.VFSPath,string).pattern'></a>

`pattern` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The glob pattern \(e\.g\., "\*\.txt", "test\*", "\*\*/config\.\*"\)\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the path matches the pattern\.