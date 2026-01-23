#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSEventArgs Class

Represents the base class for all VFS event arguments\.

```csharp
public abstract class VFSEventArgs
```

Inheritance [System\.EventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.eventargs 'System\.EventArgs') &#129106; VFSEventArgs

Derived  
&#8627; [VFSDirectoryCreatedArgs](VFSDirectoryCreatedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryCreatedArgs')  
&#8627; [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs')  
&#8627; [VFSDirectoryMovedArgs](VFSDirectoryMovedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryMovedArgs')  
&#8627; [VFSDirectoryRenamedArgs](VFSDirectoryRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryRenamedArgs')  
&#8627; [VFSFileCreatedArgs](VFSFileCreatedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileCreatedArgs')  
&#8627; [VFSFileDeletedArgs](VFSFileDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileDeletedArgs')  
&#8627; [VFSFileMovedArgs](VFSFileMovedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileMovedArgs')  
&#8627; [VFSFileRenamedArgs](VFSFileRenamedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSFileRenamedArgs')

| Properties | |
| :--- | :--- |
| [Message](VFSEventArgs.Message.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.Message') | Gets the message\. |
| [MessageTemplate](VFSEventArgs.MessageTemplate.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.MessageTemplate') | Gets the message template\. |
| [MessageWithMarkup](VFSEventArgs.MessageWithMarkup.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.MessageWithMarkup') | Gets the message with markup\. |

| Methods | |
| :--- | :--- |
| [ToMarkup\(string, object\[\]\)](VFSEventArgs.ToMarkup(string,object[]).md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\.ToMarkup\(string, object\[\]\)') | Transforms a message into a markup message with the specified color\. |
