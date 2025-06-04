#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')

## Result\.Failure Method

| Overloads | |
| :--- | :--- |
| [Failure\(string\)](Result.Failure.md#Atypical.VirtualFileSystem.Core.Models.Result.Failure(string) 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\.Failure\(string\)') | Creates a failed result with the specified error message\. |
| [Failure\(Exception\)](Result.Failure.md#Atypical.VirtualFileSystem.Core.Models.Result.Failure(System.Exception) 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\.Failure\(System\.Exception\)') | Creates a failed result from an exception\. |

<a name='Atypical.VirtualFileSystem.Core.Models.Result.Failure(string)'></a>

## Result\.Failure\(string\) Method

Creates a failed result with the specified error message\.

```csharp
public static Atypical.VirtualFileSystem.Core.Models.Result Failure(string error);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result.Failure(string).error'></a>

`error` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The error message\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
A failed result\.

<a name='Atypical.VirtualFileSystem.Core.Models.Result.Failure(System.Exception)'></a>

## Result\.Failure\(Exception\) Method

Creates a failed result from an exception\.

```csharp
public static Atypical.VirtualFileSystem.Core.Models.Result Failure(System.Exception exception);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result.Failure(System.Exception).exception'></a>

`exception` [System\.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System\.Exception')

The exception\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
A failed result with the exception message\.