#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFS](VFS.md 'Atypical.VirtualFileSystem.Core.VFS')

## VFS.FindDirectories(Regex) Method

Finds all directory nodes that match the specified regular expression.  
The regular expression must be relative to the root directory.

```csharp
public System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(System.Text.RegularExpressions.Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex).regexPattern'></a>

`regexPattern` [System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

The regular expression pattern.

Implements [FindDirectories(Regex)](IVirtualFileSystem.FindDirectories(Regex).md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex)')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[IDirectoryNode](IDirectoryNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The directory nodes.