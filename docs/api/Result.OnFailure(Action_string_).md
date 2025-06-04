#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')

## Result\.OnFailure\(Action\<string\>\) Method

Executes an action if the result is a failure\.

```csharp
public Atypical.VirtualFileSystem.Core.Models.Result OnFailure(System.Action<string> action);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result.OnFailure(System.Action_string_).action'></a>

`action` [System\.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System\.Action\`1')

The action to execute with the error message\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
The current result for chaining\.