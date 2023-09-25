using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.SubDomain.Events;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.EventHandlers;

public class CustomerCreatedDomainEventHandler : INotificationHandler<CustomerCreatedDomainEvent>
{
    private readonly ICustomerWriteRepository _customerWriteRepository;

    public CustomerCreatedDomainEventHandler(ICustomerWriteRepository customerWriteRepository)
    {
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task Handle(CustomerCreatedDomainEvent @event, CancellationToken cancellationToken)
    {
        /*CustomerAggregateRoot customer = new();
        customer.Apply(@event);
        
        _customerWriteRepository.Add(customer);
        await _customerWriteRepository.CommitAsync(cancellationToken);*/
        throw new NotImplementedException();
    }
}