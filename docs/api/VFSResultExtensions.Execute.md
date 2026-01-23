#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSResultExtensions](VFSResultExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions')

## VFSResultExtensions\.Execute Method

| Overloads | |
| :--- | :--- |
| [Execute\(Action\)](VFSResultExtensions.Execute.md#Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute(Action) 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions\.Execute\(Action\)') | Executes an operation and returns a Result, converting any exception to a failure\. |
| [Execute&lt;T&gt;\(Func&lt;T&gt;\)](VFSResultExtensions.Execute.md#Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute_T_(Func_T_) 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions\.Execute\<T\>\(Func\<T\>\)') | Executes an operation that returns a value and returns a Result\. |

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute(Action)'></a>

## VFSResultExtensions\.Execute\(Action\) Method

Executes an operation and returns a Result, converting any exception to a failure\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result Execute(Action operation);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute(Action).operation'></a>

`operation` [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action')

The operation to execute\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
A Result indicating success or containing an error message\.

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute_T_(Func_T_)'></a>

## VFSResultExtensions\.Execute\<T\>\(Func\<T\>\) Method

Executes an operation that returns a value and returns a Result\.

```csharp
public static Atypical.VirtualFileSystem.Core.Result<T> Execute<T>(Func<T> operation);
```
#### Type parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute_T_(Func_T_).T'></a>

`T`

The return type\.
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute_T_(Func_T_).operation'></a>

`operation` [System\.Func](https://learn.microsoft.com/en-us/dotnet/api/system.func 'System\.Func')

The operation to execute\.

#### Returns
[Atypical\.VirtualFileSystem\.Core\.Result&lt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')[T](VFSResultExtensions.md#Atypical.VirtualFileSystem.Core.Extensions.VFSResultExtensions.Execute_T_(Func_T_).T 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSResultExtensions\.Execute\<T\>\(Func\<T\>\)\.T')[&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Result\<T\>')  
A Result containing the value or an error message\.