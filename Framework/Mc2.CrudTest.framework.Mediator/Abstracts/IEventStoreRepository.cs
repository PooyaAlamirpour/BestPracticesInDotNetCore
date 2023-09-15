namespace Mc2.CrudTest.framework.Mediator.Abstracts;

public interface IEventStoreRepository<TAggregateRoot, TKey> where TAggregateRoot : class
{
    Task<TKey> AppendEventsAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default);
    Task<TAggregateRoot> FetchStreamAsync(Guid id, int? version = null, CancellationToken cancellationToken = default);

}