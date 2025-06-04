#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')

## Result\<T\>\.Map\<TNew\>\(Func\<T,TNew\>\) Method

Transforms the success value to another type\.

```csharp
public Atypical.VirtualFileSystem.Core.Result<TNew> Map<TNew>(System.Func<T,TNew> mapper);
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Map_TNew_(System.Func_T,TNew_).TNew'></a>

`TNew`

The new value type\.
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Map_TNew_(System.Func_T,TNew_).mapper'></a>

`mapper` [System\.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[TNew](Result_T_.Map_TNew_(Func_T,TNew_).md#Atypical.VirtualFileSystem.Core.Result_T_.Map_TNew_(System.Func_T,TNew_).TNew 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Map\<TNew\>\(System\.Func\<T,TNew\>\)\.TNew')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')

The transformation function\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[TNew](Result_T_.Map_TNew_(Func_T,TNew_).md#Atypical.VirtualFileSystem.Core.Result_T_.Map_TNew_(System.Func_T,TNew_).TNew 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Map\<TNew\>\(System\.Func\<T,TNew\>\)\.TNew')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
A new result with the transformed value or the original error\.