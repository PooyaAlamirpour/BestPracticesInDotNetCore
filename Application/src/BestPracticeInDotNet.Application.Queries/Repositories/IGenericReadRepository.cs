using System.Linq.Expressions;

namespace Mc2.CrudTest.Application.Queries.Repositories;

public interface IGenericReadRepository<TEntity, in TId> where TEntity : class where TId : notnull
{
    bool Any(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity>? QueryableFilter(Expression<Func<TEntity, bool>>? expression = null);
    
    TEntity? GetById(TId id);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken cancellationToken = default);
}