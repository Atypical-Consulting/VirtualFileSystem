#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')

## Result\.Map\<T\>\(Func\<T\>\) Method

Transforms the result to a result with a value\.

```csharp
public Atypical.VirtualFileSystem.Core.Result<T> Map<T>(Func<T> valueFactory);
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Result.Map_T_(Func_T_).T'></a>

`T`

The value type\.
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result.Map_T_(Func_T_).valueFactory'></a>

`valueFactory` [System\.Func](https://learn.microsoft.com/en-us/dotnet/api/system.func 'System\.Func')

Function to create the value on success\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[T](Result.Map_T_(Func_T_).md#Atypical.VirtualFileSystem.Core.Result.Map_T_(Func_T_).T 'Atypical\.VirtualFileSystem\.Core\.Result\.Map\<T\>\(Func\<T\>\)\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
A result with value on success or the original error on failure\.