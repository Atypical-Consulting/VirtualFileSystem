#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions')

## VFSAdvancedExtensions Class

Provides advanced extension methods for IVirtualFileSystem with smart behavior like auto\-creating parent directories\.

```csharp
public static class VFSAdvancedExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VFSAdvancedExtensions

| Methods | |
| :--- | :--- |
| [CopyDirectory\(this IVirtualFileSystem, string, string\)](VFSAdvancedExtensions.CopyDirectory(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.CopyDirectory\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Copies a directory and all its contents recursively\. |
| [CopyFile\(this IVirtualFileSystem, string, string\)](VFSAdvancedExtensions.CopyFile(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.CopyFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Copies a file from source to destination, creating parent directories if needed\. |
| [CreateDirectoryRecursively\(this IVirtualFileSystem, string\)](VFSAdvancedExtensions.CreateDirectoryRecursively(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.CreateDirectoryRecursively\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Creates a directory and automatically creates any missing parent directories\. |
| [CreateFileWithDirectories\(this IVirtualFileSystem, string, string\)](VFSAdvancedExtensions.CreateFileWithDirectories(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.CreateFileWithDirectories\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Creates a file and automatically creates any missing parent directories\. |
| [GetAllDirectoriesRecursive\(this IVirtualFileSystem\)](VFSAdvancedExtensions.GetAllDirectoriesRecursive(thisIVirtualFileSystem).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.GetAllDirectoriesRecursive\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\)') | Gets all directories in the file system recursively\. |
| [GetAllFilesRecursive\(this IVirtualFileSystem\)](VFSAdvancedExtensions.GetAllFilesRecursive(thisIVirtualFileSystem).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.GetAllFilesRecursive\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\)') | Gets all files in the file system recursively\. |
| [GetDirectoriesRecursive\(this IVirtualFileSystem, string\)](VFSAdvancedExtensions.GetDirectoriesRecursive(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.GetDirectoriesRecursive\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Gets all directories in a specific directory recursively\. |
| [GetFilesRecursive\(this IVirtualFileSystem, string\)](VFSAdvancedExtensions.GetFilesRecursive(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.GetFilesRecursive\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Gets all files in a specific directory recursively\. |
| [TryCopyDirectory\(this IVirtualFileSystem, string, string\)](VFSAdvancedExtensions.TryCopyDirectory(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.TryCopyDirectory\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely copies a directory and all its contents recursively\. |
| [TryCopyFile\(this IVirtualFileSystem, string, string\)](VFSAdvancedExtensions.TryCopyFile(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.TryCopyFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely copies a file from source to destination, creating parent directories if needed\. |
| [TryCreateDirectoryRecursively\(this IVirtualFileSystem, string\)](VFSAdvancedExtensions.TryCreateDirectoryRecursively(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.TryCreateDirectoryRecursively\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Safely creates a directory and automatically creates any missing parent directories\. |
| [TryCreateFileWithDirectories\(this IVirtualFileSystem, string, string\)](VFSAdvancedExtensions.TryCreateFileWithDirectories(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions\.TryCreateFileWithDirectories\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Safely creates a file and automatically creates any missing parent directories\. |
