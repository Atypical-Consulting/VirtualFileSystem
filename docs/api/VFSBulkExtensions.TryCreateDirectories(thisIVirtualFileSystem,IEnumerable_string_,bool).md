#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBulkExtensions](VFSBulkExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions')

## VFSBulkExtensions\.TryCreateDirectories\(this IVirtualFileSystem, IEnumerable\<string\>, bool\) Method

Safely creates multiple directories without throwing exceptions\.

```csharp
public static System.Collections.Generic.IEnumerable<string> TryCreateDirectories(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, System.Collections.Generic.IEnumerable<string> directoryPaths, bool createRecursively=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.TryCreateDirectories(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_string_,bool).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.TryCreateDirectories(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_string_,bool).directoryPaths'></a>

`directoryPaths` [System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Collection of directory paths to create\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.TryCreateDirectories(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_string_,bool).createRecursively'></a>

`createRecursively` [System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')

Whether to auto\-create parent directories\. Default is true\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Collection of successfully created directory paths\.