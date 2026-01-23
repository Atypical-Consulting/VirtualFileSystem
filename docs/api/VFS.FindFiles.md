#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFS](VFS.md 'Atypical\.VirtualFileSystem\.Core\.VFS')

## VFS\.FindFiles Method

| Overloads | |
| :--- | :--- |
| [FindFiles\(Func&lt;IFileNode,bool&gt;\)](VFS.FindFiles.md#Atypical.VirtualFileSystem.Core.VFS.FindFiles(Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindFiles\(Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode,bool\>\)') | Finds all file nodes that match the specified predicate\. |
| [FindFiles\(Regex\)](VFS.FindFiles.md#Atypical.VirtualFileSystem.Core.VFS.FindFiles(Regex) 'Atypical\.VirtualFileSystem\.Core\.VFS\.FindFiles\(Regex\)') | Finds all file nodes that match the specified regular expression\. |

<a name='Atypical.VirtualFileSystem.Core.VFS.FindFiles(Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_)'></a>

## VFS\.FindFiles\(Func\<IFileNode,bool\>\) Method

Finds all file nodes that match the specified predicate\.

```csharp
public System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> FindFiles(Func<Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool> predicate);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.FindFiles(Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_).predicate'></a>

`predicate` [System\.Func](https://learn.microsoft.com/en-us/dotnet/api/system.func 'System\.Func')

The predicate\.

Implements [FindFiles\(Func&lt;IFileNode,bool&gt;\)](IVirtualFileSystem.FindFiles.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindFiles\(Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode,bool\>\)')

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The file nodes\.

<a name='Atypical.VirtualFileSystem.Core.VFS.FindFiles(Regex)'></a>

## VFS\.FindFiles\(Regex\) Method

Finds all file nodes that match the specified regular expression\.

```csharp
public System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> FindFiles(Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFS.FindFiles(Regex).regexPattern'></a>

`regexPattern` [System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')

The regular expression pattern\.

Implements [FindFiles\(Regex\)](IVirtualFileSystem.FindFiles.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(Regex) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindFiles\(Regex\)')

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The file nodes\.