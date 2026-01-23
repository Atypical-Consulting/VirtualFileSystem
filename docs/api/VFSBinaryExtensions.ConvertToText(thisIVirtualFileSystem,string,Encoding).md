#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBinaryExtensions](VFSBinaryExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions')

## VFSBinaryExtensions\.ConvertToText\(this IVirtualFileSystem, string, Encoding\) Method

Converts a binary file to text format\.

```csharp
public static bool ConvertToText(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, System.Text.Encoding? encoding=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.ConvertToText(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,System.Text.Encoding).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.ConvertToText(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,System.Text.Encoding).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.ConvertToText(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,System.Text.Encoding).encoding'></a>

`encoding` [System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

The encoding to use for conversion\. Default is UTF\-8\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if conversion was successful, false otherwise\.