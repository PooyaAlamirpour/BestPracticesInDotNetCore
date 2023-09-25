using BestPracticeInDotNet.Application.Command.Authentication.Register;
using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.Application.Queries.Authentication.Login;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Presentation.Api.Models.AuthenticationDto;
using BestPracticeInDotNet.Presentation.Api.Models.CustomerDto;

namespace BestPracticeInDotNet.Presentation.Api.Commons.Convertors;

public class Convertor : IConvertor
{
    public CreateCustomerCommand ToCommand(CreateCustomerRequestDto customer)
    {
        return new CreateCustomerCommand(customer.Firstname, customer.Lastname, customer.DateOfBirth,
            customer.PhoneNumber, customer.Email, customer.BankAccountNumber);
    }

    public GetCustomerQuery ToQuery(GetCustomerRequestDto requestDto) => 
        new(requestDto.Firstname, requestDto.Lastname, requestDto.PhoneNumber, requestDto.Email, requestDto.BankAccountNumber);

    public List<GetCustomerResponseDto> ToDto(List<CustomerAggregateRoot> customers)
    {
        /*return customers.Select(x => new GetCustomerResponse(
                x.Id.Value,
                x.Firstname,
                x.Lastname,
                x.DateOfBirth.ToString(),
                x.PhoneNumber.Value,
                x.Email.Value,
                x.BankAccountNumber.Value))
            .ToList();*/
        throw new NotImplementedException();
    }

    public UpdateCustomerCommand ToCommand(UpdateCustomerRequestDto customer) => 
        new(customer.CustomerId, customer.PhoneNumber, customer.BankAccountNumber);

    public AuthenticationResponseDto ToDto(RegisterCommandResponse result) => new(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);

    public AuthenticationResponseDto ToDto(LoginQueryResponse result) => new(
        result.Id,
        result.FirstName,
        result.LastName,
        result.Email,
        result.Token);
}