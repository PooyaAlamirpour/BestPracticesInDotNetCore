using BestPracticeInDotNet.framework.DDD;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BestPracticeInDotNet.Infrastructure.EventStore.Interceptors;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _publisher;

    public PublishDomainEventsInterceptor(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context)
            .GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, 
        InterceptionResult<int> result, CancellationToken cancellationToken = new())
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEvents(DbContext? dbContext)
    {
        if (dbContext is null) return;
        var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IDomainEventEntity>()
            .Where(entry => entry.Entity.GetUncommittedEvents().Any())
            .Select(entry => entry.Entity)
            .ToList();

        var domainEvents = entitiesWithDomainEvents
            .SelectMany(x => x.GetUncommittedEvents())
            .ToList();

        entitiesWithDomainEvents.ForEach(x => x.ClearUncommittedEvents());

        foreach (var @event in domainEvents)
        {
            await _publisher.Publish(@event);
        }
    }
}