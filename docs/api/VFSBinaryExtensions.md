#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions')

## VFSBinaryExtensions Class

Provides extension methods for handling binary files in the Virtual File System\.

```csharp
public static class VFSBinaryExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; VFSBinaryExtensions

| Methods | |
| :--- | :--- |
| [ConvertToBinary\(this IVirtualFileSystem, string, Encoding\)](VFSBinaryExtensions.ConvertToBinary(thisIVirtualFileSystem,string,Encoding).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.ConvertToBinary\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, System\.Text\.Encoding\)') | Converts a text file to binary format\. |
| [ConvertToText\(this IVirtualFileSystem, string, Encoding\)](VFSBinaryExtensions.ConvertToText(thisIVirtualFileSystem,string,Encoding).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.ConvertToText\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, System\.Text\.Encoding\)') | Converts a binary file to text format\. |
| [CreateBinaryFile\(this IVirtualFileSystem, string, byte\[\]\)](VFSBinaryExtensions.CreateBinaryFile(thisIVirtualFileSystem,string,byte[]).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.CreateBinaryFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, byte\[\]\)') | Creates a binary file with the specified path and binary content\. |
| [CreateBinaryFileFromBase64\(this IVirtualFileSystem, string, string\)](VFSBinaryExtensions.CreateBinaryFileFromBase64(thisIVirtualFileSystem,string,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.CreateBinaryFileFromBase64\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, string\)') | Creates a binary file from a base64 encoded string\. |
| [CreateBinaryFileWithDirectories\(this IVirtualFileSystem, string, byte\[\]\)](VFSBinaryExtensions.CreateBinaryFileWithDirectories(thisIVirtualFileSystem,string,byte[]).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.CreateBinaryFileWithDirectories\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, byte\[\]\)') | Creates a binary file with auto\-created directories\. |
| [GetFileInfo\(this IVirtualFileSystem, string\)](VFSBinaryExtensions.GetFileInfo(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.GetFileInfo\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Gets file information including type and size\. |
| [GetFileSize\(this IVirtualFileSystem, string\)](VFSBinaryExtensions.GetFileSize(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.GetFileSize\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Gets the size of a file in bytes\. |
| [IsBinaryFile\(this IVirtualFileSystem, string\)](VFSBinaryExtensions.IsBinaryFile(thisIVirtualFileSystem,string).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.IsBinaryFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string\)') | Checks if a file contains binary data\. |
| [TryCreateBinaryFile\(this IVirtualFileSystem, string, byte\[\]\)](VFSBinaryExtensions.TryCreateBinaryFile(thisIVirtualFileSystem,string,byte[]).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.TryCreateBinaryFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, byte\[\]\)') | Safely creates a binary file without throwing exceptions\. |
| [TryReadBinaryFile\(this IVirtualFileSystem, string, byte\[\]\)](VFSBinaryExtensions.TryReadBinaryFile(thisIVirtualFileSystem,string,byte[]).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.TryReadBinaryFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, byte\[\]\)') | Reads binary content from a file if it contains binary data\. |
| [TryWriteBinaryFile\(this IVirtualFileSystem, string, byte\[\]\)](VFSBinaryExtensions.TryWriteBinaryFile(thisIVirtualFileSystem,string,byte[]).md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSBinaryExtensions\.TryWriteBinaryFile\(this Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem, string, byte\[\]\)') | Writes binary content to an existing file\. |
