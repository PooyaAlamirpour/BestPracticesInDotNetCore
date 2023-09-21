﻿using Mc2.CrudTest.Application.Command.Repositories;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Events;
using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.Application.Command.EventHandlers;

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