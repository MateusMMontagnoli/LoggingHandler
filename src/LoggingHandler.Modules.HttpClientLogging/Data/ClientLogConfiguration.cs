using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LoggingHandler.Modules.HttpClientLogging.Domain;

namespace LoggingHandler.Modules.HttpClientLogging.Data;

class ClientLogConfiguration : IEntityTypeConfiguration<ClientLog>
{
    public void Configure(EntityTypeBuilder<ClientLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Application)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Client)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.StatusCode);

        builder
             .Property(x => x.RequestDate)
             .IsRequired();

        builder
             .Property(x => x.RequestPath)
             .HasMaxLength(300);

        builder
             .Property(x => x.ResponseDate);

        builder
             .Property(x => x.ResponsePath)
             .HasMaxLength(300);

    }
}
