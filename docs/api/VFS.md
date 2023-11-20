#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFS Class

Constants used by the Virtual File System.

```csharp
public class VFS :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,
System.IEquatable<Atypical.VirtualFileSystem.Core.VFS>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VFS

Implements [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFS()](VFS.VFS().md 'Atypical.VirtualFileSystem.Core.VFS.VFS()') | Initializes a new instance of the [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS') class. |

| Fields | |
| :--- | :--- |
| [DIRECTORY_SEPARATOR](VFS.DIRECTORY_SEPARATOR.md 'Atypical.VirtualFileSystem.Core.VFS.DIRECTORY_SEPARATOR') | The directory separator.<br/>This is the character used to separate directory names. |
| [ROOT_PATH](VFS.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFS.ROOT_PATH') | The root path.<br/>This is the path used to identify the root directory. |

| Properties | |
| :--- | :--- |
| [Index](VFS.Index.md 'Atypical.VirtualFileSystem.Core.VFS.Index') | Gets the file index of the file system.<br/>Basically, this is a dictionary that maps file paths to file nodes.<br/>This is useful for quickly finding a file node by its path. |
| [Root](VFS.Root.md 'Atypical.VirtualFileSystem.Core.VFS.Root') | Gets the root directory of the file system.<br/>This is the entry point for all operations on the file system. |

| Methods | |
| :--- | :--- |
| [CreateDirectory(VFSDirectoryPath)](VFS.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateDirectory(string)](VFS.CreateDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(string)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateFile(VFSFilePath, string)](VFS.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |
| [CreateFile(string, string)](VFS.CreateFile(string,string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateFile(string, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |
| [DeleteDirectory(VFSDirectoryPath)](VFS.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteDirectory(string)](VFS.DeleteDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(string)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(VFSFilePath)](VFS.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteFile(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Deletes a file node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(string)](VFS.DeleteFile(string).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteFile(string)') | Deletes a file node at the specified path.<br/>The path must be absolute. |
| [FindDirectories()](VFS.FindDirectories().md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories()') | Finds all directory nodes. |
| [FindDirectories(Regex)](VFS.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex)') | Finds all directory nodes that match the specified regular expression.<br/>The regular expression must be relative to the root directory. |
| [FindFiles()](VFS.FindFiles().md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles()') | Finds all file nodes. |
| [FindFiles(Regex)](VFS.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Text.RegularExpressions.Regex)') | Finds all file nodes that match the specified regular expression. |
| [GetDirectory(VFSDirectoryPath)](VFS.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Gets a directory node by its path.<br/>The path must be absolute. |
| [GetDirectory(string)](VFS.GetDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(string)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetFile(VFSFilePath)](VFS.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetFile(string)](VFS.GetFile(string).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(string)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetRootPath()](VFS.GetRootPath().md 'Atypical.VirtualFileSystem.Core.VFS.GetRootPath()') | Gets the path of the root directory. |
| [GetTree()](VFS.GetTree().md 'Atypical.VirtualFileSystem.Core.VFS.GetTree()') | Gets the tree of the file system. |
| [IsEmpty()](VFS.IsEmpty().md 'Atypical.VirtualFileSystem.Core.VFS.IsEmpty()') | Indicates whether the file system is empty.<br/>This is the case if the root directory is empty. |
| [MoveFile(VFSFilePath, VFSFilePath)](VFS.MoveFile(VFSFilePath,VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath)') | Moves a file node from the source path to the destination path.<br/>Both paths must be absolute. |
| [MoveFile(string, string)](VFS.MoveFile(string,string).md 'Atypical.VirtualFileSystem.Core.VFS.MoveFile(string, string)') | Moves a file node from the source path to the destination path.<br/>Both paths must be absolute. |
| [RenameFile(VFSFilePath, string)](VFS.RenameFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFS.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)') | Renames a file node at the specified path.<br/>The path must be absolute. |
| [RenameFile(string, string)](VFS.RenameFile(string,string).md 'Atypical.VirtualFileSystem.Core.VFS.RenameFile(string, string)') | Renames a file node at the specified path.<br/>The path must be absolute. |
| [SelectDirectories(Func&lt;IDirectoryNode,bool&gt;)](VFS.SelectDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.VFS.SelectDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)') | Finds all directory nodes that match the specified predicate. |
| [ToString()](VFS.ToString().md 'Atypical.VirtualFileSystem.Core.VFS.ToString()') | Returns the index as an ASCII tree. |
| [TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetDirectory(string, IDirectoryNode)](VFS.TryGetDirectory(string,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](VFS.TryGetDirectory(string,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetFile(VFSFilePath, IFileNode)](VFS.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
| [TryGetFile(string, IFileNode)](VFS.TryGetFile(string,IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(string, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
