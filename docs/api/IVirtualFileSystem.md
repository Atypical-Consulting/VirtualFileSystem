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
| [Index](IVirtualFileSystem.Index.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Index') | Gets the file index of the file system.<br/>Basically, this is a dictionary that maps file paths to file nodes.<br/>This is useful for quickly finding a file node by its path. |
| [Root](IVirtualFileSystem.Root.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Root') | Gets the root directory of the file system.<br/>This is the entry point for all operations on the file system. |

| Methods | |
| :--- | :--- |
| [CreateDirectory(VFSDirectoryPath)](IVirtualFileSystem.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateDirectory(string)](IVirtualFileSystem.CreateDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(string)') | Creates a directory node at the specified path.<br/>The path must be absolute. |
| [CreateFile(VFSFilePath, string)](IVirtualFileSystem.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |
| [CreateFile(string, string)](IVirtualFileSystem.CreateFile(string,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(string, string)') | Creates a file node at the specified path.<br/>The path must be absolute. |
| [DeleteDirectory(VFSDirectoryPath)](IVirtualFileSystem.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteDirectory(string)](IVirtualFileSystem.DeleteDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(string)') | Deletes a directory node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(VFSFilePath)](IVirtualFileSystem.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)') | Deletes a file node at the specified path.<br/>The path must be absolute. |
| [DeleteFile(string)](IVirtualFileSystem.DeleteFile(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(string)') | Deletes a file node at the specified path.<br/>The path must be absolute. |
| [FindDirectories()](IVirtualFileSystem.FindDirectories().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories()') | Finds all directory nodes. |
| [FindDirectories(Regex)](IVirtualFileSystem.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex)') | Finds all directory nodes that match the specified regular expression.<br/>The regular expression must be relative to the root directory. |
| [FindFiles()](IVirtualFileSystem.FindFiles().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles()') | Finds all file nodes. |
| [FindFiles(Regex)](IVirtualFileSystem.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex)') | Finds all file nodes that match the specified regular expression. |
| [GetDirectory(VFSDirectoryPath)](IVirtualFileSystem.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)') | Gets a directory node by its path.<br/>The path must be absolute. |
| [GetDirectory(string)](IVirtualFileSystem.GetDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(string)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetFile(VFSFilePath)](IVirtualFileSystem.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetFile(string)](IVirtualFileSystem.GetFile(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(string)') | Gets a file node by its path.<br/>The path must be absolute. |
| [GetRootPath()](IVirtualFileSystem.GetRootPath().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetRootPath()') | Gets the path of the root directory. |
| [IsEmpty()](IVirtualFileSystem.IsEmpty().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.IsEmpty()') | Indicates whether the file system is empty.<br/>This is the case if the root directory is empty. |
| [TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetDirectory(string, IDirectoryNode)](IVirtualFileSystem.TryGetDirectory(string,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)') | Try to get a directory node by its path.<br/>The path must be absolute.<br/>If the directory node does not exist, this method returns `false`<br/>and [directory](IVirtualFileSystem.TryGetDirectory(string,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory') is set to `null`. |
| [TryGetFile(VFSFilePath, IFileNode)](IVirtualFileSystem.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
| [TryGetFile(string, IFileNode)](IVirtualFileSystem.TryGetFile(string,IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(string, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)') | Try to get a file node by its path.<br/>The path must be absolute. |
