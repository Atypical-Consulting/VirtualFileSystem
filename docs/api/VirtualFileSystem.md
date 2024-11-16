#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')

## Atypical.VirtualFileSystem.Core Assembly
### Namespaces

<a name='Atypical.VirtualFileSystem.Core'></a>

## Atypical.VirtualFileSystem.Core Namespace
- **[ChangeHistory](ChangeHistory.md 'Atypical.VirtualFileSystem.Core.ChangeHistory')** `Class` Represents a history of changes in a virtual file system.
  - **[ChangeHistory(IVirtualFileSystem)](ChangeHistory.ChangeHistory(IVirtualFileSystem).md 'Atypical.VirtualFileSystem.Core.ChangeHistory.ChangeHistory(Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem)')** `Constructor` Initializes a new instance of the [ChangeHistory](ChangeHistory.md 'Atypical.VirtualFileSystem.Core.ChangeHistory') class.
  - **[RedoStack](ChangeHistory.RedoStack.md 'Atypical.VirtualFileSystem.Core.ChangeHistory.RedoStack')** `Property` Gets the redo stack.
  - **[UndoStack](ChangeHistory.UndoStack.md 'Atypical.VirtualFileSystem.Core.ChangeHistory.UndoStack')** `Property` Gets the undo stack.
  - **[~ChangeHistory()](ChangeHistory.~ChangeHistory().md 'Atypical.VirtualFileSystem.Core.ChangeHistory.~ChangeHistory()')** `Method` Finalizes an instance of the [ChangeHistory](ChangeHistory.md 'Atypical.VirtualFileSystem.Core.ChangeHistory') class.
  - **[AddChange(VFSEventArgs)](ChangeHistory.AddChange(VFSEventArgs).md 'Atypical.VirtualFileSystem.Core.ChangeHistory.AddChange(Atypical.VirtualFileSystem.Core.VFSEventArgs)')** `Method` Adds a change to the history.
  - **[Dispose()](ChangeHistory.Dispose().md 'Atypical.VirtualFileSystem.Core.ChangeHistory.Dispose()')** `Method` Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
  - **[Dispose(bool)](ChangeHistory.Dispose(bool).md 'Atypical.VirtualFileSystem.Core.ChangeHistory.Dispose(bool)')** `Method` Releases the unmanaged resources used by the [ChangeHistory](ChangeHistory.md 'Atypical.VirtualFileSystem.Core.ChangeHistory') and optionally releases the managed resources.
  - **[OnChange(VFSEventArgs)](ChangeHistory.OnChange(VFSEventArgs).md 'Atypical.VirtualFileSystem.Core.ChangeHistory.OnChange(Atypical.VirtualFileSystem.Core.VFSEventArgs)')** `Method` Handles the change event from the virtual file system.
  - **[Redo()](ChangeHistory.Redo().md 'Atypical.VirtualFileSystem.Core.ChangeHistory.Redo()')** `Method` Redoes the most recent undone change.
  - **[Undo()](ChangeHistory.Undo().md 'Atypical.VirtualFileSystem.Core.ChangeHistory.Undo()')** `Method` Undoes the most recent change.
- **[DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.DirectoryNode')** `Class` Represents a directory in the virtual file system.
  - **[DirectoryNode(VFSDirectoryPath)](DirectoryNode.DirectoryNode(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.DirectoryNode.DirectoryNode(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Constructor` Initializes a new instance of the [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.DirectoryNode') class.  
    Creates a new directory node.  
    The directory is created with the current date and time as creation and last modification date.
  - **[Directories](DirectoryNode.Directories.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.Directories')** `Property` Gets the child directories of the node.
  - **[Files](DirectoryNode.Files.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.Files')** `Property` Gets the child files of the node.
  - **[IsDirectory](DirectoryNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.IsDirectory')** `Property` Indicates whether the node is a directory.
  - **[IsFile](DirectoryNode.IsFile.md 'Atypical.VirtualFileSystem.Core.DirectoryNode.IsFile')** `Property` Indicates whether the node is a file.
  - **[AddChild(IVirtualFileSystemNode)](DirectoryNode.AddChild(IVirtualFileSystemNode).md 'Atypical.VirtualFileSystem.Core.DirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode)')** `Method` x  
                    Adds a child node to the current directory.
  - **[RemoveChild(IVirtualFileSystemNode)](DirectoryNode.RemoveChild(IVirtualFileSystemNode).md 'Atypical.VirtualFileSystem.Core.DirectoryNode.RemoveChild(Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode)')** `Method` Removes a child node from the current directory.
  - **[ToString()](DirectoryNode.ToString().md 'Atypical.VirtualFileSystem.Core.DirectoryNode.ToString()')** `Method` Returns a string that represents the path of the directory.
- **[FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.FileNode')** `Class` Represents a file in the virtual file system.
  - **[FileNode(VFSFilePath, string)](FileNode.FileNode(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.FileNode.FileNode(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')** `Constructor` Initializes a new instance of the [FileNode](FileNode.md 'Atypical.VirtualFileSystem.Core.FileNode') class.  
    Creates a new file node.  
    The file is created with the current date and time as creation and last modification date.
  - **[Content](FileNode.Content.md 'Atypical.VirtualFileSystem.Core.FileNode.Content')** `Property` Gets the content of the file as a string.  
    The encoding is in UTF-8.
  - **[IsDirectory](FileNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.FileNode.IsDirectory')** `Property` Indicates whether the node is a directory.
  - **[IsFile](FileNode.IsFile.md 'Atypical.VirtualFileSystem.Core.FileNode.IsFile')** `Property` Indicates whether the node is a file.
  - **[ToString()](FileNode.ToString().md 'Atypical.VirtualFileSystem.Core.FileNode.ToString()')** `Method` Returns a string that represents the path of the file.
- **[RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.RootNode')** `Class` Represents the root directory of the virtual file system.
  - **[RootNode()](RootNode.RootNode().md 'Atypical.VirtualFileSystem.Core.RootNode.RootNode()')** `Constructor` Initializes a new instance of the [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.RootNode') class.
  - **[ToString()](RootNode.ToString().md 'Atypical.VirtualFileSystem.Core.RootNode.ToString()')** `Method` Returns a string that represents the current object.  
    For [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.RootNode') this is always the constant string <cref see="ROOT_PATH"/>.
- **[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')** `Class` Constants used by the Virtual File System.
  - **[VFS()](VFS.VFS().md 'Atypical.VirtualFileSystem.Core.VFS.VFS()')** `Constructor` Initializes a new instance of the [VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS') class.
  - **[DIRECTORY_SEPARATOR](VFS.DIRECTORY_SEPARATOR.md 'Atypical.VirtualFileSystem.Core.VFS.DIRECTORY_SEPARATOR')** `Field` The directory separator.  
    This is the character used to separate directory names.
  - **[ROOT_PATH](VFS.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFS.ROOT_PATH')** `Field` The root path.  
    This is the path used to identify the root directory.
  - **[ChangeHistory](VFS.ChangeHistory.md 'Atypical.VirtualFileSystem.Core.VFS.ChangeHistory')** `Property` Gets the change history of the file system.
  - **[Directories](VFS.Directories.md 'Atypical.VirtualFileSystem.Core.VFS.Directories')** `Property` Finds all directory nodes.
  - **[Files](VFS.Files.md 'Atypical.VirtualFileSystem.Core.VFS.Files')** `Property` Finds all file nodes.
  - **[Index](VFS.Index.md 'Atypical.VirtualFileSystem.Core.VFS.Index')** `Property` Gets the file index of the file system.  
    Basically, this is a dictionary that maps file paths to file nodes.  
    This is useful for quickly finding a file node by its path.
  - **[IsEmpty](VFS.IsEmpty.md 'Atypical.VirtualFileSystem.Core.VFS.IsEmpty')** `Property` Indicates whether the file system is empty.  
    This is the case if the root directory is empty.
  - **[Root](VFS.Root.md 'Atypical.VirtualFileSystem.Core.VFS.Root')** `Property` Gets the root directory of the file system.  
    This is the entry point for all operations on the file system.
  - **[RootPath](VFS.RootPath.md 'Atypical.VirtualFileSystem.Core.VFS.RootPath')** `Property` Gets the path of the root directory.
  - **[CreateDirectory(VFSDirectoryPath)](VFS.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Creates a directory node at the specified path.  
    The path must be absolute.
  - **[CreateFile(VFSFilePath, string)](VFS.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFS.CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')** `Method` Creates a file node at the specified path.  
    The path must be absolute.
  - **[DeleteDirectory(VFSDirectoryPath)](VFS.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Deletes a directory node at the specified path.  
    The path must be absolute.
  - **[DeleteFile(VFSFilePath)](VFS.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.DeleteFile(Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Method` Deletes a file node at the specified path.  
    The path must be absolute.
  - **[FindDirectories(Func&lt;IDirectoryNode,bool&gt;)](VFS.FindDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)')** `Method` Finds all directory nodes that match the specified predicate.
  - **[FindDirectories(Regex)](VFS.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex)')** `Method` Finds all directory nodes that match the specified regular expression.  
    The regular expression must be relative to the root directory.
  - **[FindFiles(Func&lt;IFileNode,bool&gt;)](VFS.FindFiles(Func_IFileNode,bool_).md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool>)')** `Method` Finds all file nodes that match the specified predicate.
  - **[FindFiles(Regex)](VFS.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.VFS.FindFiles(System.Text.RegularExpressions.Regex)')** `Method` Finds all file nodes that match the specified regular expression.
  - **[GetDirectory(VFSDirectoryPath)](VFS.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Gets a directory node by its path.  
    The path must be absolute.
  - **[GetFile(VFSFilePath)](VFS.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetTree()](VFS.GetTree().md 'Atypical.VirtualFileSystem.Core.VFS.GetTree()')** `Method` Gets the tree of the file system.
  - **[MoveDirectory(VFSDirectoryPath, VFSDirectoryPath)](VFS.MoveDirectory(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFS.MoveDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Moves a directory from one location to another.
  - **[MoveFile(VFSFilePath, VFSFilePath)](VFS.MoveFile(VFSFilePath,VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFS.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Method` Moves a file node from the source path to the destination path.  
    Both paths must be absolute.
  - **[RenameDirectory(VFSDirectoryPath, string)](VFS.RenameDirectory(VFSDirectoryPath,string).md 'Atypical.VirtualFileSystem.Core.VFS.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, string)')** `Method` Renames a directory.
  - **[RenameFile(VFSFilePath, string)](VFS.RenameFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFS.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')** `Method` Renames a file node at the specified path.  
    The path must be absolute.
  - **[ToString()](VFS.ToString().md 'Atypical.VirtualFileSystem.Core.VFS.ToString()')** `Method` Returns a string that represents the current object.
  - **[TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](VFS.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Try to get a directory node by its path.  
    The path must be absolute.  
    If the directory node does not exist, this method returns `false`  
    and directory is set to `null`.
  - **[TryGetFile(VFSFilePath, IFileNode)](VFS.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.VFS.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Try to get a file node by its path.  
    The path must be absolute.
  - **[DirectoryCreated](VFS.DirectoryCreated.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryCreated')** `Event` Event triggered when a directory is created.
  - **[DirectoryDeleted](VFS.DirectoryDeleted.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryDeleted')** `Event` Event triggered when a directory is deleted.
  - **[DirectoryMoved](VFS.DirectoryMoved.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryMoved')** `Event` Event triggered when a directory is moved.
  - **[DirectoryRenamed](VFS.DirectoryRenamed.md 'Atypical.VirtualFileSystem.Core.VFS.DirectoryRenamed')** `Event` Event triggered when a directory is renamed.
  - **[FileCreated](VFS.FileCreated.md 'Atypical.VirtualFileSystem.Core.VFS.FileCreated')** `Event` Event triggered when a file is created.
  - **[FileDeleted](VFS.FileDeleted.md 'Atypical.VirtualFileSystem.Core.VFS.FileDeleted')** `Event` Event triggered when a file is deleted.
  - **[FileMoved](VFS.FileMoved.md 'Atypical.VirtualFileSystem.Core.VFS.FileMoved')** `Event` Event triggered when a file is moved.
  - **[FileRenamed](VFS.FileRenamed.md 'Atypical.VirtualFileSystem.Core.VFS.FileRenamed')** `Event` Event triggered when a file is renamed.
- **[VFSDirectoryCreatedArgs](VFSDirectoryCreatedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs')** `Class` Provides data for the DirectoryCreated event.
  - **[VFSDirectoryCreatedArgs(VFSDirectoryPath)](VFSDirectoryCreatedArgs.VFSDirectoryCreatedArgs(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs.VFSDirectoryCreatedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Constructor` Initializes a new instance of the [VFSDirectoryCreatedArgs](VFSDirectoryCreatedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs') class.
  - **[Message](VFSDirectoryCreatedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSDirectoryCreatedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSDirectoryCreatedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[Path](VFSDirectoryCreatedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs.Path')** `Property` Gets the path of the created directory.
  - **[Timestamp](VFSDirectoryCreatedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryCreatedArgs.Timestamp')** `Property` Gets the timestamp when the directory was created.
- **[VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs')** `Class` Provides data for the DirectoryDeleted event.
  - **[VFSDirectoryDeletedArgs(VFSDirectoryPath)](VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Constructor` Initializes a new instance of the [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs') class.
  - **[Message](VFSDirectoryDeletedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSDirectoryDeletedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSDirectoryDeletedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[Path](VFSDirectoryDeletedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.Path')** `Property` Gets the path of the deleted directory.
  - **[Timestamp](VFSDirectoryDeletedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.Timestamp')** `Property` Gets the timestamp when the directory was deleted.
- **[VFSDirectoryMovedArgs](VFSDirectoryMovedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs')** `Class` Provides data for the DirectoryMoved event.
  - **[VFSDirectoryMovedArgs(VFSDirectoryPath, VFSDirectoryPath)](VFSDirectoryMovedArgs.VFSDirectoryMovedArgs(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs.VFSDirectoryMovedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Constructor` Initializes a new instance of the [VFSDirectoryMovedArgs](VFSDirectoryMovedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs') class.
  - **[DestinationPath](VFSDirectoryMovedArgs.DestinationPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs.DestinationPath')** `Property` Gets the destination path of the moved directory.
  - **[Message](VFSDirectoryMovedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSDirectoryMovedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSDirectoryMovedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[SourcePath](VFSDirectoryMovedArgs.SourcePath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs.SourcePath')** `Property` Gets the source path of the moved directory.
  - **[Timestamp](VFSDirectoryMovedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryMovedArgs.Timestamp')** `Property` Gets the timestamp when the directory was moved.
- **[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath')** `Class` Represents a directory in the virtual file system.  
  A directory is a first-class citizen in the virtual file system.  
  It can contain files and other directories.
  - **[VFSDirectoryPath(string)](VFSDirectoryPath.VFSDirectoryPath(string).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath.VFSDirectoryPath(string)')** `Constructor` Initializes a new instance of the [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath') class.  
    The file path is relative to the root of the virtual file system.
  - **[ToString()](VFSDirectoryPath.ToString().md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath.ToString()')** `Method` Returns a string that represents the current object.  
    The string representation of the directory path is the path itself.
  - **[implicit operator VFSDirectoryPath(string)](VFSDirectoryPath.implicitoperatorVFSDirectoryPath(string).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath.op_Implicit Atypical.VirtualFileSystem.Core.VFSDirectoryPath(string)')** `Operator` Implicit conversion from string.  
    This allows you to use a string as a [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath').
  - **[implicit operator string(VFSDirectoryPath)](VFSDirectoryPath.implicitoperatorstring(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath.op_Implicit string(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Operator` Implicit conversion to string  
    This allows you to use a [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryPath') as a string.
- **[VFSDirectoryRenamedArgs](VFSDirectoryRenamedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs')** `Class` Provides data for the DirectoryRenamed event.
  - **[VFSDirectoryRenamedArgs(VFSDirectoryPath, string, string)](VFSDirectoryRenamedArgs.VFSDirectoryRenamedArgs(VFSDirectoryPath,string,string).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.VFSDirectoryRenamedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, string, string)')** `Constructor` Initializes a new instance of the [VFSDirectoryRenamedArgs](VFSDirectoryRenamedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs') class.
  - **[Message](VFSDirectoryRenamedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSDirectoryRenamedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSDirectoryRenamedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[NewName](VFSDirectoryRenamedArgs.NewName.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.NewName')** `Property` Gets the new name of the renamed file.
  - **[OldName](VFSDirectoryRenamedArgs.OldName.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.OldName')** `Property` Gets the old name of the renamed directory.
  - **[Path](VFSDirectoryRenamedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.Path')** `Property` Gets the old path of the renamed directory.
  - **[Timestamp](VFSDirectoryRenamedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.Timestamp')** `Property` Gets the timestamp when the directory was renamed.
- **[VFSEventArgs](VFSEventArgs.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs')** `Class` Represents the base class for all VFS event arguments.
  - **[Message](VFSEventArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSEventArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSEventArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[ToMarkup(string, object[])](VFSEventArgs.ToMarkup(string,object[]).md 'Atypical.VirtualFileSystem.Core.VFSEventArgs.ToMarkup(string, object[])')** `Method` Transforms a message into a markup message with the specified color.
- **[VFSFileCreatedArgs](VFSFileCreatedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs')** `Class` Provides data for the FileCreated event.
  - **[VFSFileCreatedArgs(VFSFilePath, string)](VFSFileCreatedArgs.VFSFileCreatedArgs(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs.VFSFileCreatedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')** `Constructor` Initializes a new instance of the [VFSFileCreatedArgs](VFSFileCreatedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs') class.
  - **[Content](VFSFileCreatedArgs.Content.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs.Content')** `Property` Gets the content of the created file.
  - **[Message](VFSFileCreatedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSFileCreatedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSFileCreatedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[Path](VFSFileCreatedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs.Path')** `Property` Gets the path of the created file.
  - **[Timestamp](VFSFileCreatedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSFileCreatedArgs.Timestamp')** `Property` Gets the timestamp when the file was created.
- **[VFSFileDeletedArgs](VFSFileDeletedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs')** `Class` Provides data for the FileDeleted event.
  - **[VFSFileDeletedArgs(VFSFilePath, string)](VFSFileDeletedArgs.VFSFileDeletedArgs(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.VFSFileDeletedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')** `Constructor` Initializes a new instance of the [VFSFileDeletedArgs](VFSFileDeletedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs') class.
  - **[Content](VFSFileDeletedArgs.Content.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Content')** `Property` Gets the content of the deleted file.
  - **[Message](VFSFileDeletedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSFileDeletedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSFileDeletedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[Path](VFSFileDeletedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Path')** `Property` Gets the path of the deleted file.
  - **[Timestamp](VFSFileDeletedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Timestamp')** `Property` Gets the timestamp when the file was deleted.
- **[VFSFileMovedArgs](VFSFileMovedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs')** `Class` Provides data for the FileMoved event.
  - **[VFSFileMovedArgs(VFSFilePath, VFSFilePath)](VFSFileMovedArgs.VFSFileMovedArgs(VFSFilePath,VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.VFSFileMovedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Constructor` Initializes a new instance of the [VFSFileMovedArgs](VFSFileMovedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs') class.
  - **[DestinationPath](VFSFileMovedArgs.DestinationPath.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.DestinationPath')** `Property` Gets the destination path of the moved file.
  - **[Message](VFSFileMovedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSFileMovedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSFileMovedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[SourcePath](VFSFileMovedArgs.SourcePath.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.SourcePath')** `Property` Gets the source path of the moved file.
  - **[Timestamp](VFSFileMovedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.Timestamp')** `Property` Gets the timestamp when the file was moved.
- **[VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath')** `Class` Represents a file system entry in the virtual file system.  
  A file is a first-class citizen in the virtual file system.
  - **[VFSFilePath(string)](VFSFilePath.VFSFilePath(string).md 'Atypical.VirtualFileSystem.Core.VFSFilePath.VFSFilePath(string)')** `Constructor` Initializes a new instance of the [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath') class.  
    The file path is relative to the root of the virtual file system.
  - **[ToString()](VFSFilePath.ToString().md 'Atypical.VirtualFileSystem.Core.VFSFilePath.ToString()')** `Method` Returns a string that represents the current object.  
    The file path is relative to the root of the virtual file system.
  - **[implicit operator VFSFilePath(string)](VFSFilePath.implicitoperatorVFSFilePath(string).md 'Atypical.VirtualFileSystem.Core.VFSFilePath.op_Implicit Atypical.VirtualFileSystem.Core.VFSFilePath(string)')** `Operator` Implicit conversion from string.  
    This allows you to use a string as a [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath').
  - **[implicit operator string(VFSFilePath)](VFSFilePath.implicitoperatorstring(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFSFilePath.op_Implicit string(Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Operator` Implicit conversion to string  
    This allows you to use a [VFSFilePath](VFSFilePath.md 'Atypical.VirtualFileSystem.Core.VFSFilePath') as a string.
- **[VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs')** `Class` Provides data for the FileRenamed event.
  - **[VFSFileRenamedArgs(VFSFilePath, string, string)](VFSFileRenamedArgs.VFSFileRenamedArgs(VFSFilePath,string,string).md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.VFSFileRenamedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath, string, string)')** `Constructor` Initializes a new instance of the [VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs') class.
  - **[Message](VFSFileRenamedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.Message')** `Property` Gets the message.
  - **[MessageTemplate](VFSFileRenamedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.MessageTemplate')** `Property` Gets the message template.
  - **[MessageWithMarkup](VFSFileRenamedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.MessageWithMarkup')** `Property` Gets the message with markup.
  - **[NewName](VFSFileRenamedArgs.NewName.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.NewName')** `Property` Gets the new name of the renamed file.
  - **[OldName](VFSFileRenamedArgs.OldName.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.OldName')** `Property` Gets the old name of the renamed file.
  - **[Path](VFSFileRenamedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.Path')** `Property` Gets the source path of the renamed file.
  - **[Timestamp](VFSFileRenamedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.Timestamp')** `Property` Gets the timestamp when the file was renamed.
- **[VFSIndex](VFSIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex')** `Class` Represents the index of the virtual file system.
  - **[Count](VFSIndex.Count.md 'Atypical.VirtualFileSystem.Core.VFSIndex.Count')** `Property` Gets the total count of nodes in the index.
  - **[Directories](VFSIndex.Directories.md 'Atypical.VirtualFileSystem.Core.VFSIndex.Directories')** `Property` Gets the directories in the index.
  - **[DirectoriesCount](VFSIndex.DirectoriesCount.md 'Atypical.VirtualFileSystem.Core.VFSIndex.DirectoriesCount')** `Property` Gets the count of directories in the index.
  - **[Files](VFSIndex.Files.md 'Atypical.VirtualFileSystem.Core.VFSIndex.Files')** `Property` Gets the files in the index.
  - **[FilesCount](VFSIndex.FilesCount.md 'Atypical.VirtualFileSystem.Core.VFSIndex.FilesCount')** `Property` Gets the count of files in the index.
  - **[IsEmpty](VFSIndex.IsEmpty.md 'Atypical.VirtualFileSystem.Core.VFSIndex.IsEmpty')** `Property` Gets a value indicating whether the index is empty.
  - **[Keys](VFSIndex.Keys.md 'Atypical.VirtualFileSystem.Core.VFSIndex.Keys')** `Property` Gets the keys of the raw index.
  - **[RawIndex](VFSIndex.RawIndex.md 'Atypical.VirtualFileSystem.Core.VFSIndex.RawIndex')** `Property` Gets the raw index of the virtual file system.
  - **[this[VFSDirectoryPath]](VFSIndex.this[VFSDirectoryPath].md 'Atypical.VirtualFileSystem.Core.VFSIndex.this[Atypical.VirtualFileSystem.Core.VFSDirectoryPath]')** `Property` Gets or sets the node at the specified directory path.
  - **[this[VFSFilePath]](VFSIndex.this[VFSFilePath].md 'Atypical.VirtualFileSystem.Core.VFSIndex.this[Atypical.VirtualFileSystem.Core.VFSFilePath]')** `Property` Gets or sets the node at the specified file path.
  - **[Values](VFSIndex.Values.md 'Atypical.VirtualFileSystem.Core.VFSIndex.Values')** `Property` Gets the values of the raw index.
  - **[ContainsKey(VFSPath)](VFSIndex.ContainsKey(VFSPath).md 'Atypical.VirtualFileSystem.Core.VFSIndex.ContainsKey(Atypical.VirtualFileSystem.Core.VFSPath)')** `Method` Determines whether the index contains the specified key.
  - **[GetDirectory(VFSDirectoryPath)](VFSIndex.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFSIndex.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Gets the directory node at the specified directory path.
  - **[GetFile(VFSFilePath)](VFSIndex.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFSIndex.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Method` Gets the file node at the specified file path.
  - **[GetPathsStartingWith(VFSDirectoryPath)](VFSIndex.GetPathsStartingWith(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.VFSIndex.GetPathsStartingWith(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Gets the paths starting with the specified directory path.
  - **[Remove(VFSPath)](VFSIndex.Remove(VFSPath).md 'Atypical.VirtualFileSystem.Core.VFSIndex.Remove(Atypical.VirtualFileSystem.Core.VFSPath)')** `Method` Removes the node with the specified key.
  - **[ToString()](VFSIndex.ToString().md 'Atypical.VirtualFileSystem.Core.VFSIndex.ToString()')** `Method` Returns a string that represents the current object.
  - **[TryAdd(VFSPath, IVirtualFileSystemNode)](VFSIndex.TryAdd(VFSPath,IVirtualFileSystemNode).md 'Atypical.VirtualFileSystem.Core.VFSIndex.TryAdd(Atypical.VirtualFileSystem.Core.VFSPath, Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode)')** `Method` Tries to add the specified node to the index.
  - **[TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](VFSIndex.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.VFSIndex.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Tries to get the directory node at the specified directory path.
  - **[TryGetFile(VFSFilePath, IFileNode)](VFSIndex.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.VFSIndex.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Tries to get the file node at the specified file path.
- **[VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.VFSNode')** `Class` Represents a node in a virtual file system.  
  A node can be a file or a directory.
  - **[VFSNode(VFSPath)](VFSNode.VFSNode(VFSPath).md 'Atypical.VirtualFileSystem.Core.VFSNode.VFSNode(Atypical.VirtualFileSystem.Core.VFSPath)')** `Constructor` Initializes a new instance of the [VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.VFSNode') class.  
    This constructor is used by derived classes.
  - **[CreationTime](VFSNode.CreationTime.md 'Atypical.VirtualFileSystem.Core.VFSNode.CreationTime')** `Property` Gets the creation time of the node.
  - **[IsDirectory](VFSNode.IsDirectory.md 'Atypical.VirtualFileSystem.Core.VFSNode.IsDirectory')** `Property` Indicates whether the node is a directory.
  - **[IsFile](VFSNode.IsFile.md 'Atypical.VirtualFileSystem.Core.VFSNode.IsFile')** `Property` Indicates whether the node is a file.
  - **[LastAccessTime](VFSNode.LastAccessTime.md 'Atypical.VirtualFileSystem.Core.VFSNode.LastAccessTime')** `Property` Gets the last access time of the node.
  - **[LastWriteTime](VFSNode.LastWriteTime.md 'Atypical.VirtualFileSystem.Core.VFSNode.LastWriteTime')** `Property` Gets the last write time of the node.
  - **[Path](VFSNode.Path.md 'Atypical.VirtualFileSystem.Core.VFSNode.Path')** `Property` Gets the creation time of the node.
  - **[UpdatePath(VFSPath)](VFSNode.UpdatePath(VFSPath).md 'Atypical.VirtualFileSystem.Core.VFSNode.UpdatePath(Atypical.VirtualFileSystem.Core.VFSPath)')** `Method` Updates the path of the node.
- **[VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.VFSPath')** `Class` Represents a file system entry (file or directory) in the virtual file system.
  - **[VFSPath(string)](VFSPath.VFSPath(string).md 'Atypical.VirtualFileSystem.Core.VFSPath.VFSPath(string)')** `Constructor` Creates a new instance of [VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.VFSPath').
  - **[Depth](VFSPath.Depth.md 'Atypical.VirtualFileSystem.Core.VFSPath.Depth')** `Property` Gets the depth of the file system entry.  
    The root directory has a depth of 0.  
    The depth of a file is the depth of its parent directory plus one.  
    The depth of a directory is the depth of its parent directory plus one.
  - **[HasParent](VFSPath.HasParent.md 'Atypical.VirtualFileSystem.Core.VFSPath.HasParent')** `Property` Indicates whether the path has a parent directory.
  - **[IsRoot](VFSPath.IsRoot.md 'Atypical.VirtualFileSystem.Core.VFSPath.IsRoot')** `Property` Gets a value indicating whether the directory is the root directory.
  - **[Name](VFSPath.Name.md 'Atypical.VirtualFileSystem.Core.VFSPath.Name')** `Property` Gets the name of the file system entry.  
    The name of the root directory is [ROOT_PATH](VFS.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFS.ROOT_PATH').  
    The name of a file is the name of the file with its extension.
  - **[Parent](VFSPath.Parent.md 'Atypical.VirtualFileSystem.Core.VFSPath.Parent')** `Property` Gets the path of the parent directory.
  - **[Value](VFSPath.Value.md 'Atypical.VirtualFileSystem.Core.VFSPath.Value')** `Property` Gets the path of the file system entry with the VFS prefix.
  - **[Equals(VFSPath)](VFSPath.Equals(VFSPath).md 'Atypical.VirtualFileSystem.Core.VFSPath.Equals(Atypical.VirtualFileSystem.Core.VFSPath)')** `Method` Indicates whether the current object is equal to another object of the same type.
  - **[GetAbsoluteParentPath(int)](VFSPath.GetAbsoluteParentPath(int).md 'Atypical.VirtualFileSystem.Core.VFSPath.GetAbsoluteParentPath(int)')** `Method` Gets the absolute path of the parent directory with depth depthFromRoot.  
    The root directory has a depth of 0.  
    The depth of a file is the depth of its parent directory plus one.  
    The depth of a directory is the depth of its parent directory plus one.
  - **[GetHashCode()](VFSPath.GetHashCode().md 'Atypical.VirtualFileSystem.Core.VFSPath.GetHashCode()')** `Method` Serves as the default hash function.
  - **[IsMatch(Regex)](VFSPath.IsMatch(Regex).md 'Atypical.VirtualFileSystem.Core.VFSPath.IsMatch(System.Text.RegularExpressions.Regex)')** `Method` Indicates whether the specified regular expression finds a match in the path.
  - **[StartsWith(string)](VFSPath.StartsWith(string).md 'Atypical.VirtualFileSystem.Core.VFSPath.StartsWith(string)')** `Method` Determines whether the path starts with the specified path.
- **[VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.VFSRootPath')** `Class` Represents the root directory of the virtual file system.
  - **[VFSRootPath()](VFSRootPath.VFSRootPath().md 'Atypical.VirtualFileSystem.Core.VFSRootPath.VFSRootPath()')** `Constructor` Represents the root directory of the virtual file system.
  - **[ToString()](VFSRootPath.ToString().md 'Atypical.VirtualFileSystem.Core.VFSRootPath.ToString()')** `Method` Returns a string that represents the current object.  
    The string representation of the root directory is the constant [ROOT_PATH](VFS.ROOT_PATH.md 'Atypical.VirtualFileSystem.Core.VFS.ROOT_PATH').
  - **[implicit operator string(VFSRootPath)](VFSRootPath.implicitoperatorstring(VFSRootPath).md 'Atypical.VirtualFileSystem.Core.VFSRootPath.op_Implicit string(Atypical.VirtualFileSystem.Core.VFSRootPath)')** `Operator` Implicit conversion to string  
    This allows you to use a [VFSRootPath](VFSRootPath.md 'Atypical.VirtualFileSystem.Core.VFSRootPath') as a string.
- **[VirtualFileSystemException](VirtualFileSystemException.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemException')** `Class` Exception thrown by the VFS.
  - **[VirtualFileSystemException()](VirtualFileSystemException.VirtualFileSystemException().md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException()')** `Constructor` Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemException') class.
  - **[VirtualFileSystemException(string, Exception)](VirtualFileSystemException.VirtualFileSystemException(string,Exception).md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string, System.Exception)')** `Constructor` Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemException') class with a message and an inner exception that is the cause  
    of this exception.
  - **[VirtualFileSystemException(string)](VirtualFileSystemException.VirtualFileSystemException(string).md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string)')** `Constructor` Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemException') class with a message that describes the error.
- **[VirtualFileSystemFactory](VirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory')** `Class` Represents a factory for creating [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem') instances.
  - **[VirtualFileSystemFactory()](VirtualFileSystemFactory.VirtualFileSystemFactory().md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory.VirtualFileSystemFactory()')** `Constructor` Initializes a new instance of the [VirtualFileSystemFactory](VirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory') class.
  - **[CreateFileSystem()](VirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory.CreateFileSystem()')** `Method` Creates a new instance of [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem').
- **[IChangeHistory](IChangeHistory.md 'Atypical.VirtualFileSystem.Core.IChangeHistory')** `Interface` Represents a history of changes in a virtual file system.
  - **[RedoStack](IChangeHistory.RedoStack.md 'Atypical.VirtualFileSystem.Core.IChangeHistory.RedoStack')** `Property` Gets the redo stack.
  - **[UndoStack](IChangeHistory.UndoStack.md 'Atypical.VirtualFileSystem.Core.IChangeHistory.UndoStack')** `Property` Gets the undo stack.
  - **[AddChange(VFSEventArgs)](IChangeHistory.AddChange(VFSEventArgs).md 'Atypical.VirtualFileSystem.Core.IChangeHistory.AddChange(Atypical.VirtualFileSystem.Core.VFSEventArgs)')** `Method` Adds a change to the history.
  - **[OnChange(VFSEventArgs)](IChangeHistory.OnChange(VFSEventArgs).md 'Atypical.VirtualFileSystem.Core.IChangeHistory.OnChange(Atypical.VirtualFileSystem.Core.VFSEventArgs)')** `Method` Handles the change event from the virtual file system.
  - **[Redo()](IChangeHistory.Redo().md 'Atypical.VirtualFileSystem.Core.IChangeHistory.Redo()')** `Method` Redoes the most recent undone change.
  - **[Undo()](IChangeHistory.Undo().md 'Atypical.VirtualFileSystem.Core.IChangeHistory.Undo()')** `Method` Undoes the most recent change.

<a name='Atypical.VirtualFileSystem.Core.Contracts'></a>

## Atypical.VirtualFileSystem.Core.Contracts Namespace
- **[IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')** `Interface` Represents a directory in a virtual file system.  
  This is an in-memory representation of a directory.  
  It is not a representation of a directory on a physical file system.
  - **[Directories](IDirectoryNode.Directories.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.Directories')** `Property` Gets the child directories of the node.
  - **[Files](IDirectoryNode.Files.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.Files')** `Property` Gets the child files of the node.
  - **[AddChild(IVirtualFileSystemNode)](IDirectoryNode.AddChild(IVirtualFileSystemNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.AddChild(Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode)')** `Method` x  
                    Adds a child node to the current directory.
  - **[RemoveChild(IVirtualFileSystemNode)](IDirectoryNode.RemoveChild(IVirtualFileSystemNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.RemoveChild(Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode)')** `Method` Removes a child node from the current directory.
- **[IFileNode](IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')** `Interface` Represents a file in a virtual file system.  
  This is the base interface for all file types.
  - **[Content](IFileNode.Content.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode.Content')** `Property` Gets the content of the file as a string.  
    The encoding is in UTF-8.
- **[IRootNode](IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode')** `Interface` Represents the root of a virtual file system.  
  This is the entry point for all operations on the file system.
- **[IVFSCreate](IVFSCreate.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate')** `Interface` Represents the creation operations of the virtual file system.
  - **[CreateDirectory(VFSDirectoryPath)](IVFSCreate.CreateDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.CreateDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Creates a directory node at the specified path.  
    The path must be absolute.
  - **[CreateFile(VFSFilePath, string)](IVFSCreate.CreateFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.CreateFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')** `Method` Creates a file node at the specified path.  
    The path must be absolute.
  - **[DirectoryCreated](IVFSCreate.DirectoryCreated.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.DirectoryCreated')** `Event` Event triggered when a directory is created.
  - **[FileCreated](IVFSCreate.FileCreated.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSCreate.FileCreated')** `Event` Event triggered when a file is created.
- **[IVFSDelete](IVFSDelete.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete')** `Interface` Represents the deletion operations of the virtual file system.
  - **[DeleteDirectory(VFSDirectoryPath)](IVFSDelete.DeleteDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.DeleteDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Deletes a directory node at the specified path.  
    The path must be absolute.
  - **[DeleteFile(VFSFilePath)](IVFSDelete.DeleteFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.DeleteFile(Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Method` Deletes a file node at the specified path.  
    The path must be absolute.
  - **[DirectoryDeleted](IVFSDelete.DirectoryDeleted.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.DirectoryDeleted')** `Event` Event triggered when a directory is deleted.
  - **[FileDeleted](IVFSDelete.FileDeleted.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSDelete.FileDeleted')** `Event` Event triggered when a file is deleted.
- **[IVFSMove](IVFSMove.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove')** `Interface` Represents the move operations of the virtual file system.
  - **[MoveDirectory(VFSDirectoryPath, VFSDirectoryPath)](IVFSMove.MoveDirectory(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove.MoveDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Moves a directory from one location to another.
  - **[MoveFile(VFSFilePath, VFSFilePath)](IVFSMove.MoveFile(VFSFilePath,VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove.MoveFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Method` Moves a file node from the source path to the destination path.  
    Both paths must be absolute.
  - **[DirectoryMoved](IVFSMove.DirectoryMoved.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove.DirectoryMoved')** `Event` Event triggered when a directory is moved.
  - **[FileMoved](IVFSMove.FileMoved.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSMove.FileMoved')** `Event` Event triggered when a file is moved.
- **[IVFSRename](IVFSRename.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename')** `Interface` Represents the rename operations of the virtual file system.
  - **[RenameDirectory(VFSDirectoryPath, string)](IVFSRename.RenameDirectory(VFSDirectoryPath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, string)')** `Method` Renames a directory node at the specified path.  
    The path must be absolute.
  - **[RenameFile(VFSFilePath, string)](IVFSRename.RenameFile(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.RenameFile(Atypical.VirtualFileSystem.Core.VFSFilePath, string)')** `Method` Renames a file node at the specified path.  
    The path must be absolute.
  - **[DirectoryRenamed](IVFSRename.DirectoryRenamed.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.DirectoryRenamed')** `Event` Event triggered when a directory is renamed.
  - **[FileRenamed](IVFSRename.FileRenamed.md 'Atypical.VirtualFileSystem.Core.Contracts.IVFSRename.FileRenamed')** `Event` Event triggered when a file is renamed.
- **[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')** `Interface` Represents a virtual file system.  
  This is the main entry point for all operations on the file system.  
  You can get an instance of this interface by calling [CreateFileSystem()](IVirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.CreateFileSystem()').
  - **[ChangeHistory](IVirtualFileSystem.ChangeHistory.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.ChangeHistory')** `Property` Gets the change history of the file system.
  - **[Directories](IVirtualFileSystem.Directories.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Directories')** `Property` Finds all directory nodes.
  - **[Files](IVirtualFileSystem.Files.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Files')** `Property` Finds all file nodes.
  - **[Index](IVirtualFileSystem.Index.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Index')** `Property` Gets the file index of the file system.  
    Basically, this is a dictionary that maps file paths to file nodes.  
    This is useful for quickly finding a file node by its path.
  - **[IsEmpty](IVirtualFileSystem.IsEmpty.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.IsEmpty')** `Property` Indicates whether the file system is empty.  
    This is the case if the root directory is empty.
  - **[Root](IVirtualFileSystem.Root.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.Root')** `Property` Gets the root directory of the file system.  
    This is the entry point for all operations on the file system.
  - **[RootPath](IVirtualFileSystem.RootPath.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.RootPath')** `Property` Gets the path of the root directory.
  - **[FindDirectories(Func&lt;IDirectoryNode,bool&gt;)](IVirtualFileSystem.FindDirectories(Func_IDirectoryNode,bool_).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool>)')** `Method` Finds all directory nodes that match the specified predicate.
  - **[FindDirectories(Regex)](IVirtualFileSystem.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex)')** `Method` Finds all directory nodes that match the specified regular expression.  
    The regular expression must be relative to the root directory.
  - **[FindFiles(Func&lt;IFileNode,bool&gt;)](IVirtualFileSystem.FindFiles(Func_IFileNode,bool_).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool>)')** `Method` Finds all file nodes that match the specified predicate.
  - **[FindFiles(Regex)](IVirtualFileSystem.FindFiles(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex)')** `Method` Finds all file nodes that match the specified regular expression.
  - **[GetDirectory(VFSDirectoryPath)](IVirtualFileSystem.GetDirectory(VFSDirectoryPath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)')** `Method` Gets a directory node by its path.  
    The path must be absolute.
  - **[GetFile(VFSFilePath)](IVirtualFileSystem.GetFile(VFSFilePath).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetFile(Atypical.VirtualFileSystem.Core.VFSFilePath)')** `Method` Gets a file node by its path.  
    The path must be absolute.
  - **[GetTree()](IVirtualFileSystem.GetTree().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.GetTree()')** `Method` Gets the tree of the file system.
  - **[TryGetDirectory(VFSDirectoryPath, IDirectoryNode)](IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath,IDirectoryNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetDirectory(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode)')** `Method` Try to get a directory node by its path.  
    The path must be absolute.  
    If the directory node does not exist, this method returns `false`  
    and directory is set to `null`.
  - **[TryGetFile(VFSFilePath, IFileNode)](IVirtualFileSystem.TryGetFile(VFSFilePath,IFileNode).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.TryGetFile(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.Contracts.IFileNode)')** `Method` Try to get a file node by its path.  
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

<a name='Atypical.VirtualFileSystem.Core.Services'></a>

## Atypical.VirtualFileSystem.Core.Services Namespace
- **[ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Atypical.VirtualFileSystem.Core.Services.ServiceCollectionExtensions')** `Class` Extension methods for [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection').  
  This class is used to register the virtual file system in the dependency injection container.
  - **[AddVirtualFileSystem(this IServiceCollection)](ServiceCollectionExtensions.AddVirtualFileSystem(thisIServiceCollection).md 'Atypical.VirtualFileSystem.Core.Services.ServiceCollectionExtensions.AddVirtualFileSystem(this Microsoft.Extensions.DependencyInjection.IServiceCollection)')** `Method` Registers the virtual file system in the dependency injection container.