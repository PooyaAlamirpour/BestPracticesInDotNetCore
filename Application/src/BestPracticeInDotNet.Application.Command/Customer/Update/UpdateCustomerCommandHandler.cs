using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;
using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Application.Command.Customer.Update;

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