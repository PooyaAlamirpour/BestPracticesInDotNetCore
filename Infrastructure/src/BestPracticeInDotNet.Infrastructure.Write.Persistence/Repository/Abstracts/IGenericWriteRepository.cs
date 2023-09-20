using System.Linq.Expressions;

namespace Mc2.CrudTest.Infrastructure.Write.Persistence.Repository.Abstracts;

public interface IGenericWriteRepository<TEntity, in TId> where TEntity : class where TId : notnull
{
    void Add(TEntity aggregate);
    void Update(TEntity aggregate);
    void Attach<TProperty>(TEntity aggregateRoot, Expression<Func<TEntity, TProperty>> expression);
    void Delete(TEntity aggregate);
    Task CommitAsync(CancellationToken cancellationToken = default);
}