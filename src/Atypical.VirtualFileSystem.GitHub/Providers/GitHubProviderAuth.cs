// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.Providers.Abstractions;
using Octokit;

namespace Atypical.VirtualFileSystem.GitHub.Providers;

/// <summary>
/// Handles token-based authentication for the GitHub storage provider.
/// Validates the personal access token against the GitHub API and populates
/// <see cref="Account"/> with the authenticated user's identity and rate-limit info.
/// </summary>
public sealed class GitHubProviderAuth : IStorageProviderAuth
{
    private const string ProductHeader = "Atypical.VirtualFileSystem.GitHub";
    private string? _token;

    /// <inheritdoc />
    public AuthKind Kind => AuthKind.Token;

    /// <inheritdoc />
    public bool IsAuthenticated => !string.IsNullOrEmpty(_token) && Account is not null;

    /// <inheritdoc />
    public ProviderAccountInfo? Account { get; private set; }

    /// <inheritdoc />
    public event Action? AuthChanged;

    /// <summary>
    /// Returns the current access token, or <see langword="null"/> when not authenticated.
    /// </summary>
    public string? Token => _token;

    /// <inheritdoc />
    public async Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
            return new AuthResult(false, "Token cannot be empty.", null);

        try
        {
            var client = new GitHubClient(new Octokit.ProductHeaderValue(ProductHeader))
            {
                Credentials = new Credentials(request.Token)
            };
            var user = await client.User.Current();
            var limits = await client.RateLimit.GetRateLimits();

            _token = request.Token;
            Account = new ProviderAccountInfo
            {
                DisplayName = user.Login,
                RateLimitRemaining = limits.Resources.Core.Remaining,
                RateLimitTotal = limits.Resources.Core.Limit,
                RateLimitReset = limits.Resources.Core.Reset
            };
            AuthChanged?.Invoke();
            return new AuthResult(true, null, Account);
        }
        catch (AuthorizationException)
        {
            return new AuthResult(false, "Invalid token.", null);
        }
        catch (ApiException ex)
        {
            return new AuthResult(false, $"GitHub API error: {ex.Message}", null);
        }
    }

    /// <inheritdoc />
    public Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        _token = null;
        Account = null;
        AuthChanged?.Invoke();
        return Task.CompletedTask;
    }
}
