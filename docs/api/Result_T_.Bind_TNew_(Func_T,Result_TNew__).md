#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')

## Result\<T\>\.Bind\<TNew\>\(Func\<T,Result\<TNew\>\>\) Method

Transforms the success value to another result\.

```csharp
public Atypical.VirtualFileSystem.Core.Result<TNew> Bind<TNew>(System.Func<T,Atypical.VirtualFileSystem.Core.Result<TNew>> mapper);
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Result_TNew__).TNew'></a>

`TNew`

The new value type\.
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Result_TNew__).mapper'></a>

`mapper` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[TNew](Result_T_.Bind_TNew_(Func_T,Result_TNew__).md#Atypical.VirtualFileSystem.Core.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Result_TNew__).TNew 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Bind\<TNew\>\(System\.Func\<T,Atypical\.VirtualFileSystem\.Core\.Result\<TNew\>\>\)\.TNew')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The transformation function that returns a result\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[TNew](Result_T_.Bind_TNew_(Func_T,Result_TNew__).md#Atypical.VirtualFileSystem.Core.Result_T_.Bind_TNew_(System.Func_T,Atypical.VirtualFileSystem.Core.Result_TNew__).TNew 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Bind\<TNew\>\(System\.Func\<T,Atypical\.VirtualFileSystem\.Core\.Result\<TNew\>\>\)\.TNew')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
The result of the transformation or the original error\.