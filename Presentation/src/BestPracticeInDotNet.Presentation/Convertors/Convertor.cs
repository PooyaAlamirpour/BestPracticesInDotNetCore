using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Presentation.Server.Models;

namespace BestPracticeInDotNet.Presentation.Server.Convertors;

public class Convertor : IConvertor
{
    public CreateCustomerCommand ToCommand(CreateCustomerDto customer)
    {
        return new CreateCustomerCommand(customer.Firstname, customer.Lastname, customer.DateOfBirth,
            customer.PhoneNumber, customer.Email, customer.BankAccountNumber);
    }

    public GetCustomerQuery ToQuery(GetCustomerDto dto) => 
        new(dto.Firstname, dto.Lastname, dto.PhoneNumber, dto.Email, dto.BankAccountNumber);

    public List<GetCustomerResponse> ToDto(List<CustomerAggregateRoot> customers)
    {
        return customers.Select(x => new GetCustomerResponse(
                x.Id.Value,
                x.Firstname,
                x.Lastname,
                x.DateOfBirth.ToString(),
                x.PhoneNumber.Value,
                x.Email.Value,
                x.BankAccountNumber.Value))
            .ToList();
    }

    public UpdateCustomerCommand ToCommand(UpdateCustomerDto customer) => 
        new(customer.CustomerId, customer.PhoneNumber, customer.BankAccountNumber);
}