using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

namespace Mc2.CrudTest.Infrastructure.Write.Persistence.Repository.Abstracts;

public interface ICustomerWriteRepository : IGenericWriteRepository<CustomerAggregateRoot, CustomerId>
{
}