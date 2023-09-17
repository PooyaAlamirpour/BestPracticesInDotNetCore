using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.EventStore;
using Mc2.CrudTest.Infrastructure.EventStore.Abstracts;
using Mc2.CrudTest.Infrastructure.EventStore.Repositories.Abstracts;

namespace Mc2.CrudTest.Application.Command.Customer.Create;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly IEventStoreRepository<CustomerAggregateRoot, CustomerId> _eventStoreRepository;

    public CreateCustomerCommandHandler(IEventStoreRepository<CustomerAggregateRoot, CustomerId> eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public async Task Handle(CreateCustomerCommand message, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot newCustomer = CustomerAggregateRoot.Create(message.Firstname, message.Lastname, message.DateOfBirth,
            message.PhoneNumber, message.Email, message.BankAccountNumber);

        await _eventStoreRepository.AppendEventsAsync(newCustomer, cancellationToken);
    }
}