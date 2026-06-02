namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>How a provider authenticates.</summary>
public enum AuthKind
{
    /// <summary>A single bearer token / PAT.</summary>
    Token,
    /// <summary>Host + username/password style credentials.</summary>
    Credentials,
    /// <summary>Interactive OAuth (reserved for future providers).</summary>
    OAuth
}
