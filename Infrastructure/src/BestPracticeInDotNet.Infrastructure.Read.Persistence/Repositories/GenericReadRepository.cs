using System.Linq.Expressions;
using Mc2.CrudTest.Application.Queries.Repositories;
using Mc2.CrudTest.framework.DDD;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories;

public class GenericReadRepository<TAggregate, TId> : IGenericReadRepository<TAggregate, TId> where TAggregate : Entity<TId> 
    where TId : notnull
{
    private readonly ApplicationReadDbContext? _dbContext;

    public GenericReadRepository(IServiceProvider serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ApplicationReadDbContext>();
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
}