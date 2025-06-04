#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSDirectoryMovedArgs Class

Provides data for the DirectoryMoved event\.

```csharp
public sealed class VFSDirectoryMovedArgs : Atypical.VirtualFileSystem.Core.VFSEventArgs
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [System\.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System\.EventArgs') &#129106; [VFSEventArgs](VFSEventArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs') &#129106; VFSDirectoryMovedArgs

| Constructors | |
| :--- | :--- |
| [VFSDirectoryMovedArgs\(VFSDirectoryPath, VFSDirectoryPath\)](VFSDirectoryMovedArgs.VFSDirectoryMovedArgs(VFSDirectoryPath,VFSDirectoryPath).md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs\.VFSDirectoryMovedArgs\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Initializes a new instance of the [VFSDirectoryMovedArgs](VFSDirectoryMovedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs') class\. |

| Properties | |
| :--- | :--- |
| [DestinationPath](VFSDirectoryMovedArgs.DestinationPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs\.DestinationPath') | Gets the destination path of the moved directory\. |
| [Message](VFSDirectoryMovedArgs.Message.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs\.Message') | Gets the message\. |
| [MessageTemplate](VFSDirectoryMovedArgs.MessageTemplate.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs\.MessageTemplate') | Gets the message template\. |
| [MessageWithMarkup](VFSDirectoryMovedArgs.MessageWithMarkup.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs\.MessageWithMarkup') | Gets the message with markup\. |
| [SourcePath](VFSDirectoryMovedArgs.SourcePath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs\.SourcePath') | Gets the source path of the moved directory\. |
| [Timestamp](VFSDirectoryMovedArgs.Timestamp.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs\.Timestamp') | Gets the timestamp when the directory was moved\. |
