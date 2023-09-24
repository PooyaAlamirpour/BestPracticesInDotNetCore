using BestPracticeInDotNet.Domain.Core.DomainModels.Customer;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer.ValueObjects;

namespace BestPracticeInDotNet.Application.Command.Repositories;

public interface ICustomerWriteRepository : IGenericWriteRepository<CustomerAggregateRoot, CustomerId>
{
}