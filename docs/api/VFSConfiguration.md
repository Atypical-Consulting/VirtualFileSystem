#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSConfiguration Class

Configuration options for the Virtual File System\.

```csharp
public sealed record VFSConfiguration : System.IEquatable<Atypical.VirtualFileSystem.Core.VFSConfiguration>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VFSConfiguration

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[VFSConfiguration](VFSConfiguration.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Properties | |
| :--- | :--- |
| [CaseSensitive](VFSConfiguration.CaseSensitive.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.CaseSensitive') | Gets or sets whether file and directory operations are case sensitive\. Default is false \(case insensitive\)\. |
| [Default](VFSConfiguration.Default.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.Default') | Gets the default VFS configuration\. |
| [EnableChangeHistory](VFSConfiguration.EnableChangeHistory.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.EnableChangeHistory') | Gets or sets whether to enable change history tracking\. Default is true\. |
| [EnableIndexCaching](VFSConfiguration.EnableIndexCaching.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.EnableIndexCaching') | Gets or sets whether to enable index caching for performance\. Default is true\. |
| [Events](VFSConfiguration.Events.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.Events') | Gets or sets event handling configuration\. |
| [MaxChangeHistorySize](VFSConfiguration.MaxChangeHistorySize.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.MaxChangeHistorySize') | Gets or sets the maximum number of operations to keep in change history\. Default is 1000\. Set to 0 for unlimited \(not recommended\)\. |
| [MaxFileSize](VFSConfiguration.MaxFileSize.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.MaxFileSize') | Gets or sets the maximum file size in bytes for content operations\. Default is 1MB\. Set to 0 for unlimited\. |
| [MaxRecursionDepth](VFSConfiguration.MaxRecursionDepth.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.MaxRecursionDepth') | Gets or sets the maximum depth for recursive operations\. Default is 100 to prevent infinite recursion\. |
| [NormalizePaths](VFSConfiguration.NormalizePaths.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.NormalizePaths') | Gets or sets whether to normalize paths automatically\. Default is true\. |
| [PathComparison](VFSConfiguration.PathComparison.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.PathComparison') | Gets or sets the string comparison type for path operations\. |
| [PathSeparators](VFSConfiguration.PathSeparators.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.PathSeparators') | Gets or sets custom path separators\. Default uses forward slash\. |
| [ValidatePaths](VFSConfiguration.ValidatePaths.md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.ValidatePaths') | Gets or sets whether to validate paths on creation\. Default is true\. |

| Methods | |
| :--- | :--- |
| [ForPerformance\(\)](VFSConfiguration.ForPerformance().md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.ForPerformance\(\)') | Creates a new configuration optimized for performance\. |
| [ForSafety\(\)](VFSConfiguration.ForSafety().md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.ForSafety\(\)') | Creates a new configuration optimized for safety and validation\. |
| [WithCaseInsensitivity\(\)](VFSConfiguration.WithCaseInsensitivity().md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.WithCaseInsensitivity\(\)') | Creates a new configuration with case insensitivity\. |
| [WithCaseSensitivity\(\)](VFSConfiguration.WithCaseSensitivity().md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.WithCaseSensitivity\(\)') | Creates a new configuration with case sensitivity enabled\. |
| [WithMaxFileSize\(long\)](VFSConfiguration.WithMaxFileSize(long).md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.WithMaxFileSize\(long\)') | Creates a new configuration with custom maximum file size\. |
| [WithoutChangeHistory\(\)](VFSConfiguration.WithoutChangeHistory().md 'Atypical\.VirtualFileSystem\.Core\.VFSConfiguration\.WithoutChangeHistory\(\)') | Creates a new configuration with change history disabled\. |
