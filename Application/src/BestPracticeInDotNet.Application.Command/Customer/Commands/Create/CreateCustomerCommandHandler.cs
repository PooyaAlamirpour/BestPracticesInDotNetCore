using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Customer.Commands.Create;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly IEventStoreRepository<CustomerAggregateRoot, CustomerId> _eventStoreRepository;

    // public CreateCustomerCommandHandler(IEventStoreRepository<CustomerAggregateRoot, CustomerId> eventStoreRepository)
    // {
        // _eventStoreRepository = eventStoreRepository;
    // }

    public async Task Handle(CreateCustomerCommand message, CancellationToken cancellationToken)
    {
        CustomerAggregateRoot newCustomer = CustomerAggregateRoot.Create(message.Firstname, message.Lastname, message.DateOfBirth,
            message.PhoneNumber, message.Email, message.BankAccountNumber);

        await _eventStoreRepository.AppendEventsAsync(newCustomer, cancellationToken);
    }
}