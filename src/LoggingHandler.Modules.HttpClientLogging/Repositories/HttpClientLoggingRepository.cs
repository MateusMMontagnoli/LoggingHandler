using LoggingHandler.Modules.HttpClientLogging.Data;
using LoggingHandler.Modules.HttpClientLogging.Domain;
using Microsoft.EntityFrameworkCore;

namespace LoggingHandler.Modules.HttpClientLogging.Repositories;

class HttpClientLoggingRepository : IHttpClientLoggingRepository
{
    private readonly ClientLogDbContext _context;

    public HttpClientLoggingRepository(ClientLogDbContext context)
    {
        _context = context;
    }

    public async Task Add(ClientLog log)
    {
        await _context.AddAsync(log);
    }

    public async Task<ClientLog?> GetClientLogById(Guid id)
    {
        return await _context.ClientLogs.FindAsync(id);
    }

    public async Task<ClientLog?> GetClientLogBySearchIdentifier(string searchIdentifier)
    {
        return await _context.ClientLogs.FirstOrDefaultAsync(x => x.SearchIdentifier == searchIdentifier);
    }

    public async Task<List<ClientLog>> List()
    {
        // TODO: implement pagination
        return await _context.ClientLogs.ToListAsync();
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Update(ClientLog log)
    {
        await Task.FromResult(_context.Update(log));
    }
}
