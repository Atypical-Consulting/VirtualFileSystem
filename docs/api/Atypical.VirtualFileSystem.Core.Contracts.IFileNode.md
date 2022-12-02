#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts')

## IFileNode Interface

Represents a file in a virtual file system.  
This is the base interface for all file types.

```csharp
public interface IFileNode :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [FileNode](Atypical.VirtualFileSystem.Core.Models.FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode')

Implements [IVirtualFileSystemNode](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')

| Properties | |
| :--- | :--- |
| [Content](Atypical.VirtualFileSystem.Core.Contracts.IFileNode.Content.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode.Content') | Gets the content of the file as a string.<br/>The encoding is in UTF-8. |
