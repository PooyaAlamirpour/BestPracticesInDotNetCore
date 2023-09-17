using System.Linq.Expressions;
using Mc2.CrudTest.framework.DDD;
using Mc2.CrudTest.Infrastructure.EventStore.DbContexts;
using Mc2.CrudTest.Infrastructure.EventStore.Repositories.Abstracts;
using Mc2.CrudTest.Infrastructure.Write.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.EventStore.Repositories;

public class GenericEventRepository<TAggregate, TId> : IGenericEventRepository<TAggregate, TId> where TAggregate : Entity<TId> 
    where TId : notnull
{
    private readonly ApplicationEventDbContext? _dbContext;

    public GenericEventRepository(IServiceProvider serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ApplicationEventDbContext>();
    }

    private DbSet<TAggregate>? EntitySet
    {
        get
        {
            var entitySet = _dbContext?.Set<TAggregate>();
            return entitySet;
        }
    }
    
    public bool Any(Expression<Func<TAggregate, bool>> predicate)
    {
        var result = QueryableFilter(predicate)?.Any();
        return result ?? false;
    }

    public IQueryable<TAggregate>? QueryableFilter(Expression<Func<TAggregate, bool>>? expression = null)
    {
        var query = _dbContext?.Set<TAggregate>().AsQueryable();
        if (expression is null) return query;
            
        query = query?.Where(expression);
        return query;
    }

    public TAggregate? GetById(TId id)
    {
        var entity = QueryableFilter(e => e.Id.Equals(id))?.FirstOrDefault();
        return entity;
    }

    public async Task<List<TAggregate>> GetListAsync(Expression<Func<TAggregate, bool>>? expression = null, CancellationToken cancellationToken = default)
    {
        if (expression == null)
        {
            var entities = await QueryableFilter()?.ToListAsync(cancellationToken)!;
            return entities;
        }
        else
        {
            var entities = await QueryableFilter(expression)?.ToListAsync(cancellationToken)!;
            return entities;
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