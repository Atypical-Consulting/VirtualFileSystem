#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')

## Result\<T\>\.GetValueOrDefault Method

| Overloads | |
| :--- | :--- |
| [GetValueOrDefault\(Func&lt;string,T&gt;\)](Result_T_.GetValueOrDefault.md#Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(System.Func_string,T_) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.GetValueOrDefault\(System\.Func\<string,T\>\)') | Gets the value if successful, or gets a value from the specified function\. |
| [GetValueOrDefault\(T\)](Result_T_.GetValueOrDefault.md#Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(T) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.GetValueOrDefault\(T\)') | Gets the value if successful, or returns the specified default value\. |

<a name='Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(System.Func_string,T_)'></a>

## Result\<T\>\.GetValueOrDefault\(Func\<string,T\>\) Method

Gets the value if successful, or gets a value from the specified function\.

```csharp
public T GetValueOrDefault(System.Func<string,T> defaultValueFactory);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(System.Func_string,T_).defaultValueFactory'></a>

`defaultValueFactory` [System\.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System\.Func\`2')

Function to create default value from error message\.

#### Returns
[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')  
The success value or the result of the default value factory\.

<a name='Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(T)'></a>

## Result\<T\>\.GetValueOrDefault\(T\) Method

Gets the value if successful, or returns the specified default value\.

```csharp
public T GetValueOrDefault(T defaultValue=default(T));
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(T).defaultValue'></a>

`defaultValue` [T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')

The default value to return on failure\.

#### Returns
[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')  
The success value or the default value\.