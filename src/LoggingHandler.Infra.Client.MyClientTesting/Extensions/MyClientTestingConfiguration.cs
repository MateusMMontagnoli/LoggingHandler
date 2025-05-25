using LoggingHandler.Infra.FileSystem.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Handlers = LoggingHandler.Infra.Client.MyClientTesting.Handlers;

namespace LoggingHandler.Infra.Client.MyClientTesting.Extensions;

public static class MyClientTestingConfiguration
{
    public static IServiceCollection AddIntegrationApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureServices();
        services.ConfigureClient(configuration);

        return services;
    }

    private static IServiceCollection ConfigureClient(this IServiceCollection services, IConfiguration configuration)
    {
        var address = configuration["HttpClients:IntegrationApi:BaseAddress"] ?? throw new Exception("Serviço da API de integração não está configurado!");

        services.AddHttpClient<IIntegrationApiClientGateway, IntegrationApiClient>(client =>
        {
            client.BaseAddress = new Uri(address);
            //client.Timeout = TimeSpan.FromSeconds(30);
            client.Timeout = TimeSpan.FromSeconds(300); // For debugging
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        })
        .AddHttpMessageHandler<Handlers.LoggingHandler>();

        return services;
    }

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.ConfigureFileSystem();
        services.AddScoped<IntegrationApiClient>();
        services.AddTransient<Handlers.LoggingHandler>();

        return services;
    }
}
