using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Events;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.Write.Persistence.Repository.Abstracts;

namespace Mc2.CrudTest.Application.Command.EventHandlers;

public class CustomerDeletedDomainEventHandler : ICommandEventHandler<CustomerDeletedDomainEvent>
{
    private readonly ICustomerWriteRepository _customerWriteRepository;
    
    public CustomerDeletedDomainEventHandler(ICustomerWriteRepository customerWriteRepository)
    {
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task Handle(CustomerDeletedDomainEvent @event, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = new();
        customer.Apply(@event);
        _customerWriteRepository.Delete(customer);
        await _customerWriteRepository.CommitAsync(cancellationToken);
    }
}