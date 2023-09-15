using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.Domain.Core.Customer.ValueObjects;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories;

public class CustomerWriteRepository : GenericRepository<CustomerAggregateRoot, CustomerId>, ICustomerWriteRepository
{
    public CustomerWriteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}