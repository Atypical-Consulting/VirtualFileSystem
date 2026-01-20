#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')

## Result\.Failure Method

| Overloads | |
| :--- | :--- |
| [Failure\(string\)](Result.Failure.md#Atypical.VirtualFileSystem.Core.Result.Failure(string) 'Atypical\.VirtualFileSystem\.Core\.Result\.Failure\(string\)') | Creates a failed result with the specified error message\. |
| [Failure\(Exception\)](Result.Failure.md#Atypical.VirtualFileSystem.Core.Result.Failure(System.Exception) 'Atypical\.VirtualFileSystem\.Core\.Result\.Failure\(System\.Exception\)') | Creates a failed result from an exception\. |

<a name='Atypical.VirtualFileSystem.Core.Result.Failure(string)'></a>

## Result\.Failure\(string\) Method

Creates a failed result with the specified error message\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result Failure(string error);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result.Failure(string).error'></a>

`error` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
A failed result\.

<a name='Atypical.VirtualFileSystem.Core.Result.Failure(System.Exception)'></a>

## Result\.Failure\(Exception\) Method

Creates a failed result from an exception\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result Failure(System.Exception exception);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result.Failure(System.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
A failed result with the exception message\.