using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Application.Services.Authentication.ResponseModels;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Presentation.Contracts.Authentication;
using BestPracticeInDotNet.Presentation.Server.Commons.Models;

namespace BestPracticeInDotNet.Presentation.Server.Commons.Convertors;

public interface IConvertor
{
    CreateCustomerCommand ToCommand(CreateCustomerDto customer);
    GetCustomerQuery ToQuery(GetCustomerDto dto);
    List<GetCustomerResponse> ToDto(List<CustomerAggregateRoot> customers);
    UpdateCustomerCommand ToCommand(UpdateCustomerDto customer);
    AuthenticationResponse ToDto(AuthenticationResult registerResultValue);
}