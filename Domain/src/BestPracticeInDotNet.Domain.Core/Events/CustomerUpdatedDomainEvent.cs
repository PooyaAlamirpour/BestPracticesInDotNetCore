using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.Domain.Core.Events;

public record CustomerUpdatedDomainEvent(Guid CustomerId, string PhoneNumber, string BankAccountNumber) : IDomainEvent;