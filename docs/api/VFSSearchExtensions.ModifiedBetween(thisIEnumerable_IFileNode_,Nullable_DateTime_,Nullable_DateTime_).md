#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSSearchExtensions](VFSSearchExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSearchExtensions')

## VFSSearchExtensions\.ModifiedBetween\(this IEnumerable\<IFileNode\>, Nullable\<DateTime\>, Nullable\<DateTime\>\) Method

Filters files modified within a specific time range\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> ModifiedBetween(this System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IFileNode> files, System.Nullable<System.DateTime> from=null, System.Nullable<System.DateTime> to=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.ModifiedBetween(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,System.Nullable_System.DateTime_,System.Nullable_System.DateTime_).files'></a>

`files` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The files to filter\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.ModifiedBetween(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,System.Nullable_System.DateTime_,System.Nullable_System.DateTime_).from'></a>

`from` [System\.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System\.Nullable\`1')[System\.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System\.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System\.Nullable\`1')

Start of time range\. Default is DateTime\.MinValue\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSSearchExtensions.ModifiedBetween(thisSystem.Collections.Generic.IEnumerable_Atypical.VirtualFileSystem.Core.Contracts.IFileNode_,System.Nullable_System.DateTime_,System.Nullable_System.DateTime_).to'></a>

`to` [System\.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System\.Nullable\`1')[System\.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System\.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System\.Nullable\`1')

End of time range\. Default is DateTime\.MaxValue\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IFileNode](IFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IFileNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Files modified within the specified time range\.