using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

namespace Mc2.CrudTest.Application.Command.Repositories;

public interface ICustomerWriteRepository : IGenericWriteRepository<CustomerAggregateRoot, CustomerId>
{
}