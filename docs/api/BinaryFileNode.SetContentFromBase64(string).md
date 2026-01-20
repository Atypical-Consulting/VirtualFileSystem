#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.BinaryFileNode')

## BinaryFileNode\.SetContentFromBase64\(string\) Method

Sets the content from a base64 encoded string\.

```csharp
public void SetContentFromBase64(string base64Content);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.BinaryFileNode.SetContentFromBase64(string).base64Content'></a>

`base64Content` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base64 encoded content\.

Implements [SetContentFromBase64\(string\)](IBinaryFileNode.SetContentFromBase64(string).md 'Atypical\.VirtualFileSystem\.Core\.IBinaryFileNode\.SetContentFromBase64\(string\)')

#### Exceptions

[System\.FormatException](https://learn.microsoft.com/en-us/dotnet/api/system.formatexception 'System\.FormatException')  
Thrown when the base64 string is invalid\.