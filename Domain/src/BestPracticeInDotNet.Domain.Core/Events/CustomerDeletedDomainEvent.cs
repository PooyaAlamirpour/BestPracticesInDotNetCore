using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Events;

public record CustomerDeletedDomainEvent(Guid CustomerId) : IDomainEvent;