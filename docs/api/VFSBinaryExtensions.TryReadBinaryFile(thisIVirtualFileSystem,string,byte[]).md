#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBinaryExtensions](VFSBinaryExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions')

## VFSBinaryExtensions\.TryReadBinaryFile\(this IVirtualFileSystem, string, byte\[\]\) Method

Reads binary content from a file if it contains binary data\.

```csharp
public static bool TryReadBinaryFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, out byte[]? binaryContent);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.TryReadBinaryFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,byte[]).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.TryReadBinaryFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,byte[]).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.TryReadBinaryFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,byte[]).binaryContent'></a>

`binaryContent` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The binary content if successful\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if binary content was read successfully, false otherwise\.