using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.Domain.Core.Events;

public record CustomerDeletedDomainEvent(Guid CustomerId) : IDomainEvent;