#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

## VFSPath\(string\) Constructor

Creates a new instance of [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')\.

```csharp
protected VFSPath(string path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSPath.VFSPath(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to the file system entry\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when the path is null\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when the path is invalid\.