using Atypical.VirtualFileSystem.DemoBlazorApp.Models;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Service for managing toast notifications
/// </summary>
public class ToastService
{
    private readonly List<ToastMessage> _toasts = [];
    private readonly Lock _gate = new();

    // Returns a snapshot so callers (e.g. component render loops) can enumerate
    // safely while background auto-removal mutates the underlying list.
    public IReadOnlyList<ToastMessage> Toasts
    {
        get
        {
            lock (_gate)
            {
                return _toasts.ToList();
            }
        }
    }

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

        lock (_gate)
        {
            _toasts.Add(toast);
        }
        OnChange?.Invoke();

        // Auto-remove after the duration on a background task.
        _ = Task.Run(async () =>
        {
            await Task.Delay(durationMs);
            Remove(toast.Id);
        });
    }

    public void Remove(Guid id)
    {
        bool removed;
        lock (_gate)
        {
            var toast = _toasts.FirstOrDefault(t => t.Id == id);
            removed = toast != null && _toasts.Remove(toast);
        }

        if (removed)
            OnChange?.Invoke();
    }

    public void Clear()
    {
        lock (_gate)
        {
            _toasts.Clear();
        }
        OnChange?.Invoke();
    }
}
