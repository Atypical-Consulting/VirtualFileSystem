#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSearchExtensions](VFSSearchExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions')

## VFSSearchExtensions\.WithNameStartingWith\(this IEnumerable\<IFileNode\>, string, bool\) Method

Filters files by name starting with specific text\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> WithNameStartingWith(this System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> files, string prefix, bool ignoreCase=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameStartingWith(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool).files'></a>

`files` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The files to filter\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameStartingWith(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool).prefix'></a>

`prefix` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The prefix to search for\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithNameStartingWith(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,string,bool).ignoreCase'></a>

`ignoreCase` [System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')

Whether to ignore case\. Default is true\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Files with names starting with the specified prefix\.