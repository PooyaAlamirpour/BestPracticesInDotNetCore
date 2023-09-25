using MediatR;

namespace BestPracticeInDotNet.Domain.SubDomain.Events;

public record CustomerCreatedDomainEvent(Guid CustomerId, string Firstname, string Lastname,
    DateOnly DateOfBirth, string PhoneNumber,
    string Email, string BankAccountNumber) : INotification;
