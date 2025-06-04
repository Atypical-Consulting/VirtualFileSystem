#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')

## Result\<T\>\.OnFailure\(Action\<string\>\) Method

Executes an action if the result is a failure\.

```csharp
public Atypical.VirtualFileSystem.Core.Result<T> OnFailure(System.Action<string> action);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.OnFailure(System.Action_string_).action'></a>

`action` [System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')

The action to execute with the error message\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
The current result for chaining\.