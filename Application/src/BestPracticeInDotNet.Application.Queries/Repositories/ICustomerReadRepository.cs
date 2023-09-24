using BestPracticeInDotNet.Domain.Core.DomainModels.Customer;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer.ValueObjects;

namespace BestPracticeInDotNet.Application.Queries.Repositories;

public interface ICustomerReadRepository : IGenericReadRepository<CustomerAggregateRoot, CustomerId>
{
    Task<List<CustomerAggregateRoot>> GetListByFilter(string firstname, string lastname, string email, 
        string phoneNumber, string bankAccountNumber);
}