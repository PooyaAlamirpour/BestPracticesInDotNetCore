namespace Mc2.CrudTest.Infrastructure.EventStore.Repositories.Abstracts;

public interface IEventStoreRepository<TAggregateRoot, TKey> where TAggregateRoot : class
{
    Task<TKey> AppendEventsAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default);
    Task<TAggregateRoot> FetchStreamAsync(Guid id, int? version = null, CancellationToken cancellationToken = default);

}