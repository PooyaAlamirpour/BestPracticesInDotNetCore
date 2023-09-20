using System.Linq.Expressions;
using Mc2.CrudTest.framework.DDD;
using Mc2.CrudTest.Infrastructure.Write.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Write.Persistence.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.Write.Persistence.Repository;

public class GenericWriteRepository<TAggregate, TId> : IGenericWriteRepository<TAggregate, TId> where TAggregate : Entity<TId> 
    where TId : notnull
{
    private readonly ApplicationWriteDbContext? _dbContext;

    public GenericWriteRepository(IServiceProvider serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ApplicationWriteDbContext>();
    }

    private DbSet<TAggregate>? EntitySet
    {
        get
        {
            var entitySet = _dbContext?.Set<TAggregate>();
            return entitySet;
        }
    }
    
    public void Add(TAggregate aggregate)
    {
        EntitySet?.Add(aggregate);
    }

    public void Update(TAggregate aggregate)
    {
        EntitySet.Entry(aggregate).State = EntityState.Modified;
    }

    public void Attach<TProperty>(TAggregate aggregateRoot, Expression<Func<TAggregate, TProperty>> expression)
    {
        EntitySet.Entry(aggregateRoot).Property(expression).IsModified = true;
    }
    
    public void Delete(TAggregate aggregate)
    {
        EntitySet.Remove(aggregate);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default) => await _dbContext.SaveChangesAsync(cancellationToken);
}