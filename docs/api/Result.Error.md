#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')

## Result\.Error Property

Gets the error message\. Only available when IsFailure is true\.

```csharp
public string Error { get; }
```

#### Property Value
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

#### Exceptions

[System\.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System\.InvalidOperationException')  
Thrown when accessing Error on a successful result\.