using Microsoft.Extensions.DependencyInjection;

namespace Atypical.VirtualFileSystem.Ftp;

/// <summary>
/// Extension methods for registering the FTP storage provider in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>Registers the FTP connection factory and <see cref="FtpStorageProvider"/> as scoped services.</summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
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
