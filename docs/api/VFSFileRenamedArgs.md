#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSFileRenamedArgs Class

Provides data for the FileRenamed event\.

```csharp
public sealed class VFSFileRenamedArgs : Atypical.VirtualFileSystem.Core.VFSEventArgs
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [System\.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System\.EventArgs') &#129106; [VFSEventArgs](VFSEventArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs') &#129106; VFSFileRenamedArgs

| Constructors | |
| :--- | :--- |
| [VFSFileRenamedArgs\(VFSFilePath, string, string\)](VFSFileRenamedArgs.VFSFileRenamedArgs(VFSFilePath,string,string).md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.VFSFileRenamedArgs\(Atypical\.VirtualFileSystem\.Core\.VFSFilePath, string, string\)') | Initializes a new instance of the [VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs') class\. |

| Properties | |
| :--- | :--- |
| [Message](VFSFileRenamedArgs.Message.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.Message') | Gets the message\. |
| [MessageTemplate](VFSFileRenamedArgs.MessageTemplate.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.MessageTemplate') | Gets the message template\. |
| [MessageWithMarkup](VFSFileRenamedArgs.MessageWithMarkup.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.MessageWithMarkup') | Gets the message with markup\. |
| [NewName](VFSFileRenamedArgs.NewName.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.NewName') | Gets the new name of the renamed file\. |
| [OldName](VFSFileRenamedArgs.OldName.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.OldName') | Gets the old name of the renamed file\. |
| [Path](VFSFileRenamedArgs.Path.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.Path') | Gets the source path of the renamed file\. |
| [Timestamp](VFSFileRenamedArgs.Timestamp.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs\.Timestamp') | Gets the timestamp when the file was renamed\. |
