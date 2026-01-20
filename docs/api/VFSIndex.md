#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSIndex Class

Represents the index of the virtual file system\.

```csharp
public sealed class VFSIndex
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VFSIndex

### Remarks
The vfs index is a dictionary of vfs paths and vfs nodes\.
The vfs index is used to store the nodes of the virtual file system\.
The vfs index is sorted by the vfs paths\.
The vfs index is case insensitive\.
This class cannot be inherited\.

| Properties | |
| :--- | :--- |
| [Count](VFSIndex.Count.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.Count') | Gets the total count of nodes in the index\. |
| [Directories](VFSIndex.Directories.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.Directories') | Gets the directories in the index\. |
| [DirectoriesCount](VFSIndex.DirectoriesCount.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.DirectoriesCount') | Gets the count of directories in the index\. |
| [Files](VFSIndex.Files.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.Files') | Gets the files in the index\. |
| [FilesCount](VFSIndex.FilesCount.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.FilesCount') | Gets the count of files in the index\. |
| [IsEmpty](VFSIndex.IsEmpty.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.IsEmpty') | Gets a value indicating whether the index is empty\. |
| [Keys](VFSIndex.Keys.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.Keys') | Gets the keys of the raw index\. |
| [RawIndex](VFSIndex.RawIndex.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.RawIndex') | Gets the raw index of the virtual file system\. |
| [this\[VFSDirectoryPath\]](VFSIndex.this[VFSDirectoryPath].md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.this\[Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\]') | Gets or sets the node at the specified directory path\. |
| [this\[VFSFilePath\]](VFSIndex.this[VFSFilePath].md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.this\[Atypical\.VirtualFileSystem\.Core\.VFSFilePath\]') | Gets or sets the node at the specified file path\. |
| [Values](VFSIndex.Values.md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.Values') | Gets the values of the raw index\. |

| Methods | |
| :--- | :--- |
| [ContainsKey\(VFSPath\)](VFSIndex.ContainsKey(VFSPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.ContainsKey\(Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Determines whether the index contains the specified key\. |
| [GetDirectory\(VFSDirectoryPath\)](VFSIndex.GetDirectory(VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.GetDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Gets the directory node at the specified directory path\. |
| [GetFile\(VFSFilePath\)](VFSIndex.GetFile(VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.GetFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Gets the file node at the specified file path\. |
| [GetPathsStartingWith\(VFSDirectoryPath\)](VFSIndex.GetPathsStartingWith(VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.GetPathsStartingWith\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Gets the paths starting with the specified directory path\. |
| [Remove\(VFSPath\)](VFSIndex.Remove(VFSPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.Remove\(Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Removes the node with the specified key\. |
| [ToString\(\)](VFSIndex.ToString().md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.ToString\(\)') | Returns a string that represents the current object\. |
| [TryAdd\(VFSPath, IVirtualFileSystemNode\)](VFSIndex.TryAdd(VFSPath,IVirtualFileSystemNode).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.TryAdd\(Atypical\.VirtualFileSystem\.Core\.VFSPath, Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\)') | Tries to add the specified node to the index\. |
| [TryGetDirectory\(VFSDirectoryPath, IDirectoryNode\)](VFSIndex.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.TryGetDirectory\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\)') | Tries to get the directory node at the specified directory path\. |
| [TryGetFile\(VFSFilePath, IFileNode\)](VFSIndex.TryGetFile(VFSFilePath,IFileNode).md 'Atypical\.VirtualFileSystem\.Core\.VFSIndex\.TryGetFile\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode\)') | Tries to get the file node at the specified file path\. |
