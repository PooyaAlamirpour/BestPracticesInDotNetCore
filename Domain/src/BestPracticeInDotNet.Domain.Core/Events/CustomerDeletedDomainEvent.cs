using MediatR;

namespace BestPracticeInDotNet.Domain.Core.Events;

public record CustomerDeletedDomainEvent(Guid CustomerId) : INotification;