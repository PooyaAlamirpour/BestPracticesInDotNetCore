using Mc2.CrudTest.Application.Command.Repositories;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;
using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.Application.Command.Customer.Delete;

public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
{
    private readonly IEventStoreRepository<CustomerAggregateRoot, CustomerId> _eventStoreRepository;

    public DeleteCustomerCommandHandler(IEventStoreRepository<CustomerAggregateRoot, CustomerId> eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public async Task Handle(DeleteCustomerCommand message, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = await _eventStoreRepository.FetchStreamAsync(message.CustomerId, cancellationToken: cancellationToken);
        customer.Delete(CustomerId.Of(message.CustomerId));
        await _eventStoreRepository.AppendEventsAsync(customer, cancellationToken);
    }
}