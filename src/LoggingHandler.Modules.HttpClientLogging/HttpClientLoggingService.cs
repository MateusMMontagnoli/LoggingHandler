using LoggingHandler.Modules.HttpClientLogging.DTOs;

namespace LoggingHandler.Modules.HttpClientLogging;

class HttpClientLoggingService : IHttpClientLoggingService
{
    public Task CreateLog(CreateClientLogRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<HttpClientLogDTO> GetLogByIdentifier(string identifier)
    {
        throw new NotImplementedException();
    }

    public Task<HttpClientLogDTO> GetLogBySearchIdentifier(string searchIdentifier)
    {
        throw new NotImplementedException();
    }
}
