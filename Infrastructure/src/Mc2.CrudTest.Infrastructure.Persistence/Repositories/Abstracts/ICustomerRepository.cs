using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;

public interface ICustomerRepository : IGenericRepository<CustomerAggregateRoot, CustomerId>
{
    Task<List<CustomerAggregateRoot>> GetListByFilter(string firstname, string lastname, string email, string phoneNumber, string bankAccountNumber);
}