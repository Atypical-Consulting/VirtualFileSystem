#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions')

## VFSSafeExtensions Class

Provides safe extension methods for IVirtualFileSystem that don't throw exceptions\.
These methods return boolean success indicators instead of throwing exceptions\.

```csharp
public static class VFSSafeExtensions
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; VFSSafeExtensions

| Methods | |
| :--- | :--- |
| [TryCreateDirectory\(this IVirtualFileSystem, string\)](VFSSafeExtensions.TryCreateDirectory(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryCreateDirectory\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Safely creates a directory without throwing exceptions\. |
| [TryCreateFile\(this IVirtualFileSystem, string, string\)](VFSSafeExtensions.TryCreateFile(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryCreateFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely creates a file without throwing exceptions\. |
| [TryDeleteDirectory\(this IVirtualFileSystem, string\)](VFSSafeExtensions.TryDeleteDirectory(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryDeleteDirectory\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Safely deletes a directory without throwing exceptions\. |
| [TryDeleteFile\(this IVirtualFileSystem, string\)](VFSSafeExtensions.TryDeleteFile(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryDeleteFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Safely deletes a file without throwing exceptions\. |
| [TryMoveDirectory\(this IVirtualFileSystem, string, string\)](VFSSafeExtensions.TryMoveDirectory(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryMoveDirectory\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely moves a directory without throwing exceptions\. |
| [TryMoveFile\(this IVirtualFileSystem, string, string\)](VFSSafeExtensions.TryMoveFile(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryMoveFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely moves a file without throwing exceptions\. |
| [TryReadFile\(this IVirtualFileSystem, string, string\)](VFSSafeExtensions.TryReadFile(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryReadFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely reads file content without throwing exceptions\. |
| [TryRenameDirectory\(this IVirtualFileSystem, string, string\)](VFSSafeExtensions.TryRenameDirectory(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryRenameDirectory\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely renames a directory without throwing exceptions\. |
| [TryRenameFile\(this IVirtualFileSystem, string, string\)](VFSSafeExtensions.TryRenameFile(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryRenameFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely renames a file without throwing exceptions\. |
| [TryWriteFile\(this IVirtualFileSystem, string, string\)](VFSSafeExtensions.TryWriteFile(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSSafeExtensions\.TryWriteFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely writes file content without throwing exceptions\. |
