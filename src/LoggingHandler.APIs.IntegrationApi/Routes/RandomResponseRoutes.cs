
using LoggingHandler.Modules.QrCode.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoggingHandler.APIs.IntegrationApi.Routes;

public static class RandomResponseRoutes
{
    public static void MapperRandomResponseRoutes(this WebApplication app)
    {
        app.MapGroup("/random")
            .MapRandomResponseRoutes()
            .WithName("RandomResponse")
            .WithTags("RandomResponse")
            .WithDescription("Random Response API");
    }

    private static RouteGroupBuilder MapRandomResponseRoutes(this RouteGroupBuilder routGroup)
    {
        RandomIntRoute(routGroup);
        RandomBase64QrCodeRoute(routGroup);

        return routGroup;
    }

    private static void RandomBase64QrCodeRoute(RouteGroupBuilder routGroup)
    {
        routGroup.MapGet("/qrcode", ([FromQuery] string uri, IQrCodeService qrCodeService) =>
        {
            var base64 = qrCodeService.GenerateQrCode(uri);
            return Results.Ok(new { QrCode = base64 });
        })
                .WithName("GetQrCode")
                .Produces(200)
                .ProducesProblem(500);
    }

    private static void RandomIntRoute(RouteGroupBuilder routGroup)
    {
        routGroup.MapGet("/int", () =>
        {
            var random = new Random();
            var randomNumber = random.Next(1, 100);
            return Results.Ok(new { RandomNumber = randomNumber });
        })
                .WithName("GetRandomResponse")
                .Produces(200)
                .ProducesProblem(500);
    }
}
