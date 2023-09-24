using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer.ValueObjects;

namespace BestPracticeInDotNet.Infrastructure.Write.Persistence.Repository;

public class CustomerWriteRepository : GenericWriteRepository<CustomerAggregateRoot, CustomerId>, ICustomerWriteRepository
{
    public CustomerWriteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}