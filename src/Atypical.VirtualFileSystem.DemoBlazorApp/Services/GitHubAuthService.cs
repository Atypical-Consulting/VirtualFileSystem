using Atypical.VirtualFileSystem.DemoBlazorApp.Models;
using Microsoft.JSInterop;
using Octokit;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

/// <summary>
/// Service for managing GitHub Personal Access Token authentication.
/// Stores tokens in browser localStorage and validates them against the GitHub API.
/// </summary>
public sealed class GitHubAuthService : IDisposable
{
    private const string StorageKey = "github_pat";
    private const string ProductHeaderValue = "Atypical.VirtualFileSystem.DemoBlazorApp";

    private readonly IJSRuntime _jsRuntime;
    private GitHubCredentials _credentials = GitHubCredentials.Anonymous;
    private bool _initialized;

    /// <summary>
    /// Gets the current GitHub credentials.
    /// </summary>
    public GitHubCredentials CurrentCredentials => _credentials;

    /// <summary>
    /// Gets whether the user is authenticated with a PAT.
    /// </summary>
    public bool IsAuthenticated => !string.IsNullOrEmpty(_credentials.Token) && _credentials.IsValidated;

    /// <summary>
    /// Event fired when credentials change.
    /// </summary>
    public event Action? OnCredentialsChanged;

    /// <summary>
    /// Event fired when rate limits are updated.
    /// </summary>
    public event Action? OnRateLimitUpdated;

    public GitHubAuthService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Initializes the service by loading saved credentials from localStorage.
    /// </summary>
    public async Task InitializeAsync()
    {
        if (_initialized) return;
        _initialized = true;

        try
        {
            var savedToken = await _jsRuntime.InvokeAsync<string?>("cloudDrive.storage.get", StorageKey);
            if (!string.IsNullOrEmpty(savedToken))
            {
                // Try to validate saved token
                await ValidateTokenAsync(savedToken, saveOnSuccess: false);
            }
        }
        catch (Exception)
        {
            // Silently fail - user will need to re-authenticate
            _credentials = GitHubCredentials.Anonymous;
        }
    }

    /// <summary>
    /// Validates a GitHub Personal Access Token and updates credentials.
    /// </summary>
    /// <param name="token">The PAT to validate.</param>
    /// <param name="saveOnSuccess">Whether to save the token to localStorage if valid.</param>
    /// <returns>A tuple indicating success and any error message.</returns>
    public async Task<(bool Success, string? ErrorMessage)> ValidateTokenAsync(string token, bool saveOnSuccess = true)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return (false, "Token cannot be empty.");
        }

        try
        {
            var client = new GitHubClient(new ProductHeaderValue(ProductHeaderValue))
            {
                Credentials = new Credentials(token)
            };

            // Validate by fetching current user
            var user = await client.User.Current();
            var rateLimit = await client.RateLimit.GetRateLimits();

            _credentials = new GitHubCredentials
            {
                Token = token,
                Username = user.Login,
                RateLimitRemaining = rateLimit.Resources.Core.Remaining,
                RateLimitTotal = rateLimit.Resources.Core.Limit,
                RateLimitReset = rateLimit.Resources.Core.Reset.UtcDateTime,
                IsValidated = true,
                LastValidated = DateTimeOffset.UtcNow
            };

            if (saveOnSuccess)
            {
                await SaveTokenAsync(token);
            }

            NotifyCredentialsChanged();
            return (true, null);
        }
        catch (AuthorizationException)
        {
            return (false, "Invalid token. Please check that the token is correct and has not expired.");
        }
        catch (ForbiddenException)
        {
            return (false, "Token is valid but lacks required permissions. Please ensure the token has 'repo' scope.");
        }
        catch (ApiException ex)
        {
            return (false, $"GitHub API error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return (false, $"Failed to validate token: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets the current access token for API calls.
    /// </summary>
    /// <returns>The token if authenticated, null otherwise.</returns>
    public string? GetAccessToken()
    {
        return IsAuthenticated ? _credentials.Token : null;
    }

    /// <summary>
    /// Updates rate limit information from an API response.
    /// Call this after making GitHub API calls to keep rate limits current.
    /// </summary>
    public void UpdateRateLimits(int remaining, int total, DateTimeOffset? reset)
    {
        _credentials = _credentials with
        {
            RateLimitRemaining = remaining,
            RateLimitTotal = total,
            RateLimitReset = reset
        };

        OnRateLimitUpdated?.Invoke();
    }

    /// <summary>
    /// Updates rate limits by querying the GitHub API.
    /// </summary>
    public async Task RefreshRateLimitsAsync()
    {
        try
        {
            var client = CreateClient();
            var rateLimit = await client.RateLimit.GetRateLimits();

            _credentials = _credentials with
            {
                RateLimitRemaining = rateLimit.Resources.Core.Remaining,
                RateLimitTotal = rateLimit.Resources.Core.Limit,
                RateLimitReset = rateLimit.Resources.Core.Reset.UtcDateTime
            };

            OnRateLimitUpdated?.Invoke();
        }
        catch
        {
            // Silently fail - rate limits will update on next API call
        }
    }

    /// <summary>
    /// Clears the stored credentials and returns to anonymous mode.
    /// </summary>
    public async Task ClearCredentialsAsync()
    {
        _credentials = GitHubCredentials.Anonymous;

        try
        {
            await _jsRuntime.InvokeVoidAsync("cloudDrive.storage.remove", StorageKey);
        }
        catch
        {
            // Silently fail - credentials are cleared from memory anyway
        }

        NotifyCredentialsChanged();
    }

    /// <summary>
    /// Creates a GitHubClient configured with current credentials.
    /// </summary>
    public GitHubClient CreateClient()
    {
        var client = new GitHubClient(new ProductHeaderValue(ProductHeaderValue));

        if (!string.IsNullOrEmpty(_credentials.Token))
        {
            client.Credentials = new Credentials(_credentials.Token);
        }

        return client;
    }

    /// <summary>
    /// Checks if the current token has write access to a repository.
    /// </summary>
    public async Task<(bool HasWriteAccess, bool RequiresFork)> CheckRepositoryAccessAsync(string owner, string repository)
    {
        if (!IsAuthenticated)
        {
            return (false, true);
        }

        try
        {
            var client = CreateClient();
            var repo = await client.Repository.Get(owner, repository);

            // Check if user has push access
            var hasWriteAccess = repo.Permissions?.Push == true;

            return (hasWriteAccess, !hasWriteAccess);
        }
        catch
        {
            return (false, true);
        }
    }

    private async Task SaveTokenAsync(string token)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("cloudDrive.storage.set", StorageKey, token);
        }
        catch
        {
            // Silently fail - token is still valid in memory for this session
        }
    }

    private void NotifyCredentialsChanged()
    {
        OnCredentialsChanged?.Invoke();
    }

    public void Dispose()
    {
        // No unmanaged resources to dispose, but implement for consistency
    }
}
