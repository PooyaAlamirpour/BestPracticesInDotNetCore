using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Events;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;

namespace Mc2.CrudTest.Application.Command.EventHandlers;

public class CustomerUpdatedDomainEventHandler : ICommandEventHandler<CustomerUpdatedDomainEvent>
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerUpdatedDomainEventHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CustomerUpdatedDomainEvent @event, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = new();
        customer.Apply(@event);
        if (!string.IsNullOrWhiteSpace(@event.PhoneNumber))
        {
            _customerRepository.Attach(customer, x => x.PhoneNumber);
        }
        if (!string.IsNullOrWhiteSpace(@event.BankAccountNumber))
        {
            _customerRepository.Attach(customer, x => x.BankAccountNumber);
        }
        await _customerRepository.CommitAsync(cancellationToken);
    }
}