#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSDirectoryDeletedArgs Class

Provides data for the DirectoryDeleted event\.

```csharp
public sealed class VFSDirectoryDeletedArgs : Atypical.VirtualFileSystem.Core.VFSEventArgs
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.EventArgs](https://learn.microsoft.com/en-us/dotnet/api/system.eventargs 'System\.EventArgs') → [VFSEventArgs](VFSEventArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSEventArgs') → VFSDirectoryDeletedArgs

| Constructors | |
| :--- | :--- |
| [VFSDirectoryDeletedArgs\(VFSDirectoryPath\)](VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs.md#Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath) 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.VFSDirectoryDeletedArgs\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Initializes a new instance of the [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs') class\. |
| [VFSDirectoryDeletedArgs\(VFSDirectoryPath, ImmutableArray&lt;VFSNodeSnapshot&gt;\)](VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs.md#Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,System.Collections.Immutable.ImmutableArray_Atypical.VirtualFileSystem.Core.VFSNodeSnapshot_) 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.VFSDirectoryDeletedArgs\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, System\.Collections\.Immutable\.ImmutableArray\<Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot\>\)') | Initializes a new instance of the [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs') class with a snapshot of the deleted subtree so the deletion can be reversed\. |

| Properties | |
| :--- | :--- |
| [DeletedNodes](VFSDirectoryDeletedArgs.DeletedNodes.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.DeletedNodes') | Gets the snapshot of the directory and its descendants that were removed, used to restore the subtree on undo\. |
| [Message](VFSDirectoryDeletedArgs.Message.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.Message') | Gets the message\. |
| [MessageTemplate](VFSDirectoryDeletedArgs.MessageTemplate.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.MessageTemplate') | Gets the message template\. |
| [MessageWithMarkup](VFSDirectoryDeletedArgs.MessageWithMarkup.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.MessageWithMarkup') | Gets the message with markup\. |
| [Path](VFSDirectoryDeletedArgs.Path.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.Path') | Gets the path of the deleted directory\. |
| [Timestamp](VFSDirectoryDeletedArgs.Timestamp.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.Timestamp') | Gets the timestamp when the directory was deleted\. |
