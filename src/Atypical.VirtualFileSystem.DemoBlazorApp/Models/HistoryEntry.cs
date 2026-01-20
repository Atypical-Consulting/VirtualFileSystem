using Atypical.VirtualFileSystem.Core;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// View model for displaying history entries in the UI.
/// </summary>
public record HistoryEntry(
    VFSEventArgs EventArgs,
    string Description,
    string IconSvg,
    string ColorClass,
    DateTimeOffset Timestamp,
    string AffectedPath)
{
    /// <summary>
    /// Gets the relative time string (e.g., "2 minutes ago").
    /// </summary>
    public string RelativeTime => FormatRelativeTime(Timestamp);

    /// <summary>
    /// Creates a HistoryEntry from VFSEventArgs.
    /// </summary>
    public static HistoryEntry FromEventArgs(VFSEventArgs args)
    {
        var (description, iconSvg, colorClass, affectedPath) = args switch
        {
            VFSDirectoryCreatedArgs e => (
                $"Created folder '{GetName(e.Path.Value)}'",
                PlusIcon,
                "bg-green-100 text-green-600",
                e.Path.Value),

            VFSFileCreatedArgs e => (
                $"Created file '{GetName(e.Path.Value)}'",
                PlusIcon,
                "bg-green-100 text-green-600",
                e.Path.Value),

            VFSDirectoryDeletedArgs e => (
                $"Deleted folder '{GetName(e.Path.Value)}'",
                MinusIcon,
                "bg-red-100 text-red-600",
                e.Path.Value),

            VFSFileDeletedArgs e => (
                $"Deleted file '{GetName(e.Path.Value)}'",
                MinusIcon,
                "bg-red-100 text-red-600",
                e.Path.Value),

            VFSDirectoryMovedArgs e => (
                $"Moved folder '{GetName(e.SourcePath.Value)}' to '{GetName(e.DestinationPath.Value)}'",
                ArrowIcon,
                "bg-amber-100 text-amber-600",
                e.DestinationPath.Value),

            VFSFileMovedArgs e => (
                $"Moved file '{GetName(e.SourcePath.Value)}' to '{GetName(e.DestinationPath.Value)}'",
                ArrowIcon,
                "bg-amber-100 text-amber-600",
                e.DestinationPath.Value),

            VFSDirectoryRenamedArgs e => (
                $"Renamed folder '{e.OldName}' to '{e.NewName}'",
                PencilIcon,
                "bg-blue-100 text-blue-600",
                e.Path.Value),

            VFSFileRenamedArgs e => (
                $"Renamed file '{e.OldName}' to '{e.NewName}'",
                PencilIcon,
                "bg-blue-100 text-blue-600",
                e.Path.Value),

            _ => (
                "Unknown operation",
                QuestionIcon,
                "bg-gray-100 text-gray-600",
                "")
        };

        var timestamp = GetTimestamp(args);

        return new HistoryEntry(args, description, iconSvg, colorClass, timestamp, affectedPath);
    }

    private static DateTimeOffset GetTimestamp(VFSEventArgs args) => args switch
    {
        VFSDirectoryCreatedArgs e => e.Timestamp,
        VFSFileCreatedArgs e => e.Timestamp,
        VFSDirectoryDeletedArgs e => e.Timestamp,
        VFSFileDeletedArgs e => e.Timestamp,
        VFSDirectoryMovedArgs e => e.Timestamp,
        VFSFileMovedArgs e => e.Timestamp,
        VFSDirectoryRenamedArgs e => e.Timestamp,
        VFSFileRenamedArgs e => e.Timestamp,
        _ => DateTimeOffset.Now
    };

    private static string GetName(string path)
    {
        var trimmed = path.TrimEnd('/');
        var lastSlash = trimmed.LastIndexOf('/');
        return lastSlash >= 0 ? trimmed[(lastSlash + 1)..] : trimmed;
    }

    private static string FormatRelativeTime(DateTimeOffset timestamp)
    {
        var diff = DateTimeOffset.Now - timestamp;

        return diff.TotalSeconds switch
        {
            < 5 => "just now",
            < 60 => $"{(int)diff.TotalSeconds} seconds ago",
            < 120 => "1 minute ago",
            < 3600 => $"{(int)diff.TotalMinutes} minutes ago",
            < 7200 => "1 hour ago",
            < 86400 => $"{(int)diff.TotalHours} hours ago",
            _ => timestamp.ToString("MMM d, h:mm tt")
        };
    }

    // SVG icons as constants
    private const string PlusIcon = """
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
        </svg>
        """;

    private const string MinusIcon = """
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" d="M5 12h14" />
        </svg>
        """;

    private const string ArrowIcon = """
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" d="M13.5 4.5 21 12m0 0-7.5 7.5M21 12H3" />
        </svg>
        """;

    private const string PencilIcon = """
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" d="m16.862 4.487 1.687-1.688a1.875 1.875 0 1 1 2.652 2.652L6.832 19.82a4.5 4.5 0 0 1-1.897 1.13l-2.685.8.8-2.685a4.5 4.5 0 0 1 1.13-1.897L16.863 4.487Zm0 0L19.5 7.125" />
        </svg>
        """;

    private const string QuestionIcon = """
        <svg class="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" d="M9.879 7.519c1.171-1.025 3.071-1.025 4.242 0 1.172 1.025 1.172 2.687 0 3.712-.203.179-.43.326-.67.442-.745.361-1.45.999-1.45 1.827v.75M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Zm-9 5.25h.008v.008H12v-.008Z" />
        </svg>
        """;
}
