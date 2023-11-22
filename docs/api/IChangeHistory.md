#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core')

## IChangeHistory Interface

Represents a history of changes in a virtual file system.

```csharp
public interface IChangeHistory
```

Derived  
&#8627; [ChangeHistory](ChangeHistory.md 'Atypical.VirtualFileSystem.Core.ChangeHistory')

| Properties | |
| :--- | :--- |
| [RedoStack](IChangeHistory.RedoStack.md 'Atypical.VirtualFileSystem.Core.IChangeHistory.RedoStack') | Gets the redo stack. |
| [UndoStack](IChangeHistory.UndoStack.md 'Atypical.VirtualFileSystem.Core.IChangeHistory.UndoStack') | Gets the undo stack. |

| Methods | |
| :--- | :--- |
| [AddChange(VFSEventArgs)](IChangeHistory.AddChange(VFSEventArgs).md 'Atypical.VirtualFileSystem.Core.IChangeHistory.AddChange(Atypical.VirtualFileSystem.Core.VFSEventArgs)') | Adds a change to the history. |
| [OnChange(VFSEventArgs)](IChangeHistory.OnChange(VFSEventArgs).md 'Atypical.VirtualFileSystem.Core.IChangeHistory.OnChange(Atypical.VirtualFileSystem.Core.VFSEventArgs)') | Handles the change event from the virtual file system. |
| [Redo()](IChangeHistory.Redo().md 'Atypical.VirtualFileSystem.Core.IChangeHistory.Redo()') | Redoes the most recent undone change. |
| [Undo()](IChangeHistory.Undo().md 'Atypical.VirtualFileSystem.Core.IChangeHistory.Undo()') | Undoes the most recent change. |
