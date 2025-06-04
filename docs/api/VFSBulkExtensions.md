#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions')

## VFSBulkExtensions Class

Provides bulk operation extension methods for IVirtualFileSystem for efficient batch processing\.

```csharp
public static class VFSBulkExtensions
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; VFSBulkExtensions

| Methods | |
| :--- | :--- |
| [CreateDirectories\(this IVirtualFileSystem, IEnumerable&lt;string&gt;, bool\)](VFSBulkExtensions.CreateDirectories(thisIVirtualFileSystem,IEnumerable_string_,bool).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.CreateDirectories\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IEnumerable\<string\>, bool\)') | Creates multiple directories efficiently in a single operation\. |
| [CreateFiles\(this IVirtualFileSystem, IDictionary&lt;string,string&gt;, bool\)](VFSBulkExtensions.CreateFiles(thisIVirtualFileSystem,IDictionary_string,string_,bool).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.CreateFiles\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IDictionary\<string,string\>, bool\)') | Creates multiple files efficiently in a single operation using a dictionary\. |
| [DeleteDirectories\(this IVirtualFileSystem, IEnumerable&lt;string&gt;\)](VFSBulkExtensions.DeleteDirectories(thisIVirtualFileSystem,IEnumerable_string_).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.DeleteDirectories\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IEnumerable\<string\>\)') | Deletes multiple directories efficiently in a single operation\. |
| [DeleteFiles\(this IVirtualFileSystem, IEnumerable&lt;string&gt;\)](VFSBulkExtensions.DeleteFiles(thisIVirtualFileSystem,IEnumerable_string_).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.DeleteFiles\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IEnumerable\<string\>\)') | Deletes multiple files efficiently in a single operation\. |
| [TryCreateDirectories\(this IVirtualFileSystem, IEnumerable&lt;string&gt;, bool\)](VFSBulkExtensions.TryCreateDirectories(thisIVirtualFileSystem,IEnumerable_string_,bool).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.TryCreateDirectories\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IEnumerable\<string\>, bool\)') | Safely creates multiple directories without throwing exceptions\. |
| [TryDeleteDirectories\(this IVirtualFileSystem, IEnumerable&lt;string&gt;\)](VFSBulkExtensions.TryDeleteDirectories(thisIVirtualFileSystem,IEnumerable_string_).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.TryDeleteDirectories\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IEnumerable\<string\>\)') | Safely deletes multiple directories without throwing exceptions\. |
| [TryDeleteFiles\(this IVirtualFileSystem, IEnumerable&lt;string&gt;\)](VFSBulkExtensions.TryDeleteFiles(thisIVirtualFileSystem,IEnumerable_string_).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBulkExtensions\.TryDeleteFiles\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, System\.Collections\.Generic\.IEnumerable\<string\>\)') | Safely deletes multiple files without throwing exceptions\. |
