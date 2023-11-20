#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts')

## IVirtualFileSystem Interface

Represents a virtual file system.  
This is the main entry point for all operations on the file system.  
You can get an instance of this interface by calling [CreateFileSystem()](IVirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.CreateFileSystem()').

```csharp
public interface IVirtualFileSystem
```

Derived  
&#8627; [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

| Properties | |
| :--- | :--- |
| [Directories](IVirtualFileSystem.Directories.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Directories') | Finds all directory nodes. |
| [Files](IVirtualFileSystem.Files.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Files') | Finds all file nodes. |
| [Index](IVirtualFileSystem.Index.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Index') | Gets the file index of the file system.<br/>Basically, this is a dictionary that maps file paths to file nodes.<br/>This is useful for quickly finding a file node by its path. |
| [IsEmpty](IVirtualFileSystem.IsEmpty.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.IsEmpty') | Indicates whether the file system is empty.<br/>This is the case if the root directory is empty. |
| [Root](IVirtualFileSystem.Root.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Root') | Gets the root directory of the file system.<br/>This is the entry point for all operations on the file system. |
| [RootPath](IVirtualFileSystem.RootPath.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.RootPath') | Gets the path of the root directory. |

| Methods | |
| :--- | :--- |
| [CreateDirectory(VFSDirectoryPath)](IVirtualFileSystem.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateFile(VFSFilePath, string)](IVirtualFileSystem.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |
| [DeleteDirectory(VFSDirectoryPath)](IVirtualFileSystem.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(VFSFilePath)](IVirtualFileSystem.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Deletes a file node at the specified path.<br/>The path must be absolute. |
| [FindDirectories(Func&lt;IDirectoryNode,bool&gt;)](IVirtualFileSystem.FindDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)') | Finds all directory nodes that match the specified predicate. |
| [FindDirectories(Regex)](IVirtualFileSystem.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex)') | Finds all directory nodes that match the specified regular expression.<br/>The regular expression must be relative to the root directory. |
| [FindFiles(Func&lt;IFileNode,bool&gt;)](IVirtualFileSystem.FindFiles(Func_IFileNode,bool_).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool>)') | Finds all file nodes that match the specified predicate. |
| [FindFiles(Regex)](IVirtualFileSystem.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex)') | Finds all file nodes that match the specified regular expression. |
| [GetDirectory(VFSDirectoryPath)](IVirtualFileSystem.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Gets a directory node by its path.<br/>The path must be absolute. |
| [GetFile(VFSFilePath)](IVirtualFileSystem.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetTree()](IVirtualFileSystem.GetTree().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetTree()') | Gets the tree of the file system. |
| [MoveDirectory(VFSDirectoryPath, VFSDirectoryPath)](IVirtualFileSystem.MoveDirectory(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.MoveDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.VFSDirectoryPath)') | Moves a directory from one location to another. |
| [MoveFile(VFSFilePath, VFSFilePath)](IVirtualFileSystem.MoveFile(VFSFilePath,VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath)') | Moves a file node from the source path to the destination path.<br/>Both paths must be absolute. |
| [RenameFile(VFSFilePath, string)](IVirtualFileSystem.RenameFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)') | Renames a file node at the specified path.<br/>The path must be absolute. |
| [TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetFile(VFSFilePath, IFileNode)](IVirtualFileSystem.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
