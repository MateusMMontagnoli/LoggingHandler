using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using LoggingHandler.Modules.HttpClientLogging.Domain;
using Microsoft.EntityFrameworkCore;

namespace LoggingHandler.Modules.HttpClientLogging.Data;

class ClientLogDbContext(DbContextOptions<ClientLogDbContext> options) : DbContext(options)
{
    internal DbSet<ClientLog> ClientLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
