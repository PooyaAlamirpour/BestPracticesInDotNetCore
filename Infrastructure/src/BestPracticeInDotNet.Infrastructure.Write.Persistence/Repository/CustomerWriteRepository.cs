
using Mc2.CrudTest.Application.Command.Repositories;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

namespace Mc2.CrudTest.Infrastructure.Write.Persistence.Repository;

public class CustomerWriteRepository : GenericWriteRepository<CustomerAggregateRoot, CustomerId>, ICustomerWriteRepository
{
    public CustomerWriteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}