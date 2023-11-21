#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.VFSPath')

## VFSPath.Depth Property

Gets the depth of the file system entry.  
The root directory has a depth of 0.  
The depth of a file is the depth of its parent directory plus one.  
The depth of a directory is the depth of its parent directory plus one.

```csharp
public int Depth { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')