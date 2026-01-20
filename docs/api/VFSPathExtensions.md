#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions')

## VFSPathExtensions Class

Provides path manipulation and utility extension methods for VFS paths\.

```csharp
public static class VFSPathExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VFSPathExtensions

| Methods | |
| :--- | :--- |
| [ChangeExtension\(this VFSPath, string\)](VFSPathExtensions.ChangeExtension(thisVFSPath,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.ChangeExtension\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, string\)') | Changes the extension of a VFS path\. |
| [Combine\(this VFSDirectoryPath, string\)](VFSPathExtensions.Combine(thisVFSDirectoryPath,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.Combine\(this Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, string\)') | Combines a directory path with a relative path\. |
| [GetAncestors\(this VFSPath\)](VFSPathExtensions.GetAncestors(thisVFSPath).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.GetAncestors\(this Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Gets all ancestor paths from the current path up to the root\. |
| [GetDepth\(this VFSPath\)](VFSPathExtensions.GetDepth(thisVFSPath).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.GetDepth\(this Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Gets the depth of the path \(number of directory levels from root\)\. |
| [GetExtension\(this VFSPath\)](VFSPathExtensions.GetExtension(thisVFSPath).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.GetExtension\(this Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Gets the file extension from a VFS path\. |
| [GetFileNameWithoutExtension\(this VFSPath\)](VFSPathExtensions.GetFileNameWithoutExtension(thisVFSPath).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.GetFileNameWithoutExtension\(this Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Gets the file name without extension from a VFS path\. |
| [GetParent\(this VFSPath, int\)](VFSPathExtensions.GetParent(thisVFSPath,int).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.GetParent\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, int\)') | Gets the parent directory at the specified level up\. |
| [GetRelativePath\(this VFSDirectoryPath, VFSPath\)](VFSPathExtensions.GetRelativePath(thisVFSDirectoryPath,VFSPath).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.GetRelativePath\(this Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Gets the relative path from one directory to another\. |
| [HasAnyExtension\(this VFSPath, string\[\]\)](VFSPathExtensions.HasAnyExtension(thisVFSPath,string[]).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.HasAnyExtension\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, string\[\]\)') | Checks if the path has any of the specified extensions\. |
| [HasExtension\(this VFSPath, string, bool\)](VFSPathExtensions.HasExtension(thisVFSPath,string,bool).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.HasExtension\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, string, bool\)') | Checks if the path has a specific extension\. |
| [IsAncestorOf\(this VFSPath, VFSPath\)](VFSPathExtensions.IsAncestorOf(thisVFSPath,VFSPath).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.IsAncestorOf\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Checks if a path is a descendant of another path\. |
| [IsAtDepth\(this VFSPath, int\)](VFSPathExtensions.IsAtDepth(thisVFSPath,int).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.IsAtDepth\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, int\)') | Checks if the path is at a specific depth\. |
| [IsDirectChildOf\(this VFSPath, VFSPath\)](VFSPathExtensions.IsDirectChildOf(thisVFSPath,VFSPath).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.IsDirectChildOf\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, Atypical\.VirtualFileSystem\.Core\.VFSPath\)') | Checks if a path is a child \(direct descendant\) of another path\. |
| [MatchesGlob\(this VFSPath, string\)](VFSPathExtensions.MatchesGlob(thisVFSPath,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.MatchesGlob\(this Atypical\.VirtualFileSystem\.Core\.VFSPath, string\)') | Checks if the path matches a glob pattern\. |
| [Normalize\(string\)](VFSPathExtensions.Normalize(string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions\.Normalize\(string\)') | Normalizes a path by removing redundant separators and resolving relative components\. |
