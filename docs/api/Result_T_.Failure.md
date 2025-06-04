#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')

## Result\<T\>\.Failure Method

| Overloads | |
| :--- | :--- |
| [Failure\(string\)](Result_T_.Failure.md#Atypical.VirtualFileSystem.Core.Result_T_.Failure(string) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Failure\(string\)') | Creates a failed result with the specified error message\. |
| [Failure\(Exception\)](Result_T_.Failure.md#Atypical.VirtualFileSystem.Core.Result_T_.Failure(System.Exception) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Failure\(System\.Exception\)') | Creates a failed result from an exception\. |

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Failure(string)'></a>

## Result\<T\>\.Failure\(string\) Method

Creates a failed result with the specified error message\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result<T> Failure(string error);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Failure(string).error'></a>

`error` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The error message\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
A failed result\.

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Failure(System.Exception)'></a>

## Result\<T\>\.Failure\(Exception\) Method

Creates a failed result from an exception\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result<T> Failure(System.Exception exception);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.Failure(System.Exception).exception'></a>

`exception` [System\.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System\.Exception')

The exception\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
A failed result with the exception message\.