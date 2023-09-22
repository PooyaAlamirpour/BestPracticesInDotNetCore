using MediatR;

namespace BestPracticeInDotNet.Domain.Core.Events;

public record CustomerUpdatedDomainEvent(Guid CustomerId, string PhoneNumber, string BankAccountNumber) : INotification;