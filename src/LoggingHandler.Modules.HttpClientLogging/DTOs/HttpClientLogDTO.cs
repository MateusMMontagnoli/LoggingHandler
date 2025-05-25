namespace LoggingHandler.Modules.HttpClientLogging.DTOs;

public record HttpClientLogDTO(string SearchIdentifier, string Application, string Client, int StatusCode, DateTime RequestDate, DateTime ResponseDate, string requestPath, string responsePath);
