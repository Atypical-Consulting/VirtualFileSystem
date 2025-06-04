#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')

## Result\<T\>\.OnFailure\(Action\<string\>\) Method

Executes an action if the result is a failure\.

```csharp
public Atypical.VirtualFileSystem.Core.Models.Result<T> OnFailure(System.Action<string> action);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result_T_.OnFailure(System.Action_string_).action'></a>

`action` [System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')

The action to execute with the error message\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Models\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Models.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')  
The current result for chaining\.