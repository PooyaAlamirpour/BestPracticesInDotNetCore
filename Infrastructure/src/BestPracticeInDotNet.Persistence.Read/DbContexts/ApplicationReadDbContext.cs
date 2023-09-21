using BestPracticeInDotNet.framework.DDD.Abstracts;
using BestPracticeInDotNet.Infrastructure.SharedKernel.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BestPracticeInDotNet.Infrastructure.Persistence.DbContexts;

public class ApplicationReadDbContext : DbContext
{
    public ApplicationReadDbContext(DbContextOptions<ApplicationReadDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        foreach (var property in entity.GetProperties().Where(p => p.IsPrimaryKey()))
            property.ValueGenerated = ValueGenerated.Never;
        
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    public override int SaveChanges()
    {
        UpdateAuditableEntity();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateAuditableEntity();

        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void UpdateAuditableEntity()
    {
        foreach (var entityEntry in ChangeTracker.Entries<IAuditable>())
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(entity => entity.CreatedAt).CurrentValue = DateTime.Now;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(entity => entity.ModifiedAt).CurrentValue = DateTime.Now;
            }
        }
    }
}