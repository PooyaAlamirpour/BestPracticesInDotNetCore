using BestPracticeInDotNet.Domain.Core.Events;
using BestPracticeInDotNet.framework.DDD;
using MediatR;
using Newtonsoft.Json;

namespace BestPracticeInDotNet.Infrastructure.EventStore.Projections;

public class EventProjection<TAggregateRoot, Tkey> 
    where TAggregateRoot : AggregateRoot<Tkey>, new()
{
    private TAggregateRoot ProjectEvent<TEvent>(Action<TAggregateRoot, TEvent> func, string? payload)
    {
        TAggregateRoot root = new();
        TEvent? @event = JsonConvert.DeserializeObject<TEvent>(payload);
        func.Invoke(root, @event);
        return root;
    }

    public TAggregateRoot Project(string? payload, string aggregateType)
    {
        return aggregateType switch
        {
            nameof(CustomerCreatedDomainEvent) => ProjectEvent<CustomerCreatedDomainEvent>((item, @event) 
                => item.Apply(@event), payload),
            nameof(CustomerDeletedDomainEvent) => ProjectEvent<CustomerDeletedDomainEvent>((item, @event) 
                => item.Apply(@event), payload),
            nameof(CustomerUpdatedDomainEvent) => ProjectEvent<CustomerUpdatedDomainEvent>((item, @event) 
                => item.Apply(@event), payload),
            _ => throw new ArgumentException($"The required type {aggregateType} is not supported.")
        };
    }

    public TAggregateRoot Project<TEvent>(string? payload, string aggregateType) where TEvent : INotification =>
        ProjectEvent<TEvent>((item, @event) => item.Apply(@event), payload);
}