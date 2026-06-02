using Atypical.VirtualFileSystem.DemoBlazorApp.Components;
using Atypical.VirtualFileSystem.DemoBlazorApp.Services;
using Atypical.VirtualFileSystem.Core.Services;
using Atypical.VirtualFileSystem.Ftp;
using Atypical.VirtualFileSystem.GitHub;
using Atypical.VirtualFileSystem.GitHub.Providers;
using Atypical.VirtualFileSystem.Providers.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Virtual File System
builder.Services.AddVirtualFileSystem();

// Add GitHub Repository Loader
builder.Services.AddVirtualFileSystemGitHub();

// Add State Service
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.VFSStateService>();

// Add CloudDrive services
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.ToastService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.FileIconService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.RecentFilesService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.RecycleBinService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.UndoRedoService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.GitHubImportService>();

// Add GitHub authentication and PR services
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.GitHubAuthService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.GitHubMetadataTracker>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.GitHubPendingChangesService>();
builder.Services.AddScoped<IGitHubWriteService, GitHubWriteService>();

// Storage providers (neutral abstraction layer — alongside existing GitHub services)
builder.Services.AddVirtualFileSystemFtp();
builder.Services.AddScoped<GitHubProviderAuth>();
builder.Services.AddScoped<GitHubStorageProvider>();

// Expose both providers as IStorageProvider so the registry receives them via IEnumerable<IStorageProvider>.
// Registration order is intentional: it determines the registry's default active provider (GitHub first = default).
builder.Services.AddScoped<IStorageProvider>(sp => sp.GetRequiredService<GitHubStorageProvider>());
builder.Services.AddScoped<IStorageProvider>(sp => sp.GetRequiredService<FtpStorageProvider>());
builder.Services.AddScoped<IStorageProviderRegistry, StorageProviderRegistry>();

// Provider-neutral credential store and import service
builder.Services.AddScoped<StorageCredentialStore>();
builder.Services.AddScoped<StorageImportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
