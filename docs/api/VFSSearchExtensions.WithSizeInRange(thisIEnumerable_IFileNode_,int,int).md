#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSearchExtensions](VFSSearchExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions')

## VFSSearchExtensions\.WithSizeInRange\(this IEnumerable\<IFileNode\>, int, int\) Method

Filters files by size range\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> WithSizeInRange(this System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> files, int minSize=0, int maxSize=int.MaxValue);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithSizeInRange(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,int,int).files'></a>

`files` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The files to filter\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithSizeInRange(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,int,int).minSize'></a>

`minSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Minimum file size \(content length\)\. Default is 0\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.WithSizeInRange(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,int,int).maxSize'></a>

`maxSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Maximum file size \(content length\)\. Default is int\.MaxValue\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Files within the specified size range\.