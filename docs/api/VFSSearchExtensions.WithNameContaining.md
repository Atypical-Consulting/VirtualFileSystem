#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSearchExtensions](VFSSearchExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions')

## VFSSearchExtensions\.WithNameContaining Method

| Overloads | |
| :--- | :--- |
| [WithNameContaining\(this IEnumerable&lt;IDirectoryNode&gt;, string, bool\)](VFSSearchExtensions.WithNameContaining.md#Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_,string,bool) 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions\.WithNameContaining\(this System\.Collections\.Generic\.IEnumerable\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode\>, string, bool\)') | Filters directories by name containing specific text\. |
| [WithNameContaining\(this IEnumerable&lt;IFileNode&gt;, string, bool\)](VFSSearchExtensions.WithNameContaining.md#Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool) 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions\.WithNameContaining\(this System\.Collections\.Generic\.IEnumerable\<Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode\>, string, bool\)') | Filters files by name containing specific text\. |

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_,string,bool)'></a>

## VFSSearchExtensions\.WithNameContaining\(this IEnumerable\<IDirectoryNode\>, string, bool\) Method

Filters directories by name containing specific text\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> WithNameContaining(this System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> directories, string nameText, bool ignoreCase=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_,string,bool).directories'></a>

`directories` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The directories to filter\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_,string,bool).nameText'></a>

`nameText` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The text to search for in directory names\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_,string,bool).ignoreCase'></a>

`ignoreCase` [System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')

Whether to ignore case\. Default is true\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Directories with names containing the specified text\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool)'></a>

## VFSSearchExtensions\.WithNameContaining\(this IEnumerable\<IFileNode\>, string, bool\) Method

Filters files by name containing specific text\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> WithNameContaining(this System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> files, string nameText, bool ignoreCase=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool).files'></a>

`files` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The files to filter\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool).nameText'></a>

`nameText` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The text to search for in file names\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameContaining(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool).ignoreCase'></a>

`ignoreCase` [System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')

Whether to ignore case\. Default is true\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Files with names containing the specified text\.