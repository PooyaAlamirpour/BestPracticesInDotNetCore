using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.Domain.Core.Events;

public record CustomerCreatedDomainEvent(Guid CustomerId, string Firstname, string Lastname,
    DateOnly DateOfBirth, string PhoneNumber,
    string Email, string BankAccountNumber) : IDomainEvent;
