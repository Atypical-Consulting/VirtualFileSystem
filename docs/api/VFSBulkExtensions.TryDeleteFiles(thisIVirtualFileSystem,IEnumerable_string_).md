#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBulkExtensions](VFSBulkExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions')

## VFSBulkExtensions\.TryDeleteFiles\(this IVirtualFileSystem, IEnumerable\<string\>\) Method

Safely deletes multiple files without throwing exceptions\.

```csharp
public static System.Collections.Generic.IEnumerable<string> TryDeleteFiles(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, System.Collections.Generic.IEnumerable<string> filePaths);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.TryDeleteFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_string_).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.TryDeleteFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_string_).filePaths'></a>

`filePaths` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Collection of file paths to delete\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Collection of successfully deleted file paths\.