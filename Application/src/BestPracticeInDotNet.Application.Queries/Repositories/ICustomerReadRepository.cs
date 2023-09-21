using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

namespace Mc2.CrudTest.Application.Queries.Repositories;

public interface ICustomerReadRepository : IGenericReadRepository<CustomerAggregateRoot, CustomerId>
{
    Task<List<CustomerAggregateRoot>> GetListByFilter(string firstname, string lastname, string email, 
        string phoneNumber, string bankAccountNumber);
}