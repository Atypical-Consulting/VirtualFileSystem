namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>Kind-specific authentication payload. Only the fields relevant to the provider's AuthKind are used.</summary>
public sealed record AuthRequest
{
    // Token providers (e.g. GitHub)
    public string? Token { get; init; }

    // Credentials providers (e.g. FTP)
    public string? Host { get; init; }
    public int Port { get; init; }
    public string? Username { get; init; }
    public string? Password { get; init; }
    public bool UseTls { get; init; }
}

public sealed record AuthResult(bool Success, string? ErrorMessage, ProviderAccountInfo? Account);
