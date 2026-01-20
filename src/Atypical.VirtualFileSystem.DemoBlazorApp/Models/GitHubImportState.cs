namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Represents the state of a GitHub import operation.
/// </summary>
public class GitHubImportState
{
    /// <summary>
    /// Whether an import is currently in progress.
    /// </summary>
    public bool IsImporting { get; set; }

    /// <summary>
    /// The current file being processed (1-based index).
    /// </summary>
    public int CurrentFile { get; set; }

    /// <summary>
    /// The total number of files to process.
    /// </summary>
    public int TotalFiles { get; set; }

    /// <summary>
    /// The path of the current file being processed.
    /// </summary>
    public string? CurrentPath { get; set; }

    /// <summary>
    /// Any error message from the import operation.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Whether the import was cancelled.
    /// </summary>
    public bool WasCancelled { get; set; }

    /// <summary>
    /// Gets the progress percentage (0-100).
    /// </summary>
    public int ProgressPercent => TotalFiles > 0
        ? (int)((CurrentFile / (double)TotalFiles) * 100)
        : 0;

    /// <summary>
    /// Gets the progress text (e.g., "3/10 files").
    /// </summary>
    public string ProgressText => TotalFiles > 0
        ? $"{CurrentFile}/{TotalFiles} files"
        : "Preparing...";

    /// <summary>
    /// Resets the state for a new import.
    /// </summary>
    public void Reset()
    {
        IsImporting = false;
        CurrentFile = 0;
        TotalFiles = 0;
        CurrentPath = null;
        ErrorMessage = null;
        WasCancelled = false;
    }
}
