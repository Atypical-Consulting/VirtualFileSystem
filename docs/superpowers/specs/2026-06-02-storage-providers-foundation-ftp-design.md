# Design: Storage Provider Abstraction + FTP Provider (Foundation)

**Date:** 2026-06-02
**Status:** Approved (design); implementation plan to follow
**Scope:** Foundation (provider abstraction + migrate GitHub onto it, no behavior change) **plus** a read+write FTP provider and the UI generalization needed to drive both from capabilities.

## 1. Goal & Context

The DemoBlazorApp currently works only with GitHub repositories. Every layer is
hard-coded to GitHub: the `Atypical.VirtualFileSystem.GitHub` library (Octokit
loader + write service), five Blazor services (`GitHubAuthService`,
`GitHubImportService`, `GitHubMetadataTracker`, `GitHubPendingChangesService`,
`GitHubWriteService`), the `GitHubFileMetadata` model, and the GitHub dialogs.

This design introduces a provider abstraction so multiple storage backends can be
plugged in, migrates the existing GitHub code onto it **without changing GitHub
behavior**, and adds a working **FTP** provider (read + write) as the first new
backend to prove the abstraction end-to-end including the UI.

OneDrive (Microsoft Graph + OAuth) and the cloud adapters proposed in issue #132
(S3/Azure Blob/GCS) are **explicitly out of scope** here and become follow-on
specs. The abstraction is designed so they slot in without rework.

## 2. Architecture

Approach A (chosen): a dedicated abstractions package, providers as separate
packages, and a runtime registry in the app.

```
src/
  Atypical.VirtualFileSystem.Providers.Abstractions/   NEW: interfaces + neutral records
  Atypical.VirtualFileSystem.GitHub/                   references Abstractions; adds GitHubStorageProvider
  Atypical.VirtualFileSystem.Ftp/                      NEW: FtpStorageProvider (FluentFTP)
  Atypical.VirtualFileSystem.DemoBlazorApp/            registry + neutral services + capability-driven UI
tests/
  Atypical.VirtualFileSystem.Providers.Abstractions.Tests/  NEW
  Atypical.VirtualFileSystem.Ftp.Tests/                     NEW
```

`Atypical.VirtualFileSystem.Core` is **untouched**: it remains a pure in-memory
VFS with no remote-storage concepts. Providers depend on Core (to populate a
`IVirtualFileSystem`) and on Abstractions; the app depends on all of them.

## 3. The Abstraction Surface (Abstractions package)

```csharp
public interface IStorageProvider
{
    string Id { get; }                  // "github", "ftp"
    string DisplayName { get; }
    ProviderCapabilities Capabilities { get; }
    IStorageProviderAuth Auth { get; }

    Task<ProviderLoadResult> ImportAsync(IVirtualFileSystem vfs, ProviderLoadOptions options, CancellationToken ct = default);
    Task<ProviderFileContent> ReadFileAsync(string remotePath, CancellationToken ct = default);
    Task<ProviderWriteResult> WriteChangesAsync(IReadOnlyList<ProviderFileChange> changes, CommitContext context, CancellationToken ct = default);
    Task<ProviderAccountInfo> GetAccountInfoAsync(CancellationToken ct = default);
}

public enum AuthKind { Token, Credentials, OAuth }

public sealed record ProviderCapabilities
{
    public bool SupportsBranches { get; init; }
    public bool SupportsPullRequests { get; init; }
    public bool SupportsFork { get; init; }
    public bool SupportsAtomicMultiFileCommit { get; init; }   // GitHub=true, FTP=false
    public bool SupportsVersioning { get; init; }
    public AuthKind AuthKind { get; init; }
}

public interface IStorageProviderAuth
{
    AuthKind Kind { get; }
    bool IsAuthenticated { get; }
    ProviderAccountInfo? Account { get; }
    Task<AuthResult> AuthenticateAsync(AuthRequest request, CancellationToken ct = default);
    Task SignOutAsync(CancellationToken ct = default);
    event Action? AuthChanged;
}
```

**Neutral records:**

- `ProviderLoadOptions` — remote root path, loading strategy (Eager/Lazy/MetadataOnly),
  filters (allowed/blocked extensions, max file size, glob), and optional progress +
  metadata callbacks. Mirrors today's `GitHubLoaderOptions` semantics.
- `ProviderLoadResult` — `FilesLoaded`, `DirectoriesCreated`, `TotalBytes`,
  `Skipped` (list of `{ path, reason, size, message }`), `Duration`, `RemoteRoot`.
- `ProviderFileContent` — `byte[] Content`, `string VersionToken`, `bool IsBinary`.
- `ProviderFileChange` — `string RemotePath`, `ChangeKind Kind` (Add/Update/Delete),
  `byte[]? Content`, `string? BaseVersionToken`.
- `CommitContext` — optional `Message`, `Branch`, `Draft`. Providers honor only what
  their capabilities allow and **ignore the rest** (e.g. FTP ignores all three).
- `ProviderWriteResult` — overall success plus **per-file results**
  `{ remotePath, success, message }` so non-atomic providers can report partial success.
- `ProviderFileMetadata` — `ProviderId`, `ContainerKey` (repo / host+base path),
  `RelativePath`, `VersionToken`, `ImportedAt`.
- `ProviderAccountInfo` — `DisplayName`, optional `QuotaUsed`/`QuotaTotal`, optional
  rate-limit info.
- `AuthRequest` / `AuthResult` — `AuthRequest` carries the kind-specific payload
  (token for Token; host/port/user/password/useTls for Credentials); `AuthResult`
  carries success + error message + resulting `ProviderAccountInfo`.

**Design rule:** branch / pull-request / fork are **not** methods on the base
interface. They are `ProviderCapabilities` flags plus `CommitContext` fields, so a
capable provider (GitHub) honors them and an incapable one (FTP) simply ignores
them — FTP is never forced to fake a pull request.

## 4. GitHub Migration (no behavior change)

- Add `GitHubStorageProvider : IStorageProvider` to the existing `…GitHub` project.
  It **delegates** to the current `IGitHubRepositoryLoader` and
  `IGitHubWriteService`; their logic is not modified.
- Adapters map types both directions:
  - `ProviderLoadOptions ↔ GitHubLoaderOptions`
  - `GitHubLoadResult → ProviderLoadResult` (skipped files map across)
  - `GitHubFileMetadata ↔ ProviderFileMetadata`: GitHub `BlobSha` → neutral
    `VersionToken`; `owner/repo` → `ContainerKey`.
- `Capabilities`: `SupportsBranches/PullRequests/Fork/AtomicMultiFileCommit = true`,
  `SupportsVersioning = true`, `AuthKind = Token`.
- `WriteChangesAsync` routes to the existing fork→branch→commit→PR orchestration,
  reading `CommitContext.Message/Branch/Draft`.
- `GitHubAuthService` is adapted to `IStorageProviderAuth` (`Kind = Token`).
- **Regression guarantee:** the existing 71 GitHub tests stay green, proving the
  wrap changed nothing. New unit tests cover the adapter mappings.

## 5. FTP Provider (`…Ftp`, FluentFTP)

- `FtpStorageProvider : IStorageProvider`. `Capabilities`: all `false` except
  `AuthKind = Credentials` (no branches/PR/fork/atomic-commit/versioning).
- `ImportAsync`: recursive listing (`GetListing`/MLSD) from a base directory →
  reuse the same filter/skip rules as the GitHub loader (size, extension, binary,
  glob). `VersionToken` = last-modified timestamp + size (no SHA available).
  Returns a `ProviderLoadResult` with skipped files.
- `ReadFileAsync`: download stream (RETR).
- `WriteChangesAsync`: per-file upload/overwrite-in-place (STOR), looping the
  changes and returning **per-file results** (partial success allowed). `Delete`
  changes issue a delete. `CommitContext.Message/Branch` are ignored.
- **Connection lifetime:** FTP holds a stateful session, unlike the stateless
  `GitHubClient`. The provider owns connect/disconnect per operation (or a
  short-lived pooled connection) and is resolved per use — it is **not** a
  long-lived singleton holding an open socket.
- `GetAccountInfoAsync`: host/user display name; quota left null.
- Auth: `FtpProviderAuth` (`Kind = Credentials`) validates by connecting.
  Credentials (host/port/user/password/useTls) are persisted via the app's
  encrypted `ProtectedLocalStorage`, keyed per provider.
- FTPS/TLS via a connection flag on the credentials.

## 6. Blazor Integration

**Registry & DI:**
- `IStorageProviderRegistry` lists available providers and tracks the **active**
  one (scoped per circuit). Registration: `services.AddStorageProvider<GitHubStorageProvider>()`,
  `services.AddStorageProvider<FtpStorageProvider>()`; the active provider is
  selected at runtime by `Id`.
- New provider-neutral services — `StorageImportService`, `StorageAuthService`,
  `StorageMetadataTracker`, `StoragePendingChangesService` — delegate to the active
  provider. Existing GitHub-named services are re-pointed onto these so there is a
  single code path. `StorageMetadataTracker` reuses the boundary-safe tracking
  logic (already fixed) generalized to `ProviderFileMetadata`.

**UI (driven by `ProviderCapabilities`, never by provider name):**
- Import dialog: a provider picker at the top; fields render from capabilities —
  repo/owner/branch only if `SupportsBranches`; host/port/credentials + TLS for
  `AuthKind == Credentials`; PAT panel for `AuthKind == Token`.
- "Create Pull Request" becomes a capability-driven **"Submit changes"**: a PR for
  GitHub (`SupportsPullRequests`), a direct upload for FTP. PR-specific controls
  (title/branch/draft/fork) show only when `SupportsPullRequests`.
- Status / pending-changes / file-viewer bind to the neutral services and
  `ProviderAccountInfo` (quota / rate-limit shown only when present).
- OneDrive's future `AuthKind == OAuth` slots into the same picker/auth-panel
  switch with no UI rework.

## 7. Testing Strategy (TDD — failing test first per behavior)

- **Abstractions.Tests:** capability/record behavior; `CommitContext`-honoring rules.
- **Ftp.Tests:** `FtpStorageProvider` against a controllable FTP server — an
  in-process embedded FTP server fixture, or an `IFtpClient` seam mocked with the
  existing mocking setup — covering import filtering, read, write overwrite,
  delete, and per-file partial-success.
- **GitHub:** existing 71 tests are the regression gate proving the wrap changed
  nothing; add adapter-mapping unit tests (GitHub ↔ neutral types).
- **Blazor UI:** no automated harness exists today; verified by build + manual run.

## 8. Out of Scope (follow-on specs)

- OneDrive / Microsoft Graph + interactive OAuth (auth-code + PKCE, token refresh).
- Cloud adapters from issue #132 (S3 / Azure Blob / GCS).
- Fully retiring the GitHub-named Blazor services (kept as thin adapters this round).

## 9. Risks & Mitigations

- **GitHub regression during the wrap** → adapters only, no loader/write changes;
  existing tests must stay green.
- **FTP connection/state handling** → per-operation connect/disconnect; provider
  not held as an open-socket singleton; cancellation honored.
- **Prerender + credential storage** → `ProtectedLocalStorage` access wrapped in
  try/catch (same pattern already used for the PAT).
- **UI scope creep** → UI changes limited to capability-driven rendering of the
  existing dialogs; no redesign.
