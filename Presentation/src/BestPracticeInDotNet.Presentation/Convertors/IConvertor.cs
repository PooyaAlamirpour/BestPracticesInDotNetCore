using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Presentation.Server.Models;

namespace BestPracticeInDotNet.Presentation.Server.Convertors;

public interface IConvertor
{
    CreateCustomerCommand ToCommand(CreateCustomerDto customer);
    GetCustomerQuery ToQuery(GetCustomerDto dto);
    List<GetCustomerResponse> ToDto(List<CustomerAggregateRoot> customers);
    UpdateCustomerCommand ToCommand(UpdateCustomerDto customer);
}