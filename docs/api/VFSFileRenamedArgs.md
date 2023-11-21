#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFSFileRenamedArgs Class

Provides data for the FileRenamed event.

```csharp
public sealed class VFSFileRenamedArgs : Atypical.VirtualFileSystem.Core.VFSEventArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs') &#129106; [VFSEventArgs](VFSEventArgs.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs') &#129106; VFSFileRenamedArgs

| Constructors | |
| :--- | :--- |
| [VFSFileRenamedArgs(VFSFilePath, VFSFilePath)](VFSFileRenamedArgs.VFSFileRenamedArgs(VFSFilePath,VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.VFSFileRenamedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath)') | Initializes a new instance of the [VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs') class. |

| Properties | |
| :--- | :--- |
| [DestinationPath](VFSFileRenamedArgs.DestinationPath.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.DestinationPath') | Gets the destination path of the renamed file. |
| [Message](VFSFileRenamedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.Message') | Gets the message. |
| [MessageTemplate](VFSFileRenamedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.MessageTemplate') | Gets the message template. |
| [MessageWithMarkup](VFSFileRenamedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.MessageWithMarkup') | Gets the message with markup. |
| [SourcePath](VFSFileRenamedArgs.SourcePath.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.SourcePath') | Gets the source path of the renamed file. |
| [Timestamp](VFSFileRenamedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSFileRenamedArgs.Timestamp') | Gets the timestamp when the file was renamed. |
