using Mc2.CrudTest.Domain.Core.Customer;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;

public interface ICustomerReadRepository
{
    Task<List<CustomerAggregateRoot>> GetListByFilter(string firstname, string lastname, string email, 
        string phoneNumber, string bankAccountNumber);
}