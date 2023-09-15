using Mc2.CrudTest.framework.DDD;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.Persistence.Entities;
using Mc2.CrudTest.Infrastructure.Persistence.Projections;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories;

public class EventStoreRepository<TAggregateRoot, Tkey> : IEventStoreRepository<TAggregateRoot, Tkey> 
    where TAggregateRoot : AggregateRoot<Tkey>, new()
    where Tkey : ValueObject<Tkey>
{
    private readonly IGenericRepository<EventEntity, Guid> _repository;
    private readonly IEventDispatcher _eventDispatcher;

    public EventStoreRepository(IGenericRepository<EventEntity, Guid> repository, IEventDispatcher eventDispatcher)
    {
        _repository = repository;
        _eventDispatcher = eventDispatcher;
    }

    public async Task<Tkey> AppendEventsAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default)
    {
        IDomainEvent[] events = aggregate.GetUncommittedEvents().ToArray();
        long nextVersion = aggregate.Version + events.Length;

        await AppendAsync(aggregate.Id, events, nextVersion, cancellationToken);
        await CommitAsync(cancellationToken);
        
        aggregate.ClearUncommittedEvents();

        DispatchEvents(events);
        return aggregate.Id;
    }

    public async Task<TAggregateRoot> FetchStreamAsync(Guid id, int? version = null, CancellationToken cancellationToken = default)
    {
        var query = _repository.QueryableFilter();
        query = query?.Where(x => x.AggregateId == id);
        if (version is not null)
        {
            query = query?.Where(x => x.Version == version);
        }

        var items = await query?.ToListAsync(cancellationToken: cancellationToken)!;
        var @event = items.MaxBy(x => x.Version);
        
        return new EventProjection<TAggregateRoot, Tkey>().Project(@event?.Payload, @event?.AggregateType!);
    }

    private Task AppendAsync(Tkey id, IDomainEvent[] events, long nextVersion, CancellationToken cancellationToken)
    {
        foreach (var @event in events)
        {
            EventEntity entity = new()
            {
                Id = Guid.NewGuid(),
                AggregateType = @event.GetType().Name,
                AggregateId = id.Value,
                Version = nextVersion,
                Payload = JsonConvert.SerializeObject(@event)
            };
            _repository.Add(@entity);
        }
        
        return Task.CompletedTask;
    }
    
    private async Task CommitAsync(CancellationToken cancellationToken) =>
        await _repository.CommitAsync(cancellationToken);
    
    private void DispatchEvents(IDomainEvent[] events)
    {
        foreach (IDomainEvent @event in events)
        {
            _eventDispatcher.DispatchAsync(@event);
        } 
    }
}