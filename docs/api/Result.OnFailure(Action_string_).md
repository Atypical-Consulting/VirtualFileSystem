#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')

## Result\.OnFailure\(Action\<string\>\) Method

Executes an action if the result is a failure\.

```csharp
public Atypical.VirtualFileSystem.Core.Result OnFailure(System.Action<string> action);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result.OnFailure(System.Action_string_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute with the error message\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
The current result for chaining\.