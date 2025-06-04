#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## PathSeparatorConfiguration Class

Configuration for path separators\.

```csharp
public sealed record PathSeparatorConfiguration : System.IEquatable<Atypical.VirtualFileSystem.Core.PathSeparatorConfiguration>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; PathSeparatorConfiguration

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[PathSeparatorConfiguration](PathSeparatorConfiguration.md 'Atypical\.VirtualFileSystem\.Core\.PathSeparatorConfiguration')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Properties | |
| :--- | :--- |
| [AllSeparators](PathSeparatorConfiguration.AllSeparators.md 'Atypical\.VirtualFileSystem\.Core\.PathSeparatorConfiguration\.AllSeparators') | Gets all accepted path separators\. |
| [AlternativeSeparators](PathSeparatorConfiguration.AlternativeSeparators.md 'Atypical\.VirtualFileSystem\.Core\.PathSeparatorConfiguration\.AlternativeSeparators') | Gets or sets alternative path separators that are accepted\. Default accepts both '/' and '\\'\. |
| [Default](PathSeparatorConfiguration.Default.md 'Atypical\.VirtualFileSystem\.Core\.PathSeparatorConfiguration\.Default') | Gets the default path separator configuration\. |
| [PrimarySeparator](PathSeparatorConfiguration.PrimarySeparator.md 'Atypical\.VirtualFileSystem\.Core\.PathSeparatorConfiguration\.PrimarySeparator') | Gets or sets the primary path separator\. Default is '/'\. |

| Methods | |
| :--- | :--- |
| [UnixOnly\(\)](PathSeparatorConfiguration.UnixOnly().md 'Atypical\.VirtualFileSystem\.Core\.PathSeparatorConfiguration\.UnixOnly\(\)') | Creates a configuration that only accepts forward slashes\. |
| [WindowsOnly\(\)](PathSeparatorConfiguration.WindowsOnly().md 'Atypical\.VirtualFileSystem\.Core\.PathSeparatorConfiguration\.WindowsOnly\(\)') | Creates a configuration that only accepts backslashes\. |
