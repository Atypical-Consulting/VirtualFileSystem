# Storage Provider Abstraction + FTP Provider — Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Introduce a storage-provider abstraction, migrate the existing GitHub code onto it with no behavior change, and add a read+write FTP provider with capability-driven Blazor UI.

**Architecture:** A new `Atypical.VirtualFileSystem.Providers.Abstractions` package defines `IStorageProvider`, `IStorageProviderAuth`, `ProviderCapabilities` and neutral records. The existing `…GitHub` project adds a `GitHubStorageProvider` that wraps its current loader/write service via type adapters. A new `…Ftp` project implements `FtpStorageProvider` over FluentFTP. The DemoBlazorApp gains a provider registry, neutral services, and dialogs that render from capabilities.

**Tech Stack:** .NET 9/10, C# 13, xUnit + Shouldly, Octokit (existing GitHub), FluentFTP (new), Blazor Server (`ProtectedLocalStorage`).

**Reference spec:** `docs/superpowers/specs/2026-06-02-storage-providers-foundation-ftp-design.md`

**Conventions for this plan:**
- Library projects multi-target `net9.0;net10.0` via `Directory.Build.props` (no per-project TFM needed).
- Test projects mirror existing ones: xUnit, Shouldly, `GlobalUsings.cs` with `global using Atypical.VirtualFileSystem.Core; global using Shouldly; global using Xunit;`.
- Build a single project: `dotnet build <path> -c Release`. Run one test project on one TFM: `dotnet test <path> -c Debug -f net10.0 --filter "FullyQualifiedName~<Name>"`.
- Commit after every green step.

---

## Phase 1 — Abstractions package

Creates `Atypical.VirtualFileSystem.Providers.Abstractions` with all interfaces and neutral records. No dependency except `Core` (for `IVirtualFileSystem`).

### Task 1.1: Create the Abstractions project and wire it into the solution

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/Atypical.VirtualFileSystem.Providers.Abstractions.csproj`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/GlobalUsings.cs`
- Modify: `Atypical.VirtualFileSystem.sln`

- [ ] **Step 1: Create the csproj**

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <RootNamespace>Atypical.VirtualFileSystem.Providers.Abstractions</RootNamespace>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\Atypical.VirtualFileSystem.Core\Atypical.VirtualFileSystem.Core.csproj" />
  </ItemGroup>
</Project>
```
(TargetFrameworks/Nullable/LangVersion come from `Directory.Build.props`.)

- [ ] **Step 2: Create GlobalUsings.cs**

```csharp
global using Atypical.VirtualFileSystem.Core;
global using Atypical.VirtualFileSystem.Core.Contracts;
```

- [ ] **Step 3: Add to the solution and verify it builds**

Run: `dotnet sln add src/Atypical.VirtualFileSystem.Providers.Abstractions && dotnet build src/Atypical.VirtualFileSystem.Providers.Abstractions -c Release`
Expected: Build succeeded.

- [ ] **Step 4: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Providers.Abstractions Atypical.VirtualFileSystem.sln
git commit -m "feat(providers): scaffold Providers.Abstractions project"
```

### Task 1.2: Define enums and capability/account records

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/AuthKind.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderCapabilities.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderAccountInfo.cs`

- [ ] **Step 1: Create the types**

`AuthKind.cs`:
```csharp
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
```

`ProviderCapabilities.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>Describes which optional operations a storage provider supports.</summary>
public sealed record ProviderCapabilities
{
    public bool SupportsBranches { get; init; }
    public bool SupportsPullRequests { get; init; }
    public bool SupportsFork { get; init; }
    public bool SupportsAtomicMultiFileCommit { get; init; }
    public bool SupportsVersioning { get; init; }
    public AuthKind AuthKind { get; init; }
}
```

`ProviderAccountInfo.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>Identity and quota/limit info for the authenticated account.</summary>
public sealed record ProviderAccountInfo
{
    public static readonly ProviderAccountInfo Anonymous = new() { DisplayName = "Anonymous" };

    public required string DisplayName { get; init; }
    public long? QuotaUsedBytes { get; init; }
    public long? QuotaTotalBytes { get; init; }
    public int? RateLimitRemaining { get; init; }
    public int? RateLimitTotal { get; init; }
    public DateTimeOffset? RateLimitReset { get; init; }
}
```

- [ ] **Step 2: Build to verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.Providers.Abstractions -c Release`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Providers.Abstractions
git commit -m "feat(providers): add AuthKind, ProviderCapabilities, ProviderAccountInfo"
```

### Task 1.3: Define load/read/write neutral records

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderLoadOptions.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderLoadResult.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderFileContent.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderFileChange.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderWriteResult.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/CommitContext.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/ProviderFileMetadata.cs`

- [ ] **Step 1: Create the records**

`ProviderLoadOptions.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public enum ProviderLoadingStrategy { Eager, Lazy, MetadataOnly }

/// <summary>Options controlling an import into the VFS.</summary>
public sealed record ProviderLoadOptions
{
    /// <summary>Remote sub-path to import from (provider-specific root if null/empty).</summary>
    public string? RemoteRoot { get; init; }
    public ProviderLoadingStrategy Strategy { get; init; } = ProviderLoadingStrategy.Eager;
    public long MaxFileSizeBytes { get; init; } = 10 * 1024 * 1024;
    public IReadOnlyList<string>? AllowedExtensions { get; init; }
    public IReadOnlyList<string>? BlockedExtensions { get; init; }
    public string? GlobPattern { get; init; }
    /// <summary>Invoked as each file is loaded: (vfsPath, remotePath, versionToken).</summary>
    public Action<string, string, string>? MetadataCallback { get; init; }
    /// <summary>Invoked for progress: (filesLoaded, message).</summary>
    public Action<int, string>? ProgressCallback { get; init; }
}
```

`ProviderLoadResult.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public enum ProviderSkipReason { TooLarge, BlockedExtension, NotMatchingGlob, LoadError }

public sealed record ProviderSkippedFile(string RemotePath, ProviderSkipReason Reason, long SizeBytes, string? Message);

public sealed record ProviderLoadResult
{
    public required string RemoteRoot { get; init; }
    public int FilesLoaded { get; init; }
    public int DirectoriesCreated { get; init; }
    public long TotalBytes { get; init; }
    public IReadOnlyList<ProviderSkippedFile> Skipped { get; init; } = [];
    public TimeSpan Duration { get; init; }
}
```

`ProviderFileContent.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>The content of a single remote file plus an opaque version token (ETag/SHA/mtime).</summary>
public sealed record ProviderFileContent(byte[] Content, string VersionToken, bool IsBinary);
```

`ProviderFileChange.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public enum ChangeKind { Add, Update, Delete }

public sealed record ProviderFileChange
{
    public required string RemotePath { get; init; }
    public required ChangeKind Kind { get; init; }
    public byte[]? Content { get; init; }
    public string? BaseVersionToken { get; init; }
}
```

`ProviderWriteResult.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public sealed record ProviderFileWriteResult(string RemotePath, bool Success, string? Message);

public sealed record ProviderWriteResult
{
    public required bool Success { get; init; }
    public IReadOnlyList<ProviderFileWriteResult> FileResults { get; init; } = [];
    /// <summary>For PR-capable providers, the URL of the created pull request (else null).</summary>
    public string? PullRequestUrl { get; init; }
    public string? Message { get; init; }
}
```

`CommitContext.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>
/// Optional context for a write. Providers honor only what their capabilities allow
/// and ignore the rest (e.g. FTP ignores all of these).
/// </summary>
public sealed record CommitContext
{
    public static readonly CommitContext Empty = new();
    public string? Message { get; init; }
    public string? Branch { get; init; }
    public bool Draft { get; init; }
}
```

`ProviderFileMetadata.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>Maps a VFS file back to its remote origin so writes can target the right place.</summary>
public sealed record ProviderFileMetadata
{
    public required string ProviderId { get; init; }
    public required string ContainerKey { get; init; }   // repo "owner/name" or host+base path
    public required string RelativePath { get; init; }
    public required string VersionToken { get; init; }
    public DateTimeOffset ImportedAt { get; init; }
}
```

- [ ] **Step 2: Build to verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.Providers.Abstractions -c Release`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Providers.Abstractions
git commit -m "feat(providers): add neutral load/read/write records"
```

### Task 1.4: Define the auth and provider interfaces

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/AuthRequest.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/IStorageProviderAuth.cs`
- Create: `src/Atypical.VirtualFileSystem.Providers.Abstractions/IStorageProvider.cs`

- [ ] **Step 1: Create the types**

`AuthRequest.cs`:
```csharp
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
```

`IStorageProviderAuth.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

public interface IStorageProviderAuth
{
    AuthKind Kind { get; }
    bool IsAuthenticated { get; }
    ProviderAccountInfo? Account { get; }
    Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken cancellationToken = default);
    Task SignOutAsync(CancellationToken cancellationToken = default);
    event Action? AuthChanged;
}
```

`IStorageProvider.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions;

/// <summary>A pluggable storage backend that can import into, and write back from, a VFS.</summary>
public interface IStorageProvider
{
    string Id { get; }
    string DisplayName { get; }
    ProviderCapabilities Capabilities { get; }
    IStorageProviderAuth Auth { get; }

    Task<ProviderLoadResult> ImportAsync(IVirtualFileSystem vfs, ProviderLoadOptions options, CancellationToken cancellationToken = default);
    Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken cancellationToken = default);
    Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken cancellationToken = default);
    Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken cancellationToken = default);
}
```

- [ ] **Step 2: Build to verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.Providers.Abstractions -c Release`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Providers.Abstractions
git commit -m "feat(providers): add IStorageProvider and IStorageProviderAuth"
```

### Task 1.5: Create Abstractions test project with a capability/CommitContext test

**Files:**
- Create: `tests/Atypical.VirtualFileSystem.Providers.Abstractions.Tests/Atypical.VirtualFileSystem.Providers.Abstractions.Tests.csproj`
- Create: `tests/Atypical.VirtualFileSystem.Providers.Abstractions.Tests/GlobalUsings.cs`
- Create: `tests/Atypical.VirtualFileSystem.Providers.Abstractions.Tests/CommitContextTests.cs`

- [ ] **Step 1: Create the csproj** (copy the structure of `tests/Atypical.VirtualFileSystem.GitHub.Tests/*.csproj`: `IsPackable=false`, references to xunit, Microsoft.NET.Test.Sdk, coverlet.collector, Shouldly) and a project reference:

```xml
<ProjectReference Include="..\..\src\Atypical.VirtualFileSystem.Providers.Abstractions\Atypical.VirtualFileSystem.Providers.Abstractions.csproj" />
```

`GlobalUsings.cs`:
```csharp
global using Atypical.VirtualFileSystem.Providers.Abstractions;
global using Shouldly;
global using Xunit;
```

- [ ] **Step 2: Write the failing test**

```csharp
namespace Atypical.VirtualFileSystem.Providers.Abstractions.Tests;

public class CommitContextTests
{
    [Fact]
    public void Empty_has_no_message_branch_or_draft()
    {
        var ctx = CommitContext.Empty;
        ctx.Message.ShouldBeNull();
        ctx.Branch.ShouldBeNull();
        ctx.Draft.ShouldBeFalse();
    }

    [Fact]
    public void Capabilities_default_to_false_with_token_auth()
    {
        var caps = new ProviderCapabilities();
        caps.SupportsBranches.ShouldBeFalse();
        caps.SupportsPullRequests.ShouldBeFalse();
        caps.AuthKind.ShouldBe(AuthKind.Token);
    }
}
```

- [ ] **Step 3: Run to verify it fails, then passes**

Run: `dotnet test tests/Atypical.VirtualFileSystem.Providers.Abstractions.Tests -c Debug -f net10.0`
Expected: first run FAILS to compile until csproj/usings are correct, then PASS (2 tests).

- [ ] **Step 4: Add test project to the solution and commit**

```bash
dotnet sln add tests/Atypical.VirtualFileSystem.Providers.Abstractions.Tests
git add tests/Atypical.VirtualFileSystem.Providers.Abstractions.Tests Atypical.VirtualFileSystem.sln
git commit -m "test(providers): abstractions test project + capability tests"
```

---

## Phase 2 — GitHub migration (no behavior change)

Wrap the existing GitHub loader/write service behind `IStorageProvider` using adapters. The existing 71 GitHub tests are the regression gate.

### Task 2.1: Reference Abstractions from the GitHub project

**Files:**
- Modify: `src/Atypical.VirtualFileSystem.GitHub/Atypical.VirtualFileSystem.GitHub.csproj`

- [ ] **Step 1: Add the project reference**

```xml
<ProjectReference Include="..\Atypical.VirtualFileSystem.Providers.Abstractions\Atypical.VirtualFileSystem.Providers.Abstractions.csproj" />
```

- [ ] **Step 2: Build to verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.GitHub -c Release`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.GitHub
git commit -m "build(github): reference Providers.Abstractions"
```

### Task 2.2: Add adapter mappers (GitHub ↔ neutral) with tests

**Files:**
- Create: `src/Atypical.VirtualFileSystem.GitHub/Providers/GitHubProviderAdapters.cs`
- Test: `tests/Atypical.VirtualFileSystem.GitHub.Tests/Providers/GitHubProviderAdaptersTests.cs`

- [ ] **Step 1: Write the failing test** (verify load-options and result mapping)

```csharp
namespace Atypical.VirtualFileSystem.GitHub.Tests.Providers;

public class GitHubProviderAdaptersTests
{
    [Fact]
    public void ToGitHubLoaderOptions_maps_strategy_and_filters()
    {
        var opts = new ProviderLoadOptions
        {
            RemoteRoot = "src",
            Strategy = ProviderLoadingStrategy.Lazy,
            MaxFileSizeBytes = 1234,
        };

        var gh = GitHubProviderAdapters.ToGitHubLoaderOptions(opts, accessToken: "tok");

        gh.Strategy.ShouldBe(GitHubLoadingStrategy.Lazy);
        gh.MaxFileSize.ShouldBe(1234);
        gh.TargetPath.ShouldBe("src");
        gh.AccessToken.ShouldBe("tok");
    }

    [Fact]
    public void ToProviderLoadResult_maps_counts_and_skips()
    {
        var ghResult = new GitHubLoadResult(
            "o", "r", "main", "sha", filesLoaded: 3, directoriesCreated: 2,
            totalBytesLoaded: 99,
            skippedFiles: new List<GitHubSkippedFile> { new("a.bin", SkipReason.LoadError, 5, "boom") },
            duration: TimeSpan.FromSeconds(1), targetPath: "src");

        var result = GitHubProviderAdapters.ToProviderLoadResult(ghResult);

        result.FilesLoaded.ShouldBe(3);
        result.DirectoriesCreated.ShouldBe(2);
        result.TotalBytes.ShouldBe(99);
        result.Skipped.Count.ShouldBe(1);
        result.Skipped[0].Reason.ShouldBe(ProviderSkipReason.LoadError);
    }
}
```

> NOTE: confirm the exact `GitHubLoaderOptions` and `GitHubLoadResult` member names from
> `src/Atypical.VirtualFileSystem.GitHub/GitHubLoaderOptions.cs` and `GitHubLoadResult.cs`
> while implementing; adjust the mapper and assertions to the real names if they differ
> (e.g. `MaxFileSize` vs `MaxFileSizeBytes`).

- [ ] **Step 2: Run to verify it fails**

Run: `dotnet test tests/Atypical.VirtualFileSystem.GitHub.Tests -c Debug -f net10.0 --filter "FullyQualifiedName~GitHubProviderAdaptersTests"`
Expected: FAIL (GitHubProviderAdapters does not exist).

- [ ] **Step 3: Implement the adapters**

```csharp
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.GitHub.Providers;

internal static class GitHubProviderAdapters
{
    public static GitHubLoaderOptions ToGitHubLoaderOptions(ProviderLoadOptions o, string? accessToken)
        => new()
        {
            AccessToken = accessToken,
            TargetPath = o.RemoteRoot,
            MaxFileSize = o.MaxFileSizeBytes,
            Strategy = o.Strategy switch
            {
                ProviderLoadingStrategy.Lazy => GitHubLoadingStrategy.Lazy,
                ProviderLoadingStrategy.MetadataOnly => GitHubLoadingStrategy.MetadataOnly,
                _ => GitHubLoadingStrategy.Eager
            },
            // map MetadataCallback if GitHubLoaderOptions exposes one
        };

    public static ProviderLoadResult ToProviderLoadResult(GitHubLoadResult r)
        => new()
        {
            RemoteRoot = r.TargetPath ?? string.Empty,
            FilesLoaded = r.FilesLoaded,
            DirectoriesCreated = r.DirectoriesCreated,
            TotalBytes = r.TotalBytesLoaded,
            Duration = r.Duration,
            Skipped = r.SkippedFiles
                .Select(s => new ProviderSkippedFile(s.Path, ToSkipReason(s.Reason), s.Size, s.Message))
                .ToList(),
        };

    private static ProviderSkipReason ToSkipReason(SkipReason r) => r switch
    {
        SkipReason.TooLarge => ProviderSkipReason.TooLarge,
        SkipReason.BlockedExtension => ProviderSkipReason.BlockedExtension,
        _ => ProviderSkipReason.LoadError
    };
}
```
> Adjust property names / the `GitHubLoaderOptions` initializer to match the actual
> record (it may be a positional record — if so, build it positionally).

- [ ] **Step 4: Run to verify it passes**

Run: same as Step 2. Expected: PASS.

- [ ] **Step 5: Commit**

```bash
git add src/Atypical.VirtualFileSystem.GitHub/Providers tests/Atypical.VirtualFileSystem.GitHub.Tests/Providers
git commit -m "feat(github): add GitHub<->neutral provider adapters"
```

### Task 2.3: Implement `GitHubProviderAuth` wrapping token validation

**Files:**
- Create: `src/Atypical.VirtualFileSystem.GitHub/Providers/GitHubProviderAuth.cs`
- Test: `tests/Atypical.VirtualFileSystem.GitHub.Tests/Providers/GitHubProviderAuthTests.cs`

- [ ] **Step 1: Write the failing test** (auth kind + initial state; no network)

```csharp
namespace Atypical.VirtualFileSystem.GitHub.Tests.Providers;

public class GitHubProviderAuthTests
{
    [Fact]
    public void New_auth_is_token_kind_and_unauthenticated()
    {
        var auth = new GitHubProviderAuth();
        auth.Kind.ShouldBe(AuthKind.Token);
        auth.IsAuthenticated.ShouldBeFalse();
        auth.Account.ShouldBeNull();
    }

    [Fact]
    public async Task AuthenticateAsync_with_empty_token_returns_failure()
    {
        var auth = new GitHubProviderAuth();
        var result = await auth.AuthenticateAsync(new AuthRequest { Token = "" });
        result.Success.ShouldBeFalse();
    }
}
```

- [ ] **Step 2: Run to verify it fails**

Run: `dotnet test tests/Atypical.VirtualFileSystem.GitHub.Tests -c Debug -f net10.0 --filter "FullyQualifiedName~GitHubProviderAuthTests"`
Expected: FAIL (type missing).

- [ ] **Step 3: Implement `GitHubProviderAuth`**

```csharp
using Atypical.VirtualFileSystem.Providers.Abstractions;
using Octokit;

namespace Atypical.VirtualFileSystem.GitHub.Providers;

public sealed class GitHubProviderAuth : IStorageProviderAuth
{
    private const string ProductHeaderValue = "Atypical.VirtualFileSystem.GitHub";
    private string? _token;

    public AuthKind Kind => AuthKind.Token;
    public bool IsAuthenticated => !string.IsNullOrEmpty(_token) && Account is not null;
    public ProviderAccountInfo? Account { get; private set; }
    public event Action? AuthChanged;

    public string? Token => _token;

    public async Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
            return new AuthResult(false, "Token cannot be empty.", null);

        try
        {
            var client = new GitHubClient(new ProductHeaderValue(ProductHeaderValue))
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

    public Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        _token = null;
        Account = null;
        AuthChanged?.Invoke();
        return Task.CompletedTask;
    }
}
```

- [ ] **Step 4: Run to verify it passes** (the empty-token test runs offline; the kind test too)

Run: same as Step 2. Expected: PASS.

- [ ] **Step 5: Commit**

```bash
git add src/Atypical.VirtualFileSystem.GitHub/Providers tests/Atypical.VirtualFileSystem.GitHub.Tests/Providers
git commit -m "feat(github): add GitHubProviderAuth (Token)"
```

### Task 2.4: Implement `GitHubStorageProvider` delegating to loader/write service

**Files:**
- Create: `src/Atypical.VirtualFileSystem.GitHub/Providers/GitHubStorageProvider.cs`
- Test: `tests/Atypical.VirtualFileSystem.GitHub.Tests/Providers/GitHubStorageProviderTests.cs`

- [ ] **Step 1: Write the failing test** (capabilities + id; no network)

```csharp
namespace Atypical.VirtualFileSystem.GitHub.Tests.Providers;

public class GitHubStorageProviderTests
{
    [Fact]
    public void Provider_exposes_github_id_and_pr_capabilities()
    {
        var provider = new GitHubStorageProvider(new GitHubRepositoryLoader(), new GitHubWriteService(), new GitHubProviderAuth());
        provider.Id.ShouldBe("github");
        provider.Capabilities.SupportsPullRequests.ShouldBeTrue();
        provider.Capabilities.SupportsBranches.ShouldBeTrue();
        provider.Capabilities.SupportsAtomicMultiFileCommit.ShouldBeTrue();
        provider.Capabilities.AuthKind.ShouldBe(AuthKind.Token);
    }
}
```
> Confirm the real constructors of `GitHubRepositoryLoader`/`GitHubWriteService`; adjust the
> `new GitHubStorageProvider(...)` arguments to match whatever the implementation needs
> (the loader has a parameterless-ish ctor with optional options; the write service may
> need none).

- [ ] **Step 2: Run to verify it fails**

Run: `dotnet test tests/Atypical.VirtualFileSystem.GitHub.Tests -c Debug -f net10.0 --filter "FullyQualifiedName~GitHubStorageProviderTests"`
Expected: FAIL (type missing).

- [ ] **Step 3: Implement `GitHubStorageProvider`**

```csharp
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.GitHub.Providers;

public sealed class GitHubStorageProvider : IStorageProvider
{
    private readonly IGitHubRepositoryLoader _loader;
    private readonly IGitHubWriteService _writeService;
    private readonly GitHubProviderAuth _auth;

    public GitHubStorageProvider(IGitHubRepositoryLoader loader, IGitHubWriteService writeService, GitHubProviderAuth auth)
    {
        _loader = loader;
        _writeService = writeService;
        _auth = auth;
    }

    public string Id => "github";
    public string DisplayName => "GitHub";
    public IStorageProviderAuth Auth => _auth;

    public ProviderCapabilities Capabilities => new()
    {
        SupportsBranches = true,
        SupportsPullRequests = true,
        SupportsFork = true,
        SupportsAtomicMultiFileCommit = true,
        SupportsVersioning = true,
        AuthKind = AuthKind.Token
    };

    public async Task<ProviderLoadResult> ImportAsync(IVirtualFileSystem vfs, ProviderLoadOptions options, CancellationToken cancellationToken = default)
    {
        // RemoteRoot for GitHub is "owner/repo[/subpath]"; parse owner/repo and pass subpath via TargetPath.
        var (owner, repo, subPath) = ParseRemoteRoot(options.RemoteRoot);
        var ghOptions = GitHubProviderAdapters.ToGitHubLoaderOptions(options with { RemoteRoot = subPath }, _auth.Token);
        var result = await _loader.LoadRepositoryAsync(vfs, owner, repo, ghOptions, cancellationToken);
        return GitHubProviderAdapters.ToProviderLoadResult(result);
    }

    public Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken cancellationToken = default)
        => throw new NotSupportedException("Single-file read is performed during import for GitHub; not used by the current UI.");

    public async Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken cancellationToken = default)
    {
        // Delegate to the existing fork->branch->commit->PR orchestration via the write service.
        // The DemoBlazorApp's StoragePendingChangesService composes these calls; for the provider
        // surface, route through the write service using context.Branch/Message.
        throw new NotSupportedException("GitHub writes are orchestrated by StoragePendingChangesService in Task 4.x.");
    }

    public Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_auth.Account ?? ProviderAccountInfo.Anonymous);

    private static (string owner, string repo, string? subPath) ParseRemoteRoot(string? remoteRoot)
    {
        var parts = (remoteRoot ?? string.Empty).Trim('/').Split('/', 3);
        if (parts.Length < 2)
            throw new ArgumentException("GitHub RemoteRoot must be 'owner/repo[/subpath]'.", nameof(remoteRoot));
        return (parts[0], parts[1], parts.Length == 3 ? parts[2] : null);
    }
}
```
> Design note: GitHub's write orchestration (fork→branch→commit→PR) already lives in the
> Blazor `GitHubPendingChangesService`. To avoid duplicating it, the provider's
> `WriteChangesAsync` throws for now and the app's `StoragePendingChangesService` (Task 4.4)
> calls the GitHub write service directly when the active provider is GitHub. This is a
> deliberate, documented seam — revisit when extracting writes fully in a later milestone.

- [ ] **Step 4: Run to verify it passes**

Run: same as Step 2. Expected: PASS.

- [ ] **Step 5: Run the FULL GitHub suite to confirm zero regression**

Run: `dotnet test tests/Atypical.VirtualFileSystem.GitHub.Tests -c Debug -f net10.0`
Expected: PASS (71 existing + new provider tests).

- [ ] **Step 6: Commit**

```bash
git add src/Atypical.VirtualFileSystem.GitHub/Providers tests/Atypical.VirtualFileSystem.GitHub.Tests/Providers
git commit -m "feat(github): add GitHubStorageProvider wrapping the loader"
```

---

## Phase 3 — FTP provider

New `…Ftp` project using FluentFTP, behind an `IFtpClient` seam so it is testable without a live server.

### Task 3.1: Create the FTP project with a FluentFTP dependency

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Ftp/Atypical.VirtualFileSystem.Ftp.csproj`
- Create: `src/Atypical.VirtualFileSystem.Ftp/GlobalUsings.cs`
- Modify: `Atypical.VirtualFileSystem.sln`

- [ ] **Step 1: Create the csproj** (look up the latest stable FluentFTP version via the context7 MCP or NuGet before pinning):

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="FluentFTP" Version="<latest-stable>" />
    <ProjectReference Include="..\Atypical.VirtualFileSystem.Core\Atypical.VirtualFileSystem.Core.csproj" />
    <ProjectReference Include="..\Atypical.VirtualFileSystem.Providers.Abstractions\Atypical.VirtualFileSystem.Providers.Abstractions.csproj" />
  </ItemGroup>
</Project>
```

`GlobalUsings.cs`:
```csharp
global using Atypical.VirtualFileSystem.Core;
global using Atypical.VirtualFileSystem.Core.Contracts;
global using Atypical.VirtualFileSystem.Providers.Abstractions;
```

- [ ] **Step 2: Add to solution and build**

Run: `dotnet sln add src/Atypical.VirtualFileSystem.Ftp && dotnet build src/Atypical.VirtualFileSystem.Ftp -c Release`
Expected: Build succeeded (FluentFTP restored).

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Ftp Atypical.VirtualFileSystem.sln
git commit -m "feat(ftp): scaffold Ftp project with FluentFTP"
```

### Task 3.2: Define an `IFtpConnection` seam + FluentFTP implementation

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Ftp/IFtpConnection.cs`
- Create: `src/Atypical.VirtualFileSystem.Ftp/FtpConnectionSettings.cs`
- Create: `src/Atypical.VirtualFileSystem.Ftp/FluentFtpConnection.cs`

- [ ] **Step 1: Define the seam** (the minimal surface the provider needs — this is what tests fake):

```csharp
namespace Atypical.VirtualFileSystem.Ftp;

public sealed record FtpRemoteItem(string FullPath, bool IsDirectory, long SizeBytes, DateTime LastModifiedUtc);

/// <summary>Minimal async FTP surface used by FtpStorageProvider; backed by FluentFTP in production.</summary>
public interface IFtpConnection
{
    Task ConnectAsync(CancellationToken ct);
    Task DisconnectAsync(CancellationToken ct);
    Task<IReadOnlyList<FtpRemoteItem>> ListAsync(string remoteDir, CancellationToken ct);
    Task<byte[]> DownloadAsync(string remotePath, CancellationToken ct);
    Task UploadAsync(string remotePath, byte[] content, CancellationToken ct);
    Task DeleteFileAsync(string remotePath, CancellationToken ct);
}
```

`FtpConnectionSettings.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Ftp;

public sealed record FtpConnectionSettings
{
    public required string Host { get; init; }
    public int Port { get; init; } = 21;
    public string? Username { get; init; }
    public string? Password { get; init; }
    public bool UseTls { get; init; }
}
```

`FluentFtpConnection.cs` (wraps `AsyncFtpClient`; recursive listing handled by the provider, this lists one dir):
```csharp
using FluentFTP;

namespace Atypical.VirtualFileSystem.Ftp;

public sealed class FluentFtpConnection : IFtpConnection, IAsyncDisposable
{
    private readonly AsyncFtpClient _client;

    public FluentFtpConnection(FtpConnectionSettings settings)
    {
        _client = new AsyncFtpClient(settings.Host, settings.Username, settings.Password, settings.Port);
        _client.Config.EncryptionMode = settings.UseTls ? FtpEncryptionMode.Explicit : FtpEncryptionMode.None;
        _client.Config.ValidateAnyCertificate = settings.UseTls; // demo: accept; document for production
    }

    public Task ConnectAsync(CancellationToken ct) => _client.Connect(ct);
    public Task DisconnectAsync(CancellationToken ct) => _client.Disconnect(ct);

    public async Task<IReadOnlyList<FtpRemoteItem>> ListAsync(string remoteDir, CancellationToken ct)
    {
        var items = await _client.GetListing(remoteDir, ct);
        return items.Select(i => new FtpRemoteItem(
            i.FullName, i.Type == FtpObjectType.Directory, i.Size, i.Modified.ToUniversalTime())).ToList();
    }

    public Task<byte[]> DownloadAsync(string remotePath, CancellationToken ct)
        => _client.DownloadBytes(remotePath, ct).AsTask();

    public async Task UploadAsync(string remotePath, byte[] content, CancellationToken ct)
        => await _client.UploadBytes(content, remotePath, FtpRemoteExists.Overwrite, createRemoteDir: true, token: ct);

    public Task DeleteFileAsync(string remotePath, CancellationToken ct) => _client.DeleteFile(remotePath, ct);

    public async ValueTask DisposeAsync() => await _client.DisposeAsync();
}
```
> Verify FluentFTP async method names/signatures against the installed version (the API has
> shifted across majors — e.g. `DownloadBytes`/`UploadBytes` return types). Adjust to match.

- [ ] **Step 2: Build to verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.Ftp -c Release`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Ftp
git commit -m "feat(ftp): IFtpConnection seam + FluentFTP implementation"
```

### Task 3.3: Implement `FtpStorageProvider.ImportAsync` (TDD with a fake connection)

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Ftp/FtpStorageProvider.cs`
- Create: `src/Atypical.VirtualFileSystem.Ftp/FtpProviderAuth.cs`
- Test: `tests/Atypical.VirtualFileSystem.Ftp.Tests/*` (new project; mirror GitHub.Tests csproj)
- Test: `tests/Atypical.VirtualFileSystem.Ftp.Tests/FakeFtpConnection.cs`
- Test: `tests/Atypical.VirtualFileSystem.Ftp.Tests/FtpStorageProviderImportTests.cs`

- [ ] **Step 1: Create the test project** (copy GitHub.Tests csproj structure; reference `…Ftp` and `…Core`; `GlobalUsings.cs` with provider/Shouldly/Xunit usings). Add it to the solution.

- [ ] **Step 2: Write the fake connection**

```csharp
namespace Atypical.VirtualFileSystem.Ftp.Tests;

/// <summary>In-memory FTP server: a path->bytes map plus directory entries.</summary>
public sealed class FakeFtpConnection : IFtpConnection
{
    public Dictionary<string, byte[]> Files { get; } = new();
    public HashSet<string> Directories { get; } = new();
    public List<string> Uploaded { get; } = new();
    public List<string> Deleted { get; } = new();

    public Task ConnectAsync(CancellationToken ct) => Task.CompletedTask;
    public Task DisconnectAsync(CancellationToken ct) => Task.CompletedTask;

    public Task<IReadOnlyList<FtpRemoteItem>> ListAsync(string remoteDir, CancellationToken ct)
    {
        var dir = remoteDir.TrimEnd('/');
        IReadOnlyList<FtpRemoteItem> Children() =>
            Directories.Where(d => ParentOf(d) == dir)
                .Select(d => new FtpRemoteItem(d, true, 0, DateTime.UnixEpoch))
                .Concat(Files.Where(f => ParentOf(f.Key) == dir)
                    .Select(f => new FtpRemoteItem(f.Key, false, f.Value.Length, DateTime.UnixEpoch)))
                .ToList();
        return Task.FromResult(Children());
    }

    public Task<byte[]> DownloadAsync(string remotePath, CancellationToken ct) => Task.FromResult(Files[remotePath]);
    public Task UploadAsync(string remotePath, byte[] content, CancellationToken ct)
    { Files[remotePath] = content; Uploaded.Add(remotePath); return Task.CompletedTask; }
    public Task DeleteFileAsync(string remotePath, CancellationToken ct)
    { Files.Remove(remotePath); Deleted.Add(remotePath); return Task.CompletedTask; }

    private static string ParentOf(string path)
    {
        var p = path.TrimEnd('/');
        var idx = p.LastIndexOf('/');
        return idx <= 0 ? "" : p[..idx];
    }
}
```

- [ ] **Step 3: Write the failing import test**

```csharp
namespace Atypical.VirtualFileSystem.Ftp.Tests;

public class FtpStorageProviderImportTests
{
    private static FakeFtpConnection BuildTree()
    {
        var fake = new FakeFtpConnection();
        fake.Directories.Add("/data");
        fake.Directories.Add("/data/sub");
        fake.Files["/data/readme.txt"] = "hello"u8.ToArray();
        fake.Files["/data/sub/a.txt"] = "A"u8.ToArray();
        fake.Files["/data/big.bin"] = new byte[20]; // for size-filter test
        return fake;
    }

    [Fact]
    public async Task ImportAsync_loads_files_recursively_into_the_vfs()
    {
        var fake = BuildTree();
        var provider = new FtpStorageProvider(_ => fake);
        var vfs = new VFS();

        var result = await provider.ImportAsync(vfs, new ProviderLoadOptions { RemoteRoot = "/data" });

        result.FilesLoaded.ShouldBe(3);
        vfs.Index.ContainsKey(new VFSFilePath("data/readme.txt")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("data/sub/a.txt")).ShouldBeTrue();
    }

    [Fact]
    public async Task ImportAsync_skips_files_over_the_max_size()
    {
        var fake = BuildTree();
        var provider = new FtpStorageProvider(_ => fake);
        var vfs = new VFS();

        var result = await provider.ImportAsync(vfs, new ProviderLoadOptions { RemoteRoot = "/data", MaxFileSizeBytes = 10 });

        result.Skipped.ShouldContain(s => s.RemotePath == "/data/big.bin" && s.Reason == ProviderSkipReason.TooLarge);
        vfs.Index.ContainsKey(new VFSFilePath("data/big.bin")).ShouldBeFalse();
    }
}
```

- [ ] **Step 4: Run to verify it fails**

Run: `dotnet test tests/Atypical.VirtualFileSystem.Ftp.Tests -c Debug -f net10.0 --filter "FullyQualifiedName~Import"`
Expected: FAIL (FtpStorageProvider missing).

- [ ] **Step 5: Implement `FtpProviderAuth` and `FtpStorageProvider` (import path)**

`FtpProviderAuth.cs`:
```csharp
namespace Atypical.VirtualFileSystem.Ftp;

public sealed class FtpProviderAuth : IStorageProviderAuth
{
    private readonly Func<FtpConnectionSettings, IFtpConnection> _factory;
    public FtpProviderAuth(Func<FtpConnectionSettings, IFtpConnection> factory) => _factory = factory;

    public AuthKind Kind => AuthKind.Credentials;
    public bool IsAuthenticated => Settings is not null;
    public ProviderAccountInfo? Account { get; private set; }
    public FtpConnectionSettings? Settings { get; private set; }
    public event Action? AuthChanged;

    public async Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.Host))
            return new AuthResult(false, "Host is required.", null);

        var settings = new FtpConnectionSettings
        {
            Host = request.Host, Port = request.Port == 0 ? 21 : request.Port,
            Username = request.Username, Password = request.Password, UseTls = request.UseTls
        };
        var conn = _factory(settings);
        try
        {
            await conn.ConnectAsync(ct);
            await conn.DisconnectAsync(ct);
        }
        catch (Exception ex)
        {
            return new AuthResult(false, $"Connection failed: {ex.Message}", null);
        }
        finally
        {
            if (conn is IAsyncDisposable d) await d.DisposeAsync();
        }

        Settings = settings;
        Account = new ProviderAccountInfo { DisplayName = $"{request.Username}@{request.Host}" };
        AuthChanged?.Invoke();
        return new AuthResult(true, null, Account);
    }

    public Task SignOutAsync(CancellationToken ct = default)
    {
        Settings = null; Account = null; AuthChanged?.Invoke();
        return Task.CompletedTask;
    }
}
```

`FtpStorageProvider.cs` (import path; write path added in Task 3.4):
```csharp
using System.Diagnostics;

namespace Atypical.VirtualFileSystem.Ftp;

public sealed class FtpStorageProvider : IStorageProvider
{
    private readonly Func<FtpConnectionSettings, IFtpConnection> _connectionFactory;
    private readonly FtpProviderAuth _auth;

    public FtpStorageProvider(Func<FtpConnectionSettings, IFtpConnection> connectionFactory)
    {
        _connectionFactory = connectionFactory;
        _auth = new FtpProviderAuth(connectionFactory);
    }

    public string Id => "ftp";
    public string DisplayName => "FTP";
    public IStorageProviderAuth Auth => _auth;

    public ProviderCapabilities Capabilities => new() { AuthKind = AuthKind.Credentials };

    public async Task<ProviderLoadResult> ImportAsync(IVirtualFileSystem vfs, ProviderLoadOptions options, CancellationToken ct = default)
    {
        var settings = _auth.Settings ?? throw new InvalidOperationException("FTP provider is not authenticated.");
        var root = string.IsNullOrWhiteSpace(options.RemoteRoot) ? "/" : options.RemoteRoot!;
        var sw = Stopwatch.StartNew();
        var skipped = new List<ProviderSkippedFile>();
        int files = 0, dirs = 0; long bytes = 0;

        var conn = _connectionFactory(settings);
        try
        {
            await conn.ConnectAsync(ct);

            var queue = new Queue<string>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                ct.ThrowIfCancellationRequested();
                var current = queue.Dequeue();
                foreach (var item in await conn.ListAsync(current, ct))
                {
                    if (item.IsDirectory) { queue.Enqueue(item.FullPath); dirs++; continue; }

                    if (item.SizeBytes > options.MaxFileSizeBytes)
                    { skipped.Add(new(item.FullPath, ProviderSkipReason.TooLarge, item.SizeBytes, null)); continue; }

                    try
                    {
                        var data = await conn.DownloadAsync(item.FullPath, ct);
                        var vfsPath = ToVfsPath(item.FullPath);
                        var versionToken = $"{item.LastModifiedUtc:O}:{item.SizeBytes}";
                        if (IsBinary(item.FullPath))
                            vfs.CreateBinaryFileWithDirectories(vfsPath, data);
                        else
                            vfs.CreateFileWithDirectories(vfsPath, System.Text.Encoding.UTF8.GetString(data));
                        options.MetadataCallback?.Invoke(vfsPath, item.FullPath, versionToken);
                        files++; bytes += data.Length;
                        options.ProgressCallback?.Invoke(files, item.FullPath);
                    }
                    catch (Exception ex)
                    { skipped.Add(new(item.FullPath, ProviderSkipReason.LoadError, item.SizeBytes, ex.Message)); }
                }
            }
        }
        finally
        {
            await conn.DisconnectAsync(ct);
            if (conn is IAsyncDisposable d) await d.DisposeAsync();
        }

        sw.Stop();
        return new ProviderLoadResult
        {
            RemoteRoot = root, FilesLoaded = files, DirectoriesCreated = dirs,
            TotalBytes = bytes, Skipped = skipped, Duration = sw.Elapsed
        };
    }

    public async Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken ct = default)
    {
        var settings = _auth.Settings ?? throw new InvalidOperationException("FTP provider is not authenticated.");
        var conn = _connectionFactory(settings);
        try
        {
            await conn.ConnectAsync(ct);
            var data = await conn.DownloadAsync(remotePath, ct);
            return new ProviderFileContent(data, VersionToken: string.Empty, IsBinary: IsBinary(remotePath));
        }
        finally
        {
            await conn.DisconnectAsync(ct);
            if (conn is IAsyncDisposable d) await d.DisposeAsync();
        }
    }

    public Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken ct = default)
        => throw new NotImplementedException("Implemented in Task 3.4");

    public Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken ct = default)
        => Task.FromResult(_auth.Account ?? ProviderAccountInfo.Anonymous);

    // Map an absolute remote path (e.g. "/data/sub/a.txt") to a VFS-relative path ("data/sub/a.txt").
    private static string ToVfsPath(string remotePath) => remotePath.TrimStart('/');

    private static bool IsBinary(string path)
    {
        var ext = Path.GetExtension(path).ToLowerInvariant();
        return ext is ".png" or ".jpg" or ".jpeg" or ".gif" or ".pdf" or ".zip" or ".exe" or ".dll" or ".bin";
    }
}
```
> `CreateFileWithDirectories` / `CreateBinaryFileWithDirectories` are existing Core extension
> methods (used by the GitHub loader). Confirm signatures and the namespace they live in.

- [ ] **Step 6: Run to verify import tests pass**

Run: `dotnet test tests/Atypical.VirtualFileSystem.Ftp.Tests -c Debug -f net10.0 --filter "FullyQualifiedName~Import"`
Expected: PASS (2 tests).

- [ ] **Step 7: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Ftp tests/Atypical.VirtualFileSystem.Ftp.Tests Atypical.VirtualFileSystem.sln
git commit -m "feat(ftp): FtpStorageProvider import + FtpProviderAuth (TDD with fake)"
```

### Task 3.4: Implement `FtpStorageProvider.WriteChangesAsync` (overwrite + delete, per-file results)

**Files:**
- Modify: `src/Atypical.VirtualFileSystem.Ftp/FtpStorageProvider.cs`
- Test: `tests/Atypical.VirtualFileSystem.Ftp.Tests/FtpStorageProviderWriteTests.cs`

- [ ] **Step 1: Write the failing test**

```csharp
namespace Atypical.VirtualFileSystem.Ftp.Tests;

public class FtpStorageProviderWriteTests
{
    private static FtpStorageProvider AuthedProvider(FakeFtpConnection fake)
    {
        var provider = new FtpStorageProvider(_ => fake);
        // authenticate (fake connect succeeds)
        provider.Auth.AuthenticateAsync(new AuthRequest { Host = "h", Username = "u", Password = "p" }).GetAwaiter().GetResult();
        return provider;
    }

    [Fact]
    public async Task WriteChangesAsync_uploads_adds_and_updates_and_reports_per_file()
    {
        var fake = new FakeFtpConnection();
        var provider = AuthedProvider(fake);

        var changes = new List<ProviderFileChange>
        {
            new() { RemotePath = "/data/new.txt", Kind = ChangeKind.Add, Content = "x"u8.ToArray() },
            new() { RemotePath = "/data/edit.txt", Kind = ChangeKind.Update, Content = "y"u8.ToArray() },
        };

        var result = await provider.WriteChangesAsync(changes, CommitContext.Empty);

        result.Success.ShouldBeTrue();
        result.FileResults.Count.ShouldBe(2);
        fake.Uploaded.ShouldContain("/data/new.txt");
        fake.Files["/data/edit.txt"].ShouldBe("y"u8.ToArray());
        result.PullRequestUrl.ShouldBeNull();
    }

    [Fact]
    public async Task WriteChangesAsync_deletes_files()
    {
        var fake = new FakeFtpConnection();
        fake.Files["/data/gone.txt"] = "z"u8.ToArray();
        var provider = AuthedProvider(fake);

        var result = await provider.WriteChangesAsync(
            [new() { RemotePath = "/data/gone.txt", Kind = ChangeKind.Delete }], CommitContext.Empty);

        result.Success.ShouldBeTrue();
        fake.Deleted.ShouldContain("/data/gone.txt");
    }
}
```

- [ ] **Step 2: Run to verify it fails**

Run: `dotnet test tests/Atypical.VirtualFileSystem.Ftp.Tests -c Debug -f net10.0 --filter "FullyQualifiedName~Write"`
Expected: FAIL (NotImplementedException).

- [ ] **Step 3: Replace `WriteChangesAsync` with the implementation**

```csharp
    public async Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken ct = default)
    {
        var settings = _auth.Settings ?? throw new InvalidOperationException("FTP provider is not authenticated.");
        var fileResults = new List<ProviderFileWriteResult>();

        var conn = _connectionFactory(settings);
        try
        {
            await conn.ConnectAsync(ct);
            foreach (var change in changes)
            {
                ct.ThrowIfCancellationRequested();
                try
                {
                    if (change.Kind == ChangeKind.Delete)
                        await conn.DeleteFileAsync(change.RemotePath, ct);
                    else
                        await conn.UploadAsync(change.RemotePath, change.Content ?? [], ct);
                    fileResults.Add(new(change.RemotePath, true, null));
                }
                catch (Exception ex)
                {
                    fileResults.Add(new(change.RemotePath, false, ex.Message));
                }
            }
        }
        finally
        {
            await conn.DisconnectAsync(ct);
            if (conn is IAsyncDisposable d) await d.DisposeAsync();
        }

        return new ProviderWriteResult
        {
            Success = fileResults.All(r => r.Success),
            FileResults = fileResults
        };
    }
```

- [ ] **Step 4: Run to verify it passes**

Run: same as Step 2. Expected: PASS (2 tests). Then run the whole FTP suite: `dotnet test tests/Atypical.VirtualFileSystem.Ftp.Tests -c Debug -f net10.0` → PASS.

- [ ] **Step 5: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Ftp tests/Atypical.VirtualFileSystem.Ftp.Tests
git commit -m "feat(ftp): WriteChangesAsync overwrite/delete with per-file results"
```

### Task 3.5: Add DI registration for the FTP provider

**Files:**
- Create: `src/Atypical.VirtualFileSystem.Ftp/ServiceCollectionExtensions.cs`

- [ ] **Step 1: Implement the registration**

```csharp
using Microsoft.Extensions.DependencyInjection;

namespace Atypical.VirtualFileSystem.Ftp;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVirtualFileSystemFtp(this IServiceCollection services)
    {
        services.AddScoped<IFtpConnectionFactory, FluentFtpConnectionFactory>();
        services.AddScoped<FtpStorageProvider>(sp =>
        {
            var factory = sp.GetRequiredService<IFtpConnectionFactory>();
            return new FtpStorageProvider(settings => factory.Create(settings));
        });
        return services;
    }
}

public interface IFtpConnectionFactory { IFtpConnection Create(FtpConnectionSettings settings); }

public sealed class FluentFtpConnectionFactory : IFtpConnectionFactory
{
    public IFtpConnection Create(FtpConnectionSettings settings) => new FluentFtpConnection(settings);
}
```
> Add `Microsoft.Extensions.DependencyInjection.Abstractions` PackageReference to the Ftp
> csproj if not transitively available.

- [ ] **Step 2: Build to verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.Ftp -c Release`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.Ftp
git commit -m "feat(ftp): AddVirtualFileSystemFtp DI registration"
```

---

## Phase 4 — Blazor integration (registry + neutral services + capability-driven UI)

No automated test harness exists for the Blazor app (consistent with today); each task ends with a build and is verified by manually running the app. Run the app with: `dotnet run --project src/Atypical.VirtualFileSystem.DemoBlazorApp` and exercise the relevant flow.

### Task 4.1: Provider registry

**Files:**
- Create: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/IStorageProviderRegistry.cs`
- Create: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/StorageProviderRegistry.cs`

- [ ] **Step 1: Implement the registry**

```csharp
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

public interface IStorageProviderRegistry
{
    IReadOnlyList<IStorageProvider> Providers { get; }
    IStorageProvider Active { get; }
    void SetActive(string providerId);
    event Action? ActiveProviderChanged;
}

public sealed class StorageProviderRegistry : IStorageProviderRegistry
{
    private IStorageProvider _active;
    public IReadOnlyList<IStorageProvider> Providers { get; }
    public event Action? ActiveProviderChanged;

    public StorageProviderRegistry(IEnumerable<IStorageProvider> providers)
    {
        Providers = providers.ToList();
        if (Providers.Count == 0) throw new InvalidOperationException("No storage providers registered.");
        _active = Providers[0];
    }

    public IStorageProvider Active => _active;

    public void SetActive(string providerId)
    {
        var match = Providers.FirstOrDefault(p => p.Id == providerId)
            ?? throw new ArgumentException($"Unknown provider '{providerId}'.", nameof(providerId));
        if (!ReferenceEquals(match, _active))
        {
            _active = match;
            ActiveProviderChanged?.Invoke();
        }
    }
}
```

- [ ] **Step 2: Build and commit**

Run: `dotnet build src/Atypical.VirtualFileSystem.DemoBlazorApp -c Release` → Build succeeded.
```bash
git add src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/IStorageProviderRegistry.cs src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/StorageProviderRegistry.cs
git commit -m "feat(blazor): storage provider registry"
```

### Task 4.2: Register providers + registry in Program.cs

**Files:**
- Modify: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Program.cs`
- Modify: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Atypical.VirtualFileSystem.DemoBlazorApp.csproj` (add ProjectReference to `…Ftp` and `…Providers.Abstractions`)

- [ ] **Step 1: Add references and registrations**

In Program.cs, after existing service registrations:
```csharp
using Atypical.VirtualFileSystem.Ftp;
using Atypical.VirtualFileSystem.GitHub.Providers;
using Atypical.VirtualFileSystem.Providers.Abstractions;

// Providers
builder.Services.AddVirtualFileSystemFtp();
builder.Services.AddScoped<GitHubProviderAuth>();
builder.Services.AddScoped<GitHubStorageProvider>();

// Expose both providers as IStorageProvider for the registry
builder.Services.AddScoped<IStorageProvider>(sp => sp.GetRequiredService<GitHubStorageProvider>());
builder.Services.AddScoped<IStorageProvider>(sp => sp.GetRequiredService<FtpStorageProvider>());
builder.Services.AddScoped<IStorageProviderRegistry, StorageProviderRegistry>();
```
> The GitHub provider's loader/write service are already registered by
> `AddVirtualFileSystemGitHub()`. Confirm `IGitHubWriteService`/`IGitHubRepositoryLoader`
> are resolvable; if `GitHubStorageProvider` needs them, they are injected automatically.

- [ ] **Step 2: Build and run smoke test**

Run: `dotnet build src/Atypical.VirtualFileSystem.DemoBlazorApp -c Release` → Build succeeded.
Run the app and confirm it starts without DI errors: `dotnet run --project src/Atypical.VirtualFileSystem.DemoBlazorApp` (Ctrl+C after it serves).

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.DemoBlazorApp/Program.cs src/Atypical.VirtualFileSystem.DemoBlazorApp/Atypical.VirtualFileSystem.DemoBlazorApp.csproj
git commit -m "feat(blazor): register GitHub and FTP providers + registry"
```

### Task 4.3: Neutral import service + provider-aware credential storage

**Files:**
- Create: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/StorageImportService.cs`
- Create: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/StorageCredentialStore.cs`
- Modify: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Program.cs` (register both)

- [ ] **Step 1: Implement a credential store** (encrypts per-provider auth payloads via ProtectedLocalStorage, mirroring the GitHub PAT approach)

```csharp
using Atypical.VirtualFileSystem.Providers.Abstractions;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

public sealed class StorageCredentialStore
{
    private readonly ProtectedLocalStorage _storage;
    public StorageCredentialStore(ProtectedLocalStorage storage) => _storage = storage;

    private static string Key(string providerId) => $"provider_creds_{providerId}";

    public async Task SaveAsync(string providerId, AuthRequest request)
    {
        try { await _storage.SetAsync(Key(providerId), request); } catch { /* prerender/unavailable */ }
    }

    public async Task<AuthRequest?> LoadAsync(string providerId)
    {
        try
        {
            var result = await _storage.GetAsync<AuthRequest>(Key(providerId));
            return result.Success ? result.Value : null;
        }
        catch { return null; }
    }

    public async Task ClearAsync(string providerId)
    {
        try { await _storage.DeleteAsync(Key(providerId)); } catch { /* unavailable */ }
    }
}
```

- [ ] **Step 2: Implement the import service** (delegates to the active provider)

```csharp
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

public sealed class StorageImportService
{
    private readonly IStorageProviderRegistry _registry;
    private readonly IVirtualFileSystem _vfs;
    public StorageImportService(IStorageProviderRegistry registry, IVirtualFileSystem vfs)
    { _registry = registry; _vfs = vfs; }

    public event Action? OnStateChanged;
    public bool IsImporting { get; private set; }

    public async Task<ProviderLoadResult> ImportAsync(ProviderLoadOptions options, CancellationToken ct = default)
    {
        IsImporting = true; OnStateChanged?.Invoke();
        try { return await _registry.Active.ImportAsync(_vfs, options, ct); }
        finally { IsImporting = false; OnStateChanged?.Invoke(); }
    }
}
```
> Register both in Program.cs as scoped. This replaces direct use of `GitHubImportService`
> for the provider-neutral path; keep `GitHubImportService` only where still referenced and
> migrate callers incrementally.

- [ ] **Step 3: Build and commit**

Run: `dotnet build src/Atypical.VirtualFileSystem.DemoBlazorApp -c Release` → Build succeeded.
```bash
git add src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/StorageImportService.cs src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/StorageCredentialStore.cs src/Atypical.VirtualFileSystem.DemoBlazorApp/Program.cs
git commit -m "feat(blazor): neutral StorageImportService + encrypted credential store"
```

### Task 4.4: Capability-driven import dialog with a provider picker

**Files:**
- Modify: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Components/Dialogs/GitHubImportDialog.razor` → rename/generalize to `ImportDialog.razor` (keep file for now; add provider picker + capability-driven fields)
- Modify: callers in `MainLayout.razor`/`TopBar.razor` to the generalized dialog name if renamed

- [ ] **Step 1: Add the provider picker + capability-driven fields**

At the top of the dialog body, inject the registry and render a picker:
```razor
@inject IStorageProviderRegistry Registry
@inject StorageImportService ImportService

<label>Provider</label>
<select value="@Registry.Active.Id" @onchange="OnProviderChanged">
    @foreach (var p in Registry.Providers)
    {
        <option value="@p.Id">@p.DisplayName</option>
    }
</select>

@if (Registry.Active.Capabilities.SupportsBranches)
{
    @* GitHub: owner / repo / branch / subpath inputs (existing markup) *@
}
else if (Registry.Active.Capabilities.AuthKind == AuthKind.Credentials)
{
    @* FTP: host / port / username / password / useTls / base path inputs *@
}
```

```csharp
private void OnProviderChanged(ChangeEventArgs e)
{
    Registry.SetActive(e.Value?.ToString() ?? Registry.Active.Id);
    StateHasChanged();
}
```
Build the `ProviderLoadOptions` (and authenticate via `Registry.Active.Auth.AuthenticateAsync`) from whichever field set is shown, then call `ImportService.ImportAsync(options)`.

> Keep all event subscriptions wrapped in `InvokeAsync(StateHasChanged)` per the existing
> RequestRender pattern already in the codebase.

- [ ] **Step 2: Build and manually verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.DemoBlazorApp -c Release` → Build succeeded.
Run the app, open the import dialog, switch between GitHub and FTP, confirm the field set changes. (FTP import requires a reachable FTP server to fully exercise.)

- [ ] **Step 3: Commit**

```bash
git add src/Atypical.VirtualFileSystem.DemoBlazorApp/Components
git commit -m "feat(blazor): capability-driven import dialog with provider picker"
```

### Task 4.5: Capability-driven "Submit changes" (PR for GitHub, upload for FTP)

**Files:**
- Create: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Services/StoragePendingChangesService.cs`
- Modify: `src/Atypical.VirtualFileSystem.DemoBlazorApp/Components/Dialogs/CreatePullRequestDialog.razor` → generalize submit label/controls by capability

- [ ] **Step 1: Implement `StoragePendingChangesService`** that, for the active provider:
  - if `Capabilities.SupportsPullRequests` → call the existing GitHub write orchestration (reuse `GitHubPendingChangesService` logic / `IGitHubWriteService`) and return a `ProviderWriteResult` with `PullRequestUrl`;
  - else → build `ProviderFileChange[]` from the tracked pending changes and call `Registry.Active.WriteChangesAsync(changes, CommitContext.Empty)`.

```csharp
using Atypical.VirtualFileSystem.Providers.Abstractions;

namespace Atypical.VirtualFileSystem.DemoBlazorApp.Services;

public sealed class StoragePendingChangesService
{
    private readonly IStorageProviderRegistry _registry;
    // inject existing pending-change tracking (StorageMetadataTracker) + GitHub PR service for the PR branch
    public StoragePendingChangesService(IStorageProviderRegistry registry /*, ... */) => _registry = registry;

    public bool SupportsPullRequests => _registry.Active.Capabilities.SupportsPullRequests;

    public async Task<ProviderWriteResult> SubmitAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken ct = default)
        => await _registry.Active.WriteChangesAsync(changes, context, ct);
    // For GitHub, route to the existing fork->branch->commit->PR service (documented seam from Task 2.4).
}
```

- [ ] **Step 2: Generalize the dialog** — show PR fields (title/branch/draft/fork) only when `SupportsPullRequests`; otherwise show a simple "Upload N changes" confirmation. Rename the primary button text by capability ("Create Pull Request" vs "Upload changes").

- [ ] **Step 3: Build and manually verify**

Run: `dotnet build src/Atypical.VirtualFileSystem.DemoBlazorApp -c Release` → Build succeeded. Manually confirm GitHub still shows the PR flow and FTP shows the upload flow.

- [ ] **Step 4: Commit**

```bash
git add src/Atypical.VirtualFileSystem.DemoBlazorApp
git commit -m "feat(blazor): capability-driven submit-changes (PR vs upload)"
```

### Task 4.6: Final full-solution verification

- [ ] **Step 1: Build the whole solution**

Run: `dotnet build Atypical.VirtualFileSystem.sln -c Release`
Expected: Build succeeded, 0 errors.

- [ ] **Step 2: Run all tests**

Run: `dotnet test Atypical.VirtualFileSystem.sln -c Release`
Expected: PASS — existing Core (399) + GitHub (71 + new provider tests) + new Abstractions + new FTP tests, on net9.0 and net10.0.

- [ ] **Step 3: Manual smoke test of the app**

Run: `dotnet run --project src/Atypical.VirtualFileSystem.DemoBlazorApp`. Verify: GitHub import + PR flow unchanged; FTP provider selectable; FTP import + upload works against a test FTP server.

- [ ] **Step 4: Update CLAUDE.md architecture section** to mention the provider abstraction and the FTP/Providers projects; commit.

```bash
git add CLAUDE.md
git commit -m "docs: document storage provider abstraction and FTP provider"
```

---

## Notes for the implementer

- **Verify external API names while implementing:** FluentFTP async method signatures and the exact member names on `GitHubLoaderOptions`/`GitHubLoadResult`/`GitHubSkippedFile`/`SkipReason` must be confirmed against the real code; the plan calls these out at each use site. Use the context7 MCP for FluentFTP docs and read the GitHub project files directly.
- **Regression gate:** after Phase 2, the full GitHub test suite MUST stay green — that is the proof the wrap changed nothing.
- **TDD:** every provider/adapter behavior gets a failing test first (Phases 1–3 are fully unit-testable via the fakes/seams). Phase 4 (Blazor) has no test harness; verify by build + manual run.
- **Out of scope (follow-on specs):** OneDrive/Graph + OAuth; issue #132 cloud adapters (S3/Azure/GCS); fully deleting the GitHub-named Blazor services.
