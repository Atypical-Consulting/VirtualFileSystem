using Atypical.VirtualFileSystem.DemoBlazorApp.Models;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Service for managing toast notifications
/// </summary>
public class ToastService
{
    private readonly List<ToastMessage> _toasts = [];

    public IReadOnlyList<ToastMessage> Toasts => _toasts.AsReadOnly();

    public event Action? OnChange;

    public void ShowSuccess(string message, int durationMs = 4000)
    {
        Show(message, ToastSeverity.Success, durationMs);
    }

    public void ShowError(string message, int durationMs = 5000)
    {
        Show(message, ToastSeverity.Error, durationMs);
    }

    public void ShowWarning(string message, int durationMs = 4000)
    {
        Show(message, ToastSeverity.Warning, durationMs);
    }

    public void ShowInfo(string message, int durationMs = 4000)
    {
        Show(message, ToastSeverity.Info, durationMs);
    }

    public void Show(string message, ToastSeverity severity = ToastSeverity.Info, int durationMs = 4000)
    {
        var toast = new ToastMessage
        {
            Message = message,
            Severity = severity,
            DurationMs = durationMs
        };

        _toasts.Add(toast);
        OnChange?.Invoke();

        // Auto-remove after duration
        _ = Task.Delay(durationMs).ContinueWith(_ =>
        {
            Remove(toast.Id);
        });
    }

    public void Remove(Guid id)
    {
        var toast = _toasts.FirstOrDefault(t => t.Id == id);
        if (toast != null)
        {
            _toasts.Remove(toast);
            OnChange?.Invoke();
        }
    }

    public void Clear()
    {
        _toasts.Clear();
        OnChange?.Invoke();
    }
}
