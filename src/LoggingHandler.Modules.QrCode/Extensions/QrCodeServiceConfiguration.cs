using LoggingHandler.Modules.QrCode.Contracts;
using LoggingHandler.Modules.QrCode.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoggingHandler.Modules.QrCode.Extensions;

public static class QrCodeServiceConfiguration
{
    public static IServiceCollection ConfigureQrCodeModule(this IServiceCollection services)
    {
        services.AddScoped<IQrCodeService, QrCodeService>();

        return services;
    }
}
