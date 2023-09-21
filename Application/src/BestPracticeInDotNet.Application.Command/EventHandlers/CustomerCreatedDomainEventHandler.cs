using Mc2.CrudTest.Application.Command.Repositories;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Events;
using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.Application.Command.EventHandlers;

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