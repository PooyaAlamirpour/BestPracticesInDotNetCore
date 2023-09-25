using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;

namespace BestPracticeInDotNet.Infrastructure.Write.Persistence.Repository;

public class CustomerWriteRepository : GenericWriteRepository<CustomerAggregateRoot, CustomerId>, ICustomerWriteRepository
{
    public CustomerWriteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}