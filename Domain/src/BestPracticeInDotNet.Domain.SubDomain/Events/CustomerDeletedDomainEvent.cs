using MediatR;

namespace BestPracticeInDotNet.Domain.SubDomain.Events;

public record CustomerDeletedDomainEvent(Guid CustomerId) : INotification;