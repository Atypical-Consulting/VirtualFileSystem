#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts')

## IDirectoryNode Interface

Represents a directory in a virtual file system\.
This is an in\-memory representation of a directory\.
It is not a representation of a directory on a physical file system\.

```csharp
public interface IDirectoryNode : Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode
```

Derived  
&#8627; [IRootNode](IRootNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IRootNode')  
&#8627; [DirectoryNode](DirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.DirectoryNode')  
&#8627; [RootNode](RootNode.md 'Atypical\.VirtualFileSystem\.Core\.RootNode')

Implements [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode')

| Properties | |
| :--- | :--- |
| [Directories](IDirectoryNode.Directories.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\.Directories') | Gets the child directories of the node\. |
| [Files](IDirectoryNode.Files.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\.Files') | Gets the child files of the node\. |

| Methods | |
| :--- | :--- |
| [AddChild\(IVirtualFileSystemNode\)](IDirectoryNode.AddChild(IVirtualFileSystemNode).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\.AddChild\(Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\)') | x                 Adds a child node to the current directory\. |
| [RemoveChild\(IVirtualFileSystemNode\)](IDirectoryNode.RemoveChild(IVirtualFileSystemNode).md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\.RemoveChild\(Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\)') | Removes a child node from the current directory\. |
