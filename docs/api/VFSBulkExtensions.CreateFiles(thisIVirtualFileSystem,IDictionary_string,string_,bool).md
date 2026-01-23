#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBulkExtensions](VFSBulkExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions')

## VFSBulkExtensions\.CreateFiles\(this IVirtualFileSystem, IDictionary\<string,string\>, bool\) Method

Creates multiple files efficiently in a single operation using a dictionary\.

```csharp
public static Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateFiles(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, System.Collections.Generic.IDictionary<string,string> files, bool createDirectories=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IDictionary_string,string_,bool).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IDictionary_string,string_,bool).files'></a>

`files` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

Dictionary with file paths as keys and content as values\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IDictionary_string,string_,bool).createDirectories'></a>

`createDirectories` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to auto\-create parent directories\. Default is true\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The virtual file system for method chaining\.