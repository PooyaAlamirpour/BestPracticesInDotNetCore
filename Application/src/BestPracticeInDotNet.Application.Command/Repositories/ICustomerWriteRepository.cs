using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;

namespace BestPracticeInDotNet.Application.Command.Repositories;

public interface ICustomerWriteRepository : IGenericWriteRepository<CustomerAggregateRoot, CustomerId>
{
}