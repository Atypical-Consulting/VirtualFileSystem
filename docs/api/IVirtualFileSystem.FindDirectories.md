#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

## IVirtualFileSystem\.FindDirectories Method

| Overloads | |
| :--- | :--- |
| [FindDirectories\(Func&lt;IDirectoryNode,bool&gt;\)](IVirtualFileSystem.FindDirectories.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindDirectories\(Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode,bool\>\)') | Finds all directory nodes that match the specified predicate\. |
| [FindDirectories\(Regex\)](IVirtualFileSystem.FindDirectories.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Regex) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindDirectories\(Regex\)') | Finds all directory nodes that match the specified regular expression\. The regular expression must be relative to the root directory\. |

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_)'></a>

## IVirtualFileSystem\.FindDirectories\(Func\<IDirectoryNode,bool\>\) Method

Finds all directory nodes that match the specified predicate\.

```csharp
System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(Func<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool> predicate);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Func_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode,bool_).predicate'></a>

`predicate` [System\.Func](https://learn.microsoft.com/en-us/dotnet/api/system.func 'System\.Func')

The predicate\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The directory nodes\.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Regex)'></a>

## IVirtualFileSystem\.FindDirectories\(Regex\) Method

Finds all directory nodes that match the specified regular expression\.
The regular expression must be relative to the root directory\.

```csharp
System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> FindDirectories(Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindDirectories(Regex).regexPattern'></a>

`regexPattern` [System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')

The regular expression pattern\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The directory nodes\.