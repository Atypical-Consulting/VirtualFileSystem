#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')

## Result\<T\>\.Deconstruct\(bool, object\) Method

Deconstructs the result into success flag and value/error\.

```csharp
public void Deconstruct(out bool isSuccess, out object? valueOrError);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Deconstruct(bool,object).isSuccess'></a>

`isSuccess` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the operation was successful\.

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Deconstruct(bool,object).valueOrError'></a>

`valueOrError` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The value if successful, or the error message if failed\.