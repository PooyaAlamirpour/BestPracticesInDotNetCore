using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Events;
using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Application.Command.EventHandlers;

public class CustomerCreatedDomainEventHandler : ICommandEventHandler<CustomerCreatedDomainEvent>
{
    private readonly ICustomerWriteRepository _customerWriteRepository;

    public CustomerCreatedDomainEventHandler(ICustomerWriteRepository customerWriteRepository)
    {
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task Handle(CustomerCreatedDomainEvent @event, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = new();
        customer.Apply(@event);
        
        _customerWriteRepository.Add(customer);
        await _customerWriteRepository.CommitAsync(cancellationToken);
    }
}