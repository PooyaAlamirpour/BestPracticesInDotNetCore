using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Events;

public record CustomerCreatedDomainEvent(Guid CustomerId, string Firstname, string Lastname,
    DateOnly DateOfBirth, string PhoneNumber,
    string Email, string BankAccountNumber) : IDomainEvent;
