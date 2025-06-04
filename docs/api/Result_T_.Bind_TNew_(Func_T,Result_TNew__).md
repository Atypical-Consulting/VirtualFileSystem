#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')

## Result\<T\>\.Bind\<TNew\>\(Func\<T,Result\<TNew\>\>\) Method

Transforms the success value to another result\.

```csharp
public Atypical.VirtualFileSystem.Core.Models.Result<TNew> Bind<TNew>(System.Func<T,Atypical.VirtualFileSystem.Core.Models.Result<TNew>> mapper);
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Models.Result_TNew__).TNew'></a>

`TNew`

The new value type\.
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Models.Result_TNew__).mapper'></a>

`mapper` [System\.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Models.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>\.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[Atypical\.VirtualFileSystem\.Core\.Models\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')[TNew](Result_T_.Bind_TNew_(Func_T,Result_TNew__).md#Atypical.VirtualFileSystem.Core.Models.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Models.Result_TNew__).TNew 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>\.Bind\<TNew\>\(System\.Func\<T,Atypical\.VirtualFileSystem\.Core\.Models\.Result\<TNew\>\>\)\.TNew')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')

The transformation function that returns a result\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Models\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')[TNew](Result_T_.Bind_TNew_(Func_T,Result_TNew__).md#Atypical.VirtualFileSystem.Core.Models.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Models.Result_TNew__).TNew 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>\.Bind\<TNew\>\(System\.Func\<T,Atypical\.VirtualFileSystem\.Core\.Models\.Result\<TNew\>\>\)\.TNew')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')  
The result of the transformation or the original error\.