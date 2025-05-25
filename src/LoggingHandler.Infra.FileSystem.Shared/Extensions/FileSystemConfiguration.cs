using Microsoft.Extensions.DependencyInjection;

namespace LoggingHandler.Infra.FileSystem.Shared.Extensions;

public static class FileSystemConfiguration
{
    public static IServiceCollection ConfigureFileSystem(
        this IServiceCollection services
    )
    {
        services.AddScoped<IFileService, VolumeFileService>();
        return services;
    }
}
