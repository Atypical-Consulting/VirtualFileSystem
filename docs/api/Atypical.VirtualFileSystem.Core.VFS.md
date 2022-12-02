#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')

## VFS Class

Represents a virtual file system.  
This class cannot be inherited.

```csharp
public class VFS :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,
System.IEquatable<Atypical.VirtualFileSystem.Core.VFS>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VFS

Implements [IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFS()](Atypical.VirtualFileSystem.Core.VFS.VFS().md 'Atypical.VirtualFileSystem.Core.VFS.VFS()') | Initializes a new instance of the [VFS](Atypical.VirtualFileSystem.Core.VFS.md 'Atypical.VirtualFileSystem.Core.VFS') class. |

| Properties | |
| :--- | :--- |
| [Index](Atypical.VirtualFileSystem.Core.VFS.Index.md 'Atypical.VirtualFileSystem.Core.VFS.Index') | Gets the file index of the file system.<br/>Basically, this is a dictionary that maps file paths to file nodes.<br/>This is useful for quickly finding a file node by its path. |
| [IsEmpty](Atypical.VirtualFileSystem.Core.VFS.IsEmpty.md 'Atypical.VirtualFileSystem.Core.VFS.IsEmpty') | Indicates whether the file system is empty.<br/>This is the case if the root directory is empty. |
| [Root](Atypical.VirtualFileSystem.Core.VFS.Root.md 'Atypical.VirtualFileSystem.Core.VFS.Root') | Gets the root directory of the file system.<br/>This is the entry point for all operations on the file system. |

| Methods | |
| :--- | :--- |
| [CreateDirectory(VFSDirectoryPath)](Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateDirectory(string)](Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(string)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateFile(VFSFilePath, string)](Atypical.VirtualFileSystem.Core.VFS.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |
| [CreateFile(string, string)](Atypical.VirtualFileSystem.Core.VFS.CreateFile(string,string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateFile(string, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |
| [DeleteDirectory(VFSDirectoryPath)](Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteDirectory(string)](Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(string)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(VFSFilePath)](Atypical.VirtualFileSystem.Core.VFS.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)') | Deletes a file node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(string)](Atypical.VirtualFileSystem.Core.VFS.DeleteFile(string).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteFile(string)') | Deletes a file node at the specified path.<br/>The path must be absolute. |
| [FindDirectories()](Atypical.VirtualFileSystem.Core.VFS.FindDirectories().md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories()') | Finds all directory nodes. |
| [FindDirectories(Regex)](Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex)') | Finds all directory nodes that match the specified regular expression.<br/>The regular expression must be relative to the root directory. |
| [FindFiles()](Atypical.VirtualFileSystem.Core.VFS.FindFiles().md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles()') | Finds all file nodes. |
| [FindFiles(Regex)](Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Text.RegularExpressions.Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Text.RegularExpressions.Regex)') | Finds all file nodes that match the specified regular expression. |
| [GetBrothers(IVirtualFileSystemNode)](Atypical.VirtualFileSystem.Core.VFS.GetBrothers(Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode).md 'Atypical.VirtualFileSystem.Core.VFS.GetBrothers(Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode)') | Get all brothers of the node<br/>(all nodes on the same level including the node itself) |
| [GetDirectory(VFSDirectoryPath)](Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Gets a directory node by its path.<br/>The path must be absolute. |
| [GetDirectory(string)](Atypical.VirtualFileSystem.Core.VFS.GetDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(string)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetFile(VFSFilePath)](Atypical.VirtualFileSystem.Core.VFS.GetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetFile(string)](Atypical.VirtualFileSystem.Core.VFS.GetFile(string).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(string)') | Gets a file node by its path.<br/>The path must be absolute. |
| [ToString()](Atypical.VirtualFileSystem.Core.VFS.ToString().md 'Atypical.VirtualFileSystem.Core.VFS.ToString()') | Returns the index as an ASCII tree. |
| [TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).md#Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetDirectory(string, IDirectoryNode)](Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).md#Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetFile(VFSFilePath, IFileNode)](Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
| [TryGetFile(string, IFileNode)](Atypical.VirtualFileSystem.Core.VFS.TryGetFile(string,Atypical.VirtualFileSystem.Core.Contracts.IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(string, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
