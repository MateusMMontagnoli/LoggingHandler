using LoggingHandler.Modules.HttpClientLogging.DTOs;

namespace LoggingHandler.Modules.HttpClientLogging;

public interface IHttpClientLoggingService
{
    public Task<HttpClientLogDTO> GetLogBySearchIdentifier(string searchIdentifier);

    public Task<HttpClientLogDTO> GetLogByIdentifier(string identifier);

    public Task CreateLog(CreateClientLogRequest request);
}
