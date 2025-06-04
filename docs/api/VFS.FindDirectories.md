#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.FindDirectories Method

| Overloads | |
| :--- | :--- |
| [FindDirectories\(Func&lt;IDirectoryNode,bool&gt;\)](VFS.FindDirectories.md#Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindDirectories\(System\.Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode,bool\>\)') | Finds all directory nodes that match the specified predicate\. |
| [FindDirectories\(Regex\)](VFS.FindDirectories.md#Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindDirectories\(System\.Text\.RegularExpressions\.Regex\)') | Finds all directory nodes that match the specified regular expression\. The regular expression must be relative to the root directory\. |

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_)'></a>

## VFS\.FindDirectories\(Func\<IDirectoryNode,bool\>\) Method

Finds all directory nodes that match the specified predicate\.

```csharp
public System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool> predicate);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_).predicate'></a>

`predicate` [System\.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')

The predicate\.

Implements [FindDirectories\(Func&lt;IDirectoryNode,bool&gt;\)](IVirtualFileSystem.FindDirectories.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindDirectories\(System\.Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode,bool\>\)')

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The directory nodes\.

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex)'></a>

## VFS\.FindDirectories\(Regex\) Method

Finds all directory nodes that match the specified regular expression\.
The regular expression must be relative to the root directory\.

```csharp
public System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(System.Text.RegularExpressions.Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(System.Text.RegularExpressions.Regex).regexPattern'></a>

`regexPattern` [System\.Text\.RegularExpressions\.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System\.Text\.RegularExpressions\.Regex')

The regular expression pattern\.

Implements [FindDirectories\(Regex\)](IVirtualFileSystem.FindDirectories.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(System.Text.RegularExpressions.Regex) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindDirectories\(System\.Text\.RegularExpressions\.Regex\)')

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The directory nodes\.