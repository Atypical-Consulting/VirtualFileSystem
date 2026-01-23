#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.FindDirectories Method

| Overloads | |
| :--- | :--- |
| [FindDirectories\(Func&lt;IDirectoryNode,bool&gt;\)](VFS.FindDirectories.md#Atypical.VirtualFileSystem.Core.VFS.FindDirectories(Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindDirectories\(Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode,bool\>\)') | Finds all directory nodes that match the specified predicate\. |
| [FindDirectories\(Regex\)](VFS.FindDirectories.md#Atypical.VirtualFileSystem.Core.VFS.FindDirectories(Regex) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindDirectories\(Regex\)') | Finds all directory nodes that match the specified regular expression\. The regular expression must be relative to the root directory\. |

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_)'></a>

## VFS\.FindDirectories\(Func\<IDirectoryNode,bool\>\) Method

Finds all directory nodes that match the specified predicate\.

```csharp
public System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool> predicate);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_).predicate'></a>

`predicate` [System\.Func](https://learn.microsoft.com/en-us/dotnet/api/system.func 'System\.Func')

The predicate\.

Implements [FindDirectories\(Func&lt;IDirectoryNode,bool&gt;\)](IVirtualFileSystem.FindDirectories.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindDirectories\(Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode,bool\>\)')

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The directory nodes\.

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(Regex)'></a>

## VFS\.FindDirectories\(Regex\) Method

Finds all directory nodes that match the specified regular expression\.
The regular expression must be relative to the root directory\.

```csharp
public System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.FindDirectories(Regex).regexPattern'></a>

`regexPattern` [System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')

The regular expression pattern\.

Implements [FindDirectories\(Regex\)](IVirtualFileSystem.FindDirectories.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Regex) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindDirectories\(Regex\)')

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The directory nodes\.