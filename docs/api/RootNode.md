#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical.VirtualFileSystem.Core.Models')

## RootNode Class

Represents the root directory of the virtual file system.

```csharp
public class RootNode : Atypical.VirtualFileSystem.Core.Models.DirectoryNode,
Atypical.VirtualFileSystem.Core.Contracts.IRootNode,
Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,
Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode,
System.IEquatable<Atypical.VirtualFileSystem.Core.Models.RootNode>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [VFSNode](VFSNode.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSNode') &#129106; [DirectoryNode](DirectoryNode.md 'Atypical.VirtualFileSystem.Core.Models.DirectoryNode') &#129106; RootNode

Implements [IRootNode](IRootNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IRootNode'), [IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [RootNode()](RootNode.RootNode().md 'Atypical.VirtualFileSystem.Core.Models.RootNode.RootNode()') | Initializes a new instance of the [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode') class. |

| Methods | |
| :--- | :--- |
| [ToString()](RootNode.ToString().md 'Atypical.VirtualFileSystem.Core.Models.RootNode.ToString()') | Returns a string that represents the current object.<br/>For [RootNode](RootNode.md 'Atypical.VirtualFileSystem.Core.Models.RootNode') this is always the constant string <cref see="ROOT_PATH"/>. |
