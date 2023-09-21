using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;

namespace Mc2.CrudTest.Application.Queries.Repositories;

public interface ICustomerReadRepository : IGenericReadRepository<CustomerAggregateRoot, CustomerId>
{
    Task<List<CustomerAggregateRoot>> GetListByFilter(string firstname, string lastname, string email, 
        string phoneNumber, string bankAccountNumber);
}