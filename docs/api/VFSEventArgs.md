#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSEventArgs Class

Represents the base class for all VFS event arguments\.

```csharp
public abstract class VFSEventArgs : System.EventArgs
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.EventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.eventargs 'System\.EventArgs') → VFSEventArgs

Derived  
↳ [VFSDirectoryCreatedArgs](VFSDirectoryCreatedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryCreatedArgs')  
↳ [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs')  
↳ [VFSDirectoryMovedArgs](VFSDirectoryMovedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs')  
↳ [VFSDirectoryRenamedArgs](VFSDirectoryRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryRenamedArgs')  
↳ [VFSFileCreatedArgs](VFSFileCreatedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileCreatedArgs')  
↳ [VFSFileDeletedArgs](VFSFileDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileDeletedArgs')  
↳ [VFSFileMovedArgs](VFSFileMovedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileMovedArgs')  
↳ [VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs')

| Properties | |
| :--- | :--- |
| [Message](VFSEventArgs.Message.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.Message') | Gets the message\. |
| [MessageTemplate](VFSEventArgs.MessageTemplate.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.MessageTemplate') | Gets the message template\. |
| [MessageWithMarkup](VFSEventArgs.MessageWithMarkup.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.MessageWithMarkup') | Gets the message with markup\. |

| Methods | |
| :--- | :--- |
| [ToMarkup\(string, object\[\]\)](VFSEventArgs.ToMarkup(string,object[]).md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.ToMarkup\(string, object\[\]\)') | Transforms a message into a markup message with the specified color\. |
