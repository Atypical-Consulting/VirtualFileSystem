#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## Result\<T\> Struct

Represents the result of an operation that can either succeed or fail without throwing exceptions\.

```csharp
public readonly record struct Result<T> : System.IEquatable<Atypical.VirtualFileSystem.Core.Result<T>>
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Result_T_.T'></a>

`T`

The type of the success value\.

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Properties | |
| :--- | :--- |
| [Error](Result_T_.Error.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Error') | Gets the error message\. Only available when IsFailure is true\. |
| [IsFailure](Result_T_.IsFailure.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.IsFailure') | Gets a value indicating whether the operation failed\. |
| [IsSuccess](Result_T_.IsSuccess.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.IsSuccess') | Gets a value indicating whether the operation was successful\. |
| [Value](Result_T_.Value.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Value') | Gets the success value\. Only available when IsSuccess is true\. |

| Methods | |
| :--- | :--- |
| [Bind&lt;TNew&gt;\(Func&lt;T,Result&lt;TNew&gt;&gt;\)](Result_T_.Bind_TNew_(Func_T,Result_TNew__).md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Bind\<TNew\>\(System\.Func\<T,Atypical\.VirtualFileSystem\.Core\.Result\<TNew\>\>\)') | Transforms the success value to another result\. |
| [Deconstruct\(bool, object\)](Result_T_.Deconstruct(bool,object).md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Deconstruct\(bool, object\)') | Deconstructs the result into success flag and value/error\. |
| [Failure\(string\)](Result_T_.Failure.md#Atypical.VirtualFileSystem.Core.Result_T_.Failure(string) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Failure\(string\)') | Creates a failed result with the specified error message\. |
| [Failure\(Exception\)](Result_T_.Failure.md#Atypical.VirtualFileSystem.Core.Result_T_.Failure(System.Exception) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Failure\(System\.Exception\)') | Creates a failed result from an exception\. |
| [GetValueOrDefault\(Func&lt;string,T&gt;\)](Result_T_.GetValueOrDefault.md#Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(System.Func_string,T_) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.GetValueOrDefault\(System\.Func\<string,T\>\)') | Gets the value if successful, or gets a value from the specified function\. |
| [GetValueOrDefault\(T\)](Result_T_.GetValueOrDefault.md#Atypical.VirtualFileSystem.Core.Result_T_.GetValueOrDefault(T) 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.GetValueOrDefault\(T\)') | Gets the value if successful, or returns the specified default value\. |
| [Map&lt;TNew&gt;\(Func&lt;T,TNew&gt;\)](Result_T_.Map_TNew_(Func_T,TNew_).md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Map\<TNew\>\(System\.Func\<T,TNew\>\)') | Transforms the success value to another type\. |
| [OnFailure\(Action&lt;string&gt;\)](Result_T_.OnFailure(Action_string_).md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.OnFailure\(System\.Action\<string\>\)') | Executes an action if the result is a failure\. |
| [OnSuccess\(Action&lt;T&gt;\)](Result_T_.OnSuccess(Action_T_).md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.OnSuccess\(System\.Action\<T\>\)') | Executes an action if the result is successful\. |
| [Success\(T\)](Result_T_.Success(T).md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.Success\(T\)') | Creates a successful result with the specified value\. |
| [ToString\(\)](Result_T_.ToString().md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.ToString\(\)') | Returns a string representation of the result\. |

| Operators | |
| :--- | :--- |
| [implicit operator Result&lt;T&gt;\(T\)](Result_T_.implicitoperatorResult_T_(T).md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>\.op\_Implicit Atypical\.VirtualFileSystem\.Core\.Result\<T\>\(T\)') | Implicitly converts a value to a successful result\. |
