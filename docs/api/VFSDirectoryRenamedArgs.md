#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFSDirectoryRenamedArgs Class

Provides data for the DirectoryRenamed event.

```csharp
public sealed class VFSDirectoryRenamedArgs : Atypical.VirtualFileSystem.Core.VFSEventArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs') &#129106; [VFSEventArgs](VFSEventArgs.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs') &#129106; VFSDirectoryRenamedArgs

| Constructors | |
| :--- | :--- |
| [VFSDirectoryRenamedArgs(VFSDirectoryPath, string, string)](VFSDirectoryRenamedArgs.VFSDirectoryRenamedArgs(VFSDirectoryPath,string,string).md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.VFSDirectoryRenamedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath, string, string)') | Initializes a new instance of the [VFSDirectoryRenamedArgs](VFSDirectoryRenamedArgs.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs') class. |

| Properties | |
| :--- | :--- |
| [Message](VFSDirectoryRenamedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.Message') | Gets the message. |
| [MessageTemplate](VFSDirectoryRenamedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.MessageTemplate') | Gets the message template. |
| [MessageWithMarkup](VFSDirectoryRenamedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.MessageWithMarkup') | Gets the message with markup. |
| [NewName](VFSDirectoryRenamedArgs.NewName.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.NewName') | Gets the new name of the renamed file. |
| [OldName](VFSDirectoryRenamedArgs.OldName.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.OldName') | Gets the old name of the renamed directory. |
| [Path](VFSDirectoryRenamedArgs.Path.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.Path') | Gets the old path of the renamed directory. |
| [Timestamp](VFSDirectoryRenamedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSDirectoryRenamedArgs.Timestamp') | Gets the timestamp when the directory was renamed. |
