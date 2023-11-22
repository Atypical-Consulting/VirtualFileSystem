#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IVirtualFileSystem Interface

Represents a virtual file system.  
This is the main entry point for all operations on the file system.  
You can get an instance of this interface by calling [CreateFileSystem()](IVirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.CreateFileSystem()').

```csharp
public interface IVirtualFileSystem :
Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate,
Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete,
Atypical.VirtualFileSystem.Core.Contracts.IVFSMove,
Atypical.VirtualFileSystem.Core.Contracts.IVFSRename
```

Derived  
&#8627; [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

Implements [IVFSCreate](IVFSCreate.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate'), [IVFSDelete](IVFSDelete.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete'), [IVFSMove](IVFSMove.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove'), [IVFSRename](IVFSRename.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename')

| Properties | |
| :--- | :--- |
| [ChangeHistory](IVirtualFileSystem.ChangeHistory.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.ChangeHistory') | Gets the change history of the file system. |
| [Directories](IVirtualFileSystem.Directories.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Directories') | Finds all directory nodes. |
| [Files](IVirtualFileSystem.Files.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Files') | Finds all file nodes. |
| [Index](IVirtualFileSystem.Index.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Index') | Gets the file index of the file system.<br/>Basically, this is a dictionary that maps file paths to file nodes.<br/>This is useful for quickly finding a file node by its path. |
| [IsEmpty](IVirtualFileSystem.IsEmpty.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.IsEmpty') | Indicates whether the file system is empty.<br/>This is the case if the root directory is empty. |
| [Root](IVirtualFileSystem.Root.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Root') | Gets the root directory of the file system.<br/>This is the entry point for all operations on the file system. |
| [RootPath](IVirtualFileSystem.RootPath.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.RootPath') | Gets the path of the root directory. |

| Methods | |
| :--- | :--- |
| [FindDirectories(Func&lt;IDirectoryNode,bool&gt;)](IVirtualFileSystem.FindDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)') | Finds all directory nodes that match the specified predicate. |
| [FindDirectories(Regex)](IVirtualFileSystem.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex)') | Finds all directory nodes that match the specified regular expression.<br/>The regular expression must be relative to the root directory. |
| [FindFiles(Func&lt;IFileNode,bool&gt;)](IVirtualFileSystem.FindFiles(Func_IFileNode,bool_).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool>)') | Finds all file nodes that match the specified predicate. |
| [FindFiles(Regex)](IVirtualFileSystem.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex)') | Finds all file nodes that match the specified regular expression. |
| [GetDirectory(VFSDirectoryPath)](IVirtualFileSystem.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Gets a directory node by its path.<br/>The path must be absolute. |
| [GetFile(VFSFilePath)](IVirtualFileSystem.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetTree()](IVirtualFileSystem.GetTree().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetTree()') | Gets the tree of the file system. |
| [TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetFile(VFSFilePath, IFileNode)](IVirtualFileSystem.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
