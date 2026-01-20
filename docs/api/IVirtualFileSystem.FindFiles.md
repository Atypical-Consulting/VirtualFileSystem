#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Contracts](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Contracts 'Atypical\.VirtualFileSystem\.Core\.Contracts').[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

## IVirtualFileSystem\.FindFiles Method

| Overloads | |
| :--- | :--- |
| [FindFiles\(Func&lt;IFileNode,bool&gt;\)](IVirtualFileSystem.FindFiles.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindFiles\(System\.Func\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode,bool\>\)') | Finds all file nodes that match the specified predicate\. |
| [FindFiles\(Regex\)](IVirtualFileSystem.FindFiles.md#Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex) 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\.FindFiles\(System\.Text\.RegularExpressions\.Regex\)') | Finds all file nodes that match the specified regular expression\. |

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_)'></a>

## IVirtualFileSystem\.FindFiles\(Func\<IFileNode,bool\>\) Method

Finds all file nodes that match the specified predicate\.

```csharp
System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> FindFiles(System.Func<Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool> predicate);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Func_Atypical.VirtualFileSystem.Core.Contracts.IFileNode,bool_).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The predicate\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The file nodes\.

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex)'></a>

## IVirtualFileSystem\.FindFiles\(Regex\) Method

Finds all file nodes that match the specified regular expression\.

```csharp
System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> FindFiles(System.Text.RegularExpressions.Regex regexPattern);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem.FindFiles(System.Text.RegularExpressions.Regex).regexPattern'></a>

`regexPattern` [System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')

The regular expression pattern\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The file nodes\.