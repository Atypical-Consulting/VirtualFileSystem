#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')

## Result\.Map\<T\>\(Func\<T\>\) Method

Transforms the result to a result with a value\.

```csharp
public Atypical.VirtualFileSystem.Core.Result<T> Map<T>(System.Func<T> valueFactory);
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Result.Map_T_(System.Func_T_).T'></a>

`T`

The value type\.
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result.Map_T_(System.Func_T_).valueFactory'></a>

`valueFactory` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[T](Result.Map_T_(Func_T_).md#Atypical.VirtualFileSystem.Core.Result.Map_T_(System.Func_T_).T 'Atypical\.VirtualFileSystem\.Core\.Result\.Map\<T\>\(System\.Func\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

Function to create the value on success\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[T](Result.Map_T_(Func_T_).md#Atypical.VirtualFileSystem.Core.Result.Map_T_(System.Func_T_).T 'Atypical\.VirtualFileSystem\.Core\.Result\.Map\<T\>\(System\.Func\<T\>\)\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
A result with value on success or the original error on failure\.