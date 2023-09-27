using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Customer.Commands.Update;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IEventStoreRepository<CustomerAggregateRoot, CustomerId> _eventStoreRepository;

    // public UpdateCustomerCommandHandler(IEventStoreRepository<CustomerAggregateRoot, CustomerId> eventStoreRepository)
    // {
        // _eventStoreRepository = eventStoreRepository;
    // }

    public async Task Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot customer = await _eventStoreRepository.FetchStreamAsync(message.CustomerId, cancellationToken: cancellationToken);
        customer.Update(message.CustomerId, message.PhoneNumber, message.BankAccountNumber);
        await _eventStoreRepository.AppendEventsAsync(customer, cancellationToken);
    }
    
}