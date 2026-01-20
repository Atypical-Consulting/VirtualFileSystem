namespace Atypical.VirtualFileSystem.DemoBlazorApp.Models;

/// <summary>
/// Toast notification severity levels
/// </summary>
public enum ToastSeverity
{
    Success,
    Error,
    Warning,
    Info
}

/// <summary>
/// Toast notification message
/// </summary>
public class ToastMessage
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Message { get; init; }
    public ToastSeverity Severity { get; init; } = ToastSeverity.Info;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public int DurationMs { get; init; } = 4000;
}
