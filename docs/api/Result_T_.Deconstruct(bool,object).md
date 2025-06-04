#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')

## Result\<T\>\.Deconstruct\(bool, object\) Method

Deconstructs the result into success flag and value/error\.

```csharp
public void Deconstruct(out bool isSuccess, out object? valueOrError);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result_T_.Deconstruct(bool,object).isSuccess'></a>

`isSuccess` [System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')

Whether the operation was successful\.

<a name='Atypical.VirtualFileSystem.Core.Models.Result_T_.Deconstruct(bool,object).valueOrError'></a>

`valueOrError` [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object')

The value if successful, or the error message if failed\.