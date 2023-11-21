#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFS Class

Constants used by the Virtual File System.

```csharp
public class VFS :
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,
Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate,
Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete,
Atypical.VirtualFileSystem.Core.Contracts.IVFSMove,
Atypical.VirtualFileSystem.Core.Contracts.IVFSRename,
System.IEquatable<Atypical.VirtualFileSystem.Core.VFS>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VFS

Implements [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem'), [IVFSCreate](IVFSCreate.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate'), [IVFSDelete](IVFSDelete.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete'), [IVFSMove](IVFSMove.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove'), [IVFSRename](IVFSRename.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [VFS()](VFS.VFS().md 'Atypical.VirtualFileSystem.Core.VFS.VFS()') | Initializes a new instance of the [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS') class. |

| Fields | |
| :--- | :--- |
| [DIRECTORY_SEPARATOR](VFS.DIRECTORY_SEPARATOR.md 'Atypical.VirtualFileSystem.Core.VFS.DIRECTORY_SEPARATOR') | The directory separator.<br/>This is the character used to separate directory names. |
| [ROOT_PATH](VFS.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFS.ROOT_PATH') | The root path.<br/>This is the path used to identify the root directory. |

| Properties | |
| :--- | :--- |
| [Directories](VFS.Directories.md 'Atypical.VirtualFileSystem.Core.VFS.Directories') | Finds all directory nodes. |
| [Files](VFS.Files.md 'Atypical.VirtualFileSystem.Core.VFS.Files') | Finds all file nodes. |
| [Index](VFS.Index.md 'Atypical.VirtualFileSystem.Core.VFS.Index') | Gets the file index of the file system.<br/>Basically, this is a dictionary that maps file paths to file nodes.<br/>This is useful for quickly finding a file node by its path. |
| [IsEmpty](VFS.IsEmpty.md 'Atypical.VirtualFileSystem.Core.VFS.IsEmpty') | Indicates whether the file system is empty.<br/>This is the case if the root directory is empty. |
| [Root](VFS.Root.md 'Atypical.VirtualFileSystem.Core.VFS.Root') | Gets the root directory of the file system.<br/>This is the entry point for all operations on the file system. |
| [RootPath](VFS.RootPath.md 'Atypical.VirtualFileSystem.Core.VFS.RootPath') | Gets the path of the root directory. |

| Methods | |
| :--- | :--- |
| [FindDirectories(Func&lt;IDirectoryNode,bool&gt;)](VFS.FindDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)') | Finds all directory nodes that match the specified predicate. |
| [FindDirectories(Regex)](VFS.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex)') | Finds all directory nodes that match the specified regular expression.<br/>The regular expression must be relative to the root directory. |
| [FindFiles(Func&lt;IFileNode,bool&gt;)](VFS.FindFiles(Func_IFileNode,bool_).md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool>)') | Finds all file nodes that match the specified predicate. |
| [FindFiles(Regex)](VFS.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Text.RegularExpressions.Regex)') | Finds all file nodes that match the specified regular expression. |
| [GetDirectory(VFSDirectoryPath)](VFS.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Gets a directory node by its path.<br/>The path must be absolute. |
| [GetFile(VFSFilePath)](VFS.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetTree()](VFS.GetTree().md 'Atypical.VirtualFileSystem.Core.VFS.GetTree()') | Gets the tree of the file system. |
| [RenameDirectory(VFSDirectoryPath, string)](VFS.RenameDirectory(VFSDirectoryPath,string).md 'Atypical.VirtualFileSystem.Core.VFS.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, string)') | Renames a directory. |
| [ToString()](VFS.ToString().md 'Atypical.VirtualFileSystem.Core.VFS.ToString()') | Returns a string that represents the current object. |
| [TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetFile(VFSFilePath, IFileNode)](VFS.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |

| Events | |
| :--- | :--- |
| [DirectoryCreated](VFS.DirectoryCreated.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryCreated') | Event triggered when a directory is created. |
| [DirectoryDeleted](VFS.DirectoryDeleted.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryDeleted') | Event triggered when a directory is deleted. |
| [DirectoryMoved](VFS.DirectoryMoved.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryMoved') | Event triggered when a directory is moved. |
| [DirectoryRenamed](VFS.DirectoryRenamed.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryRenamed') | Event triggered when a directory is renamed. |
| [FileCreated](VFS.FileCreated.md 'Atypical.VirtualFileSystem.Core.VFS.FileCreated') | Event triggered when a file is created. |
| [FileDeleted](VFS.FileDeleted.md 'Atypical.VirtualFileSystem.Core.VFS.FileDeleted') | Event triggered when a file is deleted. |
| [FileMoved](VFS.FileMoved.md 'Atypical.VirtualFileSystem.Core.VFS.FileMoved') | Event triggered when a file is moved. |
| [FileRenamed](VFS.FileRenamed.md 'Atypical.VirtualFileSystem.Core.VFS.FileRenamed') | Event triggered when a file is renamed. |
