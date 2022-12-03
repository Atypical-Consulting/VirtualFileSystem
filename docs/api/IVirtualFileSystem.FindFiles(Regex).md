#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical.VirtualFileSystem.Core.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem')

## IVirtualFileSystem.FindFiles(Regex) Method

Finds all file nodes that match the specified regular expression.

```csharp
System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> FindFiles(System.Text.RegularExpressions.Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex).regexPattern'></a>

`regexPattern` [System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

The regular expression pattern.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[IFileNode](IFileNode.md 'Atypical.VirtualFileSystem.Core.Contracts.IFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The file nodes.