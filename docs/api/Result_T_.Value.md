#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result&lt;T&gt;](Result_T_.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>')

## Result\<T\>\.Value Property

Gets the success value\. Only available when IsSuccess is true\.

```csharp
public T Value { get; }
```

#### Property Value
[T](Result_T_.md#Atypical.VirtualFileSystem.Core.Models.Result_T_.T 'Atypical\.VirtualFileSystem\.Core\.Models\.Result\<T\>\.T')

#### Exceptions

[System\.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System\.InvalidOperationException')  
Thrown when accessing Value on a failed result\.