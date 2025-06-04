#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')

## Result\.Combine\(Result\) Method

Combines this result with another result\.

```csharp
public Atypical.VirtualFileSystem.Core.Result Combine(Atypical.VirtualFileSystem.Core.Result other);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Result.Combine(Atypical.VirtualFileSystem.Core.Result).other'></a>

`other` [Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')

The other result to combine with\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Result')  
Success if both results are successful, otherwise failure with the first error\.