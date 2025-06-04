#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[BinaryFileNode](BinaryFileNode.md 'Atypical\.VirtualFileSystem\.Core\.Models\.BinaryFileNode')

## BinaryFileNode\.SetContentFromBase64\(string\) Method

Sets the content from a base64 encoded string\.

```csharp
public void SetContentFromBase64(string base64Content);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.BinaryFileNode.SetContentFromBase64(string).base64Content'></a>

`base64Content` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The base64 encoded content\.

Implements [SetContentFromBase64\(string\)](IBinaryFileNode.SetContentFromBase64(string).md 'Atypical\.VirtualFileSystem\.Core\.Models\.IBinaryFileNode\.SetContentFromBase64\(string\)')

#### Exceptions

[System\.FormatException](https://docs.microsoft.com/en-us/dotnet/api/System.FormatException 'System\.FormatException')  
Thrown when the base64 string is invalid\.