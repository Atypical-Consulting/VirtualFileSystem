#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.VFSPath')

## VFSPath(string) Constructor

Creates a new instance of [VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.VFSPath').

```csharp
protected VFSPath(string path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSPath.VFSPath(string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path to the file system entry.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the path is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when the path is invalid.