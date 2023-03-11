#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')

## Atypical.VirtualFileSystem.Core Assembly
### Namespaces

<a name='Atypical.VirtualFileSystem.Core'></a>

## Atypical.VirtualFileSystem.Core Namespace
- **[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')** `Class` Represents a virtual file system.  
  This class cannot be inherited.
  - **[VFS()](VFS.VFS().md 'Atypical.VirtualFileSystem.Core.VFS.VFS()')** `Constructor` Initializes a new instance of the [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS') class.
  - **[Index](VFS.Index.md 'Atypical.VirtualFileSystem.Core.VFS.Index')** `Property` Gets the file index of the file system.  
    Basically, this is a dictionary that maps file paths to file nodes.  
    This is useful for quickly finding a file node by its path.
  - **[Root](VFS.Root.md 'Atypical.VirtualFileSystem.Core.VFS.Root')** `Property` Gets the root directory of the file system.  
    This is the entry point for all operations on the file system.
  - **[CreateDirectory(VFSDirectoryPath)](VFS.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Method` Creates a directory node at the specified path.  
    The path must be absolute.
  - **[CreateDirectory(string)](VFS.CreateDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(string)')** `Method` Creates a directory node at the specified path.  
    The path must be absolute.
  - **[CreateFile(VFSFilePath, string)](VFS.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, string)')** `Method` Creates a file node at the specified path.  
    The path must be absolute.
  - **[CreateFile(string, string)](VFS.CreateFile(string,string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateFile(string, string)')** `Method` Creates a file node at the specified path.  
    The path must be absolute.
  - **[DeleteDirectory(VFSDirectoryPath)](VFS.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Method` Deletes a directory node at the specified path.  
    The path must be absolute.
  - **[DeleteDirectory(string)](VFS.DeleteDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(string)')** `Method` Deletes a directory node at the specified path.  
    The path must be absolute.
  - **[DeleteFile(VFSFilePath)](VFS.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)')** `Method` Deletes a file node at the specified path.  
    The path must be absolute.
  - **[DeleteFile(string)](VFS.DeleteFile(string).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteFile(string)')** `Method` Deletes a file node at the specified path.  
    The path must be absolute.
  - **[FindDirectories()](VFS.FindDirectories().md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories()')** `Method` Finds all directory nodes.
  - **[FindDirectories(Regex)](VFS.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex)')** `Method` Finds all directory nodes that match the specified regular expression.  
    The regular expression must be relative to the root directory.
  - **[FindFiles()](VFS.FindFiles().md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles()')** `Method` Finds all file nodes.
  - **[FindFiles(Regex)](VFS.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Text.RegularExpressions.Regex)')** `Method` Finds all file nodes that match the specified regular expression.
  - **[GetDirectory(VFSDirectoryPath)](VFS.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Method` Gets a directory node by its path.  
    The path must be absolute.
  - **[GetDirectory(string)](VFS.GetDirectory(string).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(string)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetFile(VFSFilePath)](VFS.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetFile(string)](VFS.GetFile(string).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(string)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetRootPath()](VFS.GetRootPath().md 'Atypical.VirtualFileSystem.Core.VFS.GetRootPath()')** `Method` Gets the path of the root directory.
  - **[GetTree()](VFS.GetTree().md 'Atypical.VirtualFileSystem.Core.VFS.GetTree()')** `Method` Gets the tree of the file system.
  - **[IsEmpty()](VFS.IsEmpty().md 'Atypical.VirtualFileSystem.Core.VFS.IsEmpty()')** `Method` Indicates whether the file system is empty.  
    This is the case if the root directory is empty.
  - **[SelectDirectories(Func&lt;IDirectoryNode,bool&gt;)](VFS.SelectDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.VFS.SelectDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)')** `Method` Finds all directory nodes that match the specified predicate.
  - **[ToString()](VFS.ToString().md 'Atypical.VirtualFileSystem.Core.VFS.ToString()')** `Method` Returns the index as an ASCII tree.
  - **[TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Try to get a directory node by its path.  
    The path must be absolute.  
    If the directory node does not exist, this method returns `false`  
    and directory is set to `null`.
  - **[TryGetDirectory(string, IDirectoryNode)](VFS.TryGetDirectory(string,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Try to get a directory node by its path.  
    The path must be absolute.  
    If the directory node does not exist, this method returns `false`  
    and directory is set to `null`.
  - **[TryGetFile(VFSFilePath, IFileNode)](VFS.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Try to get a file node by its path.  
    The path must be absolute.
  - **[TryGetFile(string, IFileNode)](VFS.TryGetFile(string,IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(string, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Try to get a file node by its path.  
    The path must be absolute.
- **[VFSConstants](VFSConstants.md 'Atypical.VirtualFileSystem.Core.VFSConstants')** `Class` Constants used by the Virtual File System.
  - **[DIRECTORY_SEPARATOR](VFSConstants.DIRECTORY_SEPARATOR.md 'Atypical.VirtualFileSystem.Core.VFSConstants.DIRECTORY_SEPARATOR')** `Field` The directory separator.  
    This is the character used to separate directory names.
  - **[ROOT_PATH](VFSConstants.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFSConstants.ROOT_PATH')** `Field` The root path.  
    This is the path used to identify the root directory.
  - **[STR_INDENT_CLEAR](VFSConstants.STR_INDENT_CLEAR.md 'Atypical.VirtualFileSystem.Core.VFSConstants.STR_INDENT_CLEAR')** `Field` The string indent clear.  
    A 4 characters string used by a string builder to indent a line.
  - **[STR_INDENT_ENTRY_LAST](VFSConstants.STR_INDENT_ENTRY_LAST.md 'Atypical.VirtualFileSystem.Core.VFSConstants.STR_INDENT_ENTRY_LAST')** `Field` The string indent entry last.  
    A 4 characters string used by a string builder to indent a line which is the last one.
  - **[STR_INDENT_ENTRY_MIDDLE](VFSConstants.STR_INDENT_ENTRY_MIDDLE.md 'Atypical.VirtualFileSystem.Core.VFSConstants.STR_INDENT_ENTRY_MIDDLE')** `Field` The string indent entry middle.  
    A 4 characters string used by a string builder to indent a line which is not the last one.
  - **[STR_INDENT_FILL](VFSConstants.STR_INDENT_FILL.md 'Atypical.VirtualFileSystem.Core.VFSConstants.STR_INDENT_FILL')** `Field` The string indent entry fill.  
    A 4 characters string used by a string builder to indent a line which is not the last one.
- **[VFSIndex](VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex')** `Class` Represents the index of the virtual file system.  
  - a vfs index is a dictionary of vfs paths and vfs nodes  
  - the vfs index is used to store the nodes of the virtual file system  
  This class cannot be inherited.
  - **[VFSIndex()](VFSIndex.VFSIndex().md 'Atypical.VirtualFileSystem.Core.VFSIndex.VFSIndex()')** `Constructor` Initializes a new instance of the [VFSIndex](VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex') class.  
    - the vfs index is a dictionary of vfs paths and vfs nodes  
    - the vfs index is used to store the nodes of the virtual file system  
    - the vfs index is sorted by the vfs paths  
    - the vfs index is case insensitive
- **[VirtualFileSystemFactory](VirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory')** `Class` Represents a factory for creating [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem') instances.
  - **[VirtualFileSystemFactory()](VirtualFileSystemFactory.VirtualFileSystemFactory().md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory.VirtualFileSystemFactory()')** `Constructor` Initializes a new instance of the [VirtualFileSystemFactory](VirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory') class.
  - **[CreateFileSystem()](VirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory.CreateFileSystem()')** `Method` Creates a new instance of [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem').

<a name='Atypical.VirtualFileSystem.Core.Abstractions'></a>

## Atypical.VirtualFileSystem.Core.Abstractions Namespace
- **[VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode')** `Class` Represents a node in a virtual file system.  
  A node can be a file or a directory.
  - **[VFSNode(VFSPath)](VFSNode.VFSNode(VFSPath).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.VFSNode(Atypical.VirtualFileSystem.Core.Abstractions.VFSPath)')** `Constructor` Initializes a new instance of the [VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode') class.  
    This constructor is used by derived classes.
  - **[CreationTime](VFSNode.CreationTime.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.CreationTime')** `Property` Gets the creation time of the node.
  - **[IsDirectory](VFSNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.IsDirectory')** `Property` Indicates whether the node is a directory.
  - **[IsFile](VFSNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.IsFile')** `Property` Indicates whether the node is a file.
  - **[LastAccessTime](VFSNode.LastAccessTime.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.LastAccessTime')** `Property` Gets the last access time of the node.
  - **[LastWriteTime](VFSNode.LastWriteTime.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.LastWriteTime')** `Property` Gets the last write time of the node.
  - **[Path](VFSNode.Path.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode.Path')** `Property` Gets the creation time of the node.
- **[VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')** `Class` Represents a file system entry (file or directory) in the virtual file system.
  - **[VFSPath(string)](VFSPath.VFSPath(string).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.VFSPath(string)')** `Constructor` Creates a new instance of [VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath').
  - **[VFSPathRegex](VFSPath.VFSPathRegex.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.VFSPathRegex')** `Field` Regex for matching a valid file system path.
  - **[Depth](VFSPath.Depth.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Depth')** `Property` Gets the depth of the file system entry.  
    The root directory has a depth of 0.  
    The depth of a file is the depth of its parent directory plus one.  
    The depth of a directory is the depth of its parent directory plus one.
  - **[HasParent](VFSPath.HasParent.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.HasParent')** `Property` Indicates whether the path has a parent directory.
  - **[IsRoot](VFSPath.IsRoot.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.IsRoot')** `Property` Gets a value indicating whether the directory is the root directory.
  - **[Name](VFSPath.Name.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Name')** `Property` Gets the name of the file system entry.  
    The name of the root directory is [ROOT_PATH](VFSConstants.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFSConstants.ROOT_PATH').  
    The name of a file is the name of the file with its extension.
  - **[Parent](VFSPath.Parent.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Parent')** `Property` Gets the path of the parent directory.
  - **[Value](VFSPath.Value.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Value')** `Property` Gets the path of the file system entry with the VFS prefix.
  - **[Equals(VFSPath)](VFSPath.Equals(VFSPath).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.Equals(Atypical.VirtualFileSystem.Core.Abstractions.VFSPath)')** `Method` Indicates whether the current object is equal to another object of the same type.
  - **[GetAbsoluteParentPath(int)](VFSPath.GetAbsoluteParentPath(int).md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetAbsoluteParentPath(int)')** `Method` Gets the absolute path of the parent directory with depth depthFromRoot.  
    The root directory has a depth of 0.  
    The depth of a file is the depth of its parent directory plus one.  
    The depth of a directory is the depth of its parent directory plus one.
  - **[GetHashCode()](VFSPath.GetHashCode().md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.GetHashCode()')** `Method` Serves as the default hash function.

<a name='Atypical.VirtualFileSystem.Core.Contracts'></a>

## Atypical.VirtualFileSystem.Core.Contracts Namespace
- **[IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')** `Interface` Represents a directory in a virtual file system.  
  This is an in-memory representation of a directory.  
  It is not a representation of a directory on a physical file system.
  - **[Directories](IDirectoryNode.Directories.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.Directories')** `Property` Gets the child directories of the node.
  - **[Files](IDirectoryNode.Files.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.Files')** `Property` Gets the child files of the node.
  - **[AddChild(IDirectoryNode)](IDirectoryNode.AddChild(IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Adds a child directory to the current directory.
  - **[AddChild(IFileNode)](IDirectoryNode.AddChild(IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Adds a child file to the current directory.
- **[IFileNode](IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')** `Interface` Represents a file in a virtual file system.  
  This is the base interface for all file types.
  - **[Content](IFileNode.Content.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode.Content')** `Property` Gets the content of the file as a string.  
    The encoding is in UTF-8.
- **[IRootNode](IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode')** `Interface` Represents the root of a virtual file system.  
  This is the entry point for all operations on the file system.
- **[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')** `Interface` Represents a virtual file system.  
  This is the main entry point for all operations on the file system.  
  You can get an instance of this interface by calling [CreateFileSystem()](IVirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.CreateFileSystem()').
  - **[Index](IVirtualFileSystem.Index.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Index')** `Property` Gets the file index of the file system.  
    Basically, this is a dictionary that maps file paths to file nodes.  
    This is useful for quickly finding a file node by its path.
  - **[Root](IVirtualFileSystem.Root.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Root')** `Property` Gets the root directory of the file system.  
    This is the entry point for all operations on the file system.
  - **[CreateDirectory(VFSDirectoryPath)](IVirtualFileSystem.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Method` Creates a directory node at the specified path.  
    The path must be absolute.
  - **[CreateDirectory(string)](IVirtualFileSystem.CreateDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateDirectory(string)')** `Method` Creates a directory node at the specified path.  
    The path must be absolute.
  - **[CreateFile(VFSFilePath, string)](IVirtualFileSystem.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, string)')** `Method` Creates a file node at the specified path.  
    The path must be absolute.
  - **[CreateFile(string, string)](IVirtualFileSystem.CreateFile(string,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.CreateFile(string, string)')** `Method` Creates a file node at the specified path.  
    The path must be absolute.
  - **[DeleteDirectory(VFSDirectoryPath)](IVirtualFileSystem.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Method` Deletes a directory node at the specified path.  
    The path must be absolute.
  - **[DeleteDirectory(string)](IVirtualFileSystem.DeleteDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteDirectory(string)')** `Method` Deletes a directory node at the specified path.  
    The path must be absolute.
  - **[DeleteFile(VFSFilePath)](IVirtualFileSystem.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)')** `Method` Deletes a file node at the specified path.  
    The path must be absolute.
  - **[DeleteFile(string)](IVirtualFileSystem.DeleteFile(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.DeleteFile(string)')** `Method` Deletes a file node at the specified path.  
    The path must be absolute.
  - **[FindDirectories()](IVirtualFileSystem.FindDirectories().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories()')** `Method` Finds all directory nodes.
  - **[FindDirectories(Regex)](IVirtualFileSystem.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex)')** `Method` Finds all directory nodes that match the specified regular expression.  
    The regular expression must be relative to the root directory.
  - **[FindFiles()](IVirtualFileSystem.FindFiles().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles()')** `Method` Finds all file nodes.
  - **[FindFiles(Regex)](IVirtualFileSystem.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex)')** `Method` Finds all file nodes that match the specified regular expression.
  - **[GetDirectory(VFSDirectoryPath)](IVirtualFileSystem.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Method` Gets a directory node by its path.  
    The path must be absolute.
  - **[GetDirectory(string)](IVirtualFileSystem.GetDirectory(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(string)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetFile(VFSFilePath)](IVirtualFileSystem.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetFile(string)](IVirtualFileSystem.GetFile(string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(string)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetRootPath()](IVirtualFileSystem.GetRootPath().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetRootPath()')** `Method` Gets the path of the root directory.
  - **[GetTree()](IVirtualFileSystem.GetTree().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetTree()')** `Method` Gets the tree of the file system.
  - **[IsEmpty()](IVirtualFileSystem.IsEmpty().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.IsEmpty()')** `Method` Indicates whether the file system is empty.  
    This is the case if the root directory is empty.
  - **[SelectDirectories(Func&lt;IDirectoryNode,bool&gt;)](IVirtualFileSystem.SelectDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.SelectDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)')** `Method` Finds all directory nodes that match the specified predicate.
  - **[TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Try to get a directory node by its path.  
    The path must be absolute.  
    If the directory node does not exist, this method returns `false`  
    and directory is set to `null`.
  - **[TryGetDirectory(string, IDirectoryNode)](IVirtualFileSystem.TryGetDirectory(string,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(string, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Try to get a directory node by its path.  
    The path must be absolute.  
    If the directory node does not exist, this method returns `false`  
    and directory is set to `null`.
  - **[TryGetFile(VFSFilePath, IFileNode)](IVirtualFileSystem.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Try to get a file node by its path.  
    The path must be absolute.
  - **[TryGetFile(string, IFileNode)](IVirtualFileSystem.TryGetFile(string,IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(string, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Try to get a file node by its path.  
    The path must be absolute.
- **[IVirtualFileSystemFactory](IVirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory')** `Interface` Represents a factory for creating [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem') instances.  
  This interface is implemented by the [VirtualFileSystemFactory](VirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory') class.
  - **[CreateFileSystem()](IVirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.CreateFileSystem()')** `Method` Creates a new instance of [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem').
- **[IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode')** `Interface` Represents a node in a virtual file system.  
  A node can be a file or a directory.
  - **[CreationTime](IVirtualFileSystemNode.CreationTime.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.CreationTime')** `Property` Gets the creation time of the node.
  - **[IsDirectory](IVirtualFileSystemNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.IsDirectory')** `Property` Indicates whether the node is a directory.
  - **[IsFile](IVirtualFileSystemNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.IsFile')** `Property` Indicates whether the node is a file.
  - **[LastAccessTime](IVirtualFileSystemNode.LastAccessTime.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.LastAccessTime')** `Property` Gets the last access time of the node.
  - **[LastWriteTime](IVirtualFileSystemNode.LastWriteTime.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.LastWriteTime')** `Property` Gets the last write time of the node.
  - **[Name](IVirtualFileSystemNode.Name.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Name')** `Property` Gets the name of the virtual file system node.  
    The name is the last part of the path.  
    For example, the name of the file "vfs://temp/file.txt" is "file.txt".  
    The name of the directory "vfs://temp" is "temp".
  - **[Path](IVirtualFileSystemNode.Path.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.Path')** `Property` Gets the full path of the node.  
    The path is the path from the root of the file system to the node.  
    For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".  
    The path of the node with the path "./temp/" is "./temp/".

<a name='Atypical.VirtualFileSystem.Core.Exceptions'></a>

## Atypical.VirtualFileSystem.Core.Exceptions Namespace
- **[VFSException](VFSException.md 'Atypical.VirtualFileSystem.Core.Exceptions.VFSException')** `Class` Exception thrown by the VFS.
  - **[VFSException(string, Exception)](VFSException.VFSException(string,Exception).md 'Atypical.VirtualFileSystem.Core.Exceptions.VFSException.VFSException(string, System.Exception)')** `Constructor` Initializes a new instance of the [VFSException](VFSException.md 'Atypical.VirtualFileSystem.Core.Exceptions.VFSException') class with a message and an inner exception that is the cause  
    of this exception.
  - **[VFSException(string)](VFSException.VFSException(string).md 'Atypical.VirtualFileSystem.Core.Exceptions.VFSException.VFSException(string)')** `Constructor` Initializes a new instance of the [VFSException](VFSException.md 'Atypical.VirtualFileSystem.Core.Exceptions.VFSException') class with a message that describes the error.

<a name='Atypical.VirtualFileSystem.Core.Models'></a>

## Atypical.VirtualFileSystem.Core.Models Namespace
- **[DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode')** `Class` Represents a directory in the virtual file system.
  - **[DirectoryNode(VFSDirectoryPath)](DirectoryNode.DirectoryNode(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.DirectoryNode(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Constructor` Initializes a new instance of the [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode') class.  
    Creates a new directory node.  
    The directory is created with the current date and time as creation and last modification date.
  - **[Directories](DirectoryNode.Directories.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.Directories')** `Property` Gets the child directories of the node.
  - **[Files](DirectoryNode.Files.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.Files')** `Property` Gets the child files of the node.
  - **[IsDirectory](DirectoryNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.IsDirectory')** `Property` Indicates whether the node is a directory.
  - **[IsFile](DirectoryNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.IsFile')** `Property` Indicates whether the node is a file.
  - **[Path](DirectoryNode.Path.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.Path')** `Property` Gets the full path of the node.  
    The path is the path from the root of the file system to the node.  
    For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".  
    The path of the node with the path "./temp/" is "./temp/".
  - **[AddChild(IDirectoryNode)](DirectoryNode.AddChild(IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Adds a child directory to the current directory.
  - **[AddChild(IFileNode)](DirectoryNode.AddChild(IFileNode).md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Adds a child file to the current directory.
  - **[ToString()](DirectoryNode.ToString().md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode.ToString()')** `Method` Returns a string that represents the path of the directory.
- **[FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode')** `Class` Represents a file in the virtual file system.
  - **[FileNode(VFSFilePath, string)](FileNode.FileNode(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Models.FileNode.FileNode(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath, string)')** `Constructor` Initializes a new instance of the [FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.Models.FileNode') class.  
    Creates a new file node.  
    The file is created with the current date and time as creation and last modification date.
  - **[Content](FileNode.Content.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.Content')** `Property` Gets the content of the file as a string.  
    The encoding is in UTF-8.
  - **[IsDirectory](FileNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.IsDirectory')** `Property` Indicates whether the node is a directory.
  - **[IsFile](FileNode.IsFile.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.IsFile')** `Property` Indicates whether the node is a file.
  - **[Path](FileNode.Path.md 'Atypical.VirtualFileSystem.Core.Models.FileNode.Path')** `Property` Gets the full path of the node.  
    The path is the path from the root of the file system to the node.  
    For example, the path of the node with the path "./temp/file.txt" is "./temp/file.txt".  
    The path of the node with the path "./temp/" is "./temp/".
  - **[ToString()](FileNode.ToString().md 'Atypical.VirtualFileSystem.Core.Models.FileNode.ToString()')** `Method` Returns a string that represents the path of the file.
- **[RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode')** `Class` Represents the root directory of the virtual file system.
  - **[RootNode()](RootNode.RootNode().md 'Atypical.VirtualFileSystem.Core.Models.RootNode.RootNode()')** `Constructor` Initializes a new instance of the [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode') class.
  - **[ToString()](RootNode.ToString().md 'Atypical.VirtualFileSystem.Core.Models.RootNode.ToString()')** `Method` Returns a string that represents the current object.  
    For [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode') this is always the constant string <cref see="ROOT_PATH"/>.

<a name='Atypical.VirtualFileSystem.Core.Services'></a>

## Atypical.VirtualFileSystem.Core.Services Namespace
- **[ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Atypical.VirtualFileSystem.Core.Services.ServiceCollectionExtensions')** `Class` Extension methods for [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection').  
  This class is used to register the virtual file system in the dependency injection container.
  - **[AddVirtualFileSystem(this IServiceCollection)](ServiceCollectionExtensions.AddVirtualFileSystem(thisIServiceCollection).md 'Atypical.VirtualFileSystem.Core.Services.ServiceCollectionExtensions.AddVirtualFileSystem(this Microsoft.Extensions.DependencyInjection.IServiceCollection)')** `Method` Registers the virtual file system in the dependency injection container.

<a name='Atypical.VirtualFileSystem.Core.ValueObjects'></a>

## Atypical.VirtualFileSystem.Core.ValueObjects Namespace
- **[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath')** `Class` Represents a directory in the virtual file system.  
  A directory is a first-class citizen in the virtual file system.  
  It can contain files and other directories.
  - **[VFSDirectoryPath(string)](VFSDirectoryPath.VFSDirectoryPath(string).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.VFSDirectoryPath(string)')** `Constructor` Initializes a new instance of the [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath') class.  
    The file path is relative to the root of the virtual file system.
  - **[ToString()](VFSDirectoryPath.ToString().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.ToString()')** `Method` Returns a string that represents the current object.  
    The string representation of the directory path is the path itself.
  - **[implicit operator string(VFSDirectoryPath)](VFSDirectoryPath.implicitoperatorstring(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath.op_Implicit string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath)')** `Operator` Implicit conversion to string  
    This allows you to use a [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSDirectoryPath') as a string.
- **[VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath')** `Class` Represents a file system entry in the virtual file system.  
  A file is a first-class citizen in the virtual file system.
  - **[VFSFilePath(string)](VFSFilePath.VFSFilePath(string).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.VFSFilePath(string)')** `Constructor` Initializes a new instance of the [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath') class.  
    The file path is relative to the root of the virtual file system.
  - **[ToString()](VFSFilePath.ToString().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.ToString()')** `Method` Returns a string that represents the current object.  
    The file path is relative to the root of the virtual file system.
  - **[implicit operator string(VFSFilePath)](VFSFilePath.implicitoperatorstring(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath.op_Implicit string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath)')** `Operator` Implicit conversion to string  
    This allows you to use a [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSFilePath') as a string.
- **[VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath')** `Class` Represents the root directory of the virtual file system.
  - **[VFSRootPath()](VFSRootPath.VFSRootPath().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.VFSRootPath()')** `Constructor` Represents the root directory of the virtual file system.
  - **[ToString()](VFSRootPath.ToString().md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.ToString()')** `Method` Returns a string that represents the current object.  
    The string representation of the root directory is the constant [ROOT_PATH](VFSConstants.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFSConstants.ROOT_PATH').
  - **[implicit operator string(VFSRootPath)](VFSRootPath.implicitoperatorstring(VFSRootPath).md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath.op_Implicit string(Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath)')** `Operator` Implicit conversion to string  
    This allows you to use a [VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.ValueObjects.VFSRootPath') as a string.