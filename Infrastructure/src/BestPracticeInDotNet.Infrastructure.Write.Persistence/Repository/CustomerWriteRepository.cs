using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;
using Mc2.CrudTest.Infrastructure.Write.Persistence.Repository.Abstracts;

namespace Mc2.CrudTest.Infrastructure.Write.Persistence.Repository;

public class CustomerWriteRepository : GenericWriteRepository<CustomerAggregateRoot, CustomerId>, ICustomerWriteRepository
{
    public CustomerWriteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}