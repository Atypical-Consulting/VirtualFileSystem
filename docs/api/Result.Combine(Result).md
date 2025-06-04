#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models').[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')

## Result\.Combine\(Result\) Method

Combines this result with another result\.

```csharp
public Atypical.VirtualFileSystem.Core.Models.Result Combine(Atypical.VirtualFileSystem.Core.Models.Result other);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Models.Result.Combine(Atypical.VirtualFileSystem.Core.Models.Result).other'></a>

`other` [Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')

The other result to combine with\.

#### Returns
[Result](Result.md 'Atypical\.VirtualFileSystem\.Core\.Models\.Result')  
Success if both results are successful, otherwise failure with the first error\.