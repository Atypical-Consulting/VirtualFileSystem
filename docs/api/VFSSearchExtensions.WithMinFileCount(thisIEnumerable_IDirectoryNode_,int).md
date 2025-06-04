#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSearchExtensions](VFSSearchExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions')

## VFSSearchExtensions\.WithMinFileCount\(this IEnumerable\<IDirectoryNode\>, int\) Method

Filters directories containing a minimum number of files\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> WithMinFileCount(this System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> directories, int minFileCount);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithMinFileCount(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_,int).directories'></a>

`directories` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The directories to filter\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithMinFileCount(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode_,int).minFileCount'></a>

`minFileCount` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The minimum number of files\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Directories containing at least the specified number of files\.