#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')

## Result\<T\>\.OnSuccess\(Action\<T\>\) Method

Executes an action if the result is successful\.

```csharp
public Atypical.VirtualFileSystem.Core.Models.Result<T> OnSuccess(System.Action<T> action);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result_T_.OnSuccess(System.Action_T_).action'></a>

`action` [System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Models.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')

The action to execute with the value\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Models\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Models.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')  
The current result for chaining\.