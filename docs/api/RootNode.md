#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## RootNode Class

Represents the root directory of the virtual file system\.

```csharp
public record RootNode : Atypical.VirtualFileSystem.Core.DirectoryNode, Atypical.VirtualFileSystem.Core.Contracts.IRootNode, Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode, Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystemNode, System.IEquatable<Atypical.VirtualFileSystem.Core.RootNode>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [VFSNode](VFSNode.md 'Atypical\.VirtualFileSystem\.Core\.VFSNode') &#129106; [DirectoryNode](DirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.DirectoryNode') &#129106; RootNode

Implements [IRootNode](IRootNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IRootNode'), [IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode'), [IVirtualFileSystemNode](IVirtualFileSystemNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystemNode'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[RootNode](RootNode.md 'Atypical\.VirtualFileSystem\.Core\.RootNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [RootNode\(\)](RootNode.RootNode().md 'Atypical\.VirtualFileSystem\.Core\.RootNode\.RootNode\(\)') | Initializes a new instance of the [RootNode](RootNode.md 'Atypical\.VirtualFileSystem\.Core\.RootNode') class\. |

| Methods | |
| :--- | :--- |
| [ToString\(\)](RootNode.ToString().md 'Atypical\.VirtualFileSystem\.Core\.RootNode\.ToString\(\)') | Returns a string that represents the current object\. For [RootNode](RootNode.md 'Atypical\.VirtualFileSystem\.Core\.RootNode') this is always the constant string \<cref see="ROOT\_PATH" /\>\. |
