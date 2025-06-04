#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode')

## IVirtualFileSystemNode\.Path Property

Gets the full path of the node\.
The path is the path from the root of the file system to the node\.
For example, the path of the node with the path "\./temp/file\.txt" is "\./temp/file\.txt"\.
The path of the node with the path "\./temp/" is "\./temp/"\.

```csharp
Atypical.VirtualFileSystem.Core.VFSPath Path { get; }
```

#### Property Value
[VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')  
The full path of the node\.