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

public interface IFtpConnectionFactory
{
    IFtpConnection Create(FtpConnectionSettings settings);
}

public sealed class FluentFtpConnectionFactory : IFtpConnectionFactory
{
    public IFtpConnection Create(FtpConnectionSettings settings) => new FluentFtpConnection(settings);
}
