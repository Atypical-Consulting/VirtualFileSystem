#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSBinaryExtensions](VFSBinaryExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions')

## VFSBinaryExtensions\.TryWriteBinaryFile\(this IVirtualFileSystem, string, byte\[\]\) Method

Writes binary content to an existing file\.

```csharp
public static bool TryWriteBinaryFile(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs, string filePath, byte[] binaryContent);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.TryWriteBinaryFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,byte[]).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.TryWriteBinaryFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,byte[]).filePath'></a>

`filePath` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The file path as a string\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSBinaryExtensions.TryWriteBinaryFile(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem,string,byte[]).binaryContent'></a>

`binaryContent` [System\.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System\.Byte')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The binary content to write\.

#### Returns
[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')  
True if the binary content was written successfully, false otherwise\.