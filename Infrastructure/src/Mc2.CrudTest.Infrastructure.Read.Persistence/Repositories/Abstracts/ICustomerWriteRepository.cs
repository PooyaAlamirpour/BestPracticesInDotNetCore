using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;

public interface ICustomerWriteRepository : IGenericRepository<CustomerAggregateRoot, CustomerId>
{
}