using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using MediatR;

namespace BestPracticeInDotNet.Application.Queries.Customer.Get;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CustomerAggregateRoot>>
{
    private readonly ICustomerReadRepository _customerReadRepository;

    public GetCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    public async Task<List<CustomerAggregateRoot>> Handle(GetCustomerQuery message, CancellationToken cancellationToken)
    {
        List<CustomerAggregateRoot> customerList = await _customerReadRepository.GetListByFilter(message.Firstname, 
            message.Lastname, message.Email, message.PhoneNumber, message.BankAccountNumber);
        return customerList;
    }
}