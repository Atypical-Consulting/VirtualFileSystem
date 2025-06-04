#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBinaryExtensions](VFSBinaryExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions')

## VFSBinaryExtensions\.ConvertToBinary\(this IVirtualFileSystem, string, Encoding\) Method

Converts a text file to binary format\.

```csharp
public static bool ConvertToBinary(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, System.Text.Encoding? encoding=null);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.ConvertToBinary(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,System.Text.Encoding).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.ConvertToBinary(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,System.Text.Encoding).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.ConvertToBinary(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,System.Text.Encoding).encoding'></a>

`encoding` [System\.Text\.Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'System\.Text\.Encoding')

The encoding to use for conversion\. Default is UTF\-8\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if conversion was successful, false otherwise\.