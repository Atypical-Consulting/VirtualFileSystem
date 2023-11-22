namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Represents a history of changes in a virtual file system.
/// </summary>
public interface IChangeHistory
{
    /// <summary>
    /// Gets the undo stack.
    /// </summary>
    IReadOnlyCollection<VFSEventArgs> UndoStack { get; }

    /// <summary>
    /// Gets the redo stack.
    /// </summary>
    IReadOnlyCollection<VFSEventArgs> RedoStack { get; }

    /// <summary>
    /// Handles the change event from the virtual file system.
    /// </summary>
    /// <param name="args">The event arguments.</param>
    void OnChange(VFSEventArgs args);

    /// <summary>
    /// Undoes the most recent change.
    /// </summary>
    /// <returns>The virtual file system after the undo operation.</returns>
    IVirtualFileSystem Undo();

    /// <summary>
    /// Redoes the most recent undone change.
    /// </summary>
    /// <returns>The virtual file system after the redo operation.</returns>
    IVirtualFileSystem Redo();
}