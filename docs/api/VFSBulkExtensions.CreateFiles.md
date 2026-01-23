#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBulkExtensions](VFSBulkExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions')

## VFSBulkExtensions\.CreateFiles Method

| Overloads | |
| :--- | :--- |
| [CreateFiles\(this IVirtualFileSystem, IDictionary&lt;string,string&gt;, bool\)](VFSBulkExtensions.CreateFiles.md#Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,IDictionary_string,string_,bool) 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.CreateFiles\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, IDictionary\<string,string\>, bool\)') | Creates multiple files efficiently in a single operation using a dictionary\. |
| [CreateFiles\(this IVirtualFileSystem, IEnumerable&lt;ValueTuple&lt;string,string&gt;&gt;, bool\)](VFSBulkExtensions.CreateFiles.md#Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_ValueTuple_string,string__,bool) 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.CreateFiles\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IEnumerable\<ValueTuple\<string,string\>\>, bool\)') | Creates multiple files efficiently in a single operation\. |

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,IDictionary_string,string_,bool)'></a>

## VFSBulkExtensions\.CreateFiles\(this IVirtualFileSystem, IDictionary\<string,string\>, bool\) Method

Creates multiple files efficiently in a single operation using a dictionary\.

```csharp
public static Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateFiles(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, IDictionary<string,string> files, bool createDirectories=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,IDictionary_string,string_,bool).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,IDictionary_string,string_,bool).files'></a>

`files` [System\.Collections\.Generic\.IDictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary 'System\.Collections\.Generic\.IDictionary')

Dictionary with file paths as keys and content as values\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,IDictionary_string,string_,bool).createDirectories'></a>

`createDirectories` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to auto\-create parent directories\. Default is true\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The virtual file system for method chaining\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_ValueTuple_string,string__,bool)'></a>

## VFSBulkExtensions\.CreateFiles\(this IVirtualFileSystem, IEnumerable\<ValueTuple\<string,string\>\>, bool\) Method

Creates multiple files efficiently in a single operation\.

```csharp
public static Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem CreateFiles(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, System.Collections.Generic.IEnumerable<ValueTuple<string,string>> files, bool createDirectories=true);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_ValueTuple_string,string__,bool).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_ValueTuple_string,string__,bool).files'></a>

`files` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Collection of file path and content pairs\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBulkExtensions.CreateFiles(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,System.Collections.Generic.IEnumerable_ValueTuple_string,string__,bool).createDirectories'></a>

`createDirectories` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to auto\-create parent directories\. Default is true\.

#### Returns
[IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')  
The virtual file system for method chaining\.