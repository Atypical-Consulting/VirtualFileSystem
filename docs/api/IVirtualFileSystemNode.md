#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts')

## IVirtualFileSystemNode Interface

Represents a node in a virtual file system\.
A node can be a file or a directory\.

```csharp
public interface IVirtualFileSystemNode
```

Derived  
↳ [BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode')  
↳ [IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')  
↳ [IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')  
↳ [IRootNode](IRootNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IRootNode')  
↳ [DirectoryNode](DirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.DirectoryNode')  
↳ [FileNode](FileNode.md 'Atypical\.VirtualFileSystem\.Core\.FileNode')  
↳ [IBinaryFileNode](IBinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.IBinaryFileNode')  
↳ [RootNode](RootNode.md 'Atypical\.VirtualFileSystem\.Core\.RootNode')  
↳ [VFSNode](VFSNode.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode')

| Properties | |
| :--- | :--- |
| [CreationTime](IVirtualFileSystemNode.CreationTime.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\.CreationTime') | Gets the creation time of the node\. |
| [IsDirectory](IVirtualFileSystemNode.IsDirectory.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\.IsDirectory') | Indicates whether the node is a directory\. |
| [IsFile](IVirtualFileSystemNode.IsFile.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\.IsFile') | Indicates whether the node is a file\. |
| [LastAccessTime](IVirtualFileSystemNode.LastAccessTime.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\.LastAccessTime') | Gets the last access time of the node\. |
| [LastWriteTime](IVirtualFileSystemNode.LastWriteTime.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\.LastWriteTime') | Gets the last write time of the node\. |
| [Name](IVirtualFileSystemNode.Name.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\.Name') | Gets the name of the virtual file system node\. The name is the last part of the path\. For example, the name of the file "vfs://temp/file\.txt" is "file\.txt"\. The name of the directory "vfs://temp" is "temp"\. |
| [Path](IVirtualFileSystemNode.Path.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode\.Path') | Gets the full path of the node\. The path is the path from the root of the file system to the node\. For example, the path of the node with the path "\./temp/file\.txt" is "\./temp/file\.txt"\. The path of the node with the path "\./temp/" is "\./temp/"\. |
