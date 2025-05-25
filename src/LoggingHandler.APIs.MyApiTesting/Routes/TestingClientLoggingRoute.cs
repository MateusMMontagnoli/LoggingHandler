using LoggingHandler.Infra.Client.MyClientTesting;
using Microsoft.AspNetCore.Mvc;

namespace LoggingHandler.APIs.MyApiTesting.Routes;

public static class TestingClientLoggingRoute
{
    public static void MapperTestingClientLoggingRoutes(this WebApplication app)
    {
        app.MapGroup("/testing-logging")
            .MapRandomResponseRoutes()
            .WithName("Testing Logging")
            .WithTags("Testing Logging")
            .WithDescription("Testing Http Client Logging API");
    }

    private static RouteGroupBuilder MapRandomResponseRoutes(this RouteGroupBuilder routGroup)
    {
        RandomBase64QrCodeRoute(routGroup);

        return routGroup;
    }

    private static void RandomBase64QrCodeRoute(RouteGroupBuilder routGroup)
    {
        routGroup.MapGet("/qrcode", async ([FromQuery] string uri, [FromServices] IIntegrationApiClientGateway integrationApiClient) =>
        {
            // TODO: Use Result
            var qrCode = await integrationApiClient.GenerateQrCode(uri);
            return Results.Ok(qrCode);
        })
                .WithName("GetQrCode")
                .Produces(200)
                .ProducesProblem(500);
    }
}
