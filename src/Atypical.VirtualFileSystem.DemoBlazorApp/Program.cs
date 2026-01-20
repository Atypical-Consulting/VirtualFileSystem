using Atypical.VirtualFileSystem.DemoBlazorApp.Components;
using Atypical.VirtualFileSystem.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Virtual File System
builder.Services.AddVirtualFileSystem();

// Add State Service
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.VFSStateService>();

// Add CloudDrive services
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.ToastService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.FileIconService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.RecentFilesService>();
builder.Services.AddScoped<Atypical.VirtualFileSystem.DemoBlazorApp.Services.RecycleBinService>();

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
