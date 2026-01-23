#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions')

## FileInfo Class

Represents information about a file in the virtual file system\.

```csharp
public sealed record FileInfo : System.IEquatable<Atypical.VirtualFileSystem.Core.Extensions.FileInfo>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; FileInfo

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[FileInfo](FileInfo.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.FileInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [FileInfo\(string, bool, long, DateTime, DateTime\)](FileInfo.FileInfo(string,bool,long,DateTime,DateTime).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.FileInfo\.FileInfo\(string, bool, long, System\.DateTime, System\.DateTime\)') | Represents information about a file in the virtual file system\. |

| Properties | |
| :--- | :--- |
| [FileType](FileInfo.FileType.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.FileInfo\.FileType') | Gets the file type description\. |
| [SizeString](FileInfo.SizeString.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.FileInfo\.SizeString') | Gets a human\-readable size string\. |
