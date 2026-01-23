#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSFilePath Class

Represents a file system entry in the virtual file system\.
A file is a first\-class citizen in the virtual file system\.

```csharp
public record VFSFilePath : Atypical.VirtualFileSystem.Core.VFSPath
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IComparable](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable 'System\.IComparable') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; VFSFilePath

| Constructors | |
| :--- | :--- |
| [VFSFilePath\(string\)](VFSFilePath.VFSFilePath(string).md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath\.VFSFilePath\(string\)') | Initializes a new instance of the [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath') class\. The file path is relative to the root of the virtual file system\. |

| Methods | |
| :--- | :--- |
| [ToString\(\)](VFSFilePath.ToString().md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath\.ToString\(\)') | Returns a string that represents the current object\. The file path is relative to the root of the virtual file system\. |

| Operators | |
| :--- | :--- |
| [implicit operator VFSFilePath\(string\)](VFSFilePath.implicitoperatorVFSFilePath(string).md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath\.op\_Implicit Atypical\.VirtualFileSystem\.Core\.VFSFilePath\(string\)') | Implicit conversion from string\. This allows you to use a string as a [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath')\. |
| [implicit operator string\(VFSFilePath\)](VFSFilePath.implicitoperatorstring(VFSFilePath).md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath\.op\_Implicit string\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath\)') | Implicit conversion to string This allows you to use a [VFSFilePath](VFSFilePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSFilePath') as a string\. |
