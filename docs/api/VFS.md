#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFS Class

Constants used by the Virtual File System\.

```csharp
public record VFS : Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem, Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate, Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete, Atypical.VirtualFileSystem.Core.Contracts.IVFSMove, Atypical.VirtualFileSystem.Core.Contracts.IVFSRename, System.IEquatable<Atypical.VirtualFileSystem.Core.VFS>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VFS

Implements [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem'), [IVFSCreate](IVFSCreate.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSCreate'), [IVFSDelete](IVFSDelete.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSDelete'), [IVFSMove](IVFSMove.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSMove'), [IVFSRename](IVFSRename.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVFSRename'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [VFS\(\)](VFS.VFS().md 'Atypical\.VirtualFileSystem\.Core\.VFS\.VFS\(\)') | Initializes a new instance of the [VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS') class\. |

| Fields | |
| :--- | :--- |
| [DIRECTORY\_SEPARATOR](VFS.DIRECTORY_SEPARATOR.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.DIRECTORY\_SEPARATOR') | The directory separator\. This is the character used to separate directory names\. |
| [ROOT\_PATH](VFS.ROOT_PATH.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.ROOT\_PATH') | The root path\. This is the path used to identify the root directory\. |

| Properties | |
| :--- | :--- |
| [ChangeHistory](VFS.ChangeHistory.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.ChangeHistory') | Gets the change history of the file system\. |
| [Directories](VFS.Directories.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.Directories') | Finds all directory nodes\. |
| [Files](VFS.Files.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.Files') | Finds all file nodes\. |
| [Index](VFS.Index.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.Index') | Gets the file index of the file system\. Basically, this is a dictionary that maps file paths to file nodes\. This is useful for quickly finding a file node by its path\. |
| [IsEmpty](VFS.IsEmpty.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.IsEmpty') | Indicates whether the file system is empty\. This is the case if the root directory is empty\. |
| [Root](VFS.Root.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.Root') | Gets the root directory of the file system\. This is the entry point for all operations on the file system\. |
| [RootPath](VFS.RootPath.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.RootPath') | Gets the path of the root directory\. |

| Methods | |
| :--- | :--- |
| [CreateDirectory\(VFSDirectoryPath\)](VFS.CreateDirectory(VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.CreateDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Creates a directory node at the specified path\. The path must be absolute\. |
| [CreateFile\(VFSFilePath, string\)](VFS.CreateFile(VFSFilePath,string).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.CreateFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, string\)') | Creates a file node at the specified path\. The path must be absolute\. |
| [DeleteDirectory\(VFSDirectoryPath\)](VFS.DeleteDirectory(VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.DeleteDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Deletes a directory node at the specified path\. The path must be absolute\. |
| [DeleteFile\(VFSFilePath\)](VFS.DeleteFile(VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.DeleteFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Deletes a file node at the specified path\. The path must be absolute\. |
| [FindDirectories\(Func&lt;IDirectoryNode,bool&gt;\)](VFS.FindDirectories.md#Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindDirectories\(System\.Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode,bool\>\)') | Finds all directory nodes that match the specified predicate\. |
| [FindDirectories\(Regex\)](VFS.FindDirectories.md#Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindDirectories\(System\.Text\.RegularExpressions\.Regex\)') | Finds all directory nodes that match the specified regular expression\. The regular expression must be relative to the root directory\. |
| [FindFiles\(Func&lt;IFileNode,bool&gt;\)](VFS.FindFiles.md#Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindFiles\(System\.Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode,bool\>\)') | Finds all file nodes that match the specified predicate\. |
| [FindFiles\(Regex\)](VFS.FindFiles.md#Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Text.RegularExpressions.Regex) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindFiles\(System\.Text\.RegularExpressions\.Regex\)') | Finds all file nodes that match the specified regular expression\. |
| [GetDirectory\(VFSDirectoryPath\)](VFS.GetDirectory(VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.GetDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Gets a directory node by its path\. The path must be absolute\. |
| [GetFile\(VFSFilePath\)](VFS.GetFile(VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.GetFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Gets a file node by its path\. The path must be absolute\. |
| [GetTree\(\)](VFS.GetTree().md 'Atypical\.VirtualFileSystem\.Core\.VFS\.GetTree\(\)') | Gets the tree of the file system\. |
| [MoveDirectory\(VFSDirectoryPath, VFSDirectoryPath\)](VFS.MoveDirectory(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.MoveDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Moves a directory from one location to another\. |
| [MoveFile\(VFSFilePath, VFSFilePath\)](VFS.MoveFile(VFSFilePath,VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.MoveFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Moves a file node from the source path to the destination path\. Both paths must be absolute\. |
| [RenameDirectory\(VFSDirectoryPath, string\)](VFS.RenameDirectory(VFSDirectoryPath,string).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.RenameDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, string\)') | Renames a directory\. |
| [RenameFile\(VFSFilePath, string\)](VFS.RenameFile(VFSFilePath,string).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.RenameFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, string\)') | Renames a file node at the specified path\. The path must be absolute\. |
| [ToString\(\)](VFS.ToString().md 'Atypical\.VirtualFileSystem\.Core\.VFS\.ToString\(\)') | Returns a string that represents the current object\. |
| [TryGetDirectory\(VFSDirectoryPath, IDirectoryNode\)](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.TryGetDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\)') | Try to get a directory node by its path\. The path must be absolute\. If the directory node does not exist, this method returns `false` and [directory](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md#Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode).directory 'Atypical\.VirtualFileSystem\.Core\.VFS\.TryGetDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\)\.directory') is set to `null`\. |
| [TryGetFile\(VFSFilePath, IFileNode\)](VFS.TryGetFile(VFSFilePath,IFileNode).md 'Atypical\.VirtualFileSystem\.Core\.VFS\.TryGetFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode\)') | Try to get a file node by its path\. The path must be absolute\. |

| Events | |
| :--- | :--- |
| [DirectoryCreated](VFS.DirectoryCreated.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.DirectoryCreated') | Event triggered when a directory is created\. |
| [DirectoryDeleted](VFS.DirectoryDeleted.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.DirectoryDeleted') | Event triggered when a directory is deleted\. |
| [DirectoryMoved](VFS.DirectoryMoved.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.DirectoryMoved') | Event triggered when a directory is moved\. |
| [DirectoryRenamed](VFS.DirectoryRenamed.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.DirectoryRenamed') | Event triggered when a directory is renamed\. |
| [FileCreated](VFS.FileCreated.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.FileCreated') | Event triggered when a file is created\. |
| [FileDeleted](VFS.FileDeleted.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.FileDeleted') | Event triggered when a file is deleted\. |
| [FileMoved](VFS.FileMoved.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.FileMoved') | Event triggered when a file is moved\. |
| [FileRenamed](VFS.FileRenamed.md 'Atypical\.VirtualFileSystem\.Core\.VFS\.FileRenamed') | Event triggered when a file is renamed\. |
