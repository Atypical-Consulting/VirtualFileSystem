#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## EventConfiguration Class

Configuration for event handling\.

```csharp
public sealed record EventConfiguration : System.IEquatable<Atypical.VirtualFileSystem.Core.EventConfiguration>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; EventConfiguration

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[EventConfiguration](EventConfiguration.md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Properties | |
| :--- | :--- |
| [AsyncEvents](EventConfiguration.AsyncEvents.md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.AsyncEvents') | Gets or sets whether events should be fired asynchronously\. Default is false for synchronous events\. |
| [Default](EventConfiguration.Default.md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.Default') | Gets the default event configuration\. |
| [EnableDirectoryEvents](EventConfiguration.EnableDirectoryEvents.md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.EnableDirectoryEvents') | Gets or sets whether to enable directory operation events\. |
| [EnableEvents](EventConfiguration.EnableEvents.md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.EnableEvents') | Gets or sets whether to enable all events\. Default is true\. |
| [EnableFileEvents](EventConfiguration.EnableFileEvents.md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.EnableFileEvents') | Gets or sets whether to enable file operation events\. |
| [MaxEventHandlers](EventConfiguration.MaxEventHandlers.md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.MaxEventHandlers') | Gets or sets the maximum number of event handlers per event type\. Default is 100\. Set to 0 for unlimited\. |

| Methods | |
| :--- | :--- |
| [DirectoryEventsOnly\(\)](EventConfiguration.DirectoryEventsOnly().md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.DirectoryEventsOnly\(\)') | Creates a configuration with only directory events enabled\. |
| [Disabled\(\)](EventConfiguration.Disabled().md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.Disabled\(\)') | Creates a configuration with all events disabled\. |
| [FileEventsOnly\(\)](EventConfiguration.FileEventsOnly().md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.FileEventsOnly\(\)') | Creates a configuration with only file events enabled\. |
| [WithAsyncEvents\(\)](EventConfiguration.WithAsyncEvents().md 'Atypical\.VirtualFileSystem\.Core\.EventConfiguration\.WithAsyncEvents\(\)') | Creates a configuration with asynchronous events\. |
