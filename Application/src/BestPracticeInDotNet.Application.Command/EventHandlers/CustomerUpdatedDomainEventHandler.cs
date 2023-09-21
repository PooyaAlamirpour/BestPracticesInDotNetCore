using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Events;
using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Application.Command.EventHandlers;

public class CustomerUpdatedDomainEventHandler : ICommandEventHandler<CustomerUpdatedDomainEvent>
{
    private readonly ICustomerWriteRepository _customerWriteRepository;

    public CustomerUpdatedDomainEventHandler(ICustomerWriteRepository customerWriteRepository)
    {
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task Handle(CustomerUpdatedDomainEvent @event, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = new();
        customer.Apply(@event);
        if (!string.IsNullOrWhiteSpace(@event.PhoneNumber))
        {
            _customerWriteRepository.Attach(customer, x => x.PhoneNumber);
        }
        if (!string.IsNullOrWhiteSpace(@event.BankAccountNumber))
        {
            _customerWriteRepository.Attach(customer, x => x.BankAccountNumber);
        }
        await _customerWriteRepository.CommitAsync(cancellationToken);
    }
}