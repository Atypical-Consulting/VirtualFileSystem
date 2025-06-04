#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode')

## IVirtualFileSystemNode\.Name Property

Gets the name of the virtual file system node\.
The name is the last part of the path\.
For example, the name of the file "vfs://temp/file\.txt" is "file\.txt"\.
The name of the directory "vfs://temp" is "temp"\.

```csharp
string Name { get; }
```

#### Property Value
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')