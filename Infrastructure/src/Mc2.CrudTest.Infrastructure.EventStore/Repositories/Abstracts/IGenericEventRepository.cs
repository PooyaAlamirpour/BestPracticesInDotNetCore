using System.Linq.Expressions;

namespace Mc2.CrudTest.Infrastructure.EventStore.Repositories.Abstracts;

public interface IGenericEventRepository<TEntity, in TId> where TEntity : class where TId : notnull
{
    bool Any(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity>? QueryableFilter(Expression<Func<TEntity, bool>>? expression = null);
    
    TEntity? GetById(TId id);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken cancellationToken = default);
    
    void Add(TEntity aggregate);
    void Update(TEntity aggregate);
    void Attach<TProperty>(TEntity aggregateRoot, Expression<Func<TEntity, TProperty>> expression);
    void Delete(TEntity aggregate);
    Task CommitAsync(CancellationToken cancellationToken = default);
}