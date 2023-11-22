#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFSFileDeletedArgs Class

Provides data for the FileDeleted event.

```csharp
public sealed class VFSFileDeletedArgs : Atypical.VirtualFileSystem.Core.VFSEventArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs') &#129106; [VFSEventArgs](VFSEventArgs.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs') &#129106; VFSFileDeletedArgs

| Constructors | |
| :--- | :--- |
| [VFSFileDeletedArgs(VFSFilePath, string)](VFSFileDeletedArgs.VFSFileDeletedArgs(VFSFilePath,string).md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.VFSFileDeletedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath, string)') | Initializes a new instance of the [VFSFileDeletedArgs](VFSFileDeletedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs') class. |

| Properties | |
| :--- | :--- |
| [Content](VFSFileDeletedArgs.Content.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Content') | Gets the content of the deleted file. |
| [Message](VFSFileDeletedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Message') | Gets the message. |
| [MessageTemplate](VFSFileDeletedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.MessageTemplate') | Gets the message template. |
| [MessageWithMarkup](VFSFileDeletedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.MessageWithMarkup') | Gets the message with markup. |
| [Path](VFSFileDeletedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Path') | Gets the path of the deleted file. |
| [Timestamp](VFSFileDeletedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSFileDeletedArgs.Timestamp') | Gets the timestamp when the file was deleted. |
