#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSDirectoryPath Class

Represents a directory in the virtual file system\.
A directory is a first\-class citizen in the virtual file system\.
It can contain files and other directories\.

```csharp
public record VFSDirectoryPath : Atypical.VirtualFileSystem.Core.VFSPath
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IComparable](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable 'System\.IComparable') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; VFSDirectoryPath

Derived  
&#8627; [VFSRootPath](VFSRootPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSRootPath')

| Constructors | |
| :--- | :--- |
| [VFSDirectoryPath\(string\)](VFSDirectoryPath.VFSDirectoryPath(string).md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\.VFSDirectoryPath\(string\)') | Initializes a new instance of the [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath') class\. The file path is relative to the root of the virtual file system\. |

| Methods | |
| :--- | :--- |
| [ToString\(\)](VFSDirectoryPath.ToString().md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\.ToString\(\)') | Returns a string that represents the current object\. The string representation of the directory path is the path itself\. |

| Operators | |
| :--- | :--- |
| [implicit operator VFSDirectoryPath\(string\)](VFSDirectoryPath.implicitoperatorVFSDirectoryPath(string).md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\.op\_Implicit Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\(string\)') | Implicit conversion from string\. This allows you to use a string as a [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')\. |
| [implicit operator string\(VFSDirectoryPath\)](VFSDirectoryPath.implicitoperatorstring(VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\.op\_Implicit string\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Implicit conversion to string This allows you to use a [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath') as a string\. |
