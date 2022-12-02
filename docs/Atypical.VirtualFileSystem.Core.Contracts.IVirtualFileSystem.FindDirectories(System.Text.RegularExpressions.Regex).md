#### [Atypical.VirtualFileSystem.Core](Atypical.VirtualFileSystem.Core.md 'Atypical.VirtualFileSystem.Core')
### [Atypical.VirtualFileSystem.Core.Contracts](Atypical.VirtualFileSystem.Core.Contracts.md 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.FindDirectories(Regex) Method

Finds all directory nodes that match the specified regular expression.  
The regular expression must be relative to the root directory.

```csharp
System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(System.Text.RegularExpressions.Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex).regexPattern'></a>

`regexPattern` [System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

The regular expression pattern.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[IDirectoryNode](Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The directory nodes.