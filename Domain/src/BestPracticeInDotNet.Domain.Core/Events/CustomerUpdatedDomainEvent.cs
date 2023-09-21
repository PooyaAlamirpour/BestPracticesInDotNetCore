using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Events;

public record CustomerUpdatedDomainEvent(Guid CustomerId, string PhoneNumber, string BankAccountNumber) : IDomainEvent;