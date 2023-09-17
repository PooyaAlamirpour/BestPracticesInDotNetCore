using Mc2.CrudTest.framework.DDD.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mc2.CrudTest.Infrastructure.EventStore.DbContexts;

public class ApplicationEventDbContext : DbContext
{
    public ApplicationEventDbContext(DbContextOptions<ApplicationEventDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        foreach (var property in entity.GetProperties().Where(p => p.IsPrimaryKey()))
            property.ValueGenerated = ValueGenerated.Never;
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationEventDbContext).Assembly);
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