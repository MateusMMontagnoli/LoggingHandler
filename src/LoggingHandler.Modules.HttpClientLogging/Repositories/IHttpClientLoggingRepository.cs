using LoggingHandler.Modules.HttpClientLogging.Domain;

namespace LoggingHandler.Modules.HttpClientLogging.Repositories;

interface IHttpClientLoggingRepository
{
    public Task Add(ClientLog log);

    public Task Update(ClientLog log);

    public Task SaveChangeAsync();

    public Task<ClientLog?> GetClientLogById(Guid id);
    
    public Task<ClientLog?> GetClientLogBySearchIdentifier(string searchIdentifier);

    public Task<List<ClientLog>> List();
}
