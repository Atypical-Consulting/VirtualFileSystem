#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## Result Struct

Represents the result of an operation that can either succeed or fail without a return value\.

```csharp
public readonly record struct Result
```

| Properties | |
| :--- | :--- |
| [Error](Result.Error.md 'Atypical\.VirtualFileSystem\.Core\.Result\.Error') | Gets the error message\. Only available when IsFailure is true\. |
| [IsFailure](Result.IsFailure.md 'Atypical\.VirtualFileSystem\.Core\.Result\.IsFailure') | Gets a value indicating whether the operation failed\. |
| [IsSuccess](Result.IsSuccess.md 'Atypical\.VirtualFileSystem\.Core\.Result\.IsSuccess') | Gets a value indicating whether the operation was successful\. |

| Methods | |
| :--- | :--- |
| [Combine\(Result\)](Result.Combine(Result).md 'Atypical\.VirtualFileSystem\.Core\.Result\.Combine\(Atypical\.VirtualFileSystem\.Core\.Result\)') | Combines this result with another result\. |
| [Failure\(string\)](Result.Failure.md#Atypical.VirtualFileSystem.Core.Result.Failure(string) 'Atypical\.VirtualFileSystem\.Core\.Result\.Failure\(string\)') | Creates a failed result with the specified error message\. |
| [Failure\(Exception\)](Result.Failure.md#Atypical.VirtualFileSystem.Core.Result.Failure(System.Exception) 'Atypical\.VirtualFileSystem\.Core\.Result\.Failure\(System\.Exception\)') | Creates a failed result from an exception\. |
| [Map&lt;T&gt;\(Func&lt;T&gt;\)](Result.Map_T_(Func_T_).md 'Atypical\.VirtualFileSystem\.Core\.Result\.Map\<T\>\(Func\<T\>\)') | Transforms the result to a result with a value\. |
| [OnFailure\(Action&lt;string&gt;\)](Result.OnFailure(Action_string_).md 'Atypical\.VirtualFileSystem\.Core\.Result\.OnFailure\(Action\<string\>\)') | Executes an action if the result is a failure\. |
| [OnSuccess\(Action\)](Result.OnSuccess(Action).md 'Atypical\.VirtualFileSystem\.Core\.Result\.OnSuccess\(Action\)') | Executes an action if the result is successful\. |
| [Success\(\)](Result.Success().md 'Atypical\.VirtualFileSystem\.Core\.Result\.Success\(\)') | Creates a successful result\. |
| [ToString\(\)](Result.ToString().md 'Atypical\.VirtualFileSystem\.Core\.Result\.ToString\(\)') | Returns a string representation of the result\. |
