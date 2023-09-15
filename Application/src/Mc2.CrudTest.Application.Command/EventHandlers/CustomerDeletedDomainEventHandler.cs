using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Events;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;

namespace Mc2.CrudTest.Application.Command.EventHandlers;

public class CustomerDeletedDomainEventHandler : ICommandEventHandler<CustomerDeletedDomainEvent>
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerDeletedDomainEventHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CustomerDeletedDomainEvent @event, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = new();
        customer.Apply(@event);
        _customerRepository.Delete(customer);
        await _customerRepository.CommitAsync(cancellationToken);
    }
}