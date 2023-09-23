using BestPracticeInDotNet.Application.Command.Authentication.Register;
using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.Application.Queries.Authentication.Login;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Presentation.Server.Models.AuthenticationDto;
using BestPracticeInDotNet.Presentation.Server.Commons.Models.CustomerDto;

namespace BestPracticeInDotNet.Presentation.Server.Commons.Convertors;

public interface IConvertor
{
    CreateCustomerCommand ToCommand(CreateCustomerDto customer);
    GetCustomerQuery ToQuery(GetCustomerDto dto);
    List<GetCustomerResponse> ToDto(List<CustomerAggregateRoot> customers);
    UpdateCustomerCommand ToCommand(UpdateCustomerDto customer);
    AuthenticationResponseDto ToDto(RegisterCommandResponse result);
    AuthenticationResponseDto ToDto(LoginQueryResponse registerResultValue);
}