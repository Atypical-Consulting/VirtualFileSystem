#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## VFSFileMovedArgs Class

Provides data for the FileMoved event.

```csharp
public sealed class VFSFileMovedArgs : Atypical.VirtualFileSystem.Core.VFSEventArgs
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs') &#129106; [VFSEventArgs](VFSEventArgs.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs') &#129106; VFSFileMovedArgs

| Constructors | |
| :--- | :--- |
| [VFSFileMovedArgs(VFSFilePath, VFSFilePath)](VFSFileMovedArgs.VFSFileMovedArgs(VFSFilePath,VFSFilePath).md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.VFSFileMovedArgs(Atypical.VirtualFileSystem.Core.VFSFilePath, Atypical.VirtualFileSystem.Core.VFSFilePath)') | Initializes a new instance of the [VFSFileMovedArgs](VFSFileMovedArgs.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs') class. |

| Properties | |
| :--- | :--- |
| [DestinationPath](VFSFileMovedArgs.DestinationPath.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.DestinationPath') | Gets the destination path of the moved file. |
| [Message](VFSFileMovedArgs.Message.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.Message') | Gets the message. |
| [MessageTemplate](VFSFileMovedArgs.MessageTemplate.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.MessageTemplate') | Gets the message template. |
| [MessageWithMarkup](VFSFileMovedArgs.MessageWithMarkup.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.MessageWithMarkup') | Gets the message with markup. |
| [SourcePath](VFSFileMovedArgs.SourcePath.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.SourcePath') | Gets the source path of the moved file. |
| [Timestamp](VFSFileMovedArgs.Timestamp.md 'Atypical.VirtualFileSystem.Core.VFSFileMovedArgs.Timestamp') | Gets the timestamp when the file was moved. |
