#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Abstractions](Atypical.VirtualFileSystem.Core.Abstractions.md 'Atypical.VirtualFileSystem.Core.Abstractions').[VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')

## VFSPath(string) Constructor

Creates a new instance of [VFSPath](Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath').

```csharp
public VFSPath(string path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.VFSPath(string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path to the file system entry.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the path is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when the path is invalid.