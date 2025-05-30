using LoggingHandler.APIs.MyApiTesting.Routes;
using LoggingHandler.Infra.Client.MyClientTesting.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddIntegrationApiClient(builder.Configuration);

var app = builder.Build();

app.MapperTestingClientLoggingRoutes();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/v1/openapi.json");
}

//app.UseHttpsRedirection();



app.Run();
