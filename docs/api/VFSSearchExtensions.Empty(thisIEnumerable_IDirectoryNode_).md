#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSearchExtensions](VFSSearchExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions')

## VFSSearchExtensions\.Empty\(this IEnumerable\<IDirectoryNode\>\) Method

Filters directories that are empty \(no files or subdirectories\)\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> Empty(this System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> directories);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.Empty(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_).directories'></a>

`directories` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The directories to filter\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Empty directories\.