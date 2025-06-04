#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Models](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Models 'Atypical\.VirtualFileSystem\.Core\.Models')

## PathSeparatorConfiguration Class

Configuration for path separators\.

```csharp
public sealed record PathSeparatorConfiguration : System.IEquatable<Atypical.VirtualFileSystem.Core.Models.PathSeparatorConfiguration>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; PathSeparatorConfiguration

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[PathSeparatorConfiguration](PathSeparatorConfiguration.md 'Atypical\.VirtualFileSystem\.Core\.Models\.PathSeparatorConfiguration')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Properties | |
| :--- | :--- |
| [AllSeparators](PathSeparatorConfiguration.AllSeparators.md 'Atypical\.VirtualFileSystem\.Core\.Models\.PathSeparatorConfiguration\.AllSeparators') | Gets all accepted path separators\. |
| [AlternativeSeparators](PathSeparatorConfiguration.AlternativeSeparators.md 'Atypical\.VirtualFileSystem\.Core\.Models\.PathSeparatorConfiguration\.AlternativeSeparators') | Gets or sets alternative path separators that are accepted\. Default accepts both '/' and '\\'\. |
| [Default](PathSeparatorConfiguration.Default.md 'Atypical\.VirtualFileSystem\.Core\.Models\.PathSeparatorConfiguration\.Default') | Gets the default path separator configuration\. |
| [PrimarySeparator](PathSeparatorConfiguration.PrimarySeparator.md 'Atypical\.VirtualFileSystem\.Core\.Models\.PathSeparatorConfiguration\.PrimarySeparator') | Gets or sets the primary path separator\. Default is '/'\. |

| Methods | |
| :--- | :--- |
| [UnixOnly\(\)](PathSeparatorConfiguration.UnixOnly().md 'Atypical\.VirtualFileSystem\.Core\.Models\.PathSeparatorConfiguration\.UnixOnly\(\)') | Creates a configuration that only accepts forward slashes\. |
| [WindowsOnly\(\)](PathSeparatorConfiguration.WindowsOnly().md 'Atypical\.VirtualFileSystem\.Core\.Models\.PathSeparatorConfiguration\.WindowsOnly\(\)') | Creates a configuration that only accepts backslashes\. |
