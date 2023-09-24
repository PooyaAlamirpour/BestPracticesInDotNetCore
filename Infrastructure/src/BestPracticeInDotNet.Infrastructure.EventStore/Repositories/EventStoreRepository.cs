using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.framework.DDD;
using BestPracticeInDotNet.Infrastructure.EventStore.Abstracts;
using BestPracticeInDotNet.Infrastructure.EventStore.Entities;
using BestPracticeInDotNet.Infrastructure.EventStore.Projections;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BestPracticeInDotNet.Infrastructure.EventStore.Repositories;

public class EventStoreRepository<TAggregateRoot, Tkey> : IEventStoreRepository<TAggregateRoot, Tkey> 
    where TAggregateRoot : AggregateRoot<Tkey>, new()
    where Tkey : ValueObject<Tkey>
{
    private readonly IGenericEventRepository<EventEntity, Guid> _eventRepository;
    private readonly IEventDispatcher _eventDispatcher;

    public EventStoreRepository(IGenericEventRepository<EventEntity, Guid> eventRepository, IEventDispatcher eventDispatcher)
    {
        _eventRepository = eventRepository;
        _eventDispatcher = eventDispatcher;
    }

    public async Task<Tkey> AppendEventsAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default)
    {
        INotification[] events = aggregate.GetUncommittedEvents().ToArray();
        long nextVersion = aggregate.Version + events.Length;

        await AppendAsync(aggregate.Id, events, nextVersion, cancellationToken);
        await CommitAsync(cancellationToken);
        
        aggregate.ClearUncommittedEvents();

        DispatchEvents(events);
        return aggregate.Id;
    }

    public async Task<TAggregateRoot> FetchStreamAsync(Guid id, int? version = null, CancellationToken cancellationToken = default)
    {
        var query = _eventRepository.QueryableFilter();
        query = query?.Where(x => x.AggregateId == id);
        if (version is not null)
        {
            query = query?.Where(x => x.Version == version);
        }

        var items = await query?.ToListAsync(cancellationToken: cancellationToken)!;
        EventEntity? @event = items.MaxBy(x => x.Version);
        
        return new EventProjection<TAggregateRoot, Tkey>().Project(@event?.Payload, @event?.AggregateType!);
    }

    private Task AppendAsync(Tkey id, INotification[] events, long nextVersion, CancellationToken cancellationToken)
    {
        // foreach (var @event in events)
        // {
            // EventEntity entity = new()
            // {
                // Id = Guid.NewGuid(),
                // AggregateType = @event.GetType().Name,
                // AggregateId = id.Value,
                // Version = nextVersion,
                // Payload = JsonConvert.SerializeObject(@event)
            // };
            // _eventRepository.Add(@entity);
        // }
        
        return Task.CompletedTask;
    }
    
    private async Task CommitAsync(CancellationToken cancellationToken) =>
        await _eventRepository.CommitAsync(cancellationToken);
    
    private void DispatchEvents(INotification[] events)
    {
        foreach (INotification @event in events)
        {
            _eventDispatcher.DispatchAsync(@event);
        } 
    }
}