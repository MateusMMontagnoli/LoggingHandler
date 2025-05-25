namespace LoggingHandler.Modules.HttpClientLogging.DTOs;

public record CreateClientLogRequest(
    string Identifier, 
    string SearchIdentifier, 
    string Application, 
    string Client, 
    int StatusCode, 
    DateTime RequestDate, 
    DateTime ResponseDate, 
    string? requestPath = null, 
    string? responsePath = null
);
