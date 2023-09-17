using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.EventStore;
using Mc2.CrudTest.Infrastructure.EventStore.Abstracts;
using Mc2.CrudTest.Infrastructure.EventStore.Repositories.Abstracts;

namespace Mc2.CrudTest.Application.Command.Customer.Update;

public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly IEventStoreRepository<CustomerAggregateRoot, CustomerId> _eventStoreRepository;

    public UpdateCustomerCommandHandler(IEventStoreRepository<CustomerAggregateRoot, CustomerId> eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public async Task Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = await _eventStoreRepository.FetchStreamAsync(message.CustomerId, cancellationToken: cancellationToken);
        customer.Update(message.CustomerId, message.PhoneNumber, message.BankAccountNumber);
        await _eventStoreRepository.AppendEventsAsync(customer, cancellationToken);
    }
    
}