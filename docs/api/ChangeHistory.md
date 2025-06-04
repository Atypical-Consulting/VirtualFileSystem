#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## ChangeHistory Class

Represents a history of changes in a virtual file system\.

```csharp
public sealed class ChangeHistory : Atypical.VirtualFileSystem.Core.IChangeHistory, System.IDisposable
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; ChangeHistory

Implements [IChangeHistory](IChangeHistory.md 'Atypical\.VirtualFileSystem\.Core\.IChangeHistory'), [System\.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System\.IDisposable')

| Constructors | |
| :--- | :--- |
| [ChangeHistory\(IVirtualFileSystem\)](ChangeHistory.ChangeHistory(IVirtualFileSystem).md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.ChangeHistory\(Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem\)') | Initializes a new instance of the [ChangeHistory](ChangeHistory.md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory') class\. |

| Properties | |
| :--- | :--- |
| [RedoStack](ChangeHistory.RedoStack.md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.RedoStack') | Gets the redo stack\. |
| [UndoStack](ChangeHistory.UndoStack.md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.UndoStack') | Gets the undo stack\. |

| Methods | |
| :--- | :--- |
| [~ChangeHistory\(\)](ChangeHistory.~ChangeHistory().md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.~ChangeHistory\(\)') | Finalizes an instance of the [ChangeHistory](ChangeHistory.md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory') class\. |
| [AddChange\(VFSEventArgs\)](ChangeHistory.AddChange(VFSEventArgs).md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.AddChange\(Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\)') | Adds a change to the history\. |
| [Dispose\(\)](ChangeHistory.Dispose.md#Atypical.VirtualFileSystem.Core.ChangeHistory.Dispose() 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.Dispose\(\)') | Performs application\-defined tasks associated with freeing, releasing, or resetting unmanaged resources\. |
| [Dispose\(bool\)](ChangeHistory.Dispose.md#Atypical.VirtualFileSystem.Core.ChangeHistory.Dispose(bool) 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.Dispose\(bool\)') | Releases the unmanaged resources used by the [ChangeHistory](ChangeHistory.md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory') and optionally releases the managed resources\. |
| [OnChange\(VFSEventArgs\)](ChangeHistory.OnChange(VFSEventArgs).md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.OnChange\(Atypical\.VirtualFileSystem\.Core\.VFSEventArgs\)') | Handles the change event from the virtual file system\. |
| [Redo\(\)](ChangeHistory.Redo().md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.Redo\(\)') | Redoes the most recent undone change\. |
| [Undo\(\)](ChangeHistory.Undo().md 'Atypical\.VirtualFileSystem\.Core\.ChangeHistory\.Undo\(\)') | Undoes the most recent change\. |
