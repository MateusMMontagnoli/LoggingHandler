using LoggingHandler.Modules.HttpClientLogging.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LoggingHandler.Modules.HttpClientLogging.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace LoggingHandler.Modules.HttpClientLogging.Extensions;

public static class HttpClientLoggingConfiguration
{

    public static IServiceCollection ConfigureHttpClientLoggingModule(
        this IServiceCollection services,
        IConfigurationManager config)
    {
        services.AddScoped<IHttpClientLoggingService, HttpClientLoggingService>();
        services.AddScoped<IHttpClientLoggingRepository, HttpClientLoggingRepository>();

        string? connectionString = config.GetConnectionString("Database");

        services.AddDbContext<ClientLogDbContext>(options =>
            options.UseNpgsql(connectionString)
        );

        return services;
    }


    public static void ApplyClientLogMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ClientLogDbContext context = scope.ServiceProvider.GetRequiredService<ClientLogDbContext>();

        context.Database.Migrate();
    }
}
