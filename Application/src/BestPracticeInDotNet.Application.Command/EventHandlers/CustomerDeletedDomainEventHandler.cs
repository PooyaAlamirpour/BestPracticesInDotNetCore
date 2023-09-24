using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer;
using BestPracticeInDotNet.Domain.Core.Events;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.EventHandlers;

public class CustomerDeletedDomainEventHandler : INotificationHandler<CustomerDeletedDomainEvent>
{
    private readonly ICustomerWriteRepository _customerWriteRepository;
    
    public CustomerDeletedDomainEventHandler(ICustomerWriteRepository customerWriteRepository)
    {
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task Handle(CustomerDeletedDomainEvent @event, CancellationToken cancellationToken)
    {
        /*CustomerAggregateRoot customer = new();
        customer.Apply(@event);
        _customerWriteRepository.Delete(customer);
        await _customerWriteRepository.CommitAsync(cancellationToken);*/
        throw new NotImplementedException();
    }
}