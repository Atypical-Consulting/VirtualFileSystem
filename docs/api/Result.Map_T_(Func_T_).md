#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')

## Result\.Map\<T\>\(Func\<T\>\) Method

Transforms the result to a result with a value\.

```csharp
public Atypical.VirtualFileSystem.Core.Models.Result<T> Map<T>(System.Func<T> valueFactory);
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result.Map_T_(System.Func_T_).T'></a>

`T`

The value type\.
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result.Map_T_(System.Func_T_).valueFactory'></a>

`valueFactory` [System\.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System\.Func\`1')[T](Result.Map_T_(Func_T_).md#Atypical.VirtualFileSystem.Core.Models.Result.Map_T_(System.Func_T_).T 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\.Map\<T\>\(System\.Func\<T\>\)\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System\.Func\`1')

Function to create the value on success\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Models\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')[T](Result.Map_T_(Func_T_).md#Atypical.VirtualFileSystem.Core.Models.Result.Map_T_(System.Func_T_).T 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\.Map\<T\>\(System\.Func\<T\>\)\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')  
A result with value on success or the original error on failure\.