using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer.ValueObjects;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Customer.Delete;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
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