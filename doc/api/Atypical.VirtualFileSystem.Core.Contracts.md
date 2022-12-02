#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')

## Atypical.VirtualFileSystem.Core.Contracts Namespace

| Interfaces | |
| :--- | :--- |
| [IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode') | Represents a directory in a virtual file system.<br/>This is an in-memory representation of a directory.<br/>It is not a representation of a directory on a physical file system. |
| [IFileNode](Atypical.VirtualFileSystem.Core.Contracts.IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode') | Represents a file in a virtual file system.<br/>This is the base interface for all file types. |
| [IRootNode](Atypical.VirtualFileSystem.Core.Contracts.IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode') | Represents the root of a virtual file system.<br/>This is the entry point for all operations on the file system. |
| [IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem') | Represents a virtual file system.<br/>This is the main entry point for all operations on the file system.<br/>You can get an instance of this interface by calling [CreateFileSystem()](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.CreateFileSystem().md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.CreateFileSystem()'). |
| [IVirtualFileSystemFactory](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemFactory') | Represents a factory for creating [IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem') instances.<br/>This interface is implemented by the [VirtualFileSystemFactory](Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory.md 'Atypical.VirtualFileSystem.Core.VirtualFileSystemFactory') class. |
| [IVirtualFileSystemNode](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode') | Represents a node in a virtual file system.<br/>A node can be a file or a directory. |
