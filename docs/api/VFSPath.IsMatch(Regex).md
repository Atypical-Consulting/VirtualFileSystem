#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Abstractions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Abstractions 'Atypical.VirtualFileSystem.Core.Abstractions').[VFSPath](VFSPath.md 'Atypical.VirtualFileSystem.Core.Abstractions.VFSPath')

## VFSPath.IsMatch(Regex) Method

Indicates whether the specified regular expression finds a match in the path.

```csharp
public bool IsMatch(System.Text.RegularExpressions.Regex regex);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Abstractions.VFSPath.IsMatch(System.Text.RegularExpressions.Regex).regex'></a>

`regex` [System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

The regular expression to match.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the regular expression finds a match; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').