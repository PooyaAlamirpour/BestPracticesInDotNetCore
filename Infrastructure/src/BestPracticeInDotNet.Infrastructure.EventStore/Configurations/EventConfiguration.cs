using BestPracticeInDotNet.Infrastructure.EventStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPracticeInDotNet.Infrastructure.EventStore.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> entity)
    {
        entity.ToTable("events");

        entity.HasKey(x => x.Id).HasName("PRIMARY");
        entity.Property(x => x.Id).HasColumnName("id");
        entity.Property(x => x.Payload).HasColumnName("payload");
        entity.Property(x => x.Version).HasColumnName("version");
        entity.Property(x => x.CreatedAt).HasColumnName("created_at");
        entity.Property(x => x.ModifiedAt).HasColumnName("modified_at").IsRequired(false);
    }
}